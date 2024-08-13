using System.ComponentModel.DataAnnotations;

namespace Tienda_APPWEB.Models
{
    public class Cliente
    {
        [Key]
        public int idCliente {  get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }



    }
}
