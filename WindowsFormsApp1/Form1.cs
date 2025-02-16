using System;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private const int IntervaloTemp = 2;

        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Configurar ambos gráficos
            ConfigurarGraficoInyeccionRetorno();
            ConfigurarGraficoTemperaturaHumedad();
            ConfigurarGraficoGauge();

            // Poblar el ComboBox con los puertos disponibles
            string[] ports = SerialPort.GetPortNames();
            cmbPorts.Items.AddRange(ports);

            if (cmbPorts.Items.Count > 0)
            {
                cmbPorts.SelectedIndex = 0; // Seleccionar el primer puerto disponible
            }

            // Agregar el evento click del botón conectar
            btnConnect.Click += BtnConnect_Click;

            // Configurar el puerto serie sin abrirlo aún
            serialPort.DataReceived += SerialPort_DataReceived;
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

        private ChartArea ForceCreateChartArea(Chart chart ,string chartAreaName)
        {
            // Check if the ChartArea exists before adding it
            if (chart.ChartAreas.IndexOf(chartAreaName) != -1)
            {
                chart.ChartAreas.Remove(chart.ChartAreas[chartAreaName]);
            }
            // Now add the new ChartArea
            var chartArea = new ChartArea(chartAreaName);
            chart.ChartAreas.Add(chartArea);
            return chartArea;
        }

        private Series ForceCreateSeries(Chart chart, string seriesName)
        {
            // Check if the Series exists before adding it
            if (chart.Series.IndexOf(seriesName) != -1)
            {
                chart.Series.Remove(chart.Series[seriesName]);
            }
            // Now add the new Series
            var series = new Series (seriesName);
            chart.Series.Add(series);
            return series;
        }

        private void ConfigurarGraficoInyeccionRetorno()
        {
            var chartArea = ForceCreateChartArea(chartInyeccionRetorno, "Principal");
            //chartInyeccionRetorno.ChartAreas.Add(new ChartArea("Principal"));

            // Configurar el eje Y izquierdo (Temperatura)
            chartArea.AxisY.Title = "Temperatura (°C)";
            chartArea.AxisY.IsStartedFromZero = false;

            // Set thinner and dashed grid lines for the Y-axis (Temperature)
            chartArea.AxisY.MajorGrid.LineWidth = 1; // Makes it thinner
            chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash; // Dashed style
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;

            // Set thinner and dashed grid lines for the X-axis (Time or other)
            chartArea.AxisX.MajorGrid.LineWidth = 1;
            chartArea.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;

            // Configurar la serie para inyección
            var serieInyeccion = ForceCreateSeries(chartInyeccionRetorno, "Inyección");
            serieInyeccion.ChartType = SeriesChartType.Line;
            serieInyeccion.XValueType = ChartValueType.Time;
            serieInyeccion.YValueType = ChartValueType.Double;


            // Configurar la serie para retorno          
            var serieRetorno = ForceCreateSeries(chartInyeccionRetorno, "Retorno");
            serieRetorno.ChartType = SeriesChartType.Line;
            serieRetorno.XValueType = ChartValueType.Time;
            serieRetorno.YValueType = ChartValueType.Double;

        }
        
        private void ConfigurarGraficoTemperaturaHumedad()
        {
            var chartArea = ForceCreateChartArea(chartTemperaturaHumedad, "Principal");
            

            // Ajustar tamaño del área del gráfico para evitar desbordamientos
            //chartArea.Position = new ElementPosition(0, 0, 100, 100);
            //chartArea.InnerPlotPosition = new ElementPosition(10, 10, 80, 80);
            //chartArea.InnerPlotPosition = new ElementPosition(10, 5, 85, 85);

            // Configurar el eje Y izquierdo (Temperatura)
            chartArea.AxisY.Title = "Temperatura (°C)";
            chartArea.AxisY.IsStartedFromZero = false;

            // Configurar el eje Y derecho (Humedad)
            chartArea.AxisY2.Title = "Humedad (%)";
            chartArea.AxisY2.Enabled = AxisEnabled.True;
            chartArea.AxisY2.Minimum = 0;
            chartArea.AxisY2.Maximum = 100;
            chartArea.AxisY2.MajorGrid.Enabled = false;
            chartArea.AxisY2.LabelStyle.Enabled = true;
            //chartArea.AxisY2.TitleAlignment = StringAlignment.Far;

            // Set thinner and dashed grid lines for the Y-axis (Temperature)
            chartArea.AxisY.MajorGrid.LineWidth = 1; // Makes it thinner
            chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash; // Dashed style
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;


            // Set thinner and dashed grid lines for the X-axis (Time or other)
            chartArea.AxisX.MajorGrid.LineWidth = 1;
            chartArea.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;


            // Configurar la serie para tempRef
            var serieTempRef = ForceCreateSeries(chartTemperaturaHumedad, "TempRef");
            serieTempRef.ChartType = SeriesChartType.Line;
            serieTempRef.XValueType = ChartValueType.Time;
            serieTempRef.YValueType = ChartValueType.Double;


            // Configurar la serie para dewPoint
            var serieDewPoint = ForceCreateSeries(chartTemperaturaHumedad, "DewPoint");
            serieDewPoint.ChartType = SeriesChartType.Line;
            serieDewPoint.XValueType = ChartValueType.Time;
            serieDewPoint.YValueType = ChartValueType.Double;

            // Configurar la serie para humRef con eje Y secundario
            var serieHumRef = ForceCreateSeries(chartTemperaturaHumedad, "HumRef");
            serieHumRef.ChartType = SeriesChartType.Line;
            serieHumRef.XValueType = ChartValueType.Time;
            serieHumRef.YValueType = ChartValueType.Double;
            serieHumRef.YAxisType = AxisType.Secondary; // Asignar al eje Y2

        }

        private void ConfigurarGraficoGauge()
        {
            // Clear any previous chartAreas and series
            chartGauge.ChartAreas.Clear();
            chartGauge.Series.Clear();

            var chartArea = ForceCreateChartArea(chartGauge, "Principal");
            var series = ForceCreateSeries(chartGauge, "Gauge");
            series.ChartType = SeriesChartType.Doughnut;
            series.IsValueShownAsLabel = false;

            // Initial custom property settings.
            series["PieStartAngle"] = "180";
            series["DoughnutRadius"] = "60";
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
                string jsonFormateado = jsonObject.ToString(Formatting.None);

                MostrarDatosEnPantalla(jsonFormateado);

                // Extraer el valor de "modo" (0, 1 o 2)
                int modo = jsonObject["modo"]?.Value<int>() ?? -1;

                // Traducir el valor de "modo" a su descripción
                string modoDescripcion = ObtenerDescripcionModo(modo);

                // Mostrar el modo en el label
                MostrarModo(modoDescripcion);

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

                // Extraer datos para el gráfico de gauge
                double saltoTermico = jsonObject["saltoTermico"]?.Value<double>() ?? 0;

                ActualizarGraficoGauge(saltoTermico);
            }
            catch (JsonReaderException)
            {
                MostrarDatosEnPantalla("Error: El JSON recibido no es válido.");
            }
        }

        private string ObtenerDescripcionModo(int modo)
        {
            switch (modo)
            {
                case 0:
                    return "Refrigeración";
                case 1:
                    return "Calefacción";
                case 2:
                    return "Termohigrómetro";
                default:
                    return "Modo desconocido";
            }
        }

        private void MostrarModo(string modo)
        {
            if (lblModo.InvokeRequired)
            {
                lblModo.Invoke(new Action(() => lblModo.Text = "Modo: " + modo));
            }
            else
            {
                lblModo.Text = "Modo: " + modo;
            }
        }

        /*
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
        */
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

        private void ActualizarGraficoGauge(double saltoTermicoRaw)
        {
            if (chartGauge.InvokeRequired)
            {
                chartGauge.Invoke(new Action(() => ActualizarGraficoGauge(saltoTermicoRaw)));
                return;
            }

            var saltoTermico = Math.Abs(saltoTermicoRaw);

            var series = chartGauge.Series["Gauge"];
            series.Points.Clear();

            // Visible gauge max value (half-circle)
            double maxVisibleValue = 3;
            // Total value (visible half + hidden half)
            double totalValue = maxVisibleValue * 2;

            // Ensure that our gauge value does not exceed the visible maximum
            double valuePortion = Math.Min(saltoTermico, maxVisibleValue);
            double remainingVisible = maxVisibleValue - valuePortion;

            // Determine color based on your conditions:
            Color gaugeColor;
            if (saltoTermico < 1)
                gaugeColor = Color.Red;
            else if (saltoTermico < 2)
                gaugeColor = Color.Yellow;
            else // saltoTermico >= 2
                gaugeColor = Color.Green;

            // Data point 1: the gauge value (visible portion)
            DataPoint dpValue = new DataPoint();
            dpValue.YValues = new double[] { valuePortion };
            dpValue.Color = gaugeColor;
            series.Points.Add(dpValue);

            // Data point 2: the remaining visible portion
            DataPoint dpVisibleRemaining = new DataPoint();
            dpVisibleRemaining.YValues = new double[] { remainingVisible };
            dpVisibleRemaining.Color = Color.LightGray;
            series.Points.Add(dpVisibleRemaining);

            // Data point 3: the dummy (hidden) half. Its value equals maxVisibleValue.
            DataPoint dpHidden = new DataPoint();
            dpHidden.YValues = new double[] { maxVisibleValue };
            dpHidden.Color = Color.Transparent;
            series.Points.Add(dpHidden);

            // Adjust custom properties so that the visible half is on top.
            // "PieStartAngle" of 180 means the drawing begins at the left,
            // positioning your visible 180Â° gauge at the top half.
            series["PieStartAngle"] = "180";
            series["DoughnutRadius"] = "60";

            // Hide the legend and axes for a clean look.
            chartGauge.Legends.Clear();
            ChartArea ca = chartGauge.ChartAreas[0];
            ca.AxisX.Enabled = AxisEnabled.False;
            ca.AxisY.Enabled = AxisEnabled.False;
            ca.BorderWidth = 0;
            ca.BackColor = Color.Transparent;

            // ----- Add or update the center label -----
            // Clear existing titles.
            chartGauge.Titles.Clear();

            // Create a new Title to display the value.
            Title gaugeTitle = new Title();
            gaugeTitle.Text = "Salto Termico: " + saltoTermico.ToString("0.##") + "°C"; // format as needed
            gaugeTitle.Font = new Font("Arial", 11, FontStyle.Bold);
            gaugeTitle.ForeColor = Color.Black;
            // Do not dock automatically.
            gaugeTitle.Docking = Docking.Top;
            // Dock the title inside the ChartArea.
            gaugeTitle.IsDockedInsideChartArea = true;
            // Associate with your ChartArea (named "Principal" when created).
            gaugeTitle.DockedToChartArea = "Principal";
            // Set alignment to center.
            gaugeTitle.Alignment = ContentAlignment.MiddleCenter;

            // Position the title manually using percentages.
            // Adjust these values if needed to perfectly center the text in your doughnut hole.
            gaugeTitle.Position.X = 0;  // X position (percentage)
            gaugeTitle.Position.Y = 50;  // Y position (percentage)
            gaugeTitle.Position.Width = 100;  // Width percentage
            gaugeTitle.Position.Height = 20; // Height percentage

            chartGauge.Titles.Add(gaugeTitle);
        }

        private void AjustarEjes(Chart chart)
        {
            var chartArea = chart.ChartAreas["Principal"];

            // Verifica si es el gráfico de temperatura y humedad
            if (chart == chartTemperaturaHumedad)
            {
                // Obtener las series "TempRef" y "DewPoint"
                Series tempRefSerie = chart.Series["TempRef"];
                Series dewPointSerie = chart.Series["DewPoint"];

                if (tempRefSerie.Points.Count > 0 || dewPointSerie.Points.Count > 0)
                {
                    double minY = double.MaxValue;
                    double maxY = double.MinValue;

                    // Evaluar TempRef
                    foreach (var point in tempRefSerie.Points)
                    {
                        if (point.YValues[0] < minY) minY = point.YValues[0];
                        if (point.YValues[0] > maxY) maxY = point.YValues[0];
                    }

                    // Evaluar DewPoint
                    foreach (var point in dewPointSerie.Points)
                    {
                        if (point.YValues[0] < minY) minY = point.YValues[0];
                        if (point.YValues[0] > maxY) maxY = point.YValues[0];
                    }

                    // Ajustar el eje Y con paso fijo de 1°C
                    chartArea.AxisY.Minimum = Math.Floor(minY) - 1; // Redondear hacia abajo
                    chartArea.AxisY.Maximum = Math.Ceiling(maxY) + 1; // Redondear hacia arriba
                    chartArea.AxisY.Interval = IntervaloTemp; // Paso de 2°C
                }
            }
            else
            {
                // Ajustar ejes normalmente para otros gráficos
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

                        chartArea.AxisY.Minimum = Math.Floor(minY) - 1;
                        chartArea.AxisY.Maximum = Math.Ceiling(maxY) + 1;
                        chartArea.AxisY.Interval = IntervaloTemp; // Paso de 1°C
                    }
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
