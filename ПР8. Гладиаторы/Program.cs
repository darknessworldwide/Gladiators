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
            BattleSystem battleSystem = new BattleSystem();

            game.HireGladiator();
            game.VisitTheStore();
            game.ShowGladiators(game.MyGladiators);
            battleSystem.StartBattle();

            Console.ReadKey();
        }
    }
}
