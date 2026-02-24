using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstudiodeCasoJosef.Data
{
    public class DetalleFactura
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Producto))]
        public int ProductoId { get; set; }
        public Producto? Producto { get; set; }

        [Required]
        [ForeignKey(nameof(Factura))]
        public int FacturaId { get; set; }
        public Factura? Factura { get; set; }

        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }
    }
}