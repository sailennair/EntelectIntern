using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaTrackerWebAPI.Models.DTO_s
{
    public class MovieTransitionDTO
    {
        public int movieID { get; set; }
        public int userID { get; set; }
        public int statusID { get; set; }
        public string MovieName { get; set; }
        public string Status { get; set; }
    }
}