using System;
using System.Xml.Serialization;
using System.Text.Json.Serialization;

namespace ShipLibrary
{
    [Serializable]
    [XmlRoot("Steamship")]
    [JsonDerivedType(typeof(Steamship), "steamship")]
    public class Steamship : Ship
    {
        public int EnginePower { get; set; }

        public Steamship() : base() { EnginePower = 500; }
        public Steamship(string name, double displacement, int enginePower) : base(name, displacement)
        {
            EnginePower = enginePower;
        }
        public Ship BaseShip => new Ship(Name, Displacement);
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Мощность двигателя: {EnginePower} л.с.");
        }
        public override void Init()
        {
            base.Init();
            EnginePower = EnginePower;
        }

        public override void RandomInit()
        {
            base.RandomInit();
            var random = new Random();
            EnginePower = random.Next(100, 2000);
        }
        public override object Clone()
        {
            return new Steamship(Name, Displacement, EnginePower);
        }

        public override string ToString()
        {
            return $"[Пароход] Название: {Name}, Водоизмещение: {Displacement} т., Мощность двигателя: {EnginePower} л.с.";
        }

        public override void Write(System.IO.BinaryWriter writer)
        {
            base.Write(writer);
            writer.Write(EnginePower);
        }

        public override void Read(System.IO.BinaryReader reader)
        {
            base.Read(reader);
            EnginePower = reader.ReadInt32();
        }
    }
}
