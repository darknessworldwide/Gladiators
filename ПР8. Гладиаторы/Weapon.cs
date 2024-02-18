namespace ПР8.Гладиаторы
{
    class Weapon
    {
        internal string Name { get; }
        internal double Damage { get; }
        internal int Price { get; }

        internal Weapon(string name, double damage, int price)
        {
            Name = name;
            Damage = damage;
            Price = price;
        }

        internal string Info() { return $"{Name}    Урон: {Damage}"; }
    }
}
