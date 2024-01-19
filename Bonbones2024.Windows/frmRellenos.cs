using BonbonesFer2024.Entidades.Entidades;
using BonbonesFer2024.Servicios;

namespace Bonbones2024.Windows
{
    public partial class frmRellenos : Form
    {
        public frmRellenos()
        {
            InitializeComponent();
            _servicios = new ServiciosTipoDeRelleno();
        }
        private List<TipoDeRelleno>? lista;
        private readonly ServiciosTipoDeRelleno _servicios;
        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmRellenos_Load(object sender, EventArgs e)
        {
            try
            {
                lista = _servicios.GetLista();
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MostrarDatosEnGrilla()
        {
            //Limpiar grilla
            dgvDatos.Rows.Clear();
            //recorrer la lista e ir creando las filas
            foreach (var relleno in lista)
            {
                //Creo la fila
                var r = ConstruirFila();
                //Seteo la fila con datos
                SetearFila(r, relleno);
                //Agrego a la grilla
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, TipoDeRelleno relleno)
        {
            r.Cells[colRelleno.Index].Value = relleno.Descripcion;
            r.Cells[colStock.Index].Value = relleno.Stock;

            r.Tag = relleno;
        }

        private DataGridViewRow ConstruirFila()
        {
            var r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmRellenosAE frm = new frmRellenosAE() { Text = "Nuevo Relleno" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            try
            {
                TipoDeRelleno tipoRelleno = frm.GetTipo();

                if (!_servicios.Existe(tipoRelleno))
                {
                    _servicios.Guardar(tipoRelleno);
                    var r = ConstruirFila();
                    SetearFila(r, tipoRelleno);
                    AgregarFila(r);
                    MessageBox.Show("Registro agregado",
                        "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show(@"Registro existente!!!" + Environment.NewLine + "Alta Denegada", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            var relleno = (TipoDeRelleno)r.Tag;
            try
            {
                DialogResult dr = MessageBox.Show($"¿Desea dar de baja al relleno {relleno.Descripcion}?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }
                //TODO: Verificar si no está relacionado 
                if (!_servicios.EstaRelacionado(relleno))
                {
                    _servicios.Borrar(relleno);
                    dgvDatos.Rows.Remove(r);
                    MessageBox.Show("Registro Eliminado Satisfactoriamente!!!", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show(@"Registro relacionado!!!" + Environment.NewLine + "Eliminación Denegada", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count==0)
            {
                return;
            }
            try
            {
                var r = dgvDatos.SelectedRows[0];
                var relleno = (TipoDeRelleno)r.Tag;
                frmRellenosAE frm = new frmRellenosAE() { Text = "Editar Relleno" };
                frm.SetTipo(relleno);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel) { return; }
                relleno = frm.GetTipo();
                if (!_servicios.Existe(relleno))
                {
                    _servicios.Guardar(relleno);
                    SetearFila(r, relleno);
                    MessageBox.Show("Registro Editado Satisfactoriamente!!!", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show(@"Registro existente!!!" + Environment.NewLine + "Alta Denegada", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
