using Microsoft.AspNetCore.Mvc;
using mission09_sr482.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission09_sr482.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private IBookRepository repo { get; set; }

        public TypesViewComponent(IBookRepository temp)
        {
            repo = temp;
        }
        //Load data
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["bookType"];

            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            return View(types);
        }
    }
}
