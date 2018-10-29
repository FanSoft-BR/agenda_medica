using FanSoft.AM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FanSoft.AM.Infra.Data.EF
{
    public class AgendaMedicaDataContext : DbContext
    {
        private readonly IConfiguration _config;

        public AgendaMedicaDataContext(IConfiguration config)
        {
            _config = config;
            Database.EnsureCreated();
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Sexo> Sexos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder
                .UseSqlServer(
                    _config.GetConnectionString("AgendaMedicaConn"),
                    opts =>
                    {
                        //opts.CommandTimeout(1000);
                    }
                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Maps.PacienteMap());
            modelBuilder.ApplyConfiguration(new Maps.SexoMap());
            modelBuilder.Seed();
        }

    }
}
