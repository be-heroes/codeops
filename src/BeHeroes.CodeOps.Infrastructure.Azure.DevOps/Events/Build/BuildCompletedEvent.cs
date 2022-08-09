namespace BeHeroes.CodeOps.Infrastructure.Azure.DevOps.Events.Build
{
    public sealed class BuildCompletedEvent : AdoEvent
    {
        public const string EventIdentifier = "build.complete";
    }
}
