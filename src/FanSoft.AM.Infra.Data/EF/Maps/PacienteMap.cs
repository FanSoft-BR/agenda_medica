using FanSoft.AM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FanSoft.AM.Infra.Data.EF.Maps
{
    public class PacienteMap : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable(nameof(Paciente));
            builder.HasKey(pk => pk.Id);

            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Nome).IsRequired().HasColumnType("varchar(80)");
            builder.Property(c => c.Sobrenome).IsRequired().HasColumnType("varchar(80)");
            builder.Ignore(c => c.NomeCompleto);
            builder.Property(c => c.SexoId).IsRequired();
            builder.Property(c => c.Nascimento).IsRequired();

            builder.HasOne(c => c.Sexo).WithMany(c => c.Pacientes).HasForeignKey(fk => fk.SexoId);
        }
    }
}
