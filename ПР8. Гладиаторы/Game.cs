using System;
using System.Collections.Generic;

namespace ПР8.Гладиаторы
{
    class Game
    {
        internal int Money { get; set; }
        internal int Glory { get; set; }
        internal List<Gladiator> MyGladiators { get; set; }
        Gladiator[] hiredGladiators;
        Store store;

        internal Game()
        {
            Money = 100000;
            Glory = 0;
            store = new Store();

            MyGladiators = new List<Gladiator>()
            {
                new Gladiator("Григорий Дуболом")
            };

            hiredGladiators = new Gladiator[]
            {
                new Gladiator("Аурелиан Железный Клинок"),
                new Gladiator("Северус Кровавый Гром"),
                new Gladiator("Леонид Сокрушитель")
            };
        }

        internal void HireGladiators()
        {
            while (true)
            {
                Console.WriteLine($"Какого гладиатора нанять?\n");
                ShowHiredGladiators();

                int option = GetOption(hiredGladiators.Length);

                if (option == hiredGladiators.Length + 1) return;

                int cost = 300;
                if (NotEnoughMoney(cost)) continue;

                Gladiator newGladiator = hiredGladiators[option - 1];

                Money -= cost;
                MyGladiators.Add(newGladiator);
                Console.WriteLine($"Вы наняли гладиатора {newGladiator.Name}!\n");
            }
        }

        internal void HealGladiators()
        {
            while (true)
            {
                Console.WriteLine($"Какого гладиатора вылечить?\n");
                ShowMyGladiators();

                int option = GetOption(MyGladiators.Count);

                if (option == MyGladiators.Count + 1) return;

                Gladiator myGladiator = MyGladiators[option - 1];

                if (myGladiator.Health == 100)
                {
                    Console.WriteLine($"Гладиатор {myGladiator.Name} и так здоров!\n");
                    continue;
                }    

                int cost = (int)Math.Ceiling(100 - myGladiator.Health);
                if (NotEnoughMoney(cost)) continue;

                Money -= cost;
                myGladiator.Health = 100;
                Console.WriteLine($"Вы вылечили гладиатора {myGladiator.Name}!\n");
            }
        }

        internal void VisitTheStore()
        {
            while (true)
            {
                Console.WriteLine($"1) Выбрать доспехи\n2) Выбрать оружие\n3) Покинуть оружейную лавку");

                int gladiatorOption;

                switch (Console.ReadLine())
                {
                    case "1":
                        store.ShowArmors();

                        int armorOption = GetOption(store.Armors.Length);

                        if (armorOption == store.Armors.Length + 1) break;

                        Console.WriteLine("Какому гладиатору купить?\n");
                        ShowMyGladiators();

                        gladiatorOption = GetOption(MyGladiators.Count);
                        if (gladiatorOption == MyGladiators.Count + 1) break;

                        BuyGoods(MyGladiators[gladiatorOption - 1], store.Armors[armorOption - 1]);
                        break;

                    case "2":
                        store.ShowWeapons();

                        int weaponOption = GetOption(store.Weapons.Length);

                        if (weaponOption == store.Weapons.Length + 1) break;

                        Console.WriteLine("Какому гладиатору купить?\n");
                        ShowMyGladiators();

                        gladiatorOption = GetOption(MyGladiators.Count);
                        if (gladiatorOption == MyGladiators.Count + 1) break;

                        BuyGoods(MyGladiators[gladiatorOption - 1], store.Weapons[weaponOption - 1]);
                        break;

                    case "3": return;

                    default:
                        Console.WriteLine("Такого выбора нет! Попробуйте еще раз\n");
                        break;
                }
            }
        }

        void BuyGoods(Gladiator gladiator, Armor armor)
        {
            if (NotEnoughMoney(armor.Price)) return;

            Money -= armor.Price;
            gladiator.Armor = armor;
            Console.WriteLine($"Вы приобрели {armor.Name} для гладиатора {gladiator.Name}!\n");
        }

        void BuyGoods(Gladiator gladiator, Weapon weapon)
        {
            if (NotEnoughMoney(weapon.Price)) return;

            Money -= weapon.Price;
            gladiator.Weapon = weapon;
            Console.WriteLine($"Вы приобрели {weapon.Name} для гладиатора {gladiator.Name}!\n");
        }

        bool NotEnoughMoney(int cost)
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
                    Console.WriteLine("Такого выбора нет! Попробуйте еще раз");
                }
                else { return option; }
            }
        }

        internal void ShowMyGladiators()
        {
            for (int i = 0; i < MyGladiators.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {MyGladiators[i]}\nЗдоровье: [{MyGladiators[i].Health}/100]\n");
            }
            Console.WriteLine($"{MyGladiators.Count + 1}) Вернуться назад");
        }

        void ShowHiredGladiators()
        {
            for (int i = 0; i < hiredGladiators.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {hiredGladiators[i]}\n");
            }
            Console.WriteLine($"{hiredGladiators.Length + 1}) Вернуться назад");
        }
    }
}
