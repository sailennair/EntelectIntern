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
    [RoutePrefix("api/MovieTransition")]
    public class MovieTransitionController : ApiController
    {

        private readonly IMovieTransitionInterface movieTransitionInterface;

        public MovieTransitionController(IMovieTransitionInterface movieTransitionInterface)
        {
            this.movieTransitionInterface = movieTransitionInterface;
        }


        [HttpGet]
        [Route("{userID}")]
        public IHttpActionResult GetUserMovie(int userID)
        {
            var list = movieTransitionInterface.GetUserMovie(userID).Select(x => new MovieTransitionDTO { movieID = x.MovieID, statusID = x.StatusID, userID = x.UserID, MovieName = x.MovieTable.MovieName, Status = x.StatusTable.Status });
            return Ok(list);
        }


    }
}
