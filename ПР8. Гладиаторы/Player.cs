using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР8.Гладиаторы
{
    internal class Player
    {
        static int money;
        int glory;
        List<Gladiator> gladiators;

        internal Player()
        {
            money = 100;
            glory = 0;
            gladiators = new List<Gladiator>()
            {
                new Gladiator("Аурелиан Железный Клинок"),
                new Gladiator("Северус Кровавый Гром"),
                new Gladiator("Леонид Сокрушитель"),
                new Gladiator("Максимус Безжалостный"),
                new Gladiator("Валерий Череполом"),
                new Gladiator("Артемий Молотильщик")
            };
        }

        internal void HireGladiators(string name)
        {
            gladiators.Add(new Gladiator(name));
        }

        internal void Heal(Gladiator gladiator)
        {
            gladiator.Health = 100;
            money -= 100;
            Console.WriteLine($"Гладиатор {gladiator.Name} восстановил свое здоровье.");
        }

        internal void VisitStore(Store store, Gladiator gladiator)
        {
            store.Goods(gladiator);
        }

        internal static void BuyArmor(Gladiator gladiator, Armor armor)
        {
            if (money < armor.Price)
            {
                Console.WriteLine($"У вас недостаточно монет для покупки {armor.Name} для гладиатора {gladiator.Name}.");
                return;
            }

            money -= armor.Price;
            gladiator.Armor = armor;
            Console.WriteLine($"Вы купили {armor.Name} для гладиатора {gladiator.Name} за {armor.Price} монет.");
        }

        internal static void BuyWeapon(Gladiator gladiator, Weapon weapon)
        {
            if (money < weapon.Price)
            {
                Console.WriteLine($"У вас недостаточно монет для покупки {weapon.Name} для гладиатора {gladiator.Name}.");
                return;
            }

            money -= weapon.Price;
            gladiator.Weapon = weapon;
            Console.WriteLine($"Вы купили {weapon.Name} для гладиатора {gladiator.Name} за {weapon.Price} монет.");
        }
    }
}
