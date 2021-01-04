using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLShorten
{
    public interface IRepository<T> : IDisposable where T : class
    {
        bool ExistsKey(String key);
        bool ExistsUrl(String url);
        T FindKey(String key);
        T FindUrl(String url);
        T Add(T url);
    }
}
