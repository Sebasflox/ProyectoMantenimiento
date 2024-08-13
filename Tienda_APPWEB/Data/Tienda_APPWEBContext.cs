using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tienda_APPWEB.Data;
using Tienda_APPWEB.Models;

namespace Tienda_APPWEB.Data
{
    public class Tienda_APPWEBContext : DbContext
    {
        public Tienda_APPWEBContext(DbContextOptions<Tienda_APPWEBContext> contextOptions) : base(contextOptions) { }

        public DbSet<Tienda_APPWEB.Models.Cliente> Cliente { get; set; }
        public DbSet<Tienda_APPWEB.Models.Facturas> Facturas { get; set; } 
        public DbSet<Tienda_APPWEB.Models.FacturasxCobrar> FacturasxCobrar { get; set; } 
        public DbSet<Tienda_APPWEB.Models.Inventario_Entrada> Inventario_Entrada { get; set; } 
        public DbSet<Tienda_APPWEB.Models.Inventario_Salida> Inventario_Salida { get; set; } 
        public DbSet<Tienda_APPWEB.Models.Producto> Producto { get; set; }
        public DbSet<Tienda_APPWEB.Models.Usuario> Usuario { get; set; }
        public DbSet<Tienda_APPWEB.Models.Marca> Marca { get; set; }
        public DbSet<Tienda_APPWEB.Models.Talla> Talla { get; set; }
    }
}
