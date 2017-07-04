using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTrackerTest1
{
    public class SeriesImplementation : GenericService<SeriesTable>, ISeriesInterface
    {

        public SeriesImplementation(IEpisodesInterface _episodeImplementation)
        {
            episodeImplementation = _episodeImplementation;
        }

        public IEpisodesInterface episodeImplementation { get; set; }

        public override void Delete(int seriesID)
        {

            var deleteQ = db.SeriesTables.SingleOrDefault(x => x.SeriesID == seriesID); //

            if (deleteQ != null)
            {
                deleteQ.isDeleted = true;

                deleteQ.EpisodesTables.ToList().ForEach(x => x.isDeleted = true);

                deleteQ.EpisodesTables.ToList()
                    .ForEach(x => episodeImplementation.Delete(x.EpisodesID));

                db.SaveChanges();

            }
        }

        public IEnumerable<EpisodesTable> GetAllEpisodes(int ID)
        {
            // EpisodesTable episodes = new EpisodesTable();

            return db.EpisodesTables.Where(x => x.SeriesID == ID).ToList();

         //   return episodes;

                        
        }
    }
}
