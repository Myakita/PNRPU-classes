using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ЛабораторнаяРабота12;
using ShipLibrary;

namespace Лабораторная_работа_13
{
    public class ShipCollectionNew<TKey, TValue> : ShipHashTable<TKey, TValue>
    {
        public string Name { get; set; }

        public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);

        public event CollectionHandler CollectionCountChanged;
        public event CollectionHandler CollectionReferenceChanged;

        public void Add(TKey key, TValue value)
        {
            base.Add(key, value);
            OnCollectionCountChanged(new CollectionHandlerEventArgs(Name, "Добавление", value));
        }

        public bool Remove(TKey key)
        {
            if (base.ContainsKey(key))
            {
                TValue removedShip = this[key];
                bool removed = base.Remove(key);
                if (removed)
                {
                    OnCollectionCountChanged(new CollectionHandlerEventArgs(Name, "Удаление", removedShip));
                }
                return removed;
            }
            return false;
        }

        public TValue this[TKey key]
        {
            get => base[key];
            set
            {
                if (base.ContainsKey(key))
                {
                    OnCollectionReferenceChanged(new CollectionHandlerEventArgs(Name, "Изменение ссылки", value));
                }
                base[key] = value;
            }
        }

        public virtual void OnCollectionCountChanged(CollectionHandlerEventArgs args)
        {
            CollectionCountChanged?.Invoke(this, args);
        }

        public virtual void OnCollectionReferenceChanged(CollectionHandlerEventArgs args)
        {
            CollectionReferenceChanged?.Invoke(this, args);
        }

        public class CollectionHandlerEventArgs : EventArgs
        {
            public string Name { get; }
            public string Action { get; }
            public object AffObject { get; }

            public CollectionHandlerEventArgs(string name, string action, object affobject)
            {
                Name = name;
                Action = action;
                AffObject = affobject;
            }

            public override string ToString()
            {
                return $"Коллекция:{Name}, Действие:{Action}, Что:{AffObject}";
            }

        }


        public class Journal
        {
            public List<string> log = new List<string>();

            public void CollectionCountChanged(object source, CollectionHandlerEventArgs ev)
            {
                log.Add(ev.ToString());
            }
            public void CollectionRefChanged(object source, CollectionHandlerEventArgs ev)
            {
                log.Add(ev.ToString());
            }

            public void PrintLog()
            {
                foreach (var item in log)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
