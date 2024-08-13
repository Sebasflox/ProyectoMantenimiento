using System.ComponentModel.DataAnnotations;

namespace Tienda_APPWEB.Models
{
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }
        public string Contrasenia  { get; set; }
        public int Bloqueo { get; set; }
        public int TipoUsuario { get; set; }
    }
}
