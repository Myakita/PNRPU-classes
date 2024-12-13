using System;

namespace ShipLibrary
{
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
            return base.ToString() + $", Экипаж: {CrewSize}";
        }

        public Ship BaseShip => new Ship(Name, Displacement);
    }
}
