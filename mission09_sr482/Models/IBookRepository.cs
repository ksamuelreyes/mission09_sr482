using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission09_sr482.Models
{
    public interface IBookRepository
    {
        //IQueryable object
        IQueryable<Book> Books { get; }
    }
}
