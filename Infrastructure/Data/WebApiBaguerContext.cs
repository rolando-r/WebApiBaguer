using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;
public class WebApiBaguerContext : DbContext
{
    // Contexto añadido para la gestión con la DB
    public WebApiBaguerContext(DbContextOptions<WebApiBaguerContext> options) : base(options)
    {    
    }
    // Colección de entidades para la DB
    public DbSet<Usuario> Usuarios { get; set;}
    public DbSet<Rol> Roles { get; set; }
    
    // Función para aplicar las configuraciones
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}