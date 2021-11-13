
using BackEndOTP.entity;
using Microsoft.EntityFrameworkCore;

namespace BackEndOTP.Data
{
    public class OTAPPContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          modelBuilder.Entity<Usuario>().HasIndex(u => new { u.email,u.cpf }).IsUnique(true);
           
        }
        public OTAPPContext(DbContextOptions<OTAPPContext> opts) :base (opts) { }

         public DbSet<Usuario> usuarios { get; set; }
         public DbSet<Consulta> consultas { get; set; } 
         public DbSet<Hospital> hospitals { get; set; }

    }
   
}
