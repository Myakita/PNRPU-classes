using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace ShipLibrary
{
    [Serializable]
    [JsonDerivedType(typeof(Ship), "ship")]
    [JsonDerivedType(typeof(Corvette), "corvette")]
    [JsonDerivedType(typeof(Steamship), "steamship")]
    [JsonDerivedType(typeof(Sailboat), "sailboat")]
    [XmlInclude(typeof(Corvette))]
    [XmlInclude(typeof(Steamship))]
    [XmlInclude(typeof(Sailboat))]
    public class Ship : IInit, ICloneable, IComparable<Ship>
    {
        private double displacement;
        public string Name { get; set; }
        public double Displacement 
        { 
            get => displacement;
            set 
            { 
                if (value <= 0)
                    throw new ArgumentException("Водоизмещение должно быть больше нуля.");
                displacement = value;
            }
        }

        public Ship() { Name = "Стандартный корабль"; Displacement = 1000; }
        public Ship(string name, double displacement) { Name = name; Displacement = displacement; }

        public virtual void Show()
        {
            Console.WriteLine($"корабль: {Name}, водоизмещение: {Displacement}");
        }

        public void Display()
        {
            Console.WriteLine($"Ship: {Name}, Displacement: {Displacement}");
        }

        public virtual void Init()
        {
            Name = "стандартный корабль";
            Displacement = 1000;
        }

        public virtual void RandomInit()
        {
            var random = new Random();
            Name = $"корабль_{random.Next(1, 100)}";
            Displacement = random.Next(500, 10000);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Ship other)
            {
                return Name == other.Name && Displacement == other.Displacement;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Displacement);
        }

        public virtual int CompareTo(Ship? obj)
        {
            if (obj == null) return 1;
            return Displacement.CompareTo(obj.Displacement);
        }

        public override string ToString()
        {
            return $"[Корабль] Название: {Name}, Водоизмещение: {Displacement} т.";
        }

        public virtual object Clone()
        {
            return new Ship(Name, Displacement);
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Ship ShallowCopy()
        {
            return (Ship)this.MemberwiseClone();
        }

        public virtual void Write(System.IO.BinaryWriter writer)
        {
            writer.Write(Name ?? "");
            writer.Write(Displacement);
        }

        public virtual void Read(System.IO.BinaryReader reader)
        {
            Name = reader.ReadString();
            Displacement = reader.ReadDouble();
        }
    }
}
