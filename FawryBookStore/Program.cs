using Azure;
using FawryBookStore.Data;
using FawryBookStore.Models;
using FawryBookStore.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace FawryBookStore
{
    public class Program
    {
        static void Main(string[] args)
        {
            AppDbContext _context = new AppDbContext();
            var AllTypes = _context.types.ToList();

            while (true)
            {
                Console.WriteLine("Welcome to Online BookStore...\n");
                Console.WriteLine("please choose your Operation..");
                Console.WriteLine("1- Show Books...");
                Console.WriteLine("2- Add new Book...");
                Console.WriteLine("3- Return the OutDated Books...");
                Console.WriteLine("4- Return the Deleted OutDated Books...");
                Console.WriteLine("5- Buy a Book...");
                Console.Write("Answer: ");
                int.TryParse(Console.ReadLine(), out int operation);
                switch (operation)
                {
                    case 1:
                        Console.WriteLine("View All Books");
                        ShowAllBooks();
                        break;
                    case 2:
                        AddNewBook();
                        break;
                    case 3:
                        Console.WriteLine("Enter the Number of Last Wanted Year...");
                        Console.Write("Last Wanted Year: ");
                        int.TryParse(Console.ReadLine(), out int lastWantedYear);
                        var OutDatedBooks = GetOutDatedBooks(lastWantedYear);
                        foreach (var book in OutDatedBooks)
                        {
                            Console.WriteLine($"ISBN: {book.ISBN}, Title: {book.Title}, Year: {book.PublishedYear}, Price: {book.price}");
                        }
                        Console.WriteLine("1- continue and remove books... \n2- Back...");
                        Console.Write("Answer: ");
                        int.TryParse(Console.ReadLine(), out int choice);
                        if (choice == 1)
                        {
                            foreach (var book in OutDatedBooks)
                            {
                                DeleteBook(book);
                            }
                            Console.WriteLine("Outdated Books Removed Successfully!");
                        }
                        else
                        {
                            break;
                        }
                        break;
                    case 4:
                        var DeletedBooks = GetDeletedOutDatedBooks();
                        if (DeletedBooks.Count > 0)
                        {
                            Console.WriteLine("the Deleted OutDated Books :");
                            foreach (var book in DeletedBooks)
                            {
                                Console.WriteLine($"ISBN: {book.ISBN}, Title: {book.Title}, Year: {book.PublishedYear}, Price: {book.price}, Type: {book.Type.Name}");
                            }
                        }
                        else
                            Console.WriteLine("There is no Deleted Books");

                        break;
                    case 5:
                        Console.WriteLine("WHat Would You want to buy...");
                        ShowAllBooks();
                        Console.Write("Enter the ISBN of books you want to buy: ");
                        int.TryParse(Console.ReadLine(), out int isbn);
                        BuyBook(isbn);
                        break;
                    default:
                        Console.WriteLine("Invalid Operation");
                        break;
                }
            }

        }

        //Show All Books
        public static void ShowAllBooks()
        {
            AppDbContext _context = new AppDbContext();
            var books = _context.books.Include(x => x.Type).ToList();
            foreach (var b in books)
            {
                Console.WriteLine($"ISBN: {b.ISBN}, Title: {b.Title}, Year: {b.PublishedYear}, Qty: {b.Quantity}, Price: {b.price}, Type: {b.Type.Name}");
            }
        }


        //Add New Book
        public static void AddNewBook()
        {
            AppDbContext _context = new AppDbContext();
            var AllTypes = _context.types.ToList();
            Console.WriteLine("Add New Book");
            Console.Write("Enter Book Title: ");
            string title = Console.ReadLine();
            Console.Write("Enter Book Published Year: ");
            int.TryParse(Console.ReadLine(), out int publishedYear);
            Console.Write("Enter Quantity: ");
            int.TryParse(Console.ReadLine(), out int quantity);
            Console.Write("Enter Book Price: ");
            double.TryParse(Console.ReadLine(), out double price);
            Console.WriteLine("choose the number of Type:");
            foreach (var type in AllTypes)
            {
                Console.WriteLine($"{type.Id} - {type.Name}");
            }
            Console.WriteLine();
            Console.Write("Enter Book Type Id: ");
            int.TryParse(Console.ReadLine(), out int typeId);
            if (!string.IsNullOrEmpty(title) && publishedYear != 0 && price != 0 && typeId != 0 && quantity != 0)
            {
                var book = new Models.Book
                {
                    Title = title,
                    PublishedYear = publishedYear,
                    price = price,
                    Type_Id = typeId,
                    Quantity = quantity
                };
                _context.books.Add(book);
                _context.SaveChanges();
                Console.WriteLine("Book Added Successfully!");
            }
            else
                Console.WriteLine("Something Wrong Failed...");
        }

        //Return OutDated Books
        public static List<Book> GetOutDatedBooks(int LastWantedYear)
        {
            if (LastWantedYear <= 0)
                return null;

            AppDbContext _context = new AppDbContext();
            var books = _context.books.Where(b => b.PublishedYear < LastWantedYear).ToList();
            return books;
        }


        //Return Deleted OutDated Books
        public static List<Book> GetDeletedOutDatedBooks()
        {
            AppDbContext _context = new AppDbContext();
            var model = _context.books.Include(x => x.Type).IgnoreQueryFilters().Where(x => x.IsDeleted == true).ToList();
            return model;
        }


        //Buy Book Operation
        public static void BuyBook(int isbn)
        {
            if (isbn <= 0)
            {
                Console.WriteLine("Invalid ISBN");
                return;
            }
            AppDbContext _context = new AppDbContext();


            var book = _context.books.FirstOrDefault(x => x.ISBN == isbn);
            if (book == null)
            {
                Console.WriteLine("Book Not Found, try again");
                return;
            }

            ShowBookStatusMessage(isbn);

            Console.WriteLine("Do You want to continue....");
            Console.WriteLine("1- Yes \n2- No");
            Console.Write("Answer: ");
            int.TryParse(Console.ReadLine(), out int choice);

            if (choice != 1)
            {
                Console.WriteLine("Operation Cancelled.");
                return;
            }

            var response = GetResponse(isbn);

            Console.Write("Enter The Number of Money : ");
            double.TryParse(Console.ReadLine(), out double money);

            if (money == 0)
            {
                Console.WriteLine("Invalid Operation....");
                return;
            }

            if (book.Quantity.HasValue && book.Quantity.Value > 0)
            {
                if (money < book.price)
                {
                    Console.WriteLine($"You don't have enough money to buy the book {book.Title}. The price is {book.price}.");
                    return;
                }
                book.Quantity -= 1;
                _context.SaveChanges();
                Console.WriteLine(response != null ? response : "");
                Console.WriteLine($"You payed {book.price} and the remained = {money - book.price}");
                Console.WriteLine($"You have successfully bought the book: {book.Title}. Remaining Quantity: {book.Quantity}");
            }
            else
            {
                Console.WriteLine($"The book {book.Title} is out of stock.");
            }
        }


        //Show the Status Message of Book 
        public static void ShowBookStatusMessage(int BookId)
        {
            AppDbContext _context = new AppDbContext();
            var types = _context.types.ToList();
            var Book = _context.books.Find(BookId);

            if (types.Any(x => x.Id == Book.Type_Id))
            {
                var type = types.FirstOrDefault(x => x.Id == Book.Type_Id);
                Console.WriteLine($"The Book {Book.Title} of type {type.Name} , {type.Description}");
                Console.WriteLine("The Price = " + Book.price);
            }
        }

        public static string GetResponse(int BookId)
        {
            AppDbContext _context = new AppDbContext();
            var Book = _context.books.Find(BookId);
            var Messages = new Dictionary<int, string>();
            Messages.Add(1, $"Do you want Shipping this book ?");
            Messages.Add(2, $"Do you want Sending Book Via Email?");
            Messages.Add(3, $"This Book Can not be sold, just show");

            switch (Book.Type_Id)
            {
                case 1:
                    Console.WriteLine($"{Messages[Book.Type_Id]}");
                    Console.WriteLine("1- Yes \n2- No");
                    Console.Write("Answer: ");
                    int.TryParse(Console.ReadLine(), out int choice);
                    if (choice == 1)
                    {
                        Console.Write("Enter your Address: ");
                        string address = Console.ReadLine();
                        if (!string.IsNullOrEmpty(address))
                        {
                            ShippingService shippingService = new ShippingService();
                            var result = shippingService.ShippingBook(address);
                            if (result)
                                return $"The Book will be shipped to {address}";
                        }
                    }
                    else if (choice == 2)
                    {
                        return null;
                    }
                    break;
                case 2:
                    Console.WriteLine($"{Messages[Book.Type_Id]}");
                    Console.WriteLine("1- Yes \n2- No");
                    Console.Write("Answer: ");
                    int.TryParse(Console.ReadLine(), out int res);
                    if (res == 1)
                    {
                        Console.Write("Enter your Address: ");
                        string email = Console.ReadLine();
                        if (!string.IsNullOrEmpty(email))
                        {
                            MailService mailService = new MailService();
                            var result = mailService.SendEmail(email);
                            if (result)
                                return $"The Book will be Sended to {email}";
                        }
                    }
                    else if (res == 2)
                    {
                        return null;
                    }
                    break;
                case 3:
                    return null;
            }
            return null;

        }


        //Update Book
        public static void DeleteBook(Book Book)
        {
            AppDbContext _context = new AppDbContext();
            var book = _context.books.Find(Book.ISBN);
            if (book != null)
            {
                book.Title = Book.Title;
                book.PublishedYear = Book.PublishedYear;
                book.price = Book.price;
                book.Type_Id = Book.Type_Id;
                book.Quantity = Book.Quantity;
                book.IsDeleted = true;
                _context.SaveChanges();
                Console.WriteLine("Book Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("Book Not Found");
            }

        }
    }
}
