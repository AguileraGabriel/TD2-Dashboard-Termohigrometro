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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.chartInyeccionRetorno = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTemperaturaHumedad = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmbPorts = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblModo = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chartGauge = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartInyeccionRetorno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperaturaHumedad)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartGauge)).BeginInit();
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
            legend1.Name = "Legend1";
            this.chartInyeccionRetorno.Legends.Add(legend1);
            this.chartInyeccionRetorno.Location = new System.Drawing.Point(3, 3);
            this.chartInyeccionRetorno.Name = "chartInyeccionRetorno";
            this.chartInyeccionRetorno.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chartInyeccionRetorno.Size = new System.Drawing.Size(741, 237);
            this.chartInyeccionRetorno.TabIndex = 1;
            this.chartInyeccionRetorno.Text = "chart1";
            this.chartInyeccionRetorno.Click += new System.EventHandler(this.chartInyeccionRetorno_Click);
            // 
            // chartTemperaturaHumedad
            // 
            this.chartTemperaturaHumedad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartTemperaturaHumedad.BackColor = System.Drawing.Color.Transparent;
            this.chartTemperaturaHumedad.Cursor = System.Windows.Forms.Cursors.Cross;
            legend2.Name = "Legend1";
            this.chartTemperaturaHumedad.Legends.Add(legend2);
            this.chartTemperaturaHumedad.Location = new System.Drawing.Point(3, 246);
            this.chartTemperaturaHumedad.Name = "chartTemperaturaHumedad";
            this.chartTemperaturaHumedad.Size = new System.Drawing.Size(741, 237);
            this.chartTemperaturaHumedad.TabIndex = 2;
            this.chartTemperaturaHumedad.Text = "chart1";
            this.chartTemperaturaHumedad.Click += new System.EventHandler(this.chartTemperaturaHumedad_Click);
            // 
            // cmbPorts
            // 
            this.cmbPorts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPorts.FormattingEnabled = true;
            this.cmbPorts.Location = new System.Drawing.Point(855, 25);
            this.cmbPorts.Name = "cmbPorts";
            this.cmbPorts.Size = new System.Drawing.Size(121, 24);
            this.cmbPorts.TabIndex = 3;
            this.cmbPorts.SelectedIndexChanged += new System.EventHandler(this.cmbPorts_SelectedIndexChanged);
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(982, 25);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(96, 23);
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
            this.textBox1.Text = "Proyecto Digitales II";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblModo
            // 
            this.lblModo.AutoSize = true;
            this.lblModo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModo.Location = new System.Drawing.Point(42, 25);
            this.lblModo.Name = "lblModo";
            this.lblModo.Size = new System.Drawing.Size(58, 22);
            this.lblModo.TabIndex = 7;
            this.lblModo.Text = "label1";
            this.lblModo.Click += new System.EventHandler(this.label1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.30242F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.69758F));
            this.tableLayoutPanel1.Controls.Add(this.chartInyeccionRetorno, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartTemperaturaHumedad, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chartGauge, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(46, 104);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(992, 486);
            this.tableLayoutPanel1.TabIndex = 8;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // chartGauge
            // 
            this.chartGauge.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartGauge.BackColor = System.Drawing.Color.Transparent;
            legend3.Name = "Legend1";
            this.chartGauge.Legends.Add(legend3);
            this.chartGauge.Location = new System.Drawing.Point(750, 3);
            this.chartGauge.Name = "chartGauge";
            this.chartGauge.Size = new System.Drawing.Size(239, 237);
            this.chartGauge.TabIndex = 3;
            this.chartGauge.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 675);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblModo);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cmbPorts);
            this.Controls.Add(this.txtOutput);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chartInyeccionRetorno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperaturaHumedad)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartGauge)).EndInit();
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
        private System.Windows.Forms.Label lblModo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGauge;
    }
}

