namespace ПР8.Гладиаторы
{
    class Beast
    {
        internal string Name { get; }
        internal double Health { get; set; }
        internal double Damage { get; }

        internal Beast(string name, double damage)
        {
            Name = name;
            Health = 100;
            Damage = damage;
        }

        internal string Info() { return $"{Name}, урон = {Damage}"; }
    }
}
