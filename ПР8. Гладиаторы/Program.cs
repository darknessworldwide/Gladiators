using System;

namespace ПР8.Гладиаторы
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            BattleSystem battleSystem = new BattleSystem(game);

            bool flag = false;

            while (!flag)
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
                        game.HealGladiator();
                        break;
                    case "4":
                        game.HireGladiator();
                        break;
                    case "5":
                        flag = true;
                        break;
                    default:
                        Console.WriteLine("Такого выбора нет! Попробуйте еще раз\n");
                        break;
                }
            }
        }
    }
}
