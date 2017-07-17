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
            var list = bookTransitionInterface.GetUserBook(userID).Select(x => new BookTransitionDto { BookID = x.BookID, bookName = x.BookTable.BookName, UserID = x.UserID, isRead = x.Read, BookStatusID = x.BookStatusTable.StatusID, BookIconRef = x.BookTable.BookIcon });
            return Ok(list);
        }

        [HttpGet]
        [Route("GetRead/{userID}")]
        public IHttpActionResult GetBooksRead(int userID)
        {
           var list = bookTransitionInterface.GetUserBook(userID).Select(x => new BookTransitionDto { BookID = x.BookID, bookName = x.BookTable.BookName, UserID = x.UserID, isRead = x.Read, BookStatusID = x.BookStatusTable.StatusID, BookIconRef=x.BookTable.BookIcon }).Where(x => x.BookStatusID == 2);
       //   var list2 = list.Select
            return Ok(list);
        }


        [HttpGet]
        [Route("GetUnRead/{userID}")]
        public IHttpActionResult GetBooksNotRead(int userID)
        {
            var list = bookTransitionInterface.GetUserBook(userID).Select(x => new BookTransitionDto { BookID = x.BookID, bookName = x.BookTable.BookName, UserID = x.UserID, isRead = x.Read, BookStatusID = x.BookStatusTable.StatusID, BookIconRef = x.BookTable.BookIcon }).Where(x => x.BookStatusID == 1);
           
            return Ok(list);
        }


        [HttpGet]
        [Route("GetBusyRead/{userID}")]
        public IHttpActionResult GetBooksBusyRead(int userID)
        {
            var list = bookTransitionInterface.GetUserBook(userID).Select(x => new BookTransitionDto { BookID = x.BookID, bookName = x.BookTable.BookName, UserID = x.UserID, isRead = x.Read, BookStatusID = x.BookStatusTable.StatusID, BookIconRef = x.BookTable.BookIcon }).Where(x => x.BookStatusID == 3);

            return Ok(list);
        }

        [HttpPut]
        [Route("UpdateStatusToRead/{BookID}/{userID}")]
        public IHttpActionResult UpdateStatusToRead(int BookID, int userID)
        {
            bookTransitionInterface.UpdatestatusToRead(BookID, userID);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateStatusToNotRead/{BookID}/{userID}")]
        public IHttpActionResult UpdateStatusToNotRead(int BookID, int userID)
        {
            bookTransitionInterface.UpdatestatusToHaveNotRead(BookID, userID);
            return Ok();
        }


        [HttpPut]
        [Route("UpdateStatusBusyReading/{BookID}/{userID}")]
        public IHttpActionResult UpdateStatusBusyReading(int BookID, int userID)
        {
            bookTransitionInterface.UpdatestatusToBusyReading(BookID, userID);
            return Ok();
        }

        [HttpPost]
        [Route("AddToUserDatabase/{BookID}/{userID}")]
        public IHttpActionResult Create(int BookID, int userID)
        {
            bookTransitionInterface.addNew(BookID, userID);
            return Ok();
        }

        [HttpGet]
        [Route("GetStatusID/{BookID}/{userID}")]
        public IHttpActionResult GetStatusID(int BookID, int userID)
        {
            var Status = bookTransitionInterface.GetUserBook(userID).Where(x => x.BookID == BookID).Single();
            var statusID = Status.StatusID;
            return Ok(statusID);
        
        }

        [HttpPut]
        [Route("UpdateStatus/{BookID}/{userID}/{Status}")]
        public IHttpActionResult UpdateStatus(int BookID, int userID, int Status)
        {
            bookTransitionInterface.UpdateStatus(BookID, userID, Status);
            return Ok();
        }


    }
}
