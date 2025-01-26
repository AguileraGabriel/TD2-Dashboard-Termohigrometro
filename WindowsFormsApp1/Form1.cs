using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                serialPort.DataReceived += SerialPort_DataReceived;
                serialPort.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el puerto: " + ex.Message);
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string json = serialPort.ReadLine();
                MostrarDatosEnPantalla(json);
            }
            catch (Exception ex)
            {
                MostrarDatosEnPantalla("Error: " + ex.Message);
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
