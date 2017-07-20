using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediaTrackerTest1;
using SimpleInjector;
using MediaTrackerWebAPI.Models.DTO_s;

namespace MediaTrackerWebAPI.Controllers
{

    [RoutePrefix("api/Book")]
    public class BookController : ApiController
    {

        private readonly IBookInterface bookService;
        public BookController(IBookInterface bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            return Ok(bookService.GetAll().Select(x => new BookDto { bookName = x.BookName, BookID = x.BookID, BookIconRef = x.BookIcon}));
        }

        [HttpGet]
        [Route("{ID}")]
        public IHttpActionResult GetByID(int ID)
        {
            BookTable book = bookService.GetByID(ID);
            if (book != null)
            {
                return Ok(new BookDto { bookName = book.BookName, BookID = book.BookID });
            }
            else
                return BadRequest();
        }

        [HttpPost]
        public IHttpActionResult Create(BookTable book)
        {
            bookService.Create(book);
            return Ok();
        }

        [HttpPut]
        [Route ("{key}")]
        public IHttpActionResult Update([FromBody] BookTable book, int key)
        {
            bookService.Update(book, key);
            return Ok();
        }

        [HttpDelete]
        [Route("{key}")]
        public IHttpActionResult Delete(int key)
        {
            bookService.Delete(key);
            return Ok();
        }

    }
}
