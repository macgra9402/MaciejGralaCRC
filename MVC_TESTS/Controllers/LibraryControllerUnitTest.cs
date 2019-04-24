using MVC_01.DbContexts;
using MVC_01.Controllers;
using MVC_01.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MVC_TESTS.Controllers
{
    public class LibraryControllerUnitTest
    {
        [Fact]
        public async Task get_all_books()
        {
            // Arrange 
            var repository = LibraryContextMocker.GetInMemoryLibraryRepository(nameof(get_all_books));
            var controller = new LibraryController(repository);
            // Act
            var response = await controller.GetAll() as ObjectResult;
            var books = response.Value as List<Book>;

            // Assert
            Assert.Equal(200, response.StatusCode);
            Assert.Equal(5, books.Count);
        }

        [Fact]
        public async Task get_book_with_existing_id()
        {
            // Arrange 
            var repository = LibraryContextMocker.GetInMemoryLibraryRepository(nameof(get_book_with_existing_id));
            var controller = new LibraryController(repository);
            var expectedValue = "Wiedzmin";
            // Act
            var response = await controller.Get(1) as ObjectResult;
            var book = response.Value as Book;
            // Assert
            Assert.Equal(200, response.StatusCode);
            Assert.Equal(expectedValue, book.Title);
        }

        [Fact]
        public async Task get_book_with_not_existing_id()
        {
            // Arrange
            var repository = LibraryContextMocker.GetInMemoryLibraryRepository(nameof(get_book_with_not_existing_id));
            var controller = new LibraryController(repository);
            var expectedMessage = "Record couldn't ve found";
            // Act
            var response = await controller.Get(10) as ObjectResult;
            var book = response.Value as Book;
            // Assert
            Assert.Equal(404, response.StatusCode);
            Assert.Equal(expectedMessage, response.Value);
        }
    }
}
