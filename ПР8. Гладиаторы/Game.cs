using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР8.Гладиаторы
{
    internal class Game
    {
        internal int Money { get; set; }
        internal int Glory { get; set; }
        Store store;
        internal List<Gladiator> MyGladiators { get; set; }
        internal List<Gladiator> HiredGladiators;
        internal List<Gladiator> Opponents;
        internal List<Beast> Beasts;

        internal Game()
        {
            Money = 100000;
            Glory = 0;
            store = new Store();
            MyGladiators = new List<Gladiator>()
            {
                new Gladiator("Григорий Дуболом")
            };

            HiredGladiators = new List<Gladiator>()
            {
                new Gladiator("Аурелиан Железный Клинок"),
                new Gladiator("Северус Кровавый Гром"),
                new Gladiator("Леонид Сокрушитель")
            };

            Opponents = new List<Gladiator>()
            {
                new Gladiator("Максимус Безжалостный"),
                new Gladiator("Валерий Череполом"),
                new Gladiator("Артемий Молотильщик")
            };

            Beasts = new List<Beast>()
            {
                new Beast("Волк", 20),
                new Beast("Лев", 25),
                new Beast("Тигр", 30),
                new Beast("Медведь", 35)
            };
        }

        internal void HireGladiator()
        {
            bool flag = true;
            do
            {
                Console.WriteLine($"Какого гладиатора нанять? У вас {Money} монет\n");
                ShowGladiators(HiredGladiators);

                int option = GetOption(HiredGladiators.Count);

                if (option == HiredGladiators.Count + 1)
                {
                    flag = false;
                    return;
                }

                int cost = 300;
                if (NotEnoughMoney(cost)) return;

                Money -= cost;
                MyGladiators.Add(HiredGladiators[option - 1]);
                Console.WriteLine($"Вы наняли гладиатора {HiredGladiators[option - 1].Name} за {cost} монет!\n");
                HiredGladiators.RemoveAt(option - 1);
            } while (flag);
        }

        internal void HealGladiator()
        {
            bool flag = true;
            do
            {
                Console.WriteLine($"Какого гладиатора нанять? У вас {Money} монет\n");
                ShowGladiators(HiredGladiators);

                int option = GetOption(MyGladiators.Count);

                if (option == MyGladiators.Count + 1)
                {
                    flag = false;
                    return;
                }

                int cost = 100;
                if (NotEnoughMoney(cost)) return;

                Money -= cost;
                MyGladiators[option - 1].Health = 100;
                Console.WriteLine($"Вы исцелили гладиатора {MyGladiators[option - 1].Name} за {cost} монет!\n");
            } while (flag);
        }

        internal void VisitTheStore()
        {
            bool flag = true;
            do
            {
                Console.WriteLine($"Добро пожаловать в оружейную лавку! У вас {Money} монет\n");
                Console.WriteLine("1) Выбрать доспехи\n2) Выбрать оружие\n3) Покинуть оружейную лавку\n");
                int gladiatorOption;

                switch (Console.ReadLine())
                {
                    case "1":
                        store.ShowArmors();

                        Console.WriteLine("Какому гладиатору купить?\n");
                        ShowGladiators(MyGladiators);

                        gladiatorOption = GetOption(MyGladiators.Count);
                        if (gladiatorOption == MyGladiators.Count + 1) break;

                        int armorOption = GetOption(store.Armors.Length);
                        if (armorOption == store.Armors.Length + 1) break;

                        BuyArmor(MyGladiators[gladiatorOption - 1], store.Armors[armorOption - 1]);
                        break;

                    case "2":
                        store.ShowWeapons();

                        Console.WriteLine("Какому гладиатору купить?\n");
                        ShowGladiators(MyGladiators);

                        gladiatorOption = GetOption(MyGladiators.Count);
                        if (gladiatorOption == MyGladiators.Count + 1) break;

                        int weaponOption = GetOption(store.Weapons.Length);
                        if (weaponOption == store.Weapons.Length + 1) break;

                        BuyWeapon(MyGladiators[gladiatorOption - 1], store.Weapons[weaponOption - 1]);
                        break;

                    case "3":
                        flag = false;
                        break;

                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте еще раз!\n");
                        break;
                }
            } while (flag);
        }

        internal void BuyArmor(Gladiator gladiator, Armor armor)
        {
            if (NotEnoughMoney(armor.Price)) return;

            Money -= armor.Price;
            gladiator.Armor = armor;
            Console.WriteLine($"Вы купили {armor.Name} для гладиатора {gladiator.Name} за {armor.Price} монет!\n");
        }

        internal void BuyWeapon(Gladiator gladiator, Weapon weapon)
        {
            if (NotEnoughMoney(weapon.Price)) return;

            Money -= weapon.Price;
            gladiator.Weapon = weapon;
            Console.WriteLine($"Вы купили {weapon.Name} для гладиатора {gladiator.Name} за {weapon.Price} монет!\n");
        }

        internal bool NotEnoughMoney(int cost)
        {
            if (Money < cost)
            {
                Console.WriteLine("У вас недостаточно монет!\n");
                return true;
            }
            return false;
        }

        internal int GetOption(int len)
        {
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out int option) || option < 1 || option > len + 1)
                {
                    Console.Write("Неверный выбор. Попробуйте снова: ");
                }
                else { return option; }
            }
        }
        internal void ShowGladiators(List<Gladiator> gladiators)
        {
            for (int i = 0; i < gladiators.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {gladiators[i].Info()}\n");
            }
            Console.WriteLine($"{gladiators.Count + 1}) Вернуться назад\n");
        }

        internal void ShowBeasts()
        {
            Console.WriteLine("Звери:");
            for (int i = 0; i < Beasts.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {Beasts[i].Info()}");
            }
            Console.WriteLine($"{Beasts.Count + 1}) Вернуться назад\n");
        }
    }
}
