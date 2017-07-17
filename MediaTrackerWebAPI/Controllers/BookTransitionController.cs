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
    [RoutePrefix("api/BookTransition")]
    public class BookTransitionController : ApiController
    {
        private readonly IBookTransitionInterface bookTransitionInterface;

        public BookTransitionController(IBookTransitionInterface bookTransitionInterface)
        {
            this.bookTransitionInterface = bookTransitionInterface;
        }

        [HttpGet]
        [Route("{userID}")]
        public IHttpActionResult GetUserID(int userID)
        {
            var list = bookTransitionInterface.GetUserBook(userID).Select(x => new BookTransitionDto { BookID = x.BookID, bookName = x.BookTable.BookName, UserID = x.UserID, isRead = x.Read });
            return Ok(list);
        }


    }
}
