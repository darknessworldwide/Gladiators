using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР8.Гладиаторы
{
    internal class Store
    {
        Armor[] armors;
        Weapon[] weapons;

        internal Store()
        {
            armors = new Armor[]
            {
                new Armor("Кожанная броня", 70, 1.3),
                new Armor("Пластинчатый доспех", 120, 1.8),
                new Armor("Латы", 180, 2.2),
                new Armor("Кольчуга", 90, 1.6),
                new Armor("Шлем", 40, 1.1),
                new Armor("Бригантина", 100, 1.7)
            };

            weapons = new Weapon[]
            {
                new Weapon("Копье", 35, 60),
                new Weapon("Палица", 25, 45),
                new Weapon("Клинок с кинжалом", 28, 55),
                new Weapon("Алебарда", 40, 70),
                new Weapon("Молот бога", 50, 100)
            };
        }

        internal void Goods()
        {
            Console.WriteLine("Добро пожаловать в оружейную лавку!\n1) Выбрать доспехи\n2) Выбрать оружие\n3) Покинуть оружейную лавку\n");
            string option = Console.ReadLine();
            if (option == "1")
            {
                Console.WriteLine("Доспехи:");
                for (int i = 0; i < armors.Length; i++) { Console.WriteLine($"{i + 1}) {armors[i].Name}, {armors[i].Price} (множитель защиты = {armors[i].Protection})"); }
                Console.WriteLine($"{armors.Length + 1}) Вернуться назад\n");
            }
            else if (option == "2")
            {
                Console.WriteLine("Оружие:");
                for (int i = 0; i < weapons.Length; i++) { Console.WriteLine($"{i + 1}) {weapons[i].Name}, {weapons[i].Price} (урон = {weapons[i].Damage})"); }
                Console.WriteLine($"{weapons.Length + 1}) Вернуться назад\n");
            }
        }
    }
}
