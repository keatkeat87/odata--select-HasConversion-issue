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
        [EnableQuery]
        public ActionResult<Person> Get([FromServices] ApplicationDbContext db)
        {
            return Ok(db.People);
        }
    }
}
