using System;

namespace ShipLibrary
{
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
            return base.ToString() + $", Мощность двигателя: {EnginePower} л.с.";
        }
    }
}
