/*
 * Trabalho Prático 2
 * Microcontroladores Aplicados a Engenharia de Controle e Automação
 * Paulo Felipe Possa Parreira - 12.2.1165
 * Abr 2021
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

int origemParametrosManual = 0;
int modoOperacao = 0; // Modo de operação 0 - Manual | 1 - Automático
int kp = 23, kd = 6, ki = 1.3; // Parâmetros do PID
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

    // Variável de amostragem do ADC
    unsigned int adc_amostra(unsigned char canal);
    __delaywdt_ms(2000);
    while (1) {
        CLRWDT();
        PORTB = 1;
        heat = 1;
        if(btn3 == 0) {
            modoOperacao = 1;
        }
        valPotenciometroVentToDuty = 255/4;
        if(modoOperacao == 0)
            PWM1_Set_Duty(valPotenciometroVentToDuty);
        else
            PWM1_Set_Duty(255/2);
    }
    return;
}
