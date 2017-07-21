using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaTrackerWebAPI.Models.DTO_s
{
    public class BookTransitionDto
    {
        public int BookID { get; set; }
        public int UserID { get; set; }
        public bool isRead { get; set; }
        public string bookName { get; set; }
        public int BookStatusID { get; set; }
        public string BookIconRef { get; set; }

    }
}