using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private static List<Book> BookList = new List<Book>()
        {
            new Book{
                BookId = 1,
                Title = "Learn",
                GenreId =2,
                PageCount=200,
                PublishDate= new DateTime(2001,06,05)
            },
             new Book{
                BookId = 2,
                Title = "Test",
                GenreId =1,
                PageCount=682,
                PublishDate= new DateTime(2003,06,05)
             }
        };
        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList = BookList.OrderBy(x => x.BookId).ToList();
            return bookList;
        }

        [HttpGet("id")]
        public Book GetBookById(int id)
        {
            var book = BookList.Where(x => x.BookId == id).SingleOrDefault();
            return book;
        }
        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook)
        {
            var book = BookList.SingleOrDefault(x => x.Title == newBook.Title);
            if (book is not null)
            {
                return BadRequest();
            }
            BookList.Add(newBook);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var book = BookList.SingleOrDefault(x => x.BookId == id);
            if (book is null)
            {
                return BadRequest();
            }
            book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;
            book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;
            book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate;
            book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;

            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id, [FromBody] Book deletedBook)
        {
            var book = BookList.SingleOrDefault(x => x.BookId == id);
            if (book is null)
            {
                return BadRequest();
            }
            BookList.Remove(book);
            return Ok();
        }
    }
}