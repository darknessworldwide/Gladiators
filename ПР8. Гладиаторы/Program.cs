using System;

namespace ПР8.Гладиаторы
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.HireGladiator();

            BattleSystem battleSystem = new BattleSystem();
            battleSystem.EnterTheArena();

            Console.ReadKey();
        }
    }
}
