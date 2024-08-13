using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tienda_APPWEB.Models
{
    public class Producto
    {
        [Key]
        public int idProducto { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public decimal Precio { get; set; }
        public int IdMarca { get; set; }
        public int IdTalla { get; set; }
        [NotMapped]
        public string? Marca_D {  get; set; }
        [NotMapped]
        public string ?Talla_D { get;set; }
    }
}
