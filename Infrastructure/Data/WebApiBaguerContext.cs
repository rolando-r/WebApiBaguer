using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;
public class WebApiBaguerContext : DbContext
{
    // Contexto añadido para la gestión con la DB
    public WebApiBaguerContext(DbContextOptions<WebApiBaguerContext> options) : base(options){
        
    }
}