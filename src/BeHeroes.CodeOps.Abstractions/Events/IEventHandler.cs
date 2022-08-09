using MediatR;

namespace BeHeroes.CodeOps.Abstractions.Events
{
    public interface IEventHandler<in TEvent> : IEventHandler, INotificationHandler<TEvent> where TEvent : IEvent
    {

    }

    public interface IEventHandler
    {
    }
}
