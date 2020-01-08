using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Entity
{
    public class Car
    {
        public string name { get; set; }
    }

    public class Person
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Car car { get; set; }
    }
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
           DbContextOptions<ApplicationDbContext> options
       ) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().Property(p => p.car).HasConversion(p => JsonConvert.SerializeObject(p), s => JsonConvert.DeserializeObject<Car>(s));
            modelBuilder.Entity<Person>().Property(p => p.car).HasMaxLength(128);
            modelBuilder.Entity<Person>().Property(p => p.car).IsRequired(true);
        }
        public DbSet<Person> People { get; set; }
    }


}
