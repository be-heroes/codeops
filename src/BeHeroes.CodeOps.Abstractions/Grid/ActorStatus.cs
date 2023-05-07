using BeHeroes.CodeOps.Abstractions.Entities;

namespace BeHeroes.CodeOps.Abstractions.Grid
{
    public class ActorStatus : EntityEnumeration
    {
        public static ActorStatus Available = new ActorStatus(1, nameof(Available).ToLowerInvariant());
        public static ActorStatus Unavailable = new ActorStatus(2, nameof(Unavailable).ToLowerInvariant());
        public static ActorStatus Unknown = new ActorStatus(4, nameof(Unknown).ToLowerInvariant());

        protected ActorStatus()
        {
        }

        public ActorStatus(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<ActorStatus> List() => new[] { Available, Unavailable, Unknown };

        public static ActorStatus FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new ArgumentException(nameof(state));
            }

            return state;
        }

        public static ActorStatus From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new ArgumentException(nameof(state));
            }

            return state;
        }
    }
}
