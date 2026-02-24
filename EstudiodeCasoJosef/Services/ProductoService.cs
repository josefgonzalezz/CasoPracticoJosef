using EstudiodeCasoJosef.Data;
using EstudiodeCasoJosef.Repositories;

namespace EstudiodeCasoJosef.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }

        public List<Producto> ObtenerTodos()
            => _repository.ObtenerTodos();

        public Producto? ObtenerDetalle(int id)
            => _repository.ObtenerPorId(id);

        public void Agregar(Producto producto)
            => _repository.Agregar(producto);

        public void Eliminar(int id)
            => _repository.Eliminar(id);
    }
}