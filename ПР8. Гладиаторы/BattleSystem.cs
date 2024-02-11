using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР8.Гладиаторы
{
    internal class BattleSystem : Game
    {
        internal BattleSystem(Game game) : base() 
        {
            MyGladiators = game.MyGladiators;
            opponents = game.opponents;
            beasts = game.beasts;
        }

        internal void StartBattle()
        {
            Console.WriteLine("Выберите тип битвы:");
            Console.WriteLine("1) Гладиатор vs Гладиатор\n2) Гладиатор vs Зверь\n3) Вернуться назад");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    StartGladiatorBattle();
                    break;

                case "2":
                    StartBeastBattle();
                    break;

                case "3":
                    break;

                default:
                    Console.WriteLine("Такого выбора нет!");
                    break;
            }
        }

        internal void StartGladiatorBattle()
        {
            Console.WriteLine("Выберите своего гладиатора:");
            ShowGladiators(MyGladiators);
            int myGladiatorIdx = GetSelectedIndex(MyGladiators.Count);

            Console.WriteLine("Выберите противника:");
            ShowGladiators(opponents);
            int opponentIdx = GetSelectedIndex(opponents.Count);

            Gladiator myGladiator = MyGladiators[myGladiatorIdx];
            Gladiator opponent = opponents[opponentIdx];

            Console.WriteLine($"Битва начинается: {myGladiator.Name} vs {opponent.Name}");
            // создать метод Fight() и передавать туда гладиатора и соперника
        }

        internal void StartBeastBattle()
        {
            Console.WriteLine("Выберите своего гладиатора:");
            ShowGladiators(MyGladiators);
            int myGladiatorIdx = GetSelectedIndex(MyGladiators.Count);

            Console.WriteLine("Выберите зверя:");
            ShowBeasts();
            int beastIdx = GetSelectedIndex(beasts.Count);

            Gladiator myGladiator = MyGladiators[myGladiatorIdx];
            Beast beast = beasts[beastIdx];

            Console.WriteLine($"Битва начинается: {myGladiator.Name} vs {beast.Name}");
            // создать метод Fight() и передавать туда гладиатора и зверя
        }

        internal int GetSelectedIndex(int count)
        {
            int idx;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out idx) || idx < 1 || idx > count)
                {
                    Console.WriteLine("Неверный выбор. Попробуйте снова:");
                }
                else
                {
                    break;
                }
            }
            return idx - 1;
        }
    }
}
