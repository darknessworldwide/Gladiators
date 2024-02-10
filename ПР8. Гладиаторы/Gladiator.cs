using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ПР8.Гладиаторы
{
    internal class Gladiator
    {
        internal string Name { get; }
        internal double Health { get; set; }
        internal Armor Armor { get; set; }
        internal Weapon Weapon { get; set; }

        internal Gladiator(string name)
        {
            Name = name;
            Health = 100;
            Armor = new Armor("Тканевая одежда", 0, 1);
            Weapon = new Weapon("Кулаки", 0, 10);
        }

        internal string Info()
        {
            return $"{Name}, {Health} HP\n   Доспехи: {Armor.Name}, множитель защиты = {Armor.Protection}\n   Оружие: {Weapon.Name}, урон = {Weapon.Damage}";
        }
    }
}
