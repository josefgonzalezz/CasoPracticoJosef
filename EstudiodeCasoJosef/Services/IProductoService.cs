using EstudiodeCasoJosef.Data;

namespace EstudiodeCasoJosef.Services
{
    public interface IProductoService
    {
        List<Producto> ObtenerTodos();
        Producto? ObtenerDetalle(int id);
        void Agregar(Producto producto);
        void Eliminar(int id);
    }
}