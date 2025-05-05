using NetDbMockApp.Interfaces;
using System.Collections.Concurrent;

namespace NetDbMockApp.Services
{
    internal class DataService : IDataService
    {
        // Stores type-safe collections of objects keyed by type name
        private readonly ConcurrentDictionary<string, Dictionary<string, object>> _store = new();

        public Task<T> GetDataAsync<T>(string id)
        {
            var key = typeof(T).FullName;
            if (this._store.TryGetValue(key, out var table) && table.TryGetValue(id, out var value))
            {
                return Task.FromResult((T)value);
            }
            return Task.FromResult(default(T));
        }

        public Task<IEnumerable<T>> GetAllDataAsync<T>()
        {
            var key = typeof(T).FullName;
            if (this._store.TryGetValue(key, out var table))
            {
                return Task.FromResult(table.Values.Cast<T>());
            }
            return Task.FromResult(Enumerable.Empty<T>());
        }

        public Task<bool> SaveDataAsync<T>(T data)
        {
            var key = typeof(T).FullName;
            var idProp = typeof(T).GetProperty("Id");
            if (idProp == null)
                throw new InvalidOperationException("Data object must have an 'Id' property.");

            var id = idProp.GetValue(data)?.ToString();
            if (string.IsNullOrEmpty(id))
                throw new InvalidOperationException("Id property cannot be null or empty.");

            var table = this._store.GetOrAdd(key, _ => new Dictionary<string, object>());
            table[id] = data;
            return Task.FromResult(true);
        }

        public Task<bool> DeleteDataAsync(string id)
        {
            // Since this is generic, we can't infer type from id alone.
            // In real usage, you'd provide the type or wrap it in a higher-level service.
            return Task.FromResult(false);
        }
    }
}