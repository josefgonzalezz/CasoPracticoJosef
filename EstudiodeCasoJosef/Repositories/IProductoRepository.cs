using EstudiodeCasoJosef.Data;

namespace EstudiodeCasoJosef.Repositories
{
    public interface IProductoRepository
    {
        List<Producto> ObtenerTodos();
        Producto? ObtenerPorId(int id);
        void Agregar(Producto producto);
        void Eliminar(int id);
    }
}