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
        List<Gladiator> gladiators;

        internal Player()
        {
            money = 100;
            glory = 0;
            gladiators = new List<Gladiator>()
            {
                new Gladiator("Ваныш1"),
                new Gladiator("Ваныш2"),
                new Gladiator("Ваныш3")
            };
        }

        internal void HireGladiators(int number)
        {
            for (int i = 0; i < number; i++) { gladiators.Add(new Gladiator("Григорий")); }
        }

        internal void Heal(Gladiator gladiator)
        {
            gladiator.Health = 100;
            money -= 100;
            Console.WriteLine($"Гладиатор {gladiator.Name} восстановил свое здоровье.");
        }
    }
}
