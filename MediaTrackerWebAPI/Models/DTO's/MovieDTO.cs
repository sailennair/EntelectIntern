using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaTrackerWebAPI.Models.DTO_s
{
    public class MovieDto
    {
        public string MovieName { get; set; }

        public int MovieID { get; set; }
        public string MoviePicture { get; set; }
    }
}