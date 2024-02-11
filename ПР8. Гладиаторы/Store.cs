using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР8.Гладиаторы
{
    internal class Store
    {
        internal Armor[] Armors { get; }
        internal Weapon[] Weapons { get; }

        internal Store()
        {
            Armors = new Armor[]
            {
                new Armor("Кожаная броня", 70, 1.3),
                new Armor("Кольчуга", 90, 1.6),
                new Armor("Бригантина", 100, 1.7),
                new Armor("Пластинчатый доспех", 120, 1.8),
                new Armor("Латы", 180, 2.2)
            };

            Weapons = new Weapon[]
            {
                new Weapon("Палица", 25, 45),
                new Weapon("Клинок с кинжалом", 28, 55),
                new Weapon("Копье", 35, 60),
                new Weapon("Алебарда", 40, 70),
                new Weapon("Молот бога", 50, 100)
            };
        }

        internal void ShowArmors()
        {
            Console.WriteLine("Доспехи:");
            for (int i = 0; i < Armors.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {Armors[i].Info()}. Цена: {Armors[i].Price} монет");
            }
        }

        internal void ShowWeapons()
        {
            Console.WriteLine("Оружия:");
            for (int i = 0; i < Weapons.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {Weapons[i].Info()}. Цена: {Weapons[i].Price} монет");
            }
        }
    }
}
