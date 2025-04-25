using System;

namespace ShipLibrary
{
    public class ShipNameComparer : IComparer<Ship>
    {
        public int Compare(Ship ship1, Ship ship2)
        {
            if (ship1 == null || ship2 == null)
            {
                throw new ArgumentException("Объект не является 'кораблем'");
            }
            return string.Compare(ship1.Name, ship2.Name, StringComparison.Ordinal);
        }
    }
}
