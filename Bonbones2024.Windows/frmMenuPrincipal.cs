namespace Bonbones2024.Windows
{
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnRellenos_Click(object sender, EventArgs e)
        {
            var frm=new frmRellenos();
            frm.ShowDialog();
        }
    }
}
