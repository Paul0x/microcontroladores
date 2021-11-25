using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using EasyModbus;

namespace SupervisorioForno
{
    public partial class MainForm : Form
    {

        List<RegistroForno> registrosList = new List<RegistroForno>();
        int timerCounter = 0;
        DataTable registros = new DataTable();
        double valMin = 0;        // user data minimum
        double valMax = 100;      // ~ maximum
        float angle = 60;         // open pie angle at the bottom
        string valFmt = "{0}°";  // a format string
        ModbusClient clientModBus;
        Timer timer1;

        public MainForm()
        {
            InitializeComponent();
            setupChartGauge(0, 0, 100, 180);
            this.initComponentes();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        void setupChartGauge(double val, double vMin, double vMax, float a)
        {
            valMin = vMin;
            valMax = vMax;
            angle = a;
            Series s = gaugeChart.Series[0];
            s.ChartType = SeriesChartType.Doughnut;
            s.SetCustomProperty("PieStartAngle", (90 - angle / 2) + "");
            s.SetCustomProperty("DoughnutRadius", "10");
            s.Points.Clear();
            s.Points.AddY(angle);
            s.Points.AddY(0);
            s.Points.AddY(0);
            setChartGauge(30);
            s.BackSecondaryColor = Color.Transparent;
            s.Points[0].Color = Color.Transparent;
            s.Points[1].Color = Color.Chartreuse;
            s.Points[2].Color = Color.Tomato;
            
        }

        void setChartGauge(double val)
        {
            Series s = gaugeChart.Series[0];
            double range = valMax - valMin;
            double aRange = 360 - angle;
            double f = aRange / range;

            double v1 = val * f;
            double v2 = (range - val) * f;
            s.Points[1].YValues[0] = v1;
            s.Points[2].YValues[0] = v2;

            gaugeChart.Titles[0].Text = String.Format(valFmt, val);
            gaugeChart.Refresh();
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }



        private void initComponentes()
        {

            String[] ports = SerialPort.GetPortNames();
            // adicionar as portas ao combobox
            foreach (string port in ports)
            {
                serialComboBox.Items.Add(port);
            }

            InitModBusTimer();


        }

        private void initModbus(String port)
        {
            this.clientModBus = new ModbusClient(port);
            this.clientModBus.Connect();
            radioManual_CheckedChanged(null, null);
        }

        private void serialComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // try to open the selected port:
            try
            {
                this.initModbus(serialComboBox.SelectedItem.ToString());
            }
            // give a message, if the port is not available:
            catch(Exception ex)
            {
                
                MessageBox.Show("A porta serial " + serialComboBox.SelectedItem.ToString() +
                   " não pode ser aberta"+ ex.Message, "Erro",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                serialComboBox.SelectedText = "";
            }
        }

        private void radioManual_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.radioManual.Checked)
                {
                    this.clientModBus.WriteSingleCoil(0, true);
                    Console.WriteLine("Alterado modo de funcionamento: manual");
                    this.txtKd.Enabled = false;
                    this.txtKi.Enabled = false;
                    this.txtKp.Enabled = false;
                    this.txtSetpoint.Enabled = false;
                    this.btnAplicarParametros.Enabled = false;
                    this.trackAquecedor.Enabled = true;
                    this.trackVentoinha.Enabled = true;

                }
            }
            catch
            {

            }
        }

        private void radioModoOP_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.radioModoOP.Checked)
                {
                    this.clientModBus.WriteSingleCoil(0, false);
                    Console.WriteLine("Alterado modo de funcionamento: automático");

                    this.txtKd.Enabled = true;
                    this.txtKi.Enabled = true;
                    this.txtKp.Enabled = true;
                    this.txtSetpoint.Enabled = true;
                    this.btnAplicarParametros.Enabled = true;
                    this.trackAquecedor.Enabled = false;
                    this.trackVentoinha.Enabled = false;
                }
            }
            catch
            {

            }
        }

        private void InitModBusTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 500; // in miliseconds
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try {
                if (clientModBus != null)
                {
                    int[] registradores = clientModBus.ReadHoldingRegisters(1, 4);
                    this.setChartGauge(registradores[0]);
                    this.lblSetPoint.Text = registradores[1].ToString() + " ºC";
                    
                    this.chartVolt.Series["Voltagem Vent."].Points.AddY(registradores[2]/10.0);
                    this.chartVolt.Series["Voltagem Aquec."].Points.AddY(registradores[3]/10.0);
                    this.lblVVent.Text = (registradores[2] / 10.0).ToString();
                    this.lblVAq.Text = (registradores[3] / 10.0).ToString();
                    this.clientModBus.WriteSingleCoil(1, false);

                    RegistroForno registro = new RegistroForno();
                    registro.Tempo = timerCounter * 500;
                    registro.VoltVent = registradores[2] / 10.0;
                    registro.VoltAq = registradores[3] / 10.0;
                    registro.Setpoint = registradores[1];
                    registro.Temp = registradores[0];
                    this.registrosList.Add(registro);
                    this.registros = ConvertToDatatable(registrosList);
                    this.dataGridView1.DataSource = this.registros;
                    timerCounter++;
                }
            }
            catch
            {

            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void trackVentoinha_Scroll(object sender, EventArgs e)
        {
            try
            {
                if (clientModBus != null)
                {
                    clientModBus.WriteSingleRegister(5, this.trackVentoinha.Value);
                }
            }
            catch
            {

            }
        }

        private void trackAquecedor_Scroll(object sender, EventArgs e)
        {
            try
            {
                if (clientModBus != null)
                {
                    clientModBus.WriteSingleRegister(6, this.trackAquecedor.Value);
                }
            }
            catch
            {
            }

        }

        private void btnAplicarParametros_Click(object sender, EventArgs e)
        {
            try
            {
                if (clientModBus != null)
                {
                    int kpValue = (int)(this.txtKp.Value * 100);
                    int kdValue = (int)(this.txtKp.Value * 100);
                    int kiValue = (int)(this.txtKp.Value * 100);
                    int setPoint = (int)(this.txtSetpoint.Value * 10);
                    clientModBus.WriteSingleRegister(7, kpValue);
                    clientModBus.WriteSingleRegister(8, kdValue);
                    clientModBus.WriteSingleRegister(9, kiValue);
                    clientModBus.WriteSingleRegister(10, setPoint);
                    this.clientModBus.WriteSingleCoil(1, true);
                }
            }
            catch
            {

            }
        }

        private static DataTable ConvertToDatatable<T>(List<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    table.Columns.Add(prop.Name, prop.PropertyType.GetGenericArguments()[0]);
                else
                    table.Columns.Add(prop.Name, prop.PropertyType);
            }

            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = "Output.csv";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = dataGridView1.Columns.Count;
                            string columnNames = "";
                            string[] outputCsv = new string[dataGridView1.Rows.Count + 2];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += dataGridView1.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCsv[0] += columnNames;

                            for (int i = 1; (i - 1) < dataGridView1.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    if (dataGridView1.Rows[i - 1].Cells[j].Value != null)
                                    {
                                        outputCsv[i] += dataGridView1.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                    }
                                }
                            }

                            File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                            MessageBox.Show("Dados exportados com sucesso.", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Sem dados para exportar.", "Info");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.registrosList = new List<RegistroForno>();
            this.timerCounter = 0;
            this.chartVolt.Series["Voltagem Vent."].Points.Clear();
            this.chartVolt.Series["Voltagem Aquec."].Points.Clear();
        }
    }

}
