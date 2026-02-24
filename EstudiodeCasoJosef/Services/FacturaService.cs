using EstudiodeCasoJosef.Data;
using EstudiodeCasoJosef.Repositories;


namespace EstudiodeCasoJosef.Services
{
    public class FacturaService : IFacturaService
    {
        private readonly IFacturaRepository _repository;
        private const decimal IMPUESTO = 0.13m;

        public FacturaService(IFacturaRepository repository)
        {
            _repository = repository;
        }

        public List<Factura> ObtenerTodas()
            => _repository.ObtenerTodas();

        public Factura? ObtenerDetalle(int id)
            => _repository.ObtenerPorId(id);

        public bool CrearFactura(Factura factura)
        {
            if (string.IsNullOrWhiteSpace(factura.NombreCliente))
                return false;

            if (factura.Detalles == null || !factura.Detalles.Any())
                return false;

            foreach (var item in factura.Detalles)
            {
                if (item.Cantidad <= 0)
                    return false;
            }
            factura.Subtotal = factura.Detalles
                .Sum(d => d.Cantidad * d.PrecioUnitario);

            factura.Impuesto = factura.Subtotal * IMPUESTO;
            factura.Total = factura.Subtotal + factura.Impuesto;

            _repository.Agregar(factura);

            return true;
        }

    }
}