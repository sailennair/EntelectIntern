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
    [RoutePrefix("api/Movie")]
    public class MovieController : ApiController
    {
        private readonly IMovieService movieService;
        public MovieController(IMovieService movieService)
        {
            this.movieService = movieService;
        }



        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            return Ok(movieService.GetAll().Select(x => new MovieDto { MovieName = x.MovieName, MovieID = x.MovieID }));
        }

        [HttpGet]
        [Route("{ID}")]
        public IHttpActionResult GetByID(int ID)
        {
            MovieTable movie = movieService.GetByID(ID);

            if (movie != null)
            {
                return Ok(new MovieDto { MovieName = movie.MovieName, MovieID = movie.MovieID });
            }
            else
                return BadRequest();
        }

       
      
        [HttpPost]
        public IHttpActionResult Create(MovieTable movie)
        {
            movieService.Create(movie);
            return Ok();
        }


        [HttpDelete]
        [Route("{ID}")]
        public IHttpActionResult Delete(int ID)
        {
            movieService.Delete(ID);
            return Ok();
        }

        [HttpPut]
        [Route("{key}")]
        public IHttpActionResult Put(int key, [FromBody] MovieTable movie)
        {
            
            movieService.Update(movie, key);
            return Ok();
        }


    }
}
