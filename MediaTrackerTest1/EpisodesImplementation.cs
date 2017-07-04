using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTrackerTest1
{
   public class EpisodesImplementation : GenericService<EpisodesTable>, IEpisodesInterface
    {

       

        public override void Delete(int episodeID)
        {
            var deleteQ = db.EpisodesTables.SingleOrDefault(x => x.EpisodesID == episodeID); 

            if (deleteQ != null)
            {
                deleteQ.isDeleted = true;
                deleteQ.SeriesTransitionTables.ToList().ForEach(x => x.isDeleted = true);
                db.SaveChanges();
            }


        }


    }


}

