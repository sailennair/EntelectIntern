using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTrackerTest1
{
    public class SeriesTransitionImplementation : ISeriesTransitionInterface
    {

        public Model1 db { get; set; }

        public SeriesTransitionImplementation()
        {
            db = new Model1();
        }
        public IEnumerable<SeriesTransitionTable> GetUserSeries(int userID)
        {
            var seriesList = db.SeriesTransitionTables.Where(x => x.UserID == userID).ToList();
            return (seriesList);
        }


    }
}
