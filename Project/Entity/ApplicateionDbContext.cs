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
    //public class G<T>
    //{
    //    public List<T> values { get; set; }
    //}

    public class Person
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Car car { get; set; }
        public List<Car> cars { get; set; }
        //public G<Car> cars { get; set; }
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

            modelBuilder.Entity<Person>().Property(p => p.cars).HasConversion(p => JsonConvert.SerializeObject(p), s => JsonConvert.DeserializeObject<List<Car>>(s));

            //modelBuilder.Entity<Person>().Property(p => p.cars).HasConversion(p => JsonConvert.SerializeObject(p), s =>JsonConvert.DeserializeObject<G<Car>>(s));

            modelBuilder.Entity<Person>().Property(p => p.car).HasMaxLength(128);
            modelBuilder.Entity<Person>().Property(p => p.car).IsRequired(false);
        }
        public DbSet<Person> People { get; set; }
    }


}
