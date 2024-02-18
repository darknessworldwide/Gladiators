namespace ПР8.Гладиаторы
{
    class Armor
    {
        internal string Name { get; }
        internal double Protection { get; }
        internal int Price { get; }

        internal Armor(string name, double protection, int price)
        {
            Name = name;
            Protection = protection;
            Price = price;
        }

        internal string Info() { return $"{Name}    Множитель защиты: {Protection}"; }
    }
}
