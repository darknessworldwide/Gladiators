using System;

namespace ПР8.Гладиаторы
{
    class BattleSystem
    {
        Game game;
        Gladiator[] opponents;
        Beast[] beasts;

        internal BattleSystem(Game game)
        {
            this.game = game;

            opponents = new Gladiator[]
            {
                new Gladiator("Максимус Безжалостный"),
                new Gladiator("Валерий Череполом"),
                new Gladiator("Артемий Молотильщик")
            };

            beasts = new Beast[]
            {
                new Beast("Волк", 100, 20),
                new Beast("Тигр", 150, 25),
                new Beast("Лев", 200, 30),
                new Beast("Медведь", 250, 35)
            };
        }

        internal void EnterTheArena()
        {
            while (true)
            {
                Console.WriteLine("1) Гладиатор vs Гладиатор\n2) Гладиатор vs Зверь\n3) Покинуть стадион");

                int gladiatorOption;
                Gladiator myGladiator;

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Выберите своего гладиатора:\n");
                        game.ShowMyGladiators();

                        gladiatorOption = game.GetOption(game.MyGladiators.Count);

                        if (gladiatorOption == game.MyGladiators.Count + 1) return;

                        Console.WriteLine("Выберите противника:\n");
                        ShowOpponents();

                        int opponentOption = game.GetOption(opponents.Length);

                        if (opponentOption == opponents.Length + 1) return;

                        myGladiator = game.MyGladiators[gladiatorOption - 1];
                        Gladiator opponent = opponents[opponentOption - 1];

                        Console.WriteLine($"Битва начинается: {myGladiator.Name} vs {opponent.Name}\n");
                        Fight(myGladiator, opponent);
                        break;

                    case "2":
                        Console.WriteLine("Выберите своего гладиатора:\n");
                        game.ShowMyGladiators();

                        gladiatorOption = game.GetOption(game.MyGladiators.Count);

                        if (gladiatorOption == game.MyGladiators.Count + 1) return;

                        Console.WriteLine("Выберите зверя:");
                        ShowBeasts();

                        int beastOption = game.GetOption(beasts.Length);

                        if (beastOption == beasts.Length + 1) return;

                        myGladiator = game.MyGladiators[gladiatorOption - 1];
                        Beast beast = beasts[beastOption - 1];

                        Console.WriteLine($"Битва начинается: {myGladiator.Name} vs {beast.Name}\n");
                        Fight(myGladiator, beast);
                        break;

                    case "3": return;

                    default:
                        Console.WriteLine("Такого выбора нет! Попробуйте еще раз\n");
                        break;
                }
            }
        }

        void Fight(Gladiator myGladiator, Gladiator opponent)
        {
            double myDamage = Math.Round(myGladiator.Weapon.Damage / opponent.Armor.Protection, 1);
            double enemyDamage = Math.Round(opponent.Weapon.Damage / myGladiator.Armor.Protection, 1);

            while (true)
            {
                Console.WriteLine($"Ваш гладиатор {myGladiator.Name} наносит {myDamage} урона оппоненту {opponent.Name}");
                opponent.Health -= myDamage;
                if (opponent.Health <= 0) break;

                Console.WriteLine($"Оппонент {opponent.Name} наносит {enemyDamage} урона вашему гладиатору {myGladiator.Name}");
                myGladiator.Health -= enemyDamage;
                if (myGladiator.Health <= 0) break;
            }

            Console.WriteLine();

            if (myGladiator.Health <= 0)
            {
                Console.WriteLine($"Оппонент {opponent.Name} выиграл");

                game.MyGladiators.Remove(myGladiator);
                game.Glory -= 10;
                opponent.Health = 100;
            }
            else
            {
                Console.WriteLine($"Ваш гладиатор {myGladiator.Name} выиграл!");

                game.Glory += 15;
                game.Money += 10;
            }

            Console.WriteLine();
        }

        void Fight(Gladiator myGladiator, Beast beast)
        {
            double enemyDamage = Math.Round(beast.Damage / myGladiator.Armor.Protection, 1);
            double defaultHealth = beast.Health;

            while (true)
            {
                Console.WriteLine($"Ваш гладиатор {myGladiator.Name} наносит {myGladiator.Weapon.Damage} урона {beast.Name}");
                beast.Health -= myGladiator.Weapon.Damage;
                if (beast.Health <= 0) break;

                Console.WriteLine($"{beast.Name} наносит {enemyDamage} урона вашему гладиатору {myGladiator.Name}");
                myGladiator.Health -= enemyDamage;
                if (myGladiator.Health <= 0) break;
            }

            Console.WriteLine();

            if (myGladiator.Health <= 0)
            {
                Console.WriteLine($"{beast.Name} выиграл");

                game.MyGladiators.Remove(myGladiator);
                game.Glory -= 10;
                beast.Health = defaultHealth;
            }
            else
            {
                Console.WriteLine($"Ваш гладиатор {myGladiator.Name} выиграл!");

                game.Glory += 15;
                game.Money += 10;
            }

            Console.WriteLine();
        }

        void ShowOpponents()
        {
            for (int i = 0; i < opponents.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {opponents[i]}\n");
            }
            Console.WriteLine($"\n{opponents.Length + 1}) Вернуться назад");
        }

        void ShowBeasts()
        {
            for (int i = 0; i < beasts.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {beasts[i]}");
            }
            Console.WriteLine($"\n{beasts.Length + 1}) Вернуться назад");
        }
    }
}
