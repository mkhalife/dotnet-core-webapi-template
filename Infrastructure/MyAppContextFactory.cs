using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;

namespace MyApp.Infrastructure
{
    public class MyAppContextFactory : IDesignTimeDbContextFactory<MyAppContext>
    {
        private IConfigurationRoot _config;

        public MyAppContextFactory()
        {
            var basePath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(AppContext.BaseDirectory).FullName).FullName).FullName).FullName;

            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json");

            _config = builder.Build();
        }

        public MyAppContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyAppContext>();

            optionsBuilder.UseSqlServer(_config["SQL:ConnectionString"]);

            return new MyAppContext(_config, optionsBuilder.Options);
        }
    }
}