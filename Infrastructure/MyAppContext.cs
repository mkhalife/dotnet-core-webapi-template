using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MyApp.Entities;

namespace MyApp.Infrastructure
{
    public class MyAppContext : DbContext
    {
        private IConfigurationRoot _config;

        public MyAppContext(IConfigurationRoot config, DbContextOptions<MyAppContext> options) : base(options)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (_config["Persistence"] == "SQL")
                optionsBuilder.UseSqlServer(_config["SQL:ConnectionString"]);
            else
                optionsBuilder.UseInMemoryDatabase("MyApp");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
