using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string name { get; set; }
        public Image image { get; set; }
        public List<Image> images { get; set; } = new List<Image>();
    }

    public class Image
    {
        public string src { get; set; }
        public int size { get; set; }
    }

    public class CustomerOrderContext : DbContext
    {
        private readonly ILoggerFactory LoggerFactory;

        public CustomerOrderContext(
            DbContextOptions<CustomerOrderContext> options,
            ILoggerFactory loggerFactory
        )
            : base(options)
        {
            LoggerFactory = loggerFactory;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseLoggerFactory(LoggerFactory);
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Work!!
            //modelBuilder.Entity<Product>().OwnsOne(c => c.image);
            //modelBuilder.Entity<Product>().OwnsMany(c => c.images);

            // Not work!!
            modelBuilder.Entity<Product>().Property(c => c.image).HasConversion(c => JsonConvert.SerializeObject(c), s => JsonConvert.DeserializeObject<Image>(s));
            modelBuilder.Entity<Product>().Property(c => c.images).HasConversion(c => JsonConvert.SerializeObject(c), s => JsonConvert.DeserializeObject<List<Image>>(s));
        }
    }
}
