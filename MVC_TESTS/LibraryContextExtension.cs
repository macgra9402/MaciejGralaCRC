using MVC_01.DbContexts;
using MVC_01.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_TESTS
{
    public static class LibraryContextExtension
    {
        public static void FillDatabase(this LibraryContext dbContext)
        {
            dbContext.Books.Add
           (
               new Book
               {
                   ID = 1,
                   Title = "Wiedzmin",
                   Author = "A.Sapkowski",
                   Year = Convert.ToDateTime("1993/02/30")
               }
           );
            dbContext.Books.Add
        (
            new Book
            {
                ID = 2,
                Title = "Wladca pierscieni",
                Author = "Tolkien",
                Year = Convert.ToDateTime("1953/07/29")
            }
        );
            dbContext.Books.Add
        (
            new Book
            {
                ID = 3,
                Title = "Ksiazka",
                Author = "A.Nowak",
                Year = Convert.ToDateTime("1999/12/10")
            }
        );
            dbContext.Books.Add
        (
            new Book
            {
                ID = 4,
                Title = "Ksiazka2",
                Author = "N.Kowalski",
                Year = Convert.ToDateTime("2003/05/11")
            }
        );
            dbContext.Books.Add
        (
            new Book
            {
                ID = 5,
                Title = "Ksiazka3",
                Author = "J.Doe",
                Year = Convert.ToDateTime("2012/12/12")
            }
        );
        }
    }
}
