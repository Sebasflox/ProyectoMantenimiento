using System.ComponentModel.DataAnnotations;

namespace Tienda_APPWEB.Models
{
    public class TipoTalla
    {
        [Key]
        public int idTipoTalla { get; set; }
        public string Descripcion { get; set; }


    }
}
