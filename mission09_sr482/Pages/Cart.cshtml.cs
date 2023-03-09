using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using mission09_sr482.Infrastructure;
using mission09_sr482.Models;

namespace mission09_sr482.Pages
{
    //Model for Cart Page
    public class CartModel : PageModel
    {
        private IBookRepository repo { get; set; }
        public CartModel(IBookRepository temp)
        {
            repo = temp;
        }

        public Basket Basket { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Basket = HttpContext.Session.GetJson<Basket>("Basket") ?? new Basket();
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book p = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            Basket = HttpContext.Session.GetJson<Basket>("Basket") ?? new Basket();
            Basket.AddItem(p, 1);

            HttpContext.Session.SetJson("Basket", Basket);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}