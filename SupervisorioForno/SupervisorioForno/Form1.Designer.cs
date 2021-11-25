
namespace SupervisorioForno
{
    partial class MainForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.serialComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioManual = new System.Windows.Forms.RadioButton();
            this.radioModoOP = new System.Windows.Forms.RadioButton();
            this.btnResetarParametros = new System.Windows.Forms.Button();
            this.btnAplicarParametros = new System.Windows.Forms.Button();
            this.trackAquecedor = new System.Windows.Forms.TrackBar();
            this.trackVentoinha = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.gaugeChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.chartVolt = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label12 = new System.Windows.Forms.Label();
            this.lblVVent = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblSetPoint = new System.Windows.Forms.Label();
            this.txtKp = new System.Windows.Forms.NumericUpDown();
            this.txtKd = new System.Windows.Forms.NumericUpDown();
            this.txtKi = new System.Windows.Forms.NumericUpDown();
            this.txtSetpoint = new System.Windows.Forms.NumericUpDown();
            this.lblVAq = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnExportar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tempoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tempDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.voltVentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.voltAqDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setpointDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registroFornoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackAquecedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackVentoinha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaugeChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVolt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSetpoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registroFornoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainFormBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bem Vindo(a) ao sistema supervisório do forno elétrico.";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Selecione a porta SERIAL para se conectar:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.serialComboBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 44);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Comunicação";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // serialComboBox
            // 
            this.serialComboBox.FormattingEnabled = true;
            this.serialComboBox.Location = new System.Drawing.Point(230, 14);
            this.serialComboBox.Name = "serialComboBox";
            this.serialComboBox.Size = new System.Drawing.Size(121, 21);
            this.serialComboBox.TabIndex = 2;
            this.serialComboBox.SelectedIndexChanged += new System.EventHandler(this.serialComboBox_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSetpoint);
            this.groupBox2.Controls.Add(this.txtKi);
            this.groupBox2.Controls.Add(this.txtKd);
            this.groupBox2.Controls.Add(this.txtKp);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.btnResetarParametros);
            this.groupBox2.Controls.Add(this.btnAplicarParametros);
            this.groupBox2.Controls.Add(this.trackAquecedor);
            this.groupBox2.Controls.Add(this.trackVentoinha);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(12, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(351, 256);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controles";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 177);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 13);
            this.label13.TabIndex = 17;
            this.label13.Text = "Setpoint";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioManual);
            this.panel1.Controls.Add(this.radioModoOP);
            this.panel1.Location = new System.Drawing.Point(109, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(155, 30);
            this.panel1.TabIndex = 16;
            // 
            // radioManual
            // 
            this.radioManual.AutoSize = true;
            this.radioManual.Checked = true;
            this.radioManual.Location = new System.Drawing.Point(3, 12);
            this.radioManual.Name = "radioManual";
            this.radioManual.Size = new System.Drawing.Size(60, 17);
            this.radioManual.TabIndex = 12;
            this.radioManual.TabStop = true;
            this.radioManual.Text = "Manual";
            this.radioManual.UseVisualStyleBackColor = true;
            this.radioManual.CheckedChanged += new System.EventHandler(this.radioManual_CheckedChanged);
            // 
            // radioModoOP
            // 
            this.radioModoOP.AutoSize = true;
            this.radioModoOP.Location = new System.Drawing.Point(69, 12);
            this.radioModoOP.Name = "radioModoOP";
            this.radioModoOP.Size = new System.Drawing.Size(78, 17);
            this.radioModoOP.TabIndex = 13;
            this.radioModoOP.Text = "Automático";
            this.radioModoOP.UseVisualStyleBackColor = true;
            this.radioModoOP.CheckedChanged += new System.EventHandler(this.radioModoOP_CheckedChanged);
            // 
            // btnResetarParametros
            // 
            this.btnResetarParametros.Location = new System.Drawing.Point(144, 209);
            this.btnResetarParametros.Name = "btnResetarParametros";
            this.btnResetarParametros.Size = new System.Drawing.Size(148, 23);
            this.btnResetarParametros.TabIndex = 15;
            this.btnResetarParametros.Text = "Redefinir Parâmetros";
            this.btnResetarParametros.UseVisualStyleBackColor = true;
            // 
            // btnAplicarParametros
            // 
            this.btnAplicarParametros.Location = new System.Drawing.Point(3, 209);
            this.btnAplicarParametros.Name = "btnAplicarParametros";
            this.btnAplicarParametros.Size = new System.Drawing.Size(135, 23);
            this.btnAplicarParametros.TabIndex = 14;
            this.btnAplicarParametros.Text = "Aplicar Parâmetros";
            this.btnAplicarParametros.UseVisualStyleBackColor = true;
            this.btnAplicarParametros.Click += new System.EventHandler(this.btnAplicarParametros_Click);
            // 
            // trackAquecedor
            // 
            this.trackAquecedor.Location = new System.Drawing.Point(67, 100);
            this.trackAquecedor.Name = "trackAquecedor";
            this.trackAquecedor.Size = new System.Drawing.Size(104, 45);
            this.trackAquecedor.TabIndex = 11;
            this.trackAquecedor.Scroll += new System.EventHandler(this.trackAquecedor_Scroll);
            // 
            // trackVentoinha
            // 
            this.trackVentoinha.LargeChange = 10;
            this.trackVentoinha.Location = new System.Drawing.Point(67, 53);
            this.trackVentoinha.Maximum = 255;
            this.trackVentoinha.Name = "trackVentoinha";
            this.trackVentoinha.Size = new System.Drawing.Size(104, 45);
            this.trackVentoinha.SmallChange = 5;
            this.trackVentoinha.TabIndex = 10;
            this.trackVentoinha.Scroll += new System.EventHandler(this.trackVentoinha_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Aquecedor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Ventoinha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Modo de Operação:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Kp";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(89, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Kd";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(167, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Ki";
            // 
            // gaugeChart
            // 
            this.gaugeChart.BackColor = System.Drawing.Color.Transparent;
            this.gaugeChart.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.gaugeChart.ChartAreas.Add(chartArea1);
            this.gaugeChart.Location = new System.Drawing.Point(391, 86);
            this.gaugeChart.Name = "gaugeChart";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.gaugeChart.Series.Add(series1);
            this.gaugeChart.Size = new System.Drawing.Size(220, 132);
            this.gaugeChart.TabIndex = 4;
            this.gaugeChart.Text = "chart1";
            title1.Name = "Title1";
            this.gaugeChart.Titles.Add(title1);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(460, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Temperatura Atual";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(394, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Modo de Operação:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(394, 225);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Voltagem Ventoinha";
            // 
            // chartVolt
            // 
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.AxisX2.Minimum = 0D;
            chartArea2.AxisY.Maximum = 5D;
            chartArea2.AxisY.Minimum = 0D;
            chartArea2.AxisY2.Maximum = 5D;
            chartArea2.AxisY2.Minimum = 0D;
            chartArea2.Name = "ChartArea1";
            this.chartVolt.ChartAreas.Add(chartArea2);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend1.Name = "Voltagem Vent.";
            legend1.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Tall;
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend2.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend2.Name = "Voltagem Aquec.";
            legend2.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Tall;
            this.chartVolt.Legends.Add(legend1);
            this.chartVolt.Legends.Add(legend2);
            this.chartVolt.Location = new System.Drawing.Point(397, 250);
            this.chartVolt.Name = "chartVolt";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Voltagem Vent.";
            series2.Name = "Voltagem Vent.";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Voltagem Aquec.";
            series3.Name = "Voltagem Aquec.";
            this.chartVolt.Series.Add(series2);
            this.chartVolt.Series.Add(series3);
            this.chartVolt.Size = new System.Drawing.Size(714, 218);
            this.chartVolt.TabIndex = 8;
            this.chartVolt.Text = "chart1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(617, 224);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(106, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Voltagem Aquecedor";
            // 
            // lblVVent
            // 
            this.lblVVent.AutoSize = true;
            this.lblVVent.Location = new System.Drawing.Point(503, 224);
            this.lblVVent.Name = "lblVVent";
            this.lblVVent.Size = new System.Drawing.Size(41, 13);
            this.lblVVent.TabIndex = 10;
            this.lblVVent.Text = "label13";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(617, 70);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Setpoint:";
            // 
            // lblSetPoint
            // 
            this.lblSetPoint.AutoSize = true;
            this.lblSetPoint.Location = new System.Drawing.Point(673, 70);
            this.lblSetPoint.Name = "lblSetPoint";
            this.lblSetPoint.Size = new System.Drawing.Size(0, 13);
            this.lblSetPoint.TabIndex = 14;
            // 
            // txtKp
            // 
            this.txtKp.DecimalPlaces = 2;
            this.txtKp.Location = new System.Drawing.Point(33, 150);
            this.txtKp.Name = "txtKp";
            this.txtKp.Size = new System.Drawing.Size(50, 20);
            this.txtKp.TabIndex = 18;
            this.txtKp.Value = new decimal(new int[] {
            163,
            0,
            0,
            65536});
            // 
            // txtKd
            // 
            this.txtKd.DecimalPlaces = 2;
            this.txtKd.Location = new System.Drawing.Point(111, 149);
            this.txtKd.Name = "txtKd";
            this.txtKd.Size = new System.Drawing.Size(50, 20);
            this.txtKd.TabIndex = 19;
            this.txtKd.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            // 
            // txtKi
            // 
            this.txtKi.DecimalPlaces = 2;
            this.txtKi.Location = new System.Drawing.Point(189, 149);
            this.txtKi.Name = "txtKi";
            this.txtKi.Size = new System.Drawing.Size(50, 20);
            this.txtKi.TabIndex = 20;
            this.txtKi.Value = new decimal(new int[] {
            291,
            0,
            0,
            131072});
            // 
            // txtSetpoint
            // 
            this.txtSetpoint.DecimalPlaces = 1;
            this.txtSetpoint.Location = new System.Drawing.Point(60, 177);
            this.txtSetpoint.Name = "txtSetpoint";
            this.txtSetpoint.Size = new System.Drawing.Size(120, 20);
            this.txtSetpoint.TabIndex = 21;
            // 
            // lblVAq
            // 
            this.lblVAq.AutoSize = true;
            this.lblVAq.Location = new System.Drawing.Point(730, 225);
            this.lblVAq.Name = "lblVAq";
            this.lblVAq.Size = new System.Drawing.Size(41, 13);
            this.lblVAq.TabIndex = 15;
            this.lblVAq.Text = "label15";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tempoDataGridViewTextBoxColumn,
            this.tempDataGridViewTextBoxColumn,
            this.voltVentDataGridViewTextBoxColumn,
            this.voltAqDataGridViewTextBoxColumn,
            this.setpointDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.registroFornoBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(828, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(455, 150);
            this.dataGridView1.TabIndex = 16;
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(1199, 236);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(75, 23);
            this.btnExportar.TabIndex = 17;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1162, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Limpar Registros";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tempoDataGridViewTextBoxColumn
            // 
            this.tempoDataGridViewTextBoxColumn.DataPropertyName = "Tempo";
            this.tempoDataGridViewTextBoxColumn.HeaderText = "Tempo";
            this.tempoDataGridViewTextBoxColumn.Name = "tempoDataGridViewTextBoxColumn";
            // 
            // tempDataGridViewTextBoxColumn
            // 
            this.tempDataGridViewTextBoxColumn.DataPropertyName = "Temp";
            this.tempDataGridViewTextBoxColumn.HeaderText = "Temp";
            this.tempDataGridViewTextBoxColumn.Name = "tempDataGridViewTextBoxColumn";
            // 
            // voltVentDataGridViewTextBoxColumn
            // 
            this.voltVentDataGridViewTextBoxColumn.DataPropertyName = "VoltVent";
            this.voltVentDataGridViewTextBoxColumn.HeaderText = "VoltVent";
            this.voltVentDataGridViewTextBoxColumn.Name = "voltVentDataGridViewTextBoxColumn";
            // 
            // voltAqDataGridViewTextBoxColumn
            // 
            this.voltAqDataGridViewTextBoxColumn.DataPropertyName = "VoltAq";
            this.voltAqDataGridViewTextBoxColumn.HeaderText = "VoltAq";
            this.voltAqDataGridViewTextBoxColumn.Name = "voltAqDataGridViewTextBoxColumn";
            // 
            // setpointDataGridViewTextBoxColumn
            // 
            this.setpointDataGridViewTextBoxColumn.DataPropertyName = "Setpoint";
            this.setpointDataGridViewTextBoxColumn.HeaderText = "Setpoint";
            this.setpointDataGridViewTextBoxColumn.Name = "setpointDataGridViewTextBoxColumn";
            // 
            // registroFornoBindingSource
            // 
            this.registroFornoBindingSource.DataSource = typeof(SupervisorioForno.RegistroForno);
            // 
            // mainFormBindingSource
            // 
            this.mainFormBindingSource.DataSource = typeof(SupervisorioForno.MainForm);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 513);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblVAq);
            this.Controls.Add(this.lblSetPoint);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblVVent);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.chartVolt);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.gaugeChart);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Forno Elétrico | Supervisório";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackAquecedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackVentoinha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaugeChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVolt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSetpoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registroFornoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainFormBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox serialComboBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnResetarParametros;
        private System.Windows.Forms.Button btnAplicarParametros;
        private System.Windows.Forms.RadioButton radioModoOP;
        private System.Windows.Forms.RadioButton radioManual;
        private System.Windows.Forms.TrackBar trackAquecedor;
        private System.Windows.Forms.TrackBar trackVentoinha;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.DataVisualization.Charting.Chart gaugeChart;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVolt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblVVent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblSetPoint;
        private System.Windows.Forms.NumericUpDown txtSetpoint;
        private System.Windows.Forms.NumericUpDown txtKi;
        private System.Windows.Forms.NumericUpDown txtKp;
        private System.Windows.Forms.NumericUpDown txtKd;
        private System.Windows.Forms.Label lblVAq;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tempoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tempDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn voltVentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn voltAqDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn setpointDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource registroFornoBindingSource;
        private System.Windows.Forms.BindingSource mainFormBindingSource;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button button1;
    }
}

