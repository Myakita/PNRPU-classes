using ShipLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ЛабораторнаяРабота12
{
    public class ShipHashTable<TKey, TValue> : IDictionary<TKey, TValue>, ICloneable, IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private const int DefaultSize = 10;
        [JsonSerializable<>]private List<KeyValuePair<TKey, TValue>>[] buckets;
        [JsonConstructor]
        public ShipHashTable() : this(DefaultSize) { }
        [JsonConstructor]
        public ShipHashTable(int size = DefaultSize)
        {
            buckets = new List<KeyValuePair<TKey, TValue>>[size];
            for (int i = 0; i < size; i++)
            {
                buckets[i] = new List<KeyValuePair<TKey, TValue>>();
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                if (TryGetValue(key, out TValue value))
                    return value;
                Console.WriteLine($"Ошибка: Ключ '{key}' не найден.");
                return default;
            }
            set
            {
                int hash = GetHash(key);
                for (int i = 0; i < buckets[hash].Count; i++)
                {
                    if (buckets[hash][i].Key.Equals(key))
                    {
                        buckets[hash][i] = new KeyValuePair<TKey, TValue>(key, value);
                        return;
                    }
                }
                buckets[hash].Add(new KeyValuePair<TKey, TValue>(key, value));
            }
        }

        public void RandomGeneration(ShipHashTable<string, Ship> ht, int count)
        {
            Random rnd = new Random();
            for (int i = 0; i < count; i++)
            {
                Ship ship = new Ship("Корабль" + (i + 1), rnd.Next(1000, 10000));
                ht.Add(ship.Name, ship);
            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                List<TKey> keys = new List<TKey>();
                foreach (var bucket in buckets)
                {
                    foreach (var pair in bucket)
                    {
                        keys.Add(pair.Key);
                    }
                }
                return keys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                List<TValue> values = new List<TValue>();
                foreach (var bucket in buckets)
                {
                    foreach (var pair in bucket)
                    {
                        values.Add(pair.Value);
                    }
                }
                return values;
            }
        }

        public int Count => Values.Count;
        public bool IsReadOnly => false;

        public void Add(TKey key, TValue value)
        {
            int hash = GetHash(key);
            buckets[hash].Add(new KeyValuePair<TKey, TValue>(key, value));
        }

        public bool ContainsKey(TKey key)
        {
            int hash = GetHash(key);
            foreach (var pair in buckets[hash])
            {
                if (pair.Key.Equals(key)) return true;
            }
            return false;
        }

        public bool Remove(TKey key)
        {
            int hash = GetHash(key);
            var bucket = buckets[hash];
            for (int i = 0; i < bucket.Count; i++)
            {
                if (bucket[i].Key.Equals(key))
                {
                    bucket.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            int hash = GetHash(key);
            foreach (var pair in buckets[hash])
            {
                if (pair.Key.Equals(key))
                {
                    value = pair.Value;
                    return true;
                }
            }
            value = default;
            return false;
        }

        public void Add(KeyValuePair<TKey, TValue> item) => Add(item.Key, item.Value);

        public void Clear()
        {
            foreach (var bucket in buckets)
            {
                bucket.Clear();
            }
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            int hash = GetHash(item.Key);
            return buckets[hash].Contains(item);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException(nameof(arrayIndex));

            foreach (var bucket in buckets)
            {
                foreach (var pair in bucket)
                {
                    if (arrayIndex >= array.Length) return;
                    array[arrayIndex++] = pair;
                }
            }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            int hash = GetHash(item.Key);
            return buckets[hash].Remove(item);
        }

       

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var bucket in buckets)
            {
                foreach (var pair in bucket)
                {
                    yield return pair;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private int GetHash(TKey key)
        {
            if (key == null)
            {
                Console.WriteLine("Ошибка: Ключ не может быть null.");
                return 0;
            }
            int hash = key.GetHashCode() % buckets.Length;
            return hash < 0 ? hash + buckets.Length : hash;
        }

        public TValue Find(TKey key)
        {
            if (TryGetValue(key, out TValue value))
                return value;
            Console.WriteLine($"Ошибка: Ключ '{key}' не найден.");
            return default;
        }

        //public ShipHashTable<TKey, TValue> ShallowCopy()
        //{
        //    var copy = new ShipHashTable<TKey, TValue>(buckets.Length);
        //    foreach (var bucket in buckets)
        //    {
        //        foreach (var pair in bucket)
        //        {
        //            copy.Add(pair.Key, pair.Value);
        //        }
        //    }
        //    return copy;
        //}

        public object Clone()
        {
            var clone = new ShipHashTable<TKey, TValue>(buckets.Length);
            foreach (var bucket in buckets)
            {
                foreach (var pair in bucket)
                {
                    clone.Add(pair.Key, pair.Value);
                }
            }
            return clone;
        }

        public ShipHashTable<string, Ship> ShallowCopy() 
        {
            return (ShipHashTable<string, Ship>)this.MemberwiseClone();
        }

        public void Print()
        {
            for (int i = 0; i < buckets.Length; i++)
            {
                Console.WriteLine($"\nБакет {i}:");
                if (buckets[i].Count == 0)
                {
                    Console.WriteLine("  Пусто");
                }
                else
                {
                    foreach (var pair in buckets[i])
                    {
                        Console.WriteLine($"  Ключ: {pair.Key}, Значение: {pair.Value}");
                    }
                }
            }
        }
    }
}