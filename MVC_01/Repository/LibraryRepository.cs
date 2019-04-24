using Microsoft.EntityFrameworkCore;
using MVC_01.DbContexts;
using MVC_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_01.Repository
{
    public class LibraryRepository : ILibraryRepository<Book>
    {

        private readonly LibraryContext _dbContext;
        public LibraryRepository(LibraryContext context)
        {
            _dbContext = context;
        }
        public async Task Add(Book entity)
        {
            await _dbContext.Books.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Book book)
        {
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Book> Get(long id)
        {
            return await _dbContext.Books.FirstOrDefaultAsync(m => m.ID == id);
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task Update(Book book, Book entity)
        {
            book.ID = entity.ID;
            book.Title = entity.Title;
            book.Author = entity.Author;
            book.Year = entity.Year;

            await _dbContext.SaveChangesAsync();
        }
    }
}
