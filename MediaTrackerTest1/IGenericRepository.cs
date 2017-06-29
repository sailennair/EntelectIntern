using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTrackerTest1
{
    public interface IGenericService<T>
    {

        IEnumerable<T> GetAll();

        void Create(T entity);

        void Update(T entity, int key);

        void Delete(int ID);

    }
}
