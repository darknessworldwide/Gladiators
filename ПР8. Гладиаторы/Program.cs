using System;

namespace ПР8.Гладиаторы
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            BattleSystem battleSystem = new BattleSystem(game);

            game.HireGladiator();
            battleSystem.EnterTheArena();

            Console.ReadKey();
        }
    }
}
