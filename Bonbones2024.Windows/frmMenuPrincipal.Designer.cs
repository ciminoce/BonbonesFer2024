namespace Bonbones2024.Windows
{
    partial class frmMenuPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnRellenos = new Button();
            SuspendLayout();
            // 
            // btnRellenos
            // 
            btnRellenos.Location = new Point(42, 41);
            btnRellenos.Name = "btnRellenos";
            btnRellenos.Size = new Size(129, 60);
            btnRellenos.TabIndex = 0;
            btnRellenos.Text = "Tipos de Relleno";
            btnRellenos.UseVisualStyleBackColor = true;
            btnRellenos.Click += btnRellenos_Click;
            // 
            // frmMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRellenos);
            Name = "frmMenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menú Principal";
            ResumeLayout(false);
        }

        #endregion

        private Button btnRellenos;
    }
}
