using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Common
{
    public interface ICrudService<T>
    {
        void Create(T item);
        T Read(Func<T, bool> predicate);
        IEnumerable<T> ReadAll();
        void Update(Func<T, bool> predicate, Action<T> updateAction);
        void Delete(Func<T, bool> predicate);
        void Save(string filePath);
        void Load(string filePath);
    }
}
