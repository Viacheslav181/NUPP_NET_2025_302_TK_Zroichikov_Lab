using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Healthcare.Common
{
    public class CrudServiceAsync<T> : ICrudServiceAsync<T> where T : class
    {
        private readonly ConcurrentDictionary<Guid, T> _storage = new();
        private readonly Func<T, Guid> _keySelector;
        public string FilePath { get; }

        public CrudServiceAsync(string filePath, Func<T, Guid> keySelector)
        {
            FilePath = filePath;
            _keySelector = keySelector ?? throw new ArgumentNullException(nameof(keySelector));
        }

        public Task<bool> CreateAsync(T element)
        {
            var id = _keySelector(element);
            if (_storage.ContainsKey(id)) return Task.FromResult(false);
            return Task.FromResult(_storage.TryAdd(id, element));
        }

        public Task<T> ReadAsync(Guid id)
        {
            _storage.TryGetValue(id, out var item);
            return Task.FromResult(item);
        }

        public Task<IEnumerable<T>> ReadAllAsync()
        {
            return Task.FromResult(_storage.Values.AsEnumerable());
        }

        public Task<IEnumerable<T>> ReadAllAsync(int page, int amount)
        {
            return Task.FromResult(_storage.Values.Skip((page - 1) * amount).Take(amount));
        }

        public Task<bool> UpdateAsync(T element)
        {
            var id = _keySelector(element);
            if (!_storage.ContainsKey(id)) return Task.FromResult(false);
            _storage[id] = element;
            return Task.FromResult(true);
        }

        public Task<bool> RemoveAsync(T element)
        {
            var id = _keySelector(element);
            return Task.FromResult(_storage.TryRemove(id, out _));
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                var json = System.Text.Json.JsonSerializer.Serialize(_storage.Values);
                await File.WriteAllTextAsync(FilePath, json);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerator<T> GetEnumerator() => _storage.Values.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}