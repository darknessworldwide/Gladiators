using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР8.Гладиаторы
{
    internal class Beast
    {
        internal string Name { get; }
        internal double Health { get; set; }
        internal double Damage { get; }

        internal Beast(string name, double damage)
        {
            Name = name;
            Health = 100;
            Damage = damage;
        }
    }
}
