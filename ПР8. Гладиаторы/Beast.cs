namespace ПР8.Гладиаторы
{
    class Beast
    {
        internal string Name { get; }
        internal double Health { get; set; }
        internal double Damage { get; }

        internal Beast(string name, double health, double damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        internal string Info() { return $"{Name}, здоровье: {Health}, урон: {Damage}"; }
    }
}
