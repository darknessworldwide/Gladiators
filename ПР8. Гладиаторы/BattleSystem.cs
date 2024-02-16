using System;
using System.Collections.Generic;

namespace ПР8.Гладиаторы
{
    class BattleSystem : Game
    {
        List<Gladiator> opponents;
        List<Beast> beasts;

        internal BattleSystem()
        {
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

        internal void EnterTheArena()
        {
            while (true)
            {
                Console.WriteLine("1) Гладиатор vs Гладиатор\n2) Гладиатор vs Зверь\n3) Покинуть стадион\n");

                int gladiatorOption;
                Gladiator myGladiator;

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Выберите своего гладиатора:\n");
                        ShowGladiators(myGladiators);

                        gladiatorOption = GetOption(myGladiators.Count);

                        if (gladiatorOption == myGladiators.Count + 1) return;

                        Console.WriteLine("Выберите противника:");
                        ShowGladiators(opponents);

                        int opponentOption = GetOption(opponents.Count);

                        if (opponentOption == opponents.Count + 1) return;

                        myGladiator = myGladiators[gladiatorOption - 1];
                        Gladiator opponent = opponents[opponentOption - 1];

                        Console.WriteLine($"Битва начинается: {myGladiator.Name} vs {opponent.Name}\n");
                        Fight(myGladiator, opponent);
                        break;

                    case "2":
                        Console.WriteLine("Выберите своего гладиатора:\n");
                        ShowGladiators(myGladiators);

                        gladiatorOption = GetOption(myGladiators.Count);

                        Console.WriteLine("Выберите зверя:");
                        ShowBeasts();

                        int beastOption = GetOption(beasts.Count);

                        if (beastOption == beasts.Count + 1) return;

                        myGladiator = myGladiators[gladiatorOption - 1];
                        Beast beast = beasts[beastOption - 1];

                        Console.WriteLine($"Битва начинается: {myGladiator.Name} vs {beast.Name}\n");
                        Fight(myGladiator, beast);
                        break;

                    case "3": return;

                    default:
                        Console.WriteLine("Такого выбора нет! Попробуйте еще раз");
                        break;
                }
            }
        }

        void Fight(Gladiator myGladiator, Gladiator opponent)
        {
            while (myGladiator.Health > 0 && opponent.Health > 0)
            {
                Console.WriteLine($"Гладиатор {myGladiator.Name} наносит {myGladiator.Weapon.Damage} урона оппоненту {opponent.Name}");
                opponent.Health -= myGladiator.Weapon.Damage;

                Console.WriteLine($"Оппонент {opponent.Name} наносит {opponent.Weapon.Damage} урона гладиатору {myGladiator.Name}");
                myGladiator.Health -= opponent.Weapon.Damage;
            }

            if (myGladiator.Health <= 0)
            {
                Console.WriteLine($"Оппонент {opponent.Name} выиграл\n");

                myGladiators.Remove(myGladiator);
                glory -= 10;
                opponent.Health = 100;
            }
            else
            {
                Console.WriteLine($"Гладиатор {myGladiator.Name} выиграл!\n");

                glory += 15;
                money += 10;
            }
        }

        void Fight(Gladiator myGladiator, Beast beast)
        {
            while (myGladiator.Health > 0 && beast.Health > 0)
            {
                Console.WriteLine($"Гладиатор {myGladiator.Name} наносит {myGladiator.Weapon.Damage} урона {beast.Name}");
                beast.Health -= myGladiator.Weapon.Damage;

                Console.WriteLine($"{beast.Name} наносит {beast.Damage} урона гладиатору {myGladiator.Name}");
                myGladiator.Health -= beast.Damage;
            }

            if (myGladiator.Health <= 0)
            {
                Console.WriteLine($"{beast.Name} выиграл\n");

                myGladiators.Remove(myGladiator);
                glory -= 10;
                beast.Health = 100;
            }
            else
            {
                Console.WriteLine($"Гладиатор {myGladiator.Name} выиграл!\n");

                glory += 15;
                money += 10;
            }
        }

        void ShowBeasts()
        {
            for (int i = 0; i < beasts.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {beasts[i].Info()}");
            }
            Console.WriteLine($"{beasts.Count + 1}) Вернуться назад\n");
        }
    }
}
