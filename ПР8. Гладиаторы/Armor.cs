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

        public override string ToString() { return $"{Name} | Множитель защиты: {Protection}"; }
    }
}
