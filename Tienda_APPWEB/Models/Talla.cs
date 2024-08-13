using System.ComponentModel.DataAnnotations;

namespace Tienda_APPWEB.Models
{
    public class Talla
    {
        [Key]
        public int idTalla {  get; set; }
        public int idTipo { get; set; }
        public string Descripcion { get; set; }
    }
}
