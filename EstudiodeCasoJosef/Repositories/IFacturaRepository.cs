using EstudiodeCasoJosef.Data;


namespace EstudiodeCasoJosef.Repositories
{
    public interface IFacturaRepository
    {
        List<Factura> ObtenerTodas();
        Factura? ObtenerPorId(int id);
        void Agregar(Factura factura);
    }
}