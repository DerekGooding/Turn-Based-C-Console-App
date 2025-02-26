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

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("=================================");
        Console.WriteLine("   Welcome to the Colosseum!    ");
        Console.WriteLine("=================================");
        Console.ReadKey();
        Console.WriteLine("Prepare for your first battle againts a colosseum noob!");
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ResetColor();
        Console.ReadKey();
        while (death == false)

        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==================================");
            Console.WriteLine("         ** BATTLE STATUS **     ");
            Console.WriteLine("==================================");
            Console.ForegroundColor = ConsoleColor.Green;

            // Display Player Stats
            Console.WriteLine($"| Player {player.r} Health: {player.hp}      " +
                $"   |");
            Console.WriteLine($"| Defense: {player.d}                      |");

            Console.WriteLine("|---------------------------------|");

            // Display Enemy Stats
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"| Enemy {enemy.r} Health: {enemy.hp}           |");
            Console.WriteLine($"| Defense: {enemy.d}  PThrust({enemy.t}/{enemy.mt})        |");

            Console.WriteLine("|=================================|");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"| (A)ttack   (S)tab({player.s}/{player.ms})         " +
                $" |");
            Console.WriteLine($"| (D)efend                        |");
            Console.WriteLine("|=================================|");
            Console.ResetColor();

            Console.WriteLine("Choose an action: ");


            string choice = Console.ReadLine();


            if (choice == "a")
            {
                player.Attack(enemy, player, enemy);
                Console.ReadKey();
            }
            else if (choice == "d")
            {
                if (player.d == 0)
                {
                    player.Defense_M(enemy, player);
                    Console.ReadKey();
                }
                else if (player.d > 0)
                {
                    Console.WriteLine("You cant defend again until it is broke by an attack!");
                    Console.ReadKey();
                    continue;
                }
            }
            else if (choice == "s")
            {
                if (player.s < player.ms)
                {
                    player.Stab(enemy, player);

                    Console.ReadKey();
                }
                else
                {
                    player.youcantStab();
                    continue;
                }

                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid input");
                Console.ReadKey();
                continue;
            }

            Console.WriteLine("-- Enemy turn --");

            enemy.deathCheck(enemy);
            player.deathCheck(player);



            int EnemyChoice = Random.Shared.Next(2, 7);

            if (EnemyChoice == 2 || EnemyChoice == 3)
            {
                enemy.Attack(player, player, enemy);
                Console.ReadKey();


            }
            else if (EnemyChoice == 4 || EnemyChoice == 5)
            {
                enemy.Defense_M(player, enemy);
                Console.ReadKey();

            }
            else if (EnemyChoice == 6 || EnemyChoice == 7)

                if (enemy.t < enemy.mt)
                {
                    enemy.paralyzingThrust(player, enemy);
                    Console.ReadKey();
                }
                else
                {
                    int enemyChoice = Random.Shared.Next(2, 4);
                    if (enemyChoice == 2 | enemyChoice == 3)
                    {
                        enemy.Attack(player, player, enemy);
                        Console.ReadKey();
                    }
                    else if (enemyChoice == 4)
                    {
                        enemy.Defense_M(player, enemy);
                        Console.ReadKey();
                    }
                    enemy.paralyzingThrust(player, enemy);
                    Console.ReadKey();
                }

            Console.WriteLine($"{EnemyChoice} is choice");
            if (enemy.hp <= 0)
            {
                enemy.deathCheck(enemy);
                Console.WriteLine("To be contiued...");
                Console.ReadKey();
                Environment.Exit(0);

            }


            if (player.hp <= 0)
            {
                player.deathCheck(player);
            }

          




        }
    }
}

