using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tienda_APPWEB.Models
{
    public class FacturasxCobrar
    {
        [Key]
        public int idFacturasxCobrar {  get; set; }
        public int idCliente { get; set; }
        public decimal Total { get; set; }
        public bool Cancelada { get; set; }
        public bool Activo { get; set; }
        [NotMapped]
        public string? ClienteNombre { get; set; }
    }
}
