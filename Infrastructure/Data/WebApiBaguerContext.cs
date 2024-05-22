using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;
public class WebApiBaguerContext : DbContext
{
    public WebApiBaguerContext(DbContextOptions<WebApiBaguerContext> options) : base(options){
        
    }
}