using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Project.Entity;

namespace Project.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet([FromServices] ApplicationDbContext db)
        {
            db.People.Add(new Person { firstName = "a", lastName = "b", car = new Car { name = "dada" } });
            db.SaveChanges();
        }
    }
}
