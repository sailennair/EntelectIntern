using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTrackerTest1
{
    public interface ISeriesInterface : IGenericService<SeriesTable>
    {
        IEnumerable<EpisodesTable> GetAllEpisodes(int ID);



    }
}
