using System;
using System.IO.Ports;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Configurar ambos gráficos
                ConfigurarGraficoInyeccionRetorno();
                ConfigurarGraficoTemperaturaHumedad();

                // Configurar el puerto serie
                serialPort.DataReceived += SerialPort_DataReceived;
                serialPort.Open();

                // Poblar el ComboBox con los puertos disponibles
                string[] ports = SerialPort.GetPortNames();
                cmbPorts.Items.AddRange(ports);

                if (cmbPorts.Items.Count > 0)
                {
                    cmbPorts.SelectedIndex = 0; // Seleccionar el primer puerto disponible
                }

                btnConnect.Click += BtnConnect_Click;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el puerto: " + ex.Message);
            }
        }


        private void BtnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }

                serialPort.PortName = cmbPorts.SelectedItem.ToString();
                serialPort.Open();
                MessageBox.Show("Conectado a " + serialPort.PortName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el puerto: " + ex.Message);
            }
        }
        private void ConfigurarGraficoInyeccionRetorno()
        {
            chartInyeccionRetorno.ChartAreas.Add(new ChartArea("Principal"));

            // Configurar la serie para inyección
            var serieInyeccion = new Series("Inyección")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.Time,
                YValueType = ChartValueType.Double
            };
            chartInyeccionRetorno.Series.Add(serieInyeccion);

            // Configurar la serie para retorno
            var serieRetorno = new Series("Retorno")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.Time,
                YValueType = ChartValueType.Double
            };
            chartInyeccionRetorno.Series.Add(serieRetorno);
        }

        private void ConfigurarGraficoTemperaturaHumedad()
        {
            var chartArea = new ChartArea("Principal");
            chartTemperaturaHumedad.ChartAreas.Add(chartArea);

            // Configurar el eje Y izquierdo para tempRef y dewPoint
            chartArea.AxisY.Title = "Temperatura (°C)";
            chartArea.AxisY.IsStartedFromZero = false;

            // Configurar el eje Y derecho para humRef
            chartArea.AxisY2.Title = "Humedad (%)";
            chartArea.AxisY2.Enabled = AxisEnabled.True;
            chartArea.AxisY2.Minimum = 0;
            chartArea.AxisY2.Maximum = 100;

            // Configurar la serie para tempRef
            var serieTempRef = new Series("TempRef")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.Time,
                YValueType = ChartValueType.Double
            };
            chartTemperaturaHumedad.Series.Add(serieTempRef);

            // Configurar la serie para dewPoint
            var serieDewPoint = new Series("DewPoint")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.Time,
                YValueType = ChartValueType.Double
            };
            chartTemperaturaHumedad.Series.Add(serieDewPoint);

            // Configurar la serie para humRef con eje Y secundario
            var serieHumRef = new Series("HumRef")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.Time,
                YValueType = ChartValueType.Double,
                YAxisType = AxisType.Secondary // Asignar al eje Y2
            };
            chartTemperaturaHumedad.Series.Add(serieHumRef);
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string json = serialPort.ReadLine();
                ProcesarJson(json);
            }
            catch (Exception ex)
            {
                MostrarDatosEnPantalla("Error al leer datos: " + ex.Message);
            }
        }

        private void ProcesarJson(string json)
        {
            try
            {
                JObject jsonObject = JObject.Parse(json);
                string jsonFormateado = jsonObject.ToString(Formatting.Indented);

                MostrarDatosEnPantalla(jsonFormateado);

                // Extraer datos para el primer gráfico
                double inyeccion = jsonObject["inyeccion"]?.Value<double>() ?? 0;
                double retorno = jsonObject["retorno"]?.Value<double>() ?? 0;
                string time = jsonObject["time"]?.Value<string>() ?? DateTime.Now.ToString("HH:mm:ss");

                AgregarPuntosGraficoInyeccionRetorno(time, inyeccion, retorno);

                // Extraer datos para el segundo gráfico
                double tempRef = jsonObject["tempRef"]?.Value<double>() ?? 0;
                double humRef = jsonObject["humRef"]?.Value<double>() ?? 0;
                double dewPoint = jsonObject["dewPoint"]?.Value<double>() ?? 0;

                AgregarPuntosGraficoTemperaturaHumedad(time, tempRef, humRef, dewPoint);
            }
            catch (JsonReaderException)
            {
                MostrarDatosEnPantalla("Error: El JSON recibido no es válido.");
            }
        }

        private void AgregarPuntosGraficoInyeccionRetorno(string time, double inyeccion, double retorno)
        {
            if (chartInyeccionRetorno.InvokeRequired)
            {
                chartInyeccionRetorno.Invoke(new Action(() => AgregarPuntosGraficoInyeccionRetorno(time, inyeccion, retorno)));
            }
            else
            {
                chartInyeccionRetorno.Series["Inyección"].Points.AddXY(time, inyeccion);
                chartInyeccionRetorno.Series["Retorno"].Points.AddXY(time, retorno);

                AjustarEjes(chartInyeccionRetorno);
            }
        }

        private void AgregarPuntosGraficoTemperaturaHumedad(string time, double tempRef, double humRef, double dewPoint)
        {
            if (chartTemperaturaHumedad.InvokeRequired)
            {
                chartTemperaturaHumedad.Invoke(new Action(() => AgregarPuntosGraficoTemperaturaHumedad(time, tempRef, humRef, dewPoint)));
            }
            else
            {
                chartTemperaturaHumedad.Series["TempRef"].Points.AddXY(time, tempRef);
                chartTemperaturaHumedad.Series["HumRef"].Points.AddXY(time, humRef);
                chartTemperaturaHumedad.Series["DewPoint"].Points.AddXY(time, dewPoint);

                AjustarEjes(chartTemperaturaHumedad);
            }
        }

        private void AjustarEjes(Chart chart)
        {
            var chartArea = chart.ChartAreas["Principal"];

            foreach (var serie in chart.Series)
            {
                if (serie.Points.Count > 0 && serie.YAxisType == AxisType.Primary)
                {
                    double minY = double.MaxValue;
                    double maxY = double.MinValue;

                    foreach (var point in serie.Points)
                    {
                        if (point.YValues[0] < minY) minY = point.YValues[0];
                        if (point.YValues[0] > maxY) maxY = point.YValues[0];
                    }

                    chartArea.AxisY.Minimum = minY - 1; // Margen inferior
                    chartArea.AxisY.Maximum = maxY + 1; // Margen superior
                }
            }
        }

        private void MostrarDatosEnPantalla(string texto)
        {
            if (txtOutput.InvokeRequired)
            {
                txtOutput.Invoke(new Action(() => txtOutput.Text = texto));
            }
            else
            {
                txtOutput.Text = texto;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        private void chartInyeccionRetorno_Click(object sender, EventArgs e)
        {

        }

        private void cmbPorts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chartTemperaturaHumedad_Click(object sender, EventArgs e)
        {

        }
    }
}
