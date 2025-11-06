using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    public class Book
    {
        public int Id { get; set; }                // map: books.id
        public string Title { get; set; }          // books.title
        public string Author { get; set; }         // books.author
        public string Genre { get; set; }          // books.genre
        public string ISBN { get; set; }           // books.isbn
        public int Quantity { get; set; }          // books.quantity
        public int PublishedYear { get; set; }     // books.published_year

    }
}
