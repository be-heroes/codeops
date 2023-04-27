using Microsoft.EntityFrameworkCore;

using BeHeroes.CodeOps.Abstractions.Entities;

using MediatR;

namespace BeHeroes.CodeOps.Infrastructure.EntityFramework
{
    internal static class MediatorExtension
    {
        public static async Task DispatchDomainEventsAsync<T>(this IMediator mediator, T ctx) where T : DbContext
        {
            var entitiesWithEvents = ctx.ChangeTracker
                .Entries<IEntity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any())
                .ToList();

            var unpublishedDomainEvents = entitiesWithEvents.SelectMany(x => x.Entity.DomainEvents ?? Array.Empty<Abstractions.Events.IDomainEvent>()).ToArray();

            entitiesWithEvents.ForEach(entity => entity.Entity.ClearDomainEvents());

            var tasks = unpublishedDomainEvents
                .Select(async (domainEvent) =>
                {
                    await mediator.Publish(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
