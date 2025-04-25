using ShipLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ЛабораторнаяРабота12;

namespace Лабораторная_работа_14
{
    public static class ShipHTExtension
    {
        public static IEnumerable<KeyValuePair<TKey, TValue>> SelectByCondition<TKey, TValue>(
            this ShipHashTable<TKey, TValue> collection, Func<KeyValuePair<TKey, TValue>, bool> predicate)
        {
            return collection.Where(predicate);
        }

        public static double AggregateData<TKey, TValue>(
            this ShipHashTable<TKey, TValue> collection, Func<KeyValuePair<TKey, TValue>, double> selector,
            Func<IEnumerable<double>, double> aggregator)
        {
            return aggregator(collection.Select(selector));
        }

        public static IEnumerable<KeyValuePair<TKey, TValue>> Sort<TKey, TValue, TSortKey>(
            this ShipHashTable<TKey, TValue> collection, Func<KeyValuePair<TKey, TValue>, TSortKey> keySelector,
            bool ascending = true)
        {
            return ascending ? collection.OrderBy(keySelector) : collection.OrderByDescending(keySelector);
        }

        public static Dictionary<TKeyGroup, List<KeyValuePair<TKey, TValue>>> GroupByProperty<TKey, TValue, TKeyGroup>(
            this ShipHashTable<TKey, TValue> collection, Func<KeyValuePair<TKey, TValue>, TKeyGroup> keySelector)
        {
            return collection.GroupBy(keySelector).ToDictionary(g => g.Key, g => g.ToList());
        }

        public static void PrintToConsole<TKey, TValue>(this ShipHashTable<TKey, TValue> collection)
        {
            Console.WriteLine("Содержимое ShipHashTable:");
            foreach (var pair in collection)
            {
                Console.WriteLine($"[{pair.Key}] -> {pair.Value}");
            }
        }

        public static IEnumerable<KeyValuePair<TKey, TValue>> SelectByCondition_LINQ<TKey, TValue>(
            this ShipHashTable<TKey, TValue> collection, Func<KeyValuePair<TKey, TValue>, bool> predicate)
        {
            Stopwatch sw = Stopwatch.StartNew();
            var result = from item in collection where predicate(item) select item;
            result.ToList();
            sw.Stop();
            Console.WriteLine($"LINQ-запрос выполнен за: {sw.ElapsedTicks} тиков");
            return result;
        }
        public static IEnumerable<KeyValuePair<TKey, TValue>> SelectByCondition_Extension<TKey, TValue>(
            this ShipHashTable<TKey, TValue> collection, Func<KeyValuePair<TKey, TValue>, bool> predicate)
        {
            Stopwatch sw = Stopwatch.StartNew();
            var result = collection.Where(predicate).ToList();
            sw.Stop();
            Console.WriteLine($"Метод расширения выполнен за: {sw.ElapsedTicks} тиков");
            return result;
        }

        public static IEnumerable<KeyValuePair<TKey, TValue>> SelectByCondition_Foreach<TKey, TValue>(
            this ShipHashTable<TKey, TValue> collection, Func<KeyValuePair<TKey, TValue>, bool> predicate)
        {
            Stopwatch sw = Stopwatch.StartNew();
            List<KeyValuePair<TKey, TValue>> result = new List<KeyValuePair<TKey, TValue>>();

            for(int i = 0; i < result.Count(); i++)
            {
                if (predicate(result[i]))
                {
                    result.Add(result[i]);
                }
            }

            sw.Stop();
            Console.WriteLine($"Цикл foreach выполнен за: {sw.ElapsedTicks} тиков");
            return result;
        }
    }
}
