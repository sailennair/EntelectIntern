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
    [RoutePrefix("api/SeriesTransition")]
    public class SeriesTransitionController : ApiController
    {
        private readonly ISeriesTransitionInterface seriesTransitionInterface;

        public SeriesTransitionController(ISeriesTransitionInterface seriesTransitionInterface)
        {
            this.seriesTransitionInterface = seriesTransitionInterface;
        }

        [Route ("{userID}")]
        public IHttpActionResult GetUserSeries(int userID)
        {
            var seriesList = seriesTransitionInterface.GetUserSeries(userID).Select(x => new SeriesTransitionDto { SeriesID = x.EpisodesTable.SeriesID, SeriesName = x.EpisodesTable.SeriesTable.SeriesName, Status = x.StatusTable.Status, StatusID = x.StatusID, UserID = x.UserID , EpisodeID = x.EpisodesID});
            return Ok(seriesList);
        }






    }
}
