using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_01.Models;
using MVC_01.Repository;

namespace MVC_01.Controllers
{
    [Route("api/library")]
    [ApiController]
    public class LibraryController : Controller
    {
        private readonly ILibraryRepository<Book> _libraryRepository;

        public LibraryController(ILibraryRepository<Book> libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }
        [HttpGet]
        public async Task <IActionResult> GetAll()
        {
            var library = await _libraryRepository.GetAll();
            return Ok(library);
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(long id)
        {
            var library = await _libraryRepository.Get(id);
            return Ok(library);
        }

        [HttpGet]
        public async Task<IActionResult> Post(Book book)
        {
            await _libraryRepository.Add(book);

            if (book == null)
            {
                return NotFound("No record with that ID");
            }

            return CreatedAtAction(nameof(Get), new { ID = book.ID }, book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Book book)
        {
            var bookUpdate = await _libraryRepository.Get(id);
            await _libraryRepository.Update(bookUpdate, book);

            if (book == null)
            {
                return NotFound("No record with that ID");
            }

            return NoContent();
        }

     
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id, Book book)
        {
            var bookDelete = await _libraryRepository.Get(id);
            await _libraryRepository.Delete(bookDelete);

            if (book == null)
            {
                return NotFound("No record with that ID");
            }

            return NoContent();
        }


    }
}