using BonbonesFer2024.Datos;
using BonbonesFer2024.Entidades.Entidades;

namespace BonbonesFer2024.Servicios
{
    public class ServiciosTipoDeRelleno
    {
        private readonly RepositorioTiposDeRelleno _repositorio;
        public ServiciosTipoDeRelleno()
        {
            _repositorio=new RepositorioTiposDeRelleno();
        }
        public List<TipoDeRelleno> GetLista()
        {
            try
            {
                return _repositorio.GetLista();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(TipoDeRelleno tipoRelleno)
        {
            try
            {
                if (tipoRelleno.TipoDeRellenoId==0)
                {
                    _repositorio.Agregar(tipoRelleno);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
