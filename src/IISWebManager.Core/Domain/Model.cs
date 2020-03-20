using System.Collections.Generic;
using System.Linq;

namespace IISWebManager.Core.Domain
{
    public abstract class Model
    {
        protected static bool ValueIsEmpty(string value)
            => string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);

        protected static bool ValueIsEmpty<T>(IEnumerable<T> value)
            => value is null || !value.Any();

        protected static bool AnyCollectionValueIsEmpty<T>(IEnumerable<T> value) where T : class 
            => value.Any(x => x is null);
        
        protected static bool ValueIsEmpty<T>(T value) where T : class 
            => value is null;
        
    }
}