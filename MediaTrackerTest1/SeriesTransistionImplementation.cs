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

        public IEnumerable<SeriesTransitionTable> GetSeriesEpisodes(int SeriesID, int UserID)
        {
            var episodesList = db.SeriesTransitionTables.Where(x => x.UserID == UserID && x.EpisodesTable.SeriesID == SeriesID).ToList();
            return (episodesList);
        }

        public void UpdateStatus(int EpisodeID, int userID, int Status)
        {
            SeriesTransitionTable series = db.SeriesTransitionTables.Where(x => x.UserID == userID).Where(x => x.EpisodesID == EpisodeID).Single();
            series.StatusID = Status;
            db.SaveChanges();

        }

        public IEnumerable<SeriesTransitionTable> getEpisodesWatched(int SeriesID, int UserID)
        {
            var series = db.SeriesTransitionTables.Where(x => x.UserID == UserID && x.EpisodesTable.SeriesID == SeriesID && x.StatusID == 1).ToList();
            return (series);
        }


        //public void UpdateStatus(int MovieID, int userID, int Status)
        //{
        //    MovieTransitionTable movie = db.MovieTransitionTables.Where(x => x.UserID == userID).Where(x => x.MovieID == MovieID).Single();
        //    movie.StatusID = Status;
        //    db.SaveChanges();

        //}

    }
}
