using Meubilair.Core;
using Meubilair.Core.DomainBase;
using Meubilair.Core.RepositoryFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meubilair.Repositories
{
    public abstract class SqlCeEntityFrameWork<T> : RepositoryBase<T>
          where T : EntityBase
    {

        IEnumerable<List<T>> dataBase;
        IList<T> baseQuery;
        Func<T, bool> baseWhereClause;

        public SqlCeEntityFrameWork() : this(null)
        {

            this.dataBase = new List<List<T>>();
            this.baseQuery = this.GetBaseQuery();
            this.baseWhereClause = this.GetBaseWhereClause();
        }

        public abstract Func<T, bool> GetBaseWhereClause();


        public abstract IList<T> GetBaseQuery();


        public SqlCeEntityFrameWork(IUnitOfWork unit)
        {

        }
        public override IList<T> FindAll()
        {

            IList<T> builder = this.GetBaseQueryBuilder();
            return this.BuildEntityFromEntityFrameWork(builder);

        }

        private IList<T> BuildEntityFromEntityFrameWork(IList<T> builder)
        {
            return builder.ToList<T>();
        }

        private Func<T, bool> BuildBaseWhereClause(object key)
        {
            if (key == null)
            {
                return (T) => { return true; };
            }
            return (T) => { return T.Key.Equals(key); };
        }

        private IList<T> GetBaseQueryBuilder()
        {

            return this.baseQuery;
        }

        public override T FindBy(object key)
        {
            IList<T> builder = this.GetBaseQueryBuilder();
            builder.Where(this.BuildBaseWhereClause(key));

            return this.BuildEntityFromEntityFrameWork(builder).FirstOrDefault();
        }

        protected override void PersistDeletedItem(T item)
        {
            throw new NotImplementedException();
        }

        protected override void PersistNewItem(T item)
        {
            throw new NotImplementedException();
        }

        protected override void PersistUpdatedItem(T item)
        {
            throw new NotImplementedException();
        }



    }
}
