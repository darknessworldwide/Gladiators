using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР8.Гладиаторы
{
    internal class Game
    {
        int money;
        int glory;
        Store store;
        List<Gladiator> gladiators;
        List<Beast> beasts;

        internal Game()
        {
            money = 100000;
            glory = 0;
            store = new Store();
            gladiators = new List<Gladiator>()
            {
                new Gladiator("Аурелиан Железный Клинок"),
                new Gladiator("Северус Кровавый Гром"),
                new Gladiator("Леонид Сокрушитель"),
                new Gladiator("Максимус Безжалостный"),
                new Gladiator("Валерий Череполом"),
                new Gladiator("Артемий Молотильщик")
            };

            beasts = new List<Beast>()
            {
                new Beast("Волк", 20),
                new Beast("Лев", 25),
                new Beast("Тигр", 30),
                new Beast("Медведь", 35)
            };
        }
        internal void ShowBeasts()
        {
            Console.WriteLine("Звери:\n");
            for (int i = 0; i < beasts.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {beasts[i].Info()}\n");
            }
        }

        internal void ShowGladiators()
        {
            Console.WriteLine("Ваши гладиаторы:\n");
            for (int i = 0; i < gladiators.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {gladiators[i].Info()}\n");
            }    
        }

        internal void HireGladiator(string name)
        {
            money -= 300;
            gladiators.Add(new Gladiator(name));
            Console.WriteLine($"Вы наняли гладиатора {name}!\n");
        }

        internal void HealGladiator(Gladiator gladiator)
        {
            money -= 100;
            gladiator.Health = 100;
            Console.WriteLine($"Гладиатор {gladiator.Name} восстановил свое здоровье\n");
        }

        internal void VisitTheStore()
        {
            int option;

            Console.WriteLine("Добро пожаловать в оружейную лавку!\n1) Выбрать доспехи\n2) Выбрать оружие\n3) Покинуть оружейную лавку\n");
            switch (Console.ReadLine())
            {
                case "1":
                    store.ShowArmors();
                    option = int.Parse(Console.ReadLine());
                    if (option > store.Armors.Length) break;
                    BuyArmor(gladiators[1], store.Armors[option - 1]);
                    break;

                case "2":
                    store.ShowWeapons();
                    option = int.Parse(Console.ReadLine());
                    if (option > store.Weapons.Length) break;
                    BuyWeapon(gladiators[1], store.Weapons[option - 1]);
                    break;

                default:
                    break;
            }
        }

        internal void BuyArmor(Gladiator gladiator, Armor armor)
        {
            if (money < armor.Price)
            {
                Console.WriteLine($"У вас недостаточно монет для покупки {armor.Name} для гладиатора {gladiator.Name}!\n");
                return;
            }

            money -= armor.Price;
            gladiator.Armor = armor;
            Console.WriteLine($"Вы купили {armor.Name} для гладиатора {gladiator.Name} за {armor.Price} монет!\n");
        }

        internal void BuyWeapon(Gladiator gladiator, Weapon weapon)
        {
            if (money < weapon.Price)
            {
                Console.WriteLine($"У вас недостаточно монет для покупки {weapon.Name} для гладиатора {gladiator.Name}!\n");
                return;
            }

            money -= weapon.Price;
            gladiator.Weapon = weapon;
            Console.WriteLine($"Вы купили {weapon.Name} для гладиатора {gladiator.Name} за {weapon.Price} монет!\n");
        }
    }
}
