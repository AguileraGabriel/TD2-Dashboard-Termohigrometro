﻿namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.chartInyeccionRetorno = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTemperaturaHumedad = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartInyeccionRetorno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperaturaHumedad)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOutput
            // 
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtOutput.Location = new System.Drawing.Point(0, 521);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(1001, 46);
            this.txtOutput.TabIndex = 0;
            this.txtOutput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // serialPort
            // 
            this.serialPort.PortName = "COM3";
            // 
            // chartInyeccionRetorno
            // 
            this.chartInyeccionRetorno.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartInyeccionRetorno.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartInyeccionRetorno.Legends.Add(legend1);
            this.chartInyeccionRetorno.Location = new System.Drawing.Point(12, 12);
            this.chartInyeccionRetorno.Name = "chartInyeccionRetorno";
            this.chartInyeccionRetorno.Size = new System.Drawing.Size(977, 240);
            this.chartInyeccionRetorno.TabIndex = 1;
            this.chartInyeccionRetorno.Text = "chart1";
            // 
            // chartTemperaturaHumedad
            // 
            this.chartTemperaturaHumedad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chartTemperaturaHumedad.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartTemperaturaHumedad.Legends.Add(legend2);
            this.chartTemperaturaHumedad.Location = new System.Drawing.Point(12, 258);
            this.chartTemperaturaHumedad.Name = "chartTemperaturaHumedad";
            this.chartTemperaturaHumedad.Size = new System.Drawing.Size(977, 257);
            this.chartTemperaturaHumedad.TabIndex = 2;
            this.chartTemperaturaHumedad.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 567);
            this.Controls.Add(this.chartTemperaturaHumedad);
            this.Controls.Add(this.chartInyeccionRetorno);
            this.Controls.Add(this.txtOutput);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chartInyeccionRetorno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperaturaHumedad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOutput;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartInyeccionRetorno;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTemperaturaHumedad;
    }
}

