using WebApi.Entidades;
using WebApi.Repositorios;

namespace WebApi.Logica
{
	public class LogicaDeProductos
	{
		private readonly RepositorioDeProductos repositorioDeProductos;

		public LogicaDeProductos()
		{
			repositorioDeProductos = new RepositorioDeProductos();
		}

		public Producto ObtenerPorId(int id)
		{
			return repositorioDeProductos.ObtenerPorId(id);
		}
        public IEnumerable<Producto> ObtenerTodosLosProductos()
        {
            return repositorioDeProductos.ObtenerTodosLosProductos();
        }

        public int Crear(Producto producto)
		{
			if (producto == null) {
				throw new ArgumentException("Error al crear un producto. El paramétro producto es null");
			}

			if (string.IsNullOrEmpty(producto.Nombre))
			{
				throw new ArgumentException("Error al crear un producto. El nombre del producto no puede estar vacío");
			}

			if (string.IsNullOrEmpty(producto.Descripcion))
			{
				throw new ArgumentException("Error al crear un producto. La descripción del producto no puede estar vacío");
			}

            if (string.IsNullOrEmpty(producto.Codigo))
            {
                throw new ArgumentException("Error al crear un producto. El código del producto no puede estar vacío");
            }

            // Quiero prevenir que al crear este producto, se genere una duplicacion de dos productos con el mismo codigo                       
            var ProductoConIgualCodigo = repositorioDeProductos.ObtenerPorCodigoDeProducto(producto.Codigo);
            if (ProductoConIgualCodigo.Any())
            {
                throw new ArgumentException("No se puede crear este producto porque ya existe otro con el mismo codigo");
            }            

            // Vamos a admitir precio 0 por si queremos crear un producto y aun no tenemos definido el precio
            if (producto.Precio < 0)
			{
				throw new ArgumentException("Error al crear un producto. El precio del producto no puede ser negativo");
			}

			var id = repositorioDeProductos.Crear(producto);
			return id;
		}

        public bool Actualizar(Producto producto)
        {
            if (producto == null)
            {
                throw new ArgumentException("Error al actualizar un producto. El paramétro producto es null");
            }

            if (string.IsNullOrEmpty(producto.Nombre))
            {
                throw new ArgumentException("Error al actualizar  un producto. El nombre del producto no puede estar vacío");
            }

            if (string.IsNullOrEmpty(producto.Descripcion))
            {
                throw new ArgumentException("Error al actualizar  un producto. La descripción del producto no puede estar vacío");
            }

            if (string.IsNullOrEmpty(producto.Codigo))
            {
                throw new ArgumentException("Error al actualizar  un producto. El código del producto no puede estar vacío");
            }

            // Vamos a admitir precio 0 por si queremos modificar un producto y aun no sabemos el precio
            if (producto.Precio < 0)
            {
                throw new ArgumentException("Error al actualizar un producto. El precio del producto no puede ser negativo");
            }

            // Quiero prevenir que al modificar este producto, se genere una duplicacion de dos productos con el mismo codigo
            
            var productoConIgualCodigo = repositorioDeProductos.ObtenerPorCodigoDeProducto(producto.Codigo);
            if (productoConIgualCodigo.Any(p => p.Id != producto.Id))
            {
                throw new ArgumentException("No se puede modificar este producto porque ya existe otro con el mismo codigo");
            }
            

            return repositorioDeProductos.Actualizar(producto);
        }

        public bool Borrar(int id)
        {
            return repositorioDeProductos.Borrar(id);
        }

    }
}
