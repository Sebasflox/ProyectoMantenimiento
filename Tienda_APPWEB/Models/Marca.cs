using System.ComponentModel.DataAnnotations;

namespace Tienda_APPWEB.Models
{
    public class Marca
    {
        [Key]
        public int idMarca { get; set; }
        public string Descripcion { get; set; }
    }
}
