namespace BookShop
{
    using Data;
    using System.Linq;
    using System.Text;
    using System;
    using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
    using Castle.Core.Internal;
    using System.Runtime.CompilerServices;
    using BookShop.Models;
    using Microsoft.IdentityModel.Logging;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Collections.Specialized;
    using Microsoft.IdentityModel.Tokens;
    using System.Runtime.InteropServices;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {

                // --02.Age Restriction
                //string input = Console.ReadLine();
                //Console.WriteLine(GetBooksByAgeRestriction(db, input));

                // --03.Golden Books
                //Console.WriteLine(GetGoldenBooks(db));

                // --04. Books by Price
                //Console.WriteLine(GetBooksByPrice(db));

                // --05.Not Released In
                //int number = int.Parse(Console.ReadLine());
                //Console.WriteLine(GetBooksNotReleasedIn(db , number));      

                // --06.Book Titles by Category
                //string input = Console.ReadLine();
                //Console.WriteLine(GetBooksByCategory(db, input));


                // --07.Released Before Date
                //string input = Console.ReadLine();
                //Console.WriteLine(GetBooksReleasedBefore(db, input));

                // --08.Author Search

                //string input = Console.ReadLine();
                // Console.WriteLine(  GetAuthorNamesEndingIn(db,input));

                // --09.Book Search
                //Console.WriteLine(GetBookTitlesContaining(db,input));

                // --10.Book Search by Author
                //Console.WriteLine(GetBooksByAuthor(db,input));

                // --11.Count Books
                //int number = int.Parse(Console.ReadLine());
                //Console.WriteLine(CountBooks(db,number));

                // --12.Total Book Copies
                //Console.WriteLine(CountCopiesByAuthor(db));


                // --13.Profit by Category
                //Console.WriteLine(GetTotalProfitByCategory(db));

                // --14.Most Recent Books
                // Console.WriteLine(GetMostRecentBooks(db));

                // --15.Increase Prices
                // IncreasePrices(db);

                // --16.Remove Books
                Console.WriteLine(RemoveBooks(db));
            }


        }

        public static string GetBooksByAgeRestriction(BookShopContext db, string command)
        {
            StringBuilder sb = new StringBuilder();

            var books = db.Books.ToList()
                .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
                .Select(b => new
                {
                    b.Title
                }).OrderBy(b => b.Title);

            foreach (var b in books)
            {
                sb.AppendLine(b.Title);
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext db)
        {
            var sb = new StringBuilder();

            var goldenBooks = db.Books.ToList()
                .Where(b => b.EditionType.ToString() == "Gold" && b.Copies <= 5000)
                .Select(b => new
                {
                    b.Title,
                    b.BookId
                })
                .OrderBy(b => b.BookId)
                .ToList();

            foreach (var book in goldenBooks)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var booksByPrice = context.Books.ToList()
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price);

            foreach (var b in booksByPrice)
            {
                sb.AppendLine($"{b.Title} - ${b.Price:F2}");
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new StringBuilder();



            var notReleasedBooks = context.Books.ToList()
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,

                });

            foreach (var b in notReleasedBooks)
            {
                sb.AppendLine(b.Title);
            }
            return sb.ToString().TrimEnd();

        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            var bookList = new List<string>();
            foreach (var category in categories)
            {

                var currentBook = context.Books
                   .Where(b => b.BookCategories.Any(bc => bc.Category.Name.ToLower() == category.ToLower()))
                   .Select(b => new
                   {
                       b.Title
                   })
                   .ToList();


                foreach (var b in currentBook)
                {
                    bookList.Add(b.Title);
                }
            }

            StringBuilder sb = new StringBuilder();

            foreach (var b in bookList.OrderBy(b => b))
            {
                sb.AppendLine(b);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate < DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.CurrentCulture))
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price,
                    b.ReleaseDate
                })
                .OrderByDescending(b => b.ReleaseDate)
                .ToList();


            StringBuilder sb = new StringBuilder();
            foreach (var b in books)
            {
                sb.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:f2}");
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var author = context.Authors.ToList()
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new { name = a.FirstName + " " + a.LastName })
                .OrderBy(a => a.name)
;


            StringBuilder sb = new StringBuilder();

            foreach (var a in author)
            {
                sb.AppendLine(a.name);
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => new { b.Title })
                .OrderBy(b => b.Title)
                .ToList();


            StringBuilder sb = new StringBuilder();

            foreach (var b in books)
            {
                sb.AppendLine(b.Title);
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                .Where(a => a.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(a => new
                {
                    books = a.Books.Select(b => new { b.Title, b.BookId }),
                    a.FirstName,
                    a.LastName,

                }).ToList();


            foreach (var a in authors)
            {
                foreach (var b in a.books.OrderBy(b => b.BookId))
                {
                    sb.AppendLine($"{b.Title} ({a.FirstName} {a.LastName})");
                }
            }
            return sb.ToString().TrimEnd();
        }
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books.Where(b => b.Title.Length > lengthCheck)
                .ToList();


            return books.Count();

        }
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors.Select(a => new
            {
                countCopies = a.Books.Sum(b => b.Copies),
                a.FirstName,
                a.LastName
            })
                .OrderByDescending(c => c.countCopies).ToList();

            foreach (var a in authors)
            {
                sb.AppendLine($"{a.FirstName} {a.LastName} - {a.countCopies.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var booksByCategory = context.Categories.Select(c => new
            {
                c.Name,
                profit = c.CategoryBooks.Select(cb => cb.Book.Copies * cb.Book.Price).Sum()
            })
                .OrderByDescending(c => c.profit)
                .ThenBy(c => c.Name)
                .ToList();
            foreach (var bc in booksByCategory)
            {
                sb.AppendLine($"{bc.Name} ${bc.profit:F2}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Categories
                .Select(c => new
                {
                    c.Name,
                    top3Books = c.CategoryBooks
                    .OrderByDescending(cb => cb.Book.ReleaseDate)
                    .Select(cb => new
                    {
                        cb.Book.Title,
                        year = cb.Book.ReleaseDate.Value.Year
                    })
                  .Take(3)
                  .ToList()
                })
                .OrderBy(c => c.Name)
                .ToList();

            foreach (var b in books)
            {
                sb.AppendLine($"--{b.Name}");
                foreach (var bc in b.top3Books)
                {
                    sb.AppendLine($"{bc.Title} ({bc.year})");
                }
            }
            return sb.ToString().TrimEnd();
        }
        public static void IncreasePrices(BookShopContext context)
        {

            int date = 2010;
            var booksToIncrease = context.Books.Where(b => b.ReleaseDate.Value.Year < date).ToList();

            foreach (var b in booksToIncrease)
            {
                b.Price += 5;
            }
            context.SaveChanges();
        }
        public static int RemoveBooks(BookShopContext context)
        {
            int copiesCount = 4200;
            var booksToRemove = context.Books.Where(b => b.Copies < copiesCount);

            var result = booksToRemove.Count();

            context.Books.RemoveRange(booksToRemove);

            context.SaveChanges();

            return result;

        }
    }
}
