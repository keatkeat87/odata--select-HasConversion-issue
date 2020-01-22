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

        public void OnGet([FromServices] CustomerOrderContext Db)
        {
            //Db.Products.Add(new Product
            //{
            //    name = "mk100",
            //    image = null,
            //    images = new List<Image> { new Image { src = "da", size = 5 }, new Image { src = "da", size = 5 } }
            //});
            //Db.Products.Add(new Product
            //{
            //    name = "mk200",
            //    image = new Image { src = "aa", size = 6 }
            //});
            //Db.SaveChanges();
        }
    }
}
