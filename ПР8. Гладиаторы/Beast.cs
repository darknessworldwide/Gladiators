namespace ПР8.Гладиаторы
{
    class Beast
    {
        internal string Name { get; }
        internal double Health { get; set; }
        internal double Damage { get; }
        internal int Money { get; }
        internal int Glory { get; }

        internal Beast(string name, double health, double damage, int money, int glory)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Money = money;
            Glory = glory;
        }

        public override string ToString() { return $"{Name} | Здоровье: {Health} | Урон: {Damage}\nНаграда за победу: {Money} монет и {Glory} славы"; }
    }
}
