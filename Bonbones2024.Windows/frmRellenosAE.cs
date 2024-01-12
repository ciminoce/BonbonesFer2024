using BonbonesFer2024.Entidades.Entidades;

namespace Bonbones2024.Windows
{
    public partial class frmRellenosAE : Form
    {
        public frmRellenosAE()
        {
            InitializeComponent();
        }
        private TipoDeRelleno tipoRelleno;
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                tipoRelleno = new TipoDeRelleno()
                {
                    Descripcion = txtRelleno.Text,
                    Stock = (int)nudStock.Value
                };
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtRelleno.Text))
            {
                valido = false;
                errorProvider1.SetError(txtRelleno, "El relleno es requerido");
            }
            return valido;
        }

        public TipoDeRelleno GetTipo()
        {
            return tipoRelleno;
        }
    }
}
