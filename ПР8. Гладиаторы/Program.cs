using System;

namespace ПР8.Гладиаторы
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            BattleSystem battleSystem = new BattleSystem();

            game.HireGladiator();
            game.VisitTheStore();
            battleSystem.EnterTheArena();
            game.HealGladiator();

            Console.ReadKey();
        }
    }
}
