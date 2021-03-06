﻿using Meubilair.Core.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meubilair.Core.RepositoryFramework
{
    public interface IRepository<T> where T : EntityBase
    {
        T FindBy(object key);
        void Add(T item);
        IList<T> FindAll();
        T this[object key] { get; set; }
        void Remove(T item);
    }
}
