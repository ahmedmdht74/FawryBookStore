using FawryBookStore.Data;
using FawryBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryBookStore.UnitTest
{
    public class TestCases
    {
        AppDbContext _context = new AppDbContext();


        public void AddProduct()
        {
            // Arrange

            string title = "Sample Book";
            int publishedYear = 2023;
            double price = 19.99;
            int typeId = 1; 
            int quantity = 10;

            var Book = new Book
            {
                Title = title,
                IsDeleted = false,
                price = price,
                PublishedYear = publishedYear,
                Quantity = quantity,
                Type_Id = typeId,
            };
            _context.books.Add(Book);
            _context.SaveChanges();

        }


        public void DeleteProduct(int BookId) 
        {
            if(BookId <= 0)
            {
                Console.WriteLine("Invalid Book ID");
                return;
            }

            var book = _context.books.FirstOrDefault(b => b.ISBN == BookId);
            if (book == null)
            {
                Console.WriteLine("Book not found");
                return;
            }

            book.IsDeleted = true;
            _context.books.Update(book);
            _context.SaveChanges();
        }

    }
}
