using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ПР8.Гладиаторы
{
    internal class BattleSystem : Game
    {
        internal BattleSystem(Game game) : base()
        {
            MyGladiators = game.MyGladiators;
        }

        internal void StartBattle()
        {
            bool flag = true;
            do
            {
                ShowGladiators(MyGladiators);
                Console.WriteLine("Выберите тип битвы:");
                Console.WriteLine("1) Гладиатор vs Гладиатор\n2) Гладиатор vs Зверь\n3) Вернуться назад\n");

                switch (Console.ReadLine())
                {
                    case "1":
                        StartGladiatorBattle();
                        break;

                    case "2":
                        StartBeastBattle();
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

        internal void StartGladiatorBattle()
        {
            Console.WriteLine("Выберите своего гладиатора:");
            ShowGladiators(MyGladiators);
            int gladiatorOption = GetOption(MyGladiators.Count);
            if (gladiatorOption == MyGladiators.Count + 1) return;

            Console.WriteLine("Выберите противника:");
            ShowGladiators(Opponents);
            int opponentOption = GetOption(Opponents.Count);
            if (opponentOption == Opponents.Count + 1) return;

            Gladiator myGladiator = MyGladiators[gladiatorOption - 1];
            Gladiator opponent = Opponents[opponentOption - 1];

            Console.WriteLine($"Битва начинается: {myGladiator.Name} vs {opponent.Name}");
            Fight(myGladiator, opponent);
        }

        internal void StartBeastBattle()
        {
            Console.WriteLine("Выберите своего гладиатора:");
            ShowGladiators(MyGladiators);
            int myGladiatorIdx = GetOption(MyGladiators.Count);

            Console.WriteLine("Выберите зверя:");
            ShowBeasts();
            int beastIdx = GetOption(Beasts.Count);

            Gladiator myGladiator = MyGladiators[myGladiatorIdx - 1];
            Beast beast = Beasts[beastIdx - 1];

            Console.WriteLine($"Битва начинается: {myGladiator.Name} vs {beast.Name}");
            Fight(myGladiator, beast);
        }

        internal void Fight(Gladiator myGladiator, Gladiator opponent)
        {
            do
            {
                Console.WriteLine($"Гладиатор {myGladiator.Name} наносит {myGladiator.Weapon.Damage} урона оппоненту {opponent.Name}");
                opponent.Health -= myGladiator.Weapon.Damage;

                Console.WriteLine();

                Console.WriteLine($"Оппонент {opponent.Name} наносит {opponent.Weapon.Damage} урона гладиатору {opponent.Name}");
                myGladiator.Health -= opponent.Weapon.Damage;
            } while (myGladiator.Health > 0 && opponent.Health > 0);

            if (myGladiator.Health < opponent.Health)
            {
                Console.WriteLine($"{opponent.Name} выиграл!\n");
                MyGladiators.Remove(myGladiator);
                Glory -= 10;
                opponent.Health = 100;
            }
            else
            {
                Console.WriteLine($"{myGladiator.Name} выиграл!\n");
                Glory += 15;
                Money += 10;
            }
        }

        internal void Fight(Gladiator myGladiator, Beast beast)
        {
            do
            {
                Console.WriteLine($"Гладиатор {myGladiator.Name} наносит {myGladiator.Weapon.Damage} оппоненту {beast.Name}");
                beast.Health -= myGladiator.Weapon.Damage;

                Console.WriteLine();

                Console.WriteLine($"Оппонент {beast.Name} наносит {beast.Damage} гладиатору {beast.Name}");
                myGladiator.Health -= beast.Damage;
            } while (myGladiator.Health > 0 && beast.Health > 0);

            if (myGladiator.Health < beast.Health)
            {
                Console.WriteLine($"{beast.Name} выиграл!\n");
                MyGladiators.Remove(myGladiator);
                Glory -= 10;
                beast.Health = 100;
            }
            else
            {
                Console.WriteLine($"{myGladiator.Name} выиграл!\n");
                Glory += 15;
                Money += 10;
            }
        }
    }
}
