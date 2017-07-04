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
    [RoutePrefix("api/Series")]
    public class SeriesController : ApiController
    {

        private readonly ISeriesInterface seriesServices;
    
        public SeriesController(ISeriesInterface seriesServices)
        {
            this.seriesServices = seriesServices;
        }


        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(seriesServices.GetAll().Select(x => new SeriesDto { seriesName = x.SeriesName, seriesID = x.SeriesID }));


        }



        [HttpGet]
        [Route("{ID}")]
        public IHttpActionResult GetByID(int ID)
        {
            SeriesTable series = new SeriesTable();

            if (series != null)
            {
                return Ok(new SeriesDto { seriesName = series.SeriesName, seriesID = series.SeriesID });
            }
            else
                return null;

        }


        [HttpPost]
        public IHttpActionResult Create(SeriesTable series)
        {
            seriesServices.Create(series);
            return Ok();
        }


        [HttpPut]
        [Route("{key}")]
        public IHttpActionResult Update([FromBody] SeriesTable series, int key)
        {
            seriesServices.Update(series, key);
            return Ok();
        }

        [HttpDelete]
        [Route("{key}")]
        public IHttpActionResult Delete(int key)
        {
            SeriesTable series = new SeriesTable();
            series = seriesServices.GetByID(key);
            if (series != null)
            {
                series.isDeleted = true;
                return Ok();
            }
            else
            {
                return null;
            }
        }


        [HttpGet]
        [Route("GetEpisodes/{key}")]

        public IHttpActionResult GetEpisodes(int key)
        {
            SeriesTable series = new SeriesTable();
            series = seriesServices.GetByID(key);
            var episodes = seriesServices.GetAllEpisodes(key);
            return Ok(episodes.Select(x => new EpisodeDto { SeriesName = series.SeriesName, EpisodeID = x.EpisodesID, Season = x.Season ,SeriesID = x.SeriesID}));
        }







    }
}
