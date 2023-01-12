using Microsoft.EntityFrameworkCore;
using TFinal.Models;

namespace TFinal.Context
{
    public class InmuebleContext : DbContext 
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Inmueble> Inmuebles { get; set; }
        public DbSet<Tipo_Inmueble> TiposInmuebles { get; set; }
        public DbSet<Forma_Pago> FormaPagos { get; set;}
        public DbSet<Condicion> Condiciones { get; set;}
        public InmuebleContext(DbContextOptions<InmuebleContext> options)
            : base(options)
        {

        }
    }
}
