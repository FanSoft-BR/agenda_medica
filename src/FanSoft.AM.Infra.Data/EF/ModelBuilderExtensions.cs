using FanSoft.AM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace FanSoft.AM.Infra.Data.EF
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Paciente>().HasData(
                new Paciente(1, "Raphael Akyu", "Nalin",new DateTime(1999,8,20),1),
                new Paciente(2, "Murilo", "Franco Nalin",new DateTime(2010,7,1),1),
                new Paciente(3, "Rebeca", "Souza Nalin",new DateTime(2008,8,18),2)
            );

            modelBuilder.Entity<Sexo>().HasData(
                new Sexo(1, "Masculino"),
                new Sexo(2, "Feminino")
            );

        }
    }
}
