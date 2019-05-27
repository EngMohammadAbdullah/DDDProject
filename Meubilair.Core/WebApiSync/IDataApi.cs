using Meubilair.Core.DomainBase;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Meubilair.Core.WebApiSync
{
    public interface IDataApi<T> where T : EntityBase
    {

        T Get(object key);
        IList<T> GetAll();
        void Remove(object key);
        Task<EntityRequestStatus> Put(object key);
        Task<EntityRequestStatus> Post(T Item);

    }
}