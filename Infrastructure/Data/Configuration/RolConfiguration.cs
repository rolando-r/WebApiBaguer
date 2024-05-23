using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class RolConfiguration : IEntityTypeConfiguration<Rol>
{
    public void Configure(EntityTypeBuilder<Rol> builder)
    {
        //Nombre de la tabla
        builder.ToTable("Rol");

        // Valores de los atributos
        builder.Property(x => x.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(x => x.Descripcion)
        .IsRequired()
        .HasMaxLength(250);
    }
}