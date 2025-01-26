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
                // Configurar el gráfico
                ConfigurarGrafico();

                // Configurar el puerto serie
                serialPort.DataReceived += SerialPort_DataReceived;
                serialPort.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el puerto: " + ex.Message);
            }
        }

        private void ConfigurarGrafico()
        {
            // Configurar el área del gráfico
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
                // Validar el JSON y formatearlo con indentación.
                JObject jsonObject = JObject.Parse(json);
                string jsonFormateado = jsonObject.ToString(Formatting.Indented);

                // Mostrar el JSON formateado en el TextBox.
                MostrarDatosEnPantalla(jsonFormateado);

                // Extraer datos para el gráfico
                double inyeccion = jsonObject["inyeccion"]?.Value<double>() ?? 0;
                double retorno = jsonObject["retorno"]?.Value<double>() ?? 0;
                string time = jsonObject["time"]?.Value<string>() ?? DateTime.Now.ToString("HH:mm:ss");

                // Agregar puntos al gráfico
                AgregarPuntosAlGrafico(time, inyeccion, retorno);
            }
            catch (JsonReaderException)
            {
                // Si el JSON es inválido, mostrar un mensaje de error.
                MostrarDatosEnPantalla("Error: El JSON recibido no es válido.");
            }
        }

        private void AgregarPuntosAlGrafico(string time, double inyeccion, double retorno)
        {
            if (chartInyeccionRetorno.InvokeRequired)
            {
                chartInyeccionRetorno.Invoke(new Action(() => AgregarPuntosAlGrafico(time, inyeccion, retorno)));
            }
            else
            {
                // Agregar puntos a las series
                chartInyeccionRetorno.Series["Inyección"].Points.AddXY(time, inyeccion);
                chartInyeccionRetorno.Series["Retorno"].Points.AddXY(time, retorno);

                // Mantener un límite de puntos para evitar saturación
                if (chartInyeccionRetorno.Series["Inyección"].Points.Count > 100)
                {
                    chartInyeccionRetorno.Series["Inyección"].Points.RemoveAt(0);
                    chartInyeccionRetorno.Series["Retorno"].Points.RemoveAt(0);
                }

                // Ajustar el eje X automáticamente
                chartInyeccionRetorno.ChartAreas["Principal"].RecalculateAxesScale();
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
    }
}
