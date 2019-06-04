using Microsoft.EntityFrameworkCore;
using poc_apis_netcore.Entities;
using System;

namespace Database
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
