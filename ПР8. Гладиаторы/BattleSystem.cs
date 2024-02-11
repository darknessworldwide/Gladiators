using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР8.Гладиаторы
{
    internal class BattleSystem : Game
    {
        internal void StartBattle()
        {
            bool flag = true;
            do
            {
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
            // создать метод Fight() и передавать туда гладиатора и соперника
        }

        internal void StartBeastBattle()
        {
            Console.WriteLine("Выберите своего гладиатора:");
            ShowGladiators(MyGladiators);
            int myGladiatorIdx = GetOption(MyGladiators.Count);

            Console.WriteLine("Выберите зверя:");
            ShowBeasts();
            int beastIdx = GetOption(Beasts.Count);

            Gladiator myGladiator = MyGladiators[myGladiatorIdx];
            Beast beast = Beasts[beastIdx];

            Console.WriteLine($"Битва начинается: {myGladiator.Name} vs {beast.Name}");
            // создать метод Fight() и передавать туда гладиатора и зверя
        }
    }
}
