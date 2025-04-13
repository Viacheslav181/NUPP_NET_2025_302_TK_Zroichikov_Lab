using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;



namespace Healthcare.Common
{
    public class CrudService<T> : ICrudService<T>
    {
        private readonly List<T> _items = new List<T>();

        public void Create(T item) => _items.Add(item);

        public T Read(Func<T, bool> predicate) => _items.FirstOrDefault(predicate);

        public IEnumerable<T> ReadAll() => _items;

        public void Update(Func<T, bool> predicate, Action<T> updateAction)
        {
            var item = _items.FirstOrDefault(predicate);
            if (item != null)
            {
                updateAction(item);
            }
        }

        public void Delete(Func<T, bool> predicate)
        {
            var item = _items.FirstOrDefault(predicate);
            if (item != null)
            {
                _items.Remove(item);
            }
        }

        public void Save(string filePath)
        {
            try
            {
                var json = JsonConvert.SerializeObject(_items, Formatting.Indented);
                File.WriteAllText(filePath, json);
                Console.WriteLine($"✅ Дані збережено у файл: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Помилка при збереженні: {ex.Message}");
            }
        }

        public void Load(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    var json = File.ReadAllText(filePath);
                    var loadedItems = JsonConvert.DeserializeObject<List<T>>(json);

                    if (loadedItems != null)
                    {
                        _items.Clear();
                        _items.AddRange(loadedItems);
                        Console.WriteLine($"✅ Дані завантажено з файлу: {filePath}");
                    }
                    else
                    {
                        Console.WriteLine("⚠️ Файл не містить дійсних даних.");
                    }
                }
                else
                {
                    Console.WriteLine($"⚠️ Файл не знайдено: {filePath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Помилка при завантаженні: {ex.Message}");
            }
        }
    }
}



