using System.ComponentModel.DataAnnotations;

namespace EstudiodeCasoJosef.Data
{
    public class Factura
    {
        [Key]
        public int Id { get; set; }
        public string NombreCliente { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        [Range(0, double.MaxValue, ErrorMessage = "El subtotal no puede ser menor a 0")]
        public decimal Subtotal { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El impuesto no puede ser menor a 0")]
        public decimal Impuesto { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El total no puede ser menor a 0")]
        public decimal Total { get; set; }

        public List<DetalleFactura> Detalles { get; set; } = new();
    }
}