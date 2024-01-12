namespace Bonbones2024.Windows
{
    partial class frmRellenosAE
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            txtRelleno = new TextBox();
            errorProvider1 = new ErrorProvider(components);
            btnOK = new Button();
            btnCancelar = new Button();
            label2 = new Label();
            nudStock = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 30);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 0;
            label1.Text = "Relleno:";
            // 
            // txtRelleno
            // 
            txtRelleno.Location = new Point(107, 29);
            txtRelleno.MaxLength = 50;
            txtRelleno.Name = "txtRelleno";
            txtRelleno.Size = new Size(351, 23);
            txtRelleno.TabIndex = 1;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // btnOK
            // 
            btnOK.Image = Properties.Resources.Aceptar;
            btnOK.Location = new Point(48, 101);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(88, 61);
            btnOK.TabIndex = 2;
            btnOK.Text = "OK";
            btnOK.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Image = Properties.Resources.Cancelar;
            btnCancelar.Location = new Point(370, 101);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(88, 61);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 59);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 0;
            label2.Text = "Stock:";
            // 
            // nudStock
            // 
            nudStock.Location = new Point(107, 61);
            nudStock.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudStock.Name = "nudStock";
            nudStock.Size = new Size(120, 23);
            nudStock.TabIndex = 3;
            nudStock.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // frmRellenosAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(530, 198);
            Controls.Add(nudStock);
            Controls.Add(btnCancelar);
            Controls.Add(btnOK);
            Controls.Add(label2);
            Controls.Add(txtRelleno);
            Controls.Add(label1);
            Name = "frmRellenosAE";
            Text = "frmRellenosAE";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtRelleno;
        private ErrorProvider errorProvider1;
        private NumericUpDown nudStock;
        private Button btnCancelar;
        private Button btnOK;
        private Label label2;
    }
}