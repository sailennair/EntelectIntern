using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaTrackerWebAPI.Models.DTO_s
{
    public class BookDto
    {

        public string bookName { get; set; }

        public int BookID { get; set; }
        public string BookIconRef { get; set; }

      //  public string BookStatus { get; set; }
    }
}