using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using BeHeroes.CodeOps.Abstractions.Data;

using MediatR;

namespace BeHeroes.CodeOps.Infrastructure.EntityFramework
{
    public abstract class EntityContext : DbContext, IUnitOfWork
    {
        protected readonly IMediator? _mediator;
        protected readonly IDictionary<Type, IEnumerable<IView>>? _seedData;

        public IDbContextTransaction? GetCurrentTransaction { get; private set; }

        public Assembly ModelConfigurationAssembly { get; set; }

        protected EntityContext() : this(new DbContextOptions<EntityContext>()) { }

        protected EntityContext(DbContextOptions options, IMediator? mediator = default, IDictionary<Type, IEnumerable<IView>>? seedData = default) : base(options)
        {
            _mediator = mediator;
            _seedData = seedData;

            if (ModelConfigurationAssembly == null)
            {
                ModelConfigurationAssembly = Assembly.GetCallingAssembly();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (ModelConfigurationAssembly == null) return;

            var configurationTypes = ModelConfigurationAssembly.GetTypes().Where(t => t.GetInterface("IEntityTypeConfiguration`1") != null);

            if(!configurationTypes.Any()) return;

            foreach (var configurationType in configurationTypes)
            {
                if(configurationType == null)
                    continue;

                var configurationCtorArgs = new Dictionary<Type, object>();
                var entityType = configurationType.GetInterface("IEntityTypeConfiguration`1")?.GenericTypeArguments.SingleOrDefault();
                var viewData = _seedData?.SingleOrDefault(v => v.Key == entityType).Value;

                if (viewData != null)
                {
                    configurationCtorArgs.Add(viewData.GetType(), viewData);
                }

                var configurationCtor = configurationType.GetConstructor(BindingFlags.Public | BindingFlags.Instance, null, configurationCtorArgs.Keys.ToArray(), null);
                dynamic? entityConfiguration = configurationCtor?.Invoke(configurationCtorArgs.Values.ToArray());

                if (entityConfiguration == null)
                {
                    throw new EntityContextException($"Could not find configuration for entity: ${entityType} in model configuration assembly: ${ModelConfigurationAssembly}");
                }

                modelBuilder.ApplyConfiguration(entityConfiguration);
            }
        }

        public virtual async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers.
            if(_mediator != null)
                await _mediator.DispatchDomainEventsAsync(this);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed
            await base.SaveChangesAsync(cancellationToken);

            return true;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var recordsToValidate = ChangeTracker.Entries();

            foreach (var recordToValidate in recordsToValidate)
            {
                var entity = recordToValidate.Entity;
                var validationContext = new ValidationContext(entity);
                var results = new List<ValidationResult>();

                if (Validator.TryValidateObject(entity, validationContext, results, true)) continue;

                var messages = results.Select(r => r.ErrorMessage).ToList().Aggregate((message, nextMessage) => message + ", " + nextMessage);

                throw new EntityContextException($"Unable to save changes for {entity.GetType().FullName} due to error(s): {messages}");
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task BeginTransactionAsync()
        {
            GetCurrentTransaction ??= await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);
        }

        public virtual async Task CommitTransactionAsync()
        {
            try
            {
                await SaveEntitiesAsync();

                GetCurrentTransaction?.Commit();
            }
            catch
            {
                RollbackTransaction();

                throw;
            }
            finally
            {
                if (GetCurrentTransaction != null)
                {
                    GetCurrentTransaction.Dispose();

                    GetCurrentTransaction = null;
                }
            }
        }

        public virtual void RollbackTransaction()
        {
            try
            {
                GetCurrentTransaction?.Rollback();
            }
            finally
            {
                if (GetCurrentTransaction != null)
                {
                    GetCurrentTransaction.Dispose();

                    GetCurrentTransaction = null;
                }
            }
        }
    }
}
