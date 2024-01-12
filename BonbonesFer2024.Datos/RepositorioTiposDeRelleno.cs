using BonbonesFer2024.Entidades.Entidades;
using System.Configuration;
using System.Data.SqlClient;

namespace BonbonesFer2024.Datos
{
    public class RepositorioTiposDeRelleno
    {
        private readonly string _connectionString;
        public RepositorioTiposDeRelleno()
        {
            _connectionString= ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }

        public void Agregar(TipoDeRelleno tipoRelleno)
        {
            using (var conn=new SqlConnection(_connectionString))
            {
                conn.Open();
                string insertComando = @"INSERT INTO TiposDeRellenos (Descripcion, Stock)
                    VALUES(@desc, @stock)";
                using (var cmd=new SqlCommand(insertComando,conn))
                {
                    cmd.Parameters.AddWithValue("@desc", tipoRelleno.Descripcion);
                    cmd.Parameters.AddWithValue("@stock", tipoRelleno.Stock);
                    //Ejecuta un comando y devuelve la cantidad de registros 
                    //afectados
                    int cantidad=cmd.ExecuteNonQuery();
                    if (cantidad>0)
                    {
                        string selectComando = "SELECT @@IDENTITY";
                        using (var cmd2=new SqlCommand(selectComando,conn))
                        {
                            int id=Convert.ToInt32(cmd2.ExecuteScalar());
                            tipoRelleno.TipoDeRellenoId= id;
                        }
                    }
                }
            }
        }

        public List<TipoDeRelleno> GetLista()
        {
            List<TipoDeRelleno> lista=new List<TipoDeRelleno>();
            using (var conn=new SqlConnection(_connectionString))
            {
                conn.Open();
                string cadenaComando = @"SELECT TipoDeRellenoId, Descripcion, Stock 
                    FROM TiposDeRellenos";
                using (var cmd=new SqlCommand(cadenaComando,conn))
                {
                    using (var reader=cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tipoDeRelleno = ConstruirTipoDeRelleno(reader);
                            lista.Add(tipoDeRelleno);
                        }
                    }
                }
            }
            return lista;
        }

        private TipoDeRelleno ConstruirTipoDeRelleno(SqlDataReader reader)
        {
            return new TipoDeRelleno
            {
                TipoDeRellenoId = reader.GetInt32(0),
                Descripcion = reader.GetString(1),
                Stock=reader.GetInt32(2)
            };
        }
    }
}
