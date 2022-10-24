using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Entitites;

namespace TaskManager.DataAccess
{

    public class TaskDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer($"Data Source={dbHost};Initial Catalog={dbName};User ID=SA;Password={dbPassword};");
        }

        public DbSet<Task> Tasks { get; set; }
    }
    
}
