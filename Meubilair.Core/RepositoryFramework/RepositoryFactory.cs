using System;
using System.Collections.Generic;
using System.Configuration;
using Meubilair.Core.RepositoryFramework;
using Meubilair.Core.DomainBase;
using Meubilair.Core.RepositoryFramework.Configuration;

namespace Meubilair.Core.RepositoryFramework
{
    public static class RepositoryFactory
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
            if (!RepositoryFactory.repositories.ContainsKey(interfaceShortName))
            {

                // Not there, so create it

                // Get the repositoryMappingsConfiguration config section
                RepositorySettings settings = (RepositorySettings)ConfigurationManager.GetSection(RepositoryMappingConstants.RepositoryMappingsConfigurationSectionName);

                Type repositoryType = RepositoryFactory.GetType(settings.RepositoryMappings[interfaceShortName].RepositoryFullTypeName);

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
                RepositoryFactory.repositories.Add(interfaceShortName, repository);

            }
            else
            {
                // The provider was in the cache, so retrieve it
                repository = (TRepository)RepositoryFactory.repositories[interfaceShortName];
            }
            return repository;

        }



        public static Type GetType(string typeName)
        {
            var type = Type.GetType(typeName);
            if (type != null) return type;
            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = a.GetType(typeName);
                if (type != null)
                    return type;
            }
            return null;
        }
    }
}
