using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission09_sr482.Models
{
    //Repository for Books
    public class EFBookRepository : IBookRepository
    {
        private BookstoreContext context { get; set;  }

        public EFBookRepository(BookstoreContext temp) => context = temp;
        public IQueryable<Book> Books => context.Books;
    }
}
