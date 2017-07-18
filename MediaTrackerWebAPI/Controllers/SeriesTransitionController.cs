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

        [HttpGet]
        [Route("{userID}")]
        public IHttpActionResult GetUserSeries(int userID)
        {
            var seriesList = seriesTransitionInterface.GetUserSeries(userID).Select(x => new SeriesTransitionDto { SeriesID = x.EpisodesTable.SeriesID, SeriesName = x.EpisodesTable.SeriesTable.SeriesName, Status = x.StatusTable.Status, StatusID = x.StatusID, UserID = x.UserID, EpisodeID = x.EpisodesID, Season = x.EpisodesTable.Season, SeriesPicture = x.EpisodesTable.SeriesTable.SeriesPicture });
            var test = seriesList.Select(x => x.SeriesID).Distinct();
            return Ok(seriesList);
        }

        [HttpGet]
        [Route("GetSeriesEpisodes/{seriesID}/{userID}")]
        public IHttpActionResult GetSeriesEpisodes(int seriesID, int userID)
        {
            var seriesEpisodes = seriesTransitionInterface.GetSeriesEpisodes(seriesID, userID).Select(x => new EpisodesDto { SeriesID = x.EpisodesTable.SeriesID, EpisodeID = x.EpisodesID, SeriesName = x.EpisodesTable.SeriesTable.SeriesName }).ToList();
            return Ok(seriesEpisodes);
        }

        [HttpGet]
        [Route("GetEpisodesWatched/{userID}/{seriesID}")]
        public IHttpActionResult GetSeriesEpisodesWatched(int userID, int seriesID)
        {
            var episodeswatched = seriesTransitionInterface.getEpisodesWatched(seriesID, userID).Select(x => new EpisodesDto { SeriesID = x.EpisodesTable.SeriesID, EpisodeID = x.EpisodesID, SeriesName = x.EpisodesTable.SeriesTable.SeriesName }).ToList();
            return Ok(episodeswatched);
        }

    }
}
