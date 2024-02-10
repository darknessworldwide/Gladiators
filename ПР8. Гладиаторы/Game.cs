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

        internal void ShowGladiators()
        {
            Console.WriteLine("Ваши гладиаторы:\n");
            for (int i = 0; i < gladiators.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {gladiators[i].Info()}\n");
            }    
        }

        internal void ShowBeasts()
        {
            Console.WriteLine("Звери:\n");
            for (int i = 0; i < beasts.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {beasts[i].Info()}\n");
            }
        }

        internal void HireGladiator(string name)
        {
            int hiringCost = 300;

            if (money < hiringCost)
            {
                Console.WriteLine("У вас недостаточно монет для найма гладиатора!");
                return;
            }

            money -= hiringCost;
            gladiators.Add(new Gladiator(name));
            Console.WriteLine($"Вы наняли гладиатора {name}!\n");
        }

        internal void HealGladiator(Gladiator gladiator)
        {
            int healingCost = 100;

            if (money < healingCost)
            {
                Console.WriteLine("У вас недостаточно денег для лечения гладиатора!");
                return;
            }

            money -= healingCost;
            gladiator.Health = 100;
            Console.WriteLine($"Гладиатор {gladiator.Name} восстановил свое здоровье\n");
        }

        internal void VisitTheStore()
        {
            Console.WriteLine($"Добро пожаловать в оружейную лавку! У вас {money} монет.");
            Console.WriteLine("1) Выбрать доспехи\n2) Выбрать оружие\n3) Покинуть оружейную лавку\n");

            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 3)
            {
                Console.WriteLine("Некорректный выбор! Введите номер опции (1, 2 или 3)");
                return;
            }

            switch (choice)
            {
                case 1:
                    store.ShowArmors();
                    if (!int.TryParse(Console.ReadLine(), out int armorOption) || armorOption < 1 || armorOption > store.Armors.Length)
                    {
                        Console.WriteLine("Некорректный выбор!");
                        break;
                    }
                    BuyArmor(gladiators[1], store.Armors[armorOption - 1]);
                    break;

                case 2:
                    store.ShowWeapons();
                    if (!int.TryParse(Console.ReadLine(), out int weaponOption) || weaponOption < 1 || weaponOption > store.Weapons.Length)
                    {
                        Console.WriteLine("Некорректный выбор!");
                        break;
                    }
                    BuyWeapon(gladiators[1], store.Weapons[weaponOption - 1]);
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
