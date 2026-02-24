using EstudiodeCasoJosef.Data;


namespace EstudiodeCasoJosef.Services
{
    public interface IFacturaService
    {
        List<Factura> ObtenerTodas();
        Factura? ObtenerDetalle(int id);
        bool CrearFactura(Factura factura);

    }
}