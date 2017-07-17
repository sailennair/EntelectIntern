using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTrackerTest1
{
 public   interface IBookInterface : IGenericService<BookTable>
    {
        string GetBookIcon(int UserID);

    }
}
