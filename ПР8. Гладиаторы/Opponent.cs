namespace ПР8.Гладиаторы
{
    class Opponent : Gladiator
    {
        internal int Money { get; }
        internal int Glory { get; }

        internal Opponent(string name, Armor armor, Weapon weapon, int money, int glory) : base(name, armor, weapon)
        {
            Money = money;
            Glory = glory;
        }

        public override string ToString() { return $"{Name}\nДоспехи: {Armor}\nОружие: {Weapon}\nНаграда за победу: {Money} монет и {Glory} славы"; }
    }
}