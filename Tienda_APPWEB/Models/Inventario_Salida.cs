using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tienda_APPWEB.Models
{
    public class Inventario_Salida
    {
        [Key]
        public int idInventario_Salida { get; set; }
        public int idProducto { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public bool Activo { get; set; }
        [NotMapped]
        public string? NombreProducto { get; set; }
    }
}
