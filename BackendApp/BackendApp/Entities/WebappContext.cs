﻿using Microsoft.EntityFrameworkCore;

namespace BackendApp.Entities
{
    public class WebappContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("Database");

            optionsBuilder.UseSqlServer(connectionString, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });
            base.OnConfiguring(optionsBuilder);
        }


        public WebappContext(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<User> Users { get; set; }

    }
}
