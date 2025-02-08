namespace WindowsFormsApp1
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
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.chartInyeccionRetorno = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTemperaturaHumedad = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmbPorts = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartInyeccionRetorno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperaturaHumedad)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOutput
            // 
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtOutput.Location = new System.Drawing.Point(0, 629);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(1090, 46);
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
            this.chartInyeccionRetorno.BackColor = System.Drawing.Color.Transparent;
            this.chartInyeccionRetorno.BorderlineColor = System.Drawing.Color.Transparent;
            this.chartInyeccionRetorno.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.chartInyeccionRetorno.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            this.chartInyeccionRetorno.Cursor = System.Windows.Forms.Cursors.Cross;
            this.chartInyeccionRetorno.Location = new System.Drawing.Point(60, 86);
            this.chartInyeccionRetorno.Name = "chartInyeccionRetorno";
            this.chartInyeccionRetorno.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chartInyeccionRetorno.Size = new System.Drawing.Size(977, 159);
            this.chartInyeccionRetorno.TabIndex = 1;
            this.chartInyeccionRetorno.Text = "chart1";
            this.chartInyeccionRetorno.Click += new System.EventHandler(this.chartInyeccionRetorno_Click);
            // 
            // chartTemperaturaHumedad
            // 
            this.chartTemperaturaHumedad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartTemperaturaHumedad.BackColor = System.Drawing.Color.Transparent;
            this.chartTemperaturaHumedad.Cursor = System.Windows.Forms.Cursors.Cross;
            this.chartTemperaturaHumedad.Location = new System.Drawing.Point(60, 293);
            this.chartTemperaturaHumedad.Name = "chartTemperaturaHumedad";
            this.chartTemperaturaHumedad.Size = new System.Drawing.Size(977, 319);
            this.chartTemperaturaHumedad.TabIndex = 2;
            this.chartTemperaturaHumedad.Text = "chart1";
            this.chartTemperaturaHumedad.Click += new System.EventHandler(this.chartTemperaturaHumedad_Click);
            // 
            // cmbPorts
            // 
            this.cmbPorts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPorts.FormattingEnabled = true;
            this.cmbPorts.Location = new System.Drawing.Point(871, 25);
            this.cmbPorts.Name = "cmbPorts";
            this.cmbPorts.Size = new System.Drawing.Size(121, 24);
            this.cmbPorts.TabIndex = 3;
            this.cmbPorts.SelectedIndexChanged += new System.EventHandler(this.cmbPorts_SelectedIndexChanged);
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(1003, 25);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Conectar";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(344, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(413, 38);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "Proyecto Termohigrometro";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 675);
            this.Controls.Add(this.chartTemperaturaHumedad);
            this.Controls.Add(this.chartInyeccionRetorno);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cmbPorts);
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
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTemperaturaHumedad;
        private System.Windows.Forms.ComboBox cmbPorts;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartInyeccionRetorno;
    }
}

