﻿using Meubilair.Core;
using Meubilair.Core.DomainBase;
using Meubilair.Core.RepositoryFramework;
using Meubilair.Core.RepositoryFramework.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meubilair.Repositories.Customers
{
    public class CustomerFactoryTest
    {
        // Dictionary to enforce the singleton pattern
        private static Dictionary<string, object> repositories = new Dictionary<string, object>();

        public static TRepository GetRepository<TRepository, TEntity>(IUnitOfWork unitOfWork)
              where TRepository : class, IRepository<TEntity>
            where TEntity : EntityBase
        {
            TRepository repository = default(TRepository);
            string interfaceShortName = typeof(TRepository).Name;
            // See if the provider was already created and is in the cache
            if (!CustomerFactoryTest.repositories.ContainsKey(interfaceShortName))
            {

                // Not there, so create it




                Type repositoryType = RepositoryFactory.GetType("Meubilair.Repositories.Customers.CustomerRepository,Meubilair.Repositories,Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");

                // Get the type to be created


                // See if an IUnitOfWork needs to be injected to the repository's constructor
                object[] constructorArgs = null;

                // Check if an IUnitOfWork was passed in and if the repository 
                // type to be created derives from RepositoryBase<T>
                if (unitOfWork != null &&
                    repositoryType.IsSubclassOf(typeof(RepositoryBase<TEntity>)))
                {
                    constructorArgs = new object[] { unitOfWork };
                }

                // Create the repository, and cast it to the interface specified
                repository = Activator.CreateInstance(repositoryType, constructorArgs) as TRepository;

                // Add the new provider instance to the cache
                CustomerFactoryTest.repositories.Add(interfaceShortName, repository);

            }
            else
            {
                // The provider was in the cache, so retrieve it
                repository = (TRepository)CustomerFactoryTest.repositories[interfaceShortName];
            }
            return repository;

        }
    }


}
