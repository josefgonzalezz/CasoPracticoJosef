using EstudiodeCasoJosef.Data;

namespace EstudiodeCasoJosef.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private static List<Producto> _productos = new()
        {
            new Producto { Id = 1, Nombre = "Laptop", Precio = 450000 },
            new Producto { Id = 2, Nombre = "Mouse", Precio = 8500 },
            new Producto { Id = 3, Nombre = "Teclado", Precio = 15000 }
        };

        private static int _contador = 4;

        public List<Producto> ObtenerTodos()
            => _productos;

        public Producto? ObtenerPorId(int id)
            => _productos.FirstOrDefault(p => p.Id == id);

        public void Agregar(Producto producto)
        {
            producto.Id = _contador++;
            _productos.Add(producto);
        }

        public void Eliminar(int id)
        {
            var producto = _productos.FirstOrDefault(p => p.Id == id);
            if (producto != null)
                _productos.Remove(producto);
        }
    }
}