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
            return Ok(bookService.GetAll().Select(x => new BookDto { BookName = x.BookName, BookID = x.BookID }));
        }

        [HttpGet]
        [Route("{key}")]
        public IHttpActionResult GetByID(int ID)
        {
            BookTable book = bookService.GetByID(ID);
            if (book != null)
            {
                return Ok(new BookDto { BookName = book.BookName, BookID = book.BookID });
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














        //[HttpGet]
        //public IHttpActionResult GetByID(int ID)
        //{
        //    MovieTable movie = movieService.GetByID(ID);

        //    if (movie != null)
        //    {
        //        return Ok(new MovieDto { MovieName = movie.MovieName, MovieID = movie.MovieID });
        //    }
        //    else
        //        return BadRequest();
        //}



        //[HttpPost]
        //public IHttpActionResult Create(MovieTable movie)
        //{
        //    movieService.Create(movie);
        //    return Ok();
        //}


        //[HttpDelete]
        //[Route("{ID}")]
        //public IHttpActionResult Delete(int ID)
        //{
        //    movieService.Delete(ID);
        //    return Ok();
        //}

        //[HttpPut]
        //[Route("{key}")]
        //public IHttpActionResult Put(int key, [FromBody] MovieTable movie)
        //{

        //    movieService.Update(movie, key);
        //    return Ok();
        //}



    }
}
