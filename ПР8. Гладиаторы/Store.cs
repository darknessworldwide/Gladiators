using System;

namespace ПР8.Гладиаторы
{
    class Store
    {
        internal Armor[] Armors { get; }
        internal Weapon[] Weapons { get; }

        internal Store()
        {
            Armors = new Armor[]
            {
                new Armor("Кожаная броня", 1.3, 70),
                new Armor("Кольчуга", 1.6, 90),
                new Armor("Бригантина", 1.7, 100),
                new Armor("Пластинчатый доспех", 1.8, 120),
                new Armor("Латы", 2.2, 180)
            };

            Weapons = new Weapon[]
            {
                new Weapon("Палица", 45, 25),
                new Weapon("Клинок с кинжалом", 55, 28),
                new Weapon("Копье", 60, 35),
                new Weapon("Алебарда", 70, 40),
                new Weapon("Молот бога", 100, 50)
            };
        }

        internal void ShowArmors()
        {
            for (int i = 0; i < Armors.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {Armors[i].Info()}    Цена: {Armors[i].Price} монет");
            }
            Console.WriteLine($"{Armors.Length + 1}) Вернуться назад\n");
        }

        internal void ShowWeapons()
        {
            for (int i = 0; i < Weapons.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {Weapons[i].Info()}    Цена: {Weapons[i].Price} монет");
            }
            Console.WriteLine($"{Weapons.Length + 1}) Вернуться назад\n");
        }
    }
}
