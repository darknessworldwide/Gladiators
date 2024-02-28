namespace ПР8.Гладиаторы
{
    class Gladiator
    {
        internal string Name { get; }
        internal double Health { get; set; }
        internal Armor Armor { get; set; }
        internal Weapon Weapon { get; set; }

        internal Gladiator(string name)
        {
            Name = name;
            Health = 100;
            Armor = new Armor("Тканевая одежда", 1, 0);
            Weapon = new Weapon("Кулаки", 10, 0);
        }

        internal Gladiator(string name, Armor armor, Weapon weapon)
        {
            Name = name;
            Health = 100;
            Armor = armor;
            Weapon = weapon;
        }

        public override string ToString() { return $"{Name} | Здоровье: [{Health}/100]\nДоспехи: {Armor}\nОружие: {Weapon}"; }
    }
}
