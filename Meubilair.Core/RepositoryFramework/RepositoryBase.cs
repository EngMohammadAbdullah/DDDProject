using Meubilair.Core.DomainBase;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Meubilair.Core.RepositoryFramework
{
    public abstract class RepositoryBase<T>
        : IRepository<T>, IUnitOfWorkRepository where T : EntityBase
    {
        private IUnitOfWork unitOfWork;

        protected RepositoryBase()
            : this(null)
        {
        }

        private string  connectionString = ConfigurationManager.
            ConnectionStrings["Meubilair"].ToString();
        public string ConnectionString {
            get {

                return this.connectionString;
            }
        }

        protected RepositoryBase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #region IRepository<T> Members

        public abstract T FindBy(object key);

        public abstract IList<T> FindAll();

        public void Add(T item)
        {
            if (this.unitOfWork != null)
            {
                this.unitOfWork.RegisterAdded(item, this);
            }
        }

        public void Remove(T item)
        {
            if (this.unitOfWork != null)
            {
                this.unitOfWork.RegisterRemoved(item, this);
            }
        }

        public T this[object key]
        {
            get
            {
                return this.FindBy(key);
            }
            set
            {
                if (this.FindBy(key) == null)
                {
                    this.Add(value);
                }
                else
                {
                    if (this.unitOfWork != null)
                    {
                        this.unitOfWork.RegisterChanged(value, this);
                    }
                }
            }
        }

        #endregion

        #region IUnitOfWorkRepository Members

        public virtual void PersistNewItem(EntityBase item)
        {
            this.PersistNewItem((T)item);
        }

        public virtual void PersistUpdatedItem(EntityBase item)
        {
            this.PersistUpdatedItem((T)item);
        }

        public virtual void PersistDeletedItem(EntityBase item)
        {
            this.PersistDeletedItem((T)item);
        }

        #endregion

        protected IUnitOfWork UnitOfWork
        {
            get { return this.unitOfWork; }
        }

        protected abstract void PersistNewItem(T item);
        protected abstract void PersistUpdatedItem(T item);
        protected abstract void PersistDeletedItem(T item);
    }
}
