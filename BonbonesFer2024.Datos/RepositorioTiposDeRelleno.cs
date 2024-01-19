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
            _connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }
        public bool Existe(TipoDeRelleno tipoDeRelleno)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                //TODO:OJO cuando es edición
                string selectCommand = @"SELECT * FROM TiposDeRellenos ";
                if (tipoDeRelleno.TipoDeRellenoId==0)
                {
                    string whereCondition = "WHERE Descripcion=@desc";
                    var finalCondition=string.Concat(selectCommand, whereCondition);
                    using (var cmd = new SqlCommand(finalCondition, conn))
                    {
                        cmd.Parameters.AddWithValue("@desc", tipoDeRelleno.Descripcion);
                        using (var reader = cmd.ExecuteReader())
                        {
                            return reader.HasRows;
                        }
                    }

                }
                else
                {
                    string whereCondition = "WHERE Descripcion=@desc AND TipoDeRellenoId<>@id";
                    var finalCondition = string.Concat(selectCommand, whereCondition);
                    using (var cmd = new SqlCommand(finalCondition, conn))
                    {
                        cmd.Parameters.AddWithValue("@desc", tipoDeRelleno.Descripcion);
                        cmd.Parameters.AddWithValue("@id", tipoDeRelleno.TipoDeRellenoId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            return reader.HasRows;
                        }
                    }

                }
            }
        }
        public void Agregar(TipoDeRelleno tipoRelleno)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string insertComando = @"INSERT INTO TiposDeRellenos (Descripcion, Stock)
                    VALUES(@desc, @stock)";
                using (var cmd = new SqlCommand(insertComando, conn))
                {
                    cmd.Parameters.AddWithValue("@desc", tipoRelleno.Descripcion);
                    cmd.Parameters.AddWithValue("@stock", tipoRelleno.Stock);
                    //Ejecuta un comando y devuelve la cantidad de registros 
                    //afectados
                    int cantidad = cmd.ExecuteNonQuery();
                    if (cantidad > 0)
                    {
                        string selectComando = "SELECT @@IDENTITY";
                        using (var cmd2 = new SqlCommand(selectComando, conn))
                        {
                            int id = Convert.ToInt32(cmd2.ExecuteScalar());
                            tipoRelleno.TipoDeRellenoId = id;
                        }
                    }
                }

            }
        }


        public void Borrar(TipoDeRelleno relleno)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string deleteCommand = @"DELETE FROM TiposDeRellenos WHERE TipoDeRellenoId=@id";
                using (var cmd = new SqlCommand(deleteCommand, conn))
                {
                    cmd.Parameters.AddWithValue("@id", relleno.TipoDeRellenoId);

                    int registros = cmd.ExecuteNonQuery();
                    if (registros == 0)
                    {
                        throw new Exception("Registro no encontrado!!!");
                    }
                }
            }
        }

        public List<TipoDeRelleno> GetLista()
        {
            List<TipoDeRelleno> lista = new List<TipoDeRelleno>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string cadenaComando = @"SELECT TipoDeRellenoId, Descripcion, Stock 
                    FROM TiposDeRellenos";
                using (var cmd = new SqlCommand(cadenaComando, conn))
                {
                    using (var reader = cmd.ExecuteReader())
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
                Stock = reader.GetInt32(2)
            };
        }

        public bool EstaRelacionada(TipoDeRelleno tipoDeRelleno)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string selectCommand = @"SELECT COUNT(*) FROM Bombones WHERE TipoDeRellenoId=@id";
                using (var cmd = new SqlCommand(selectCommand, conn))
                {
                    cmd.Parameters.AddWithValue("@id", tipoDeRelleno.TipoDeRellenoId);

                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        public void Editar(TipoDeRelleno tipoRelleno)
        {
            using (var conn=new SqlConnection(_connectionString))
            {
                conn.Open();
                string updateCommand = @"UPDATE TiposDeRellenos SET Descripcion=@desc, Stock=@stock
                    WHERE TipoDeRellenoId=@id";
                using (var cmd=new SqlCommand(updateCommand,conn))
                {
                    cmd.Parameters.AddWithValue("@desc", tipoRelleno.Descripcion);
                    cmd.Parameters.AddWithValue("@stock", tipoRelleno.Stock);

                    cmd.Parameters.AddWithValue("@id", tipoRelleno.TipoDeRellenoId);

                    int registrosAfectados=cmd.ExecuteNonQuery();
                    if (registrosAfectados==0)
                    {
                        throw new Exception("No se pudo editar el registro");
                    }
                }
            }
        }
    }

}