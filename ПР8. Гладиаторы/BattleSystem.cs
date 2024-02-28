using System;

namespace ПР8.Гладиаторы
{
    class BattleSystem
    {
        Game game;
        Opponent[] opponents;
        Beast[] beasts;

        internal BattleSystem(Game game)
        {
            this.game = game;

            opponents = new Opponent[]
            {
                new Opponent("Максимус Безжалостный", new Armor("Рваная кольчуга", 1.4, 60), new Weapon("Ржавый клинок", 30, 60), 30, 50),
                new Opponent("Валерий Череполом", new Armor("Бригантина", 1.9, 110), new Weapon("Рапира", 70, 130), 50, 75),
                new Opponent("Артемий Молотильщик", new Armor("Латы", 2.7, 190), new Weapon("Палаш Погибели", 120, 210), 100, 200),
            };

            beasts = new Beast[]
            {
                new Beast("Волк", 200, 20, 25, 30),
                new Beast("Тигр", 400, 30, 35, 40),
                new Beast("Лев", 600, 40, 50, 60),
                new Beast("Медведь", 1000, 50, 75, 100),
            };
        }

        internal void EnterTheArena()
        {
            while (true)
            {
                int gladiatorOption;
                Gladiator myGladiator;

                Console.WriteLine("1) Гладиатор vs Гладиатор\n2) Гладиатор vs Зверь\n3) Покинуть стадион");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Выберите своего гладиатора:\n");
                        game.ShowMyGladiators();
                        gladiatorOption = game.GetOption(game.MyGladiators.Count);

                        if (gladiatorOption == game.MyGladiators.Count + 1) break;

                        Console.WriteLine("Выберите противника:\n");
                        ShowOpponents();
                        int opponentOption = game.GetOption(opponents.Length);

                        if (opponentOption == opponents.Length + 1) break;

                        myGladiator = game.MyGladiators[gladiatorOption - 1];
                        Opponent opponent = opponents[opponentOption - 1];

                        Console.WriteLine($"Битва начинается: {myGladiator.Name} vs {opponent.Name}\n");
                        Fight(myGladiator, opponent);
                        break;

                    case "2":
                        Console.WriteLine("Выберите своего гладиатора:\n");
                        game.ShowMyGladiators();
                        gladiatorOption = game.GetOption(game.MyGladiators.Count);

                        if (gladiatorOption == game.MyGladiators.Count + 1) break;

                        Console.WriteLine("Выберите зверя:");
                        ShowBeasts();
                        int beastOption = game.GetOption(beasts.Length);

                        if (beastOption == beasts.Length + 1) break;

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

        void Fight(Gladiator myGladiator, Opponent opponent)
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
                Console.WriteLine($"Ваш гладиатор {myGladiator.Name} проиграл!");

                game.MyGladiators.Remove(myGladiator);
                game.Glory -= 10;
            }
            else
            {
                Console.WriteLine($"Ваш гладиатор {myGladiator.Name} выиграл!");

                game.Money += opponent.Money;
                game.Glory += opponent.Glory;
            }

            opponent.Health = 100;

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
                Console.WriteLine($"Ваш гладиатор {myGladiator.Name} проиграл!");

                game.MyGladiators.Remove(myGladiator);
                game.Glory -= 10;
            }
            else
            {
                Console.WriteLine($"Ваш гладиатор {myGladiator.Name} выиграл!");

                game.Money += beast.Money;
                game.Glory += beast.Glory;
            }

            beast.Health = defaultHealth;

            Console.WriteLine();
        }

        void ShowOpponents()
        {
            for (int i = 0; i < opponents.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {opponents[i]}\n");
            }
            Console.WriteLine($"{opponents.Length + 1}) Вернуться назад");
        }

        void ShowBeasts()
        {
            for (int i = 0; i < beasts.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {beasts[i]}\n");
            }
            Console.WriteLine($"{beasts.Length + 1}) Вернуться назад");
        }
    }
}
