using Microsoft.EntityFrameworkCore;
using poc_apis_netcore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace poc_apis_netcore.Contexts
{
    public class AppDbContext: DbContext
    {
        public DbSet<Autor> Autores { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {

        }

    }
}
