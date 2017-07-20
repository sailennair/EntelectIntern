using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTrackerTest1
{
    public abstract class GenericService<T> : IGenericService<T> where T : Entity
    {
        public Model1 db { get; set; }

        public GenericService()
        {
            db = new Model1();
        }

        // T genericInput = new T();

        public virtual IEnumerable<T> GetAll()
        {
            return db.Set<T>().Where(x => x.isDeleted == false);
        }

        public virtual void Create(T genericInput)
        {
            db.Set<T>().Add(genericInput);
            db.SaveChanges();
        }

        public virtual void Update(T updated, int key)
        {
            T exisiting = db.Set<T>().Find(key);

            if (exisiting != null)
            {
                db.Entry(exisiting).CurrentValues.SetValues(updated);
                db.SaveChanges();
            }
        }

        public virtual void Delete(int key)
        {
            T deleteQ = db.Set<T>().Find(key);

            if (deleteQ != null)
            {
                deleteQ.isDeleted = true;
                db.SaveChanges();
            }
        }

        public virtual T GetByID(int key)
        {
            T findQ = db.Set<T>().Find(key);

            return findQ;
        }
    }
}
