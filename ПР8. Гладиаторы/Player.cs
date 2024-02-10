using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР8.Гладиаторы
{
    internal class Player
    {
        int money;
        int glory;

        internal Player()
        {
            money = 100;
            glory = 0;
        }

        internal void Heal(Gladiator gladiator)
        {
            gladiator.Health = 100;
            money -= 100;
            Console.WriteLine($"Гладиатор {gladiator.Name} восстановил свое здоровье.");
        }
    }
}
