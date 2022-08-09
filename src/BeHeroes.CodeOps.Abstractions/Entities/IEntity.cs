using BeHeroes.CodeOps.Abstractions.Data;
using BeHeroes.CodeOps.Abstractions.Events;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeHeroes.CodeOps.Abstractions.Entities
{
    public interface IEntity<TKey> : IEntity where TKey : struct
    {
        TKey Id { get; }

        bool IsTransient();
    }

    public interface IEntity : IView, IValidatableObject
    {
        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

        void AddDomainEvent(IDomainEvent @event);

        void RemoveDomainEvent(IDomainEvent @event);

        void ClearDomainEvents();
    }
}
