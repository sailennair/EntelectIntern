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
            var list = movieTransitionInterface.GetUserMovie(userID).Where(x=>x.MovieTable.isDeleted==false).Select(x => new MovieTransitionDTO { MovieID = x.MovieID, statusID = x.StatusID, userID = x.UserID, MovieName = x.MovieTable.MovieName, Status = x.StatusTable.Status, MoviePicture = x.MovieTable.MoviePicture});
            return Ok(list);
        }



        [HttpPut]
        [Route("UpdateStatus/{MovieID}/{userID}/{Status}")]
        public IHttpActionResult UpdateStatus(int MovieID, int userID, int Status)
        {
            movieTransitionInterface.UpdateStatus(MovieID, userID, Status);
            return Ok();
        }


        [HttpPost]
        [Route("AddToUserDatabase/{MovieID}/{userID}")]
        public IHttpActionResult Create(int MovieID, int userID)
        {
            movieTransitionInterface.addNew(MovieID, userID);
            return Ok();
        }


        [HttpGet]
        [Route("GetWatched/{userID}")]
        public IHttpActionResult GetMoviesWatched(int userID)
        {
            var list = movieTransitionInterface.GetUserMovie(userID).Select(x => new MovieTransitionDTO { MovieID = x.MovieID, MovieName = x.MovieTable.MovieName, userID = x.UserID, MoviePicture = x.MovieTable.MoviePicture, statusID = x.StatusID, Status = x.StatusTable.Status }).Where(x => x.statusID == 1);
            return Ok(list);
        }


        [HttpGet]
        [Route("GetNotWatched/{userID}")]
        public IHttpActionResult GetMoviesNotWatched(int userID)
        {
            var list = movieTransitionInterface.GetUserMovie(userID).Select(x => new MovieTransitionDTO { MovieID = x.MovieID, MovieName = x.MovieTable.MovieName, userID = x.UserID, MoviePicture = x.MovieTable.MoviePicture, statusID = x.StatusID, Status = x.StatusTable.Status }).Where(x => x.statusID == 2);
            return Ok(list);
        }

    }
}
