namespace SistemaPrestamos.UI
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.txtPlazo = new System.Windows.Forms.TextBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnPrestamos = new System.Windows.Forms.Button();
            this.dgvAmortizacion = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAmortizacion)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Monto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Plazo";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(67, 14);
            this.txtMonto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(89, 22);
            this.txtMonto.TabIndex = 2;
            // 
            // txtPlazo
            // 
            this.txtPlazo.Location = new System.Drawing.Point(67, 46);
            this.txtPlazo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPlazo.Name = "txtPlazo";
            this.txtPlazo.Size = new System.Drawing.Size(89, 22);
            this.txtPlazo.TabIndex = 3;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(12, 80);
            this.btnCalcular.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(89, 23);
            this.btnCalcular.TabIndex = 4;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(12, 116);
            this.btnClientes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(89, 23);
            this.btnClientes.TabIndex = 5;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnPrestamos
            // 
            this.btnPrestamos.Location = new System.Drawing.Point(12, 152);
            this.btnPrestamos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrestamos.Name = "btnPrestamos";
            this.btnPrestamos.Size = new System.Drawing.Size(89, 23);
            this.btnPrestamos.TabIndex = 6;
            this.btnPrestamos.Text = "Prestamos";
            this.btnPrestamos.Click += new System.EventHandler(this.btnPrestamos_Click);
            // 
            // dgvAmortizacion
            // 
            this.dgvAmortizacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAmortizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAmortizacion.Location = new System.Drawing.Point(217, 8);
            this.dgvAmortizacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvAmortizacion.Name = "dgvAmortizacion";
            this.dgvAmortizacion.RowHeadersWidth = 51;
            this.dgvAmortizacion.RowTemplate.Height = 24;
            this.dgvAmortizacion.Size = new System.Drawing.Size(646, 323);
            this.dgvAmortizacion.TabIndex = 5;
            this.dgvAmortizacion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAmortizacion_CellContentClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 480);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.txtPlazo);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.btnPrestamos);
            this.Controls.Add(this.dgvAmortizacion);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(891, 489);
            this.Name = "Form1";
            this.Text = "Sistema de Prestamos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAmortizacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.TextBox txtPlazo;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnPrestamos;
        private System.Windows.Forms.DataGridView dgvAmortizacion;
    }
}