using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaTrackerWebAPI.Models.DTO_s
{
    public class EpisodesDto
    {
        public int EpisodeID { get; set; }
        public int SeriesID { get; set; }
        public string SeriesName { get; set; }
        
    }
}