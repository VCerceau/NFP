using Microsoft.EntityFrameworkCore;
using System;
using WpfApp2;

namespace WpfApp2
{
    public class DB : DbContext
    {
        public DbSet<Pass> Passes { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=myDatabase.db");
        }
    }
}