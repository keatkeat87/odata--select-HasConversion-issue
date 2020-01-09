using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Entity;


namespace Project
{
    public class PeopleController : ODataController
    {
        #region DI
        public PeopleController(
            ApplicationDbContext applicationDbContext
        )
        {
            Db = applicationDbContext;
        }
        #endregion

        private readonly ApplicationDbContext Db;

        [EnableQuery]
        public IActionResult Get()
        {
            Db.People.Add(new Person
            {
                firstName = "a",
                lastName = "b",
                car = new Car { name = "dada" },
                //cars = new G<Car> { values = new List<Car> { new Car { name = "sdad" } } }
                cars = new List<Car> { new Car { name = "sdad" } }
            });
            Db.SaveChanges();
            return Ok(Db.People);
        }
    }
}
