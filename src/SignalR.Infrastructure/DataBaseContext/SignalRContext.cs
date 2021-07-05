using Microsoft.EntityFrameworkCore;
using SignalR.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalR.Infrastructure.DataBaseContext
{
    public class SignalRContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SignalR;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<Group> Groups { get; set; }

    }
}
