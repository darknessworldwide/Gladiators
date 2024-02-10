using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР8.Гладиаторы
{
    internal class Weapon
    {
        internal string Name { get; }
        internal int Price { get; }
        internal double Damage { get; }

        internal Weapon(string name, int price, double damage)
        {
            Name = name;
            Price = price;
            Damage = damage;
        }

        internal string Info()
        {
            return $"{Name}, урон = {Damage}. Цена: {Price} монет";
        }
    }
}
