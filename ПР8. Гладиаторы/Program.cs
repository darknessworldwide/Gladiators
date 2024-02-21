using System;

namespace ПР8.Гладиаторы
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            BattleSystem battleSystem = new BattleSystem(game);

            bool stop = false;

            while (!stop)
            {
                Console.WriteLine($"Монеты: {game.Money} Слава: {game.Glory}\n");
                Console.WriteLine($"1) Сразиться на арене\n2) Зайти в оружейную лавку\n3) Вылечить гладиаторов\n4) Нанять гладиаторов\n\n5) Выйти из игры");

                switch (Console.ReadLine())
                {
                    case "1":
                        battleSystem.EnterTheArena();
                        break;
                    case "2":
                        game.VisitTheStore();
                        break;
                    case "3":
                        game.HealGladiators();
                        break;
                    case "4":
                        game.HireGladiators();
                        break;
                    case "5":
                        stop = true;
                        break;
                    default:
                        Console.WriteLine("Такого выбора нет! Попробуйте еще раз\n");
                        break;
                }
            }
        }
    }
}
