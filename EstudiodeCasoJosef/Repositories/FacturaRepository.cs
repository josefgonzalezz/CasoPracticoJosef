using EstudiodeCasoJosef.Data;


namespace EstudiodeCasoJosef.Repositories
{
    public class FacturaRepository : IFacturaRepository
    {
        private static List<Factura> _facturas = new();
        private static int _contadorId = 1;

        public List<Factura> ObtenerTodas()
            => _facturas
                .OrderByDescending(f => f.Fecha)
                .ToList();

        public Factura? ObtenerPorId(int id)
            => _facturas.FirstOrDefault(f => f.Id == id);

        public void Agregar(Factura factura)
        {
            factura.Id = _contadorId++;
            _facturas.Add(factura);
        }
    }
}