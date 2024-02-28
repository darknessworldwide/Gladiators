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
                new Armor("Простая кожаная броня", 1.1, 30),
                new Armor("Рваная кольчуга", 1.4, 60),
                new Armor("Кольчуга с кожаными вставками", 1.5, 70),
                new Armor("Легкий пластинчатый доспех", 1.6, 80),
                new Armor("Стальной корсет", 1.7, 90),
                new Armor("Усиленная кольчуга", 1.8, 100),
                new Armor("Бригантина", 1.9, 110),
                new Armor("Тяжелый пластинчатый доспех", 2.2, 140),
                new Armor("Бесшовная броня", 2.3, 150),
                new Armor("Кольчуга с пластинами", 2.4, 160),
                new Armor("Поврежденные латы", 2.6, 180),
                new Armor("Латы", 2.7, 190),
                new Armor("Доспех великого хранителя", 3.0, 250),
            };

            Weapons = new Weapon[]
            {
                new Weapon("Старый кинжал", 25, 50),
                new Weapon("Ржавый клинок", 30, 60),
                new Weapon("Стальной меч", 35, 70),
                new Weapon("Копье", 40, 80),
                new Weapon("Железный боевой топор", 45, 90),
                new Weapon("Двуручный меч", 65, 120),
                new Weapon("Рапира", 70, 130),
                new Weapon("Клеймор", 75, 140),
                new Weapon("Палица", 80, 150),
                new Weapon("Алебарда", 90, 160),
                new Weapon("Пика", 95, 170),
                new Weapon("Экскалибур", 100, 180),
                new Weapon("Клинок тьмы", 110, 200),
                new Weapon("Палаш Погибели", 120, 210),
                new Weapon("Молот бога", 130, 250),
            };
        }

        internal void ShowArmors()
        {
            for (int i = 0; i < Armors.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {Armors[i]} | Цена: {Armors[i].Price} монет");
            }
            Console.WriteLine($"{Armors.Length + 1}) Вернуться назад");
        }

        internal void ShowWeapons()
        {
            for (int i = 0; i < Weapons.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {Weapons[i]} | Цена: {Weapons[i].Price} монет");
            }
            Console.WriteLine($"{Weapons.Length + 1}) Вернуться назад");
        }
    }
}
