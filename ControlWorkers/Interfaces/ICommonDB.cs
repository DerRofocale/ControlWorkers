using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorkers.Interfaces
{
    public interface ICommonDB<T>
    {
        public T GetByID(Guid id);
        public List<T> GetAll();
        public bool Add(T model);
        public bool Update(T model);
        public bool Delete(T model);
    }
}
