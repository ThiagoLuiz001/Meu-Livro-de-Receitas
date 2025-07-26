using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Infraestructure.DataAcess
{
    public class MyRecipeBookDBContext : DbContext
    {
        public MyRecipeBookDBContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyRecipeBookDBContext).Assembly);
        }

    }
}
