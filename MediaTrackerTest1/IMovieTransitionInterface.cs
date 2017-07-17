using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTrackerTest1
{
  public  interface IMovieTransitionInterface
    {

        IEnumerable<MovieTransitionTable> GetUserMovie(int userID);


    }
}
