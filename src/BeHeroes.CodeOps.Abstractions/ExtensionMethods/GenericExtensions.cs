using System.Text.Json;

namespace BeHeroes.CodeOps.Abstractions.ExtensionMethods
{
    public static class GenericExtensions
    {
        /// <summary>
        /// Creates a deep copy of the specified object using JSON serialization and deserialization.
        /// </summary>
        /// <typeparam name="T">The type of the object to copy.</typeparam>
        /// <param name="self">The object to copy.</param>
        /// <returns>A deep copy of the specified object.</returns>
        public static T DeepCopy<T>(this T self)
        {
            var serialized = JsonSerializer.Serialize(self);
            
            return JsonSerializer.Deserialize<T>(serialized) ?? throw new ArgumentNullException(nameof(serialized));
        }
    }
}
