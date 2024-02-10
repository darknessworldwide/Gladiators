using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР8.Гладиаторы
{
    internal class Armor
    {
        internal string Name { get; }
        internal int Price { get; }
        internal double Protection { get; }

        internal Armor(string name, int price, double protection)
        {
            Name = name;
            Price = price;
            Protection = protection;
        }

        internal string Info()
        {
            return $"{Name}, множитель защиты = {Protection}. Цена: {Price} монет";
        }
    }
}
