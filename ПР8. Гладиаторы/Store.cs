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
                new Armor("Кожаные", 200, 1.2),
                new Armor("Кольчуга", 500, 1.5),
                new Armor("Латные", 750, 1.75)
            };

            weapons = new Weapon[]
            {
                new Weapon("Короткий меч", 100, 30),
                new Weapon("Копье", 50, 40),
                new Weapon("Топор", 130, 40)
            };
        }

        internal void Goods()
        {
            Console.WriteLine("Добро пожаловать в мастерскую!\n1) Выбрать доспехи\n2) Выбрать оружие\n3) Покинуть мастерскую\n");
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
