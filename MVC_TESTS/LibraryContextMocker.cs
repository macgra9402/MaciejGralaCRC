using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MVC_01.DbContexts;
using MVC_01.Models;
using MVC_01.Repository;

namespace MVC_TESTS
{
    class LibraryContextMocker
    {
        public static ILibraryRepository<Book> GetInMemoryLibraryRepository(string dbName)
        {
            var options = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

           LibraryContext libraryContext = new LibraryContext(options);
            libraryContext.FillDatabase();

            return new LibraryRepository(libraryContext);
        }
    }
}
