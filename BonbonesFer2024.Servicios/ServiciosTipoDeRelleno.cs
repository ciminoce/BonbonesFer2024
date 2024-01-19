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
        public bool EstaRelacionado(TipoDeRelleno tipoDeRelleno)
        {
            try
            {
                return _repositorio.EstaRelacionada(tipoDeRelleno);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Borrar(TipoDeRelleno relleno)
        {
            try
            {
                _repositorio.Borrar(relleno);
            }
            catch (Exception)
            {

                throw;
            }
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
        public bool Existe(TipoDeRelleno tipoDeRelleno)
        {
            try
            {
                return _repositorio.Existe(tipoDeRelleno);
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
                else
                {
                    _repositorio.Editar(tipoRelleno);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
