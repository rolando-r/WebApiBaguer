using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        //Nombre de la tabla
        builder.ToTable("Usuario");

        // Valores de los atributos
        builder.Property(x => x.NombreUsuario)
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(x => x.Nombre)
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(x => x.Clave)
        .IsRequired()
        .HasMaxLength(100);

        // Relación con rol
        builder.HasOne(x => x.Rol)
        .WithOne()// Rol por usuario
        .HasForeignKey<Usuario>(x => x.RolId);
    }
}