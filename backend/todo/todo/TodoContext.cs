using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using todos.Models;

namespace todos
{
    public class TodoContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=Todo;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
                          //.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().HasData(
                new Todo()
                {
                    Id = 1,
                    Name = "Redecorate Bathroom"
                },
                new Todo()
                {
                    Id = 2,
                    Name = "Laser Project"
                });
        }
    }
}
