using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mission09_sr482.Models;
using mission09_sr482.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace mission09_sr482.Controllers
{
    public class HomeController : Controller
    {

        private IBookRepository repo;
        public HomeController (IBookRepository temp)
        {
            repo = temp;
        }
        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 10;
            //Create BooksViewModel model
            var x = new BooksViewModel
            {
                //Load in books repo
                Books = repo.Books
                .OrderBy(p => p.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                //New PageInfo model
                PageInfo = new PageInfo
                {
                    TotalNumBooks = repo.Books.Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };
            //Pass this variable to the index
            return View(x);
        }

    }
}
