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
        internal List<Gladiator> MyGladiators { get; }
        List<Gladiator> hiredGladiators;
        List<Gladiator> opponents;
        List<Beast> beasts;

        internal Game()
        {
            money = 100000;
            glory = 0;
            store = new Store();
            MyGladiators = new List<Gladiator>()
            {
                new Gladiator("Григорий Дуболом")
            };

            hiredGladiators = new List<Gladiator>()
            {
                new Gladiator("Аурелиан Железный Клинок"),
                new Gladiator("Северус Кровавый Гром"),
                new Gladiator("Леонид Сокрушитель")
            };

            opponents = new List<Gladiator>()
            {
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
            for (int i = 0; i < beasts.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {beasts[i].Info()}");
            }
            Console.WriteLine();
        }

        internal void HireGladiator()
        {
            int cost = 300;

            Console.WriteLine($"Какого гладиатора нанять? У вас {money} монет\n");
            ShowGladiators(hiredGladiators);

            string input = Console.ReadLine();
            if (Error(input)) return;
            int option = int.Parse(input);

            if (option == hiredGladiators.Count + 1) return;

            if (NotEnoughMoney(cost)) return;

            money -= cost;
            MyGladiators.Add(hiredGladiators[option - 1]);
            hiredGladiators.RemoveAt(option - 1);
            Console.WriteLine($"Вы наняли гладиатора {hiredGladiators[option - 1].Name} за {cost} монет!\n");
        }

        internal void HealGladiator(Gladiator gladiator)
        {
            int cost = 100;

            if (NotEnoughMoney(cost)) return;

            money -= cost;
            gladiator.Health = 100;
            Console.WriteLine($"Вы исцелили гладиатора {gladiator.Name} за {cost} монет!\n");
        }

        internal void VisitTheStore()
        {
            Console.WriteLine($"Добро пожаловать в оружейную лавку! У вас {money} монет\n");
            Console.WriteLine("1) Выбрать доспехи\n2) Выбрать оружие\n3) Покинуть оружейную лавку\n");

            string input;
            int gladiatorOption;
            switch (Console.ReadLine())
            {
                case "1":
                    store.ShowArmors();

                    input = Console.ReadLine();
                    if (Error(input)) break;
                    int armorOption = int.Parse(input);   

                    if (armorOption == store.Armors.Length + 1) break;

                    Console.WriteLine("Какому гладиатору купить?\n");
                    ShowGladiators(MyGladiators);

                    input = Console.ReadLine();
                    if (Error(input)) break;
                    gladiatorOption = int.Parse(input);

                    if (gladiatorOption == MyGladiators.Count + 1) break;

                    BuyArmor(MyGladiators[gladiatorOption - 1], store.Armors[armorOption - 1]);
                    break;

                case "2":
                    store.ShowWeapons();

                    input = Console.ReadLine();
                    if (Error(input)) break;
                    int weaponOption = int.Parse(input);

                    Console.WriteLine("Какому гладиатору купить?\n");
                    ShowGladiators(MyGladiators);

                    input = Console.ReadLine();
                    if (Error(input)) break;
                    gladiatorOption = int.Parse(input);

                    if (gladiatorOption == MyGladiators.Count + 1) break;

                    BuyWeapon(MyGladiators[gladiatorOption - 1], store.Weapons[weaponOption - 1]);
                    break;

                case "3":
                    break;

                default:
                    Console.WriteLine("Такого выбора нет!\n");
                    break;
            }
        }

        internal void BuyArmor(Gladiator gladiator, Armor armor)
        {
            if (NotEnoughMoney(armor.Price)) return;

            money -= armor.Price;
            gladiator.Armor = armor;
            Console.WriteLine($"Вы купили {armor.Name} для гладиатора {gladiator.Name} за {armor.Price} монет!\n");
        }

        internal void BuyWeapon(Gladiator gladiator, Weapon weapon)
        {
            if (NotEnoughMoney(weapon.Price)) return;

            money -= weapon.Price;
            gladiator.Weapon = weapon;
            Console.WriteLine($"Вы купили {weapon.Name} для гладиатора {gladiator.Name} за {weapon.Price} монет!\n");
        }

        internal bool NotEnoughMoney(int cost)
        {
            if (money < cost)
            {
                Console.WriteLine("У вас недостаточно монет!\n");
                return true;
            }
            return false;
        }

        internal bool Error(string input)
        {
            if (!int.TryParse(input, out int option) || option < 1 || option > store.Armors.Length + 1)
            {
                Console.WriteLine("Такого выбора нет!\n");
                return true;
            }
            return false;
        }
    }
}
