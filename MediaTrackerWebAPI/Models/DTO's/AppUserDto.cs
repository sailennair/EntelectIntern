using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaTrackerWebAPI.Models.DTO_s
{
    public class AppUserDto
    {

        public string username { get; set; }
        public int ID { get; set; }
        public string password { get; set; }
        public bool isDetailsCorrect { get; set; }
    }
}