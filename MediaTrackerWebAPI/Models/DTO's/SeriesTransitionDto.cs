using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaTrackerWebAPI.Models.DTO_s
{
    public class SeriesTransitionDto
    {
        public int SeriesID { get; set; }
        public string SeriesName { get; set; }
        public int UserID { get; set; }
        public int StatusID { get; set; }
        public string Status { get; set; }
        public int EpisodeID { get; set; }
        public int Season { get; set; }

    }
}