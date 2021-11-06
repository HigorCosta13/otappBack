
using BackEndOTP.entity;
using Microsoft.EntityFrameworkCore;

namespace BackEndOTP.Data
{
    public class OTAPPContext : DbContext
    {
        public OTAPPContext(DbContextOptions<OTAPPContext> opts) :base (opts) { }

         public DbSet<Usuario> usuarios { get; set; }
         public DbSet<Consulta> consultas { get; set; } 
         public DbSet<Hospital> hospitals { get; set; }

    }
}
