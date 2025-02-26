namespace ConsoleAppTurnBased;

internal static class Program
{
    static void Main()
    {
        Player player = new Player(2, 20, 60, 0, 0, 3, 0, 0, 0, 3, 0, "Water");
        Enemy enemy = new Enemy(2, 20, 50, 0, 0, 3, 0, 0, 0, 3, 0, "Noob");

        //{player.r} Defense - {player.d}
        //{enemy.r} Health - {enemy.hp}");
        //Console.WriteLine($"{enemy.r} Defense - {enemy.d}");
        //Console.WriteLine($" {enemy.r} Health - {enemy.hp}");
        //
        //

        bool death = false;

        ForegroundColor = ConsoleColor.Blue;
        WriteLine("=================================");
        WriteLine("   Welcome to the Colosseum!    ");
        WriteLine("=================================");
        ReadKey();
        WriteLine("Prepare for your first battle againts a colosseum noob!");
        WriteLine();
        WriteLine("Press any key to continue...");
        ResetColor();
        ReadKey();
        while (death == false)

        {
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("==================================");
            WriteLine("         ** BATTLE STATUS **     ");
            WriteLine("==================================");
            ForegroundColor = ConsoleColor.Green;

            // Display Player Stats
            WriteLine($"| Player {player.r} Health: {player.hp}      " +
                $"   |");
            WriteLine($"| Defense: {player.d}                      |");

            WriteLine("|---------------------------------|");

            // Display Enemy Stats
            ForegroundColor = ConsoleColor.Red;
            WriteLine($"| Enemy {enemy.r} Health: {enemy.hp}           |");
            WriteLine($"| Defense: {enemy.d}  PThrust({enemy.t}/{enemy.mt})        |");

            WriteLine("|=================================|");
            ForegroundColor = ConsoleColor.White;
            WriteLine($"| (A)ttack   (S)tab({player.s}/{player.ms})         " +
                $" |");
            WriteLine($"| (D)efend                        |");
            WriteLine("|=================================|");
            ResetColor();

            WriteLine("Choose an action: ");

            string choice = ReadLine();

            if (choice == "a")
            {
                player.Attack(enemy, player, enemy);
                ReadKey();
            }
            else if (choice == "d")
            {
                if (player.d == 0)
                {
                    player.Defense_M(enemy, player);
                    ReadKey();
                }
                else if (player.d > 0)
                {
                    WriteLine("You cant defend again until it is broke by an attack!");
                    ReadKey();
                    continue;
                }
            }
            else if (choice == "s")
            {
                if (player.s < player.ms)
                {
                    player.Stab(enemy, player);

                    ReadKey();
                }
                else
                {
                    player.YouCantStab();
                    continue;
                }

                ReadKey();
            }
            else
            {
                WriteLine("Invalid input");
                ReadKey();
                continue;
            }

            WriteLine("-- Enemy turn --");

            enemy.DeathCheck(enemy);
            player.DeathCheck(player);

            int EnemyChoice = Random.Shared.Next(2, 7);

            if (EnemyChoice == 2 || EnemyChoice == 3)
            {
                enemy.Attack(player, player, enemy);
                ReadKey();
            }
            else if (EnemyChoice == 4 || EnemyChoice == 5)
            {
                enemy.Defense_M(player, enemy);
                ReadKey();
            }
            else if (EnemyChoice == 6 || EnemyChoice == 7)
                if (enemy.t < enemy.mt)
                {
                    enemy.ParalyzingThrust(player, enemy);
                    ReadKey();
                }
                else
                {
                    int enemyChoice = Random.Shared.Next(2, 4);
                    if (enemyChoice == 2 || enemyChoice == 3)
                    {
                        enemy.Attack(player, player, enemy);
                        ReadKey();
                    }
                    else if (enemyChoice == 4)
                    {
                        enemy.Defense_M(player, enemy);
                        ReadKey();
                    }
                    enemy.ParalyzingThrust(player, enemy);
                    ReadKey();
                }

            WriteLine($"{EnemyChoice} is choice");
            if (enemy.hp <= 0)
            {
                enemy.DeathCheck(enemy);
                WriteLine("To be contiued...");
                ReadKey();
                Environment.Exit(0);
            }

            if (player.hp <= 0)
            {
                player.DeathCheck(player);
            }
        }
    }
}
