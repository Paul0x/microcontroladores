/*
 * Trabalho Prático 1
 * Microcontroladores Aplicados a Engenharia de Controle e Automação
 * Paulo Felipe Possa Parreira - 12.2.1165
 * Mar 2021
 */
#define _XTAL_FREQ 8000000
#include <xc.h>
#include <stdio.h>
#include "configbits.h"
#include "flexlcd.h"
#include "adc.h"
#include "itoa.h"
#include "pwm.h"
#include <usart.h>
#include "system.h"        /* System funct/params, like osc/peripheral config */
#include "user.h"          /* User funct/params, such as InitApp */
#include "modbus.h"

// Declaração de variáveis
unsigned int adcResult; // Resultado do ADC ventoinha
float temperatura = 0; // Temperatura
char strLcd1[50]; // String do LCD1
char strLcd2[50]; //String do LCD2

int origemParametrosManual = 1;
int modoOperacao = 0; // Modo de operação 0 - Manual | 1 - Automático
int kp = 16, kd = .05, ki = 2.915; // Parâmetros do PID
int tempSetpoint = 40; // Setpoint da temperatura
float voltPotenciometro; // Valor do potenciometro para o modo manual
float valPotenciometroVentToDuty = 0;
float valPotenciometroHeatToDuty = 0;
float valPotenciometroHeat = 0;
float valPotenciometroVent = 0;
int timerHeatCount = 0;
int ligarAquecedor = 0;

float pidSum = 0;
float lastErr = 0;
float pidVentVal = 0;
float err;
// Identificadores
#define rele1 LATCbits.LC0
#define rele2 LATEbits.LE0
#define heat PORTCbits.RC5
#define btn1 PORTBbits.RB0

// Configuração do botão de ligar e desligar o aquecedor
#define btn3 PORTBbits.RB3

void main(void) {
    /*
     * Configurações iniciais
     */

    // Habilita PULLUP
    INTCON = 0b00000000;
    INTCON2 = 0b00000000;
    INTCON2bits.RBPU = 0;

    // Define entradas e saídas
    TRISA = 0xFF;
    TRISB = 0b00001111;
    TRISC = 0b00000000;
    TRISD = 0b00001111;
    TRISE = 0b00000000;

    // Limpa as portas
    PORTA = 0;
    LATA = 0;
    PORTB = 0;
    LATB = 0;
    PORTC = 0;
    LATC = 0;
    PORTD = 0;
    LATD = 0;
    PORTE = 0;
    LATE = 0;

    // Configurações de interrupções de botão
    // Habilitando RB0/RB1/RB2
    INTCON2bits.INTEDG0 = 0;
    INTCONbits.INT0IF = 0;
    INTCONbits.INT0IE = 1;
    INTCON3bits.INT1E = 1;
    INTCON3bits.INT1F = 0;
    INTCON3bits.INT2E = 1;
    INTCON3bits.INT2F = 0;

    // Inicializa o LCD, adc e pwm
    adc_init();
    Lcd_Init();
    Lcd_Cmd(LCD_CURSOR_OFF);
    PWM1_Init(1000); // configura frequencia do PWM para 1kHz
    PWM1_Start(); // configura registradores e inicia PWM


    OpnUSART();
    ConfigInterrupts();

    // Variável de amostragem do ADC
    unsigned int adc_amostra(unsigned char canal);
    while (1) {
        CLRWDT();

        if (modbusMessage) {
            decodeIt();
            if (coils[0] == 0) {
                modoOperacao = 1;
            } else {
                modoOperacao = 0;
            }

            if (coils[1] != 0) {
                kp = holdingReg[7] / 100.0;
                kd = holdingReg[8] / 100.0;
                ki = holdingReg[9] / 100.0;
                tempSetpoint = holdingReg[10] / 10.0;
                coils[1] = 0;
            }
        }

        // Altera a origem dos dados (PIC -> Supervisorio)
        if (btn3 == 0) {
            origemParametrosManual = !origemParametrosManual;
        }

        // Amostragem da Temperatura
        temperatura = (adc_amostra(2)) / 2;

        // Verifica o modo de operação
        if (modoOperacao == 0) {

            if (origemParametrosManual == 0) {
                // Pega o valor do potenciometro 1 
                adcResult = (adc_amostra(0));
                voltPotenciometro = (adcResult * 5) / 1023;
                valPotenciometroVent = voltPotenciometro;
                valPotenciometroVentToDuty = (255 * voltPotenciometro) / 5;

                // Pega o valor do potenciometro 2
                adcResult = (adc_amostra(1));
                voltPotenciometro = ((float) adcResult * 5.0) / 1023.0;
                valPotenciometroHeat = voltPotenciometro;
                valPotenciometroHeatToDuty = (10.0 * voltPotenciometro) / 5.0;
            } else {
                valPotenciometroVentToDuty = holdingReg[5];
                valPotenciometroVent = (valPotenciometroVentToDuty * 5) / 255;
                valPotenciometroHeatToDuty = holdingReg[6];
                valPotenciometroHeat = (valPotenciometroHeatToDuty * 5) / 10;
            }
            // Liga a ventoinha
            PWM1_Set_Duty(valPotenciometroVentToDuty);

            // Saída PWM do Aquecedor
            timerHeatCount++;
            if (timerHeatCount >= valPotenciometroHeatToDuty) {
                heat = 0;
            }
            if (timerHeatCount == 10) {
                if (valPotenciometroHeatToDuty != 0) {
                    heat = 1; // Drive PWM Output HIGH
                }
                timerHeatCount = 0; // Reset Counter
            }
        } else {
            heat = 1;
            err = temperatura - tempSetpoint;
            pidVentVal = kp * err + ki * pidSum + kd * (err - lastErr);
            pidSum += err;
            lastErr = err;

            if (pidVentVal > 255) pidVentVal = 255;
            if (pidVentVal < 10) pidVentVal = 10;

            valPotenciometroVent = (pidVentVal * 5) / 255;
            valPotenciometroHeat = 5;
            PWM1_Set_Duty(pidVentVal);
            sprintf(strLcd1, "PI: %f ", pidVentVal);
            Lcd_Out(3, -4, strLcd1);

        }
        // Mostra a temperatura na tela        
        sprintf(strLcd1, "Tmp: %0.2fC", temperatura);
        Lcd_Out(1, 0, strLcd1);

        // Exibe o modo de operação
        if (modoOperacao == 0) {
            if (origemParametrosManual == 0) {
                sprintf(strLcd2, "Man. P  ");
            } else {
                sprintf(strLcd2, "Man. S  ");
            }
            Lcd_Out(2, 0, strLcd2);
            sprintf(strLcd2,"Vc: %0.1f Va: %0.1f", valPotenciometroVent, valPotenciometroHeat);
            Lcd_Out(3, -4, strLcd2);
        } else {
            Lcd_Out(2, 0, "Aut. Aq:ON");
            sprintf(strLcd2, "%0.2f", kp);            
            sprintf(strLcd2,"Setpoint: %dC", holdingReg[2]);
            Lcd_Out(4, -4, strLcd2);
        }

        // Envia os registradores para o MODBus
        holdingReg[1] = temperatura;
        holdingReg[2] = tempSetpoint;
        holdingReg[3] = valPotenciometroVent * 10;
        holdingReg[4] = valPotenciometroHeat * 10;
    }
    return;
}

/*
 *  Função de interrupção
 *
 */
void interrupt isr(void) {
    // Altera o modo de operaçãoo
    if (INTCONbits.INT0IF == 1) {
        INTCONbits.INT0IF = 0;
        Lcd_Cmd(LCD_CLEAR);
        modoOperacao = !modoOperacao;
    }

    // Diminui o setpoint em 1ºC
    if (INTCON3bits.INT1F == 1) {
        INTCON3bits.INT1F = 0;
        if (tempSetpoint > 1) {
            tempSetpoint--;
        }
    }

    // Aumenta o setpoint em 1ºC
    if (INTCON3bits.INT2F == 1) {
        INTCON3bits.INT2F = 0;
        tempSetpoint++;
    }

    if (PIR1bits.RCIF) { // USART receive interrupt flag has been set

        if ((!endOfMessage)&&(!newMessage)) {
            if (PIR1bits.TXIF) { // check if the TXREG is empty
                received[z] = ReceiveBuffer;
                z++;
                timerCount = 0;
            }
        }
        if (newMessage) {
            OpenTmr0();
            if (PIR1bits.TXIF) { // check if the TXREG is empty
                received[z] = ReceiveBuffer;
                z++;
                newMessage = 0;
                endOfMessage = 0;
                messageLength = 0;
                modbusMessage = 0;
                timerCount = 0;
                return;
            }
        }
        PIR1bits.RCIF = 0;
    }
    if (INTCONbits.TMR0IF) { //TMR0 interrupt flag
        modbusDelay(); //Resets timer for 1.04ms
        timerCount++;
        if (timerCount > 4) {
            endOfMessage = 1;
            newMessage = 1;
            messageLength = z;
            modbusMessage = 1;
            for (z = (messageLength); z != 125; z++) { //Clear rest of message
                received[z] = 0;
            }
            z = 0;
            T0CONbits.TMR0ON = 0; //Close timer0
            timerCount = 0;
        }
        INTCONbits.TMR0IF = 0; // Clear flag

    }
}