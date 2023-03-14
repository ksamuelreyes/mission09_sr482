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
        public Basket Basket { get; set; }
        public string ReturnUrl { get; set; }
        public CartModel(IBookRepository temp, Basket b)
        {
            repo = temp;
            Basket = b;
        }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book p = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            Basket.AddItem(p, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove (int bookId, string returnUrl)
        {
            Basket.RemoveItem(Basket.Items.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage(new { ReturnUrl = returnUrl });

        }
    }
}