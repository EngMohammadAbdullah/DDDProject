using Meubilair.Core.DomainBase;
using System.Data;


namespace Meubilair.Core.EntityFactoryFramework
{
    public interface IEntityFactory<T> where T : IEntity 
    {
        T BuildEntity(IDataReader reader);
    }
}
