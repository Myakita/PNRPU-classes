using System;

namespace ShipLibrary
{
    public class Sailboat : Ship
    {
        public int SailArea { get; set; }

        public Ship BaseShip => new Ship(Name, Displacement);

        public Sailboat() : base() { SailArea = 50; }
        public Sailboat(string name, double displacement, int sailArea) : base(name, displacement)
        {
            SailArea = sailArea;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Площадь паруса: {SailArea} m²");
        }

        public override void Init()
        {
            base.Init();
            SailArea = SailArea;
        }

        public override void RandomInit()
        {
            base.RandomInit();
            var random = new Random();
            SailArea = random.Next(1, 200);
        }

        public override object Clone()
        {
            return new Sailboat(this.Name, this.Displacement, this.SailArea);
        }

        public override string ToString()
        {
            return base.ToString() + $", Площадь паруса: {SailArea} m²";
        }
    }
}
