using System;
using System.Xml.Serialization;
using System.Text.Json.Serialization;

namespace ShipLibrary
{
    [Serializable]
    [XmlRoot("Corvette")]
    [JsonDerivedType(typeof(Corvette), "corvette")]
    public class Corvette : Ship
    {
        public int CrewSize { get; set; }

        public Corvette() : base() { CrewSize = 50; }
        public Corvette(string name, double displacement, int crewSize) : base(name, displacement)
        {
            CrewSize = crewSize;
        }

        public override void Init()
        {
            base.Init();
            CrewSize = CrewSize;
        }
       
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Количество членов экипажа: {CrewSize}");
        }

        public override void RandomInit()
        {
            base.RandomInit();
            var random = new Random();
            CrewSize = random.Next(10, 300);
        }

        public override string ToString()
        {
            return $"[Корвет] Название: {Name}, Водоизмещение: {Displacement} т., Экипаж: {CrewSize} чел.";
        }

        public Ship BaseShip => new Ship(Name, Displacement);

        public override void Write(System.IO.BinaryWriter writer)
        {
            base.Write(writer);
            writer.Write(CrewSize);
        }

        public override void Read(System.IO.BinaryReader reader)
        {
            base.Read(reader);
            CrewSize = reader.ReadInt32();
        }
    }
}
