using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTrackerTest1
{
  public  interface IBookTransitionInterface
    {
        IEnumerable<BookTransitionTable> GetUserBook(int userID);

        void UpdatestatusToRead(int BookID, int userID);
        void UpdatestatusToBusyReading(int BookID, int userID);
        void UpdatestatusToHaveNotRead(int BookID, int userID);
        void addNew(int BookID, int userID);
        void UpdateStatus(int BookID, int userID, int Status);
        
    }
}
