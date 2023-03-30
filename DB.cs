using Microsoft.EntityFrameworkCore;
using System;
using NeverForgetPass;

namespace NeverForgetPass
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