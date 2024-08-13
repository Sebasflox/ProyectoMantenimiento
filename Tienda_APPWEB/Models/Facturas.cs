using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tienda_APPWEB.Models
{
    public class Facturas
    {
        [Key]
        public int idFactura { get; set; }
        public int idCliente { get; set; }
        public int idProducto { get; set; }
        public decimal Precio { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        public bool Activo { get; set; }
        [NotMapped]
        public string? NombreCliente { get; set; }
        [NotMapped]
        public string? NombreProducto { get; set; }
        [NotMapped]
        public string? Estado { get; set; }
    }
}
