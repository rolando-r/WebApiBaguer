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
        builder.Property(x => x.Username)
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(x => x.Nombre)
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(x => x.Password)
        .IsRequired()
        .HasMaxLength(100);

        builder.HasIndex(e => e.Username).IsUnique();//Sirve para verificar que  el mismo usuario no este duplicado

               builder.HasMany(x => x.Roles)
                   .WithMany(x => x.Usuarios)
                   .UsingEntity<UsuarioRoles>(
                   
                   j => j
                   .HasOne(pt => pt.Rol)
                   .WithMany(t => t.UsuarioRoles)
                   .HasForeignKey(ut => ut.RolId),

                   j => j
                   .HasOne(et => et.Usuario)
                   .WithMany(et => et.UsuarioRoles)
                   .HasForeignKey(el => el.UsuarioId),


                    j =>
                    
                    {
                         j. HasKey(t => new {t.RolId,t.UsuarioId});
                    }
                          
                   );  
    }
}