using WebApi.Entidades;
using System.Data.SqlClient;

namespace WebApi.Repositorios
{
	public class RepositorioDeProductos
	{

		// Crear, Modificar, Eliminar, ObtenerPorId, ObtenerTodos
		string connectionString = "Server=localhost;Database=AngularNetCRUD;Trusted_Connection=True;MultipleActiveResultSets=true";


		public Producto ObtenerPorId(int id)		{
			Producto producto = null;

			using (SqlConnection conexion = new SqlConnection(connectionString))
			{
				conexion.Open();

				using (SqlCommand comando = new SqlCommand("SELECT Id, Nombre, Descripcion, Codigo, Precio FROM Productos WHERE Id = @Id", conexion))
				{
					comando.Parameters.AddWithValue("id", id);

					using (SqlDataReader reader = comando.ExecuteReader())
					{
						if (reader.Read())
						{
							producto = new Producto
							{
								Id = Convert.ToInt32(reader["Id"]),
								Nombre = Convert.ToString(reader["Nombre"]),
								Descripcion = Convert.ToString(reader["Descripcion"]),
								Codigo = Convert.ToString(reader["Codigo"]),
								Precio = Convert.ToDecimal(reader["Precio"]),
							};
						}
					}
				}
			}
			return producto;
		}

		public IEnumerable<Producto> ObtenerTodosLosProductos() 
		{
			List<Producto> productos = new List<Producto>();
			using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
				using (SqlCommand comando = new SqlCommand("SELECT Id, Nombre, Descripcion, Codigo, Precio FROM Productos", conexion)) 
				{
					using (SqlDataReader leer  = comando.ExecuteReader())
					{
						while (leer.Read())
						{
							var producto = new Producto
							{
								Id = Convert.ToInt32(leer["Id"]),
								Nombre = Convert.ToString(leer["Nombre"]),
								Descripcion = Convert.ToString(leer["Descripcion"]),
								Codigo = Convert.ToString(leer["Codigo"]),
								Precio = Convert.ToDecimal(leer["Precio"]),
							};
							productos.Add(producto);
						}
					}

				}
			}
			return productos;
		}

		public int Crear(Producto producto)
		{
			int idInsertado = 0;
			using (SqlConnection conexion = new SqlConnection(connectionString))
			{
				
				var sql = "INSERT INTO productos (Nombre, Descripcion, Codigo, Precio ) VALUES (@Nombre, @Descripcion, @Codigo, @Precio); SELECT SCOPE_IDENTITY();";
				SqlCommand comandoSql = new SqlCommand(sql, conexion);
				comandoSql.Parameters.AddWithValue("@Nombre", producto.Nombre);
				comandoSql.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
				comandoSql.Parameters.AddWithValue("@Codigo", producto.Codigo);
				comandoSql.Parameters.AddWithValue("@Precio", producto.Precio);
				conexion.Open();
				// Ejecuto el SQL esperando que retorne un solo valor (el valor identity del producto inserado)
				idInsertado = Convert.ToInt32(comandoSql.ExecuteScalar());
			}
			return idInsertado;
		}

		public bool Actualizar(Producto producto)
		{
			bool resultado = false;
			using (SqlConnection conexion = new SqlConnection(connectionString)) 
			{
                string consulta = "UPDATE Productos SET Nombre = @Nombre, Descripcion = @Descripcion, Codigo = @Codigo, Precio = @Precio WHERE Id = @Id";
                SqlCommand comandoSql = new SqlCommand(consulta, conexion);
                comandoSql.Parameters.AddWithValue("@Nombre", producto.Nombre);
                comandoSql.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                comandoSql.Parameters.AddWithValue("@Codigo", producto.Codigo);
                comandoSql.Parameters.AddWithValue("@Precio", producto.Precio);
                comandoSql.Parameters.AddWithValue("@Id", producto.Id);
                conexion.Open();
                resultado = comandoSql.ExecuteNonQuery() == 1 ? true : false;

            }

				return resultado;
		}

        public IEnumerable<Producto> ObtenerPorCodigoDeProducto(string Codigo)
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                using (SqlCommand comandoSql = new SqlCommand("SELECT Id, Nombre, Descripcion, Codigo, Precio FROM Productos WHERE Codigo = @Codigo", conexion))
                {
                    comandoSql.Parameters.AddWithValue("@Codigo", Codigo);

                    using (SqlDataReader leer = comandoSql.ExecuteReader())
                    {
                        while (leer.Read())
                        {
                            var producto = new Producto
                            {
                                Id = Convert.ToInt32(leer["Id"]),
                                Nombre = Convert.ToString(leer["Nombre"]),
                                Descripcion = Convert.ToString(leer["Descripcion"]),
                                Codigo = Convert.ToString(leer["Codigo"]),
                                Precio= Convert.ToDecimal(leer["Precio"]),

                            };

                            productos.Add(producto);
                        }
                    }
                }
            }

            return productos;
        }

		public bool Borrar(int id) 
		{
			bool resultado = false;
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
				string consulta = "DELETE FROM Productos WHERE Id = @Id";
                SqlCommand comandoSql = new SqlCommand(consulta, conexion);
                comandoSql.Parameters.AddWithValue("@Id", id);
				conexion.Open();
                int rowsAffected = comandoSql.ExecuteNonQuery();
                resultado = rowsAffected == 1;

            }
			return resultado;
		}

    }
}
