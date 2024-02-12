using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР8.Гладиаторы
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            BattleSystem battleSystem = new BattleSystem(game);

            game.HireGladiator();
            game.VisitTheStore();
            battleSystem.StartBattle();

            Console.ReadKey();
        }
    }
}
