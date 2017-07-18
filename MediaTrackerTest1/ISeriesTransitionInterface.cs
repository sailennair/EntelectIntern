using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTrackerTest1
{
  public  interface ISeriesTransitionInterface
    {

        IEnumerable<SeriesTransitionTable> GetUserSeries(int UserID);
        IEnumerable<SeriesTransitionTable> GetSeriesEpisodes(int SeriesID, int UserID);

        void UpdateStatus(int EpisodeID, int userID, int Status);
        IEnumerable<SeriesTransitionTable> getEpisodesWatched(int SeriesID, int UserID);



    }
}
