using System;
using System.Collections.Generic;

namespace ПР8.Гладиаторы
{
    class Game
    {
        private protected int money;
        private protected int glory;
        Store store;
        private protected List<Gladiator> myGladiators;
        List<Gladiator> hiredGladiators;

        internal Game()
        {
            money = 100000;
            glory = 0;
            store = new Store();

            myGladiators = new List<Gladiator>()
            {
                new Gladiator("Григорий Дуболом")
            };

            hiredGladiators = new List<Gladiator>()
            {
                new Gladiator("Аурелиан Железный Клинок"),
                new Gladiator("Северус Кровавый Гром"),
                new Gladiator("Леонид Сокрушитель")
            };
        }

        internal void HireGladiator()
        {
            while (true)
            {
                Console.WriteLine($"Какого гладиатора нанять? У вас {money} монет\n");
                ShowGladiators(hiredGladiators);

                int option = GetOption(hiredGladiators.Count);

                if (option == hiredGladiators.Count + 1) return;

                int cost = 300;
                if (NotEnoughMoney(cost)) return;

                Gladiator newGladiator = hiredGladiators[option - 1];

                money -= cost;
                myGladiators.Add(newGladiator);
                Console.WriteLine($"Вы наняли гладиатора {newGladiator.Name}!\n");

                hiredGladiators.Remove(newGladiator);
            }
        }

        internal void HealGladiator()
        {
            while(true)
            {
                Console.WriteLine($"Какого гладиатора исцелить? У вас {money} монет\n");
                ShowGladiators(myGladiators);

                int option = GetOption(myGladiators.Count);

                if (option == myGladiators.Count + 1) return;

                int cost = 100;
                if (NotEnoughMoney(cost)) return;

                Gladiator myGladiator = myGladiators[option - 1];

                money -= cost;
                myGladiator.Health = 100;
                Console.WriteLine($"Вы исцелили гладиатора {myGladiator.Name}!\n");
            }
        }

        internal void VisitTheStore()
        {
            while (true)
            {
                Console.WriteLine($"У вас {money} монет");
                Console.WriteLine($"1) Выбрать доспехи\n2) Выбрать оружие\n3) Покинуть оружейную лавку\n");

                int gladiatorOption;

                switch (Console.ReadLine())
                {
                    case "1":
                        store.ShowArmors();

                        int armorOption = GetOption(store.Armors.Length);

                        if (armorOption == store.Armors.Length + 1) break;

                        Console.WriteLine("Какому гладиатору купить?\n");
                        ShowGladiators(myGladiators);

                        gladiatorOption = GetOption(myGladiators.Count);
                        if (gladiatorOption == myGladiators.Count + 1) break;

                        BuyGoods(myGladiators[gladiatorOption - 1], store.Armors[armorOption - 1]);
                        break;

                    case "2":
                        store.ShowWeapons();

                        int weaponOption = GetOption(store.Weapons.Length);

                        if (weaponOption == store.Weapons.Length + 1) break;

                        Console.WriteLine("Какому гладиатору купить?\n");
                        ShowGladiators(myGladiators);

                        gladiatorOption = GetOption(myGladiators.Count);
                        if (gladiatorOption == myGladiators.Count + 1) break;

                        BuyGoods(myGladiators[gladiatorOption - 1], store.Weapons[weaponOption - 1]);
                        break;

                    case "3": return;

                    default:
                        Console.WriteLine("Такого выбора нет! Попробуйте еще раз");
                        break;
                }
            }
        }

        void BuyGoods(Gladiator gladiator, Armor armor)
        {
            if (NotEnoughMoney(armor.Price)) return;

            money -= armor.Price;
            gladiator.Armor = armor;
            Console.WriteLine($"Вы приобрели {armor.Name} для гладиатора {gladiator.Name}!\n");
        }

        void BuyGoods(Gladiator gladiator, Weapon weapon)
        {
            if (NotEnoughMoney(weapon.Price)) return;

            money -= weapon.Price;
            gladiator.Weapon = weapon;
            Console.WriteLine($"Вы приобрели {weapon.Name} для гладиатора {gladiator.Name}!\n");
        }

        bool NotEnoughMoney(int cost)
        {
            if (money < cost)
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
        internal void ShowGladiators(List<Gladiator> gladiators)
        {
            for (int i = 0; i < gladiators.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {gladiators[i].Info()}\n");
            }
            Console.WriteLine($"{gladiators.Count + 1}) Вернуться назад\n");
        }
    }
}
