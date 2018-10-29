using FanSoft.AM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FanSoft.AM.Infra.Data.EF.Maps
{
    public class SexoMap : IEntityTypeConfiguration<Sexo>
    {
        public void Configure(EntityTypeBuilder<Sexo> builder)
        {
            builder.ToTable(nameof(Sexo));
            builder.HasKey(pk => pk.Id);

            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Genero).IsRequired().HasColumnType("varchar(80)");
        }
    }
}
