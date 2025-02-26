namespace ConsoleAppTurnBased;

class Player(int attackPower,
             int CurrentHealth,
             int MaxHealth,
             int Defense,
             int t_Defense,
             int maxstabUses,
             int stabUses,
             int bleedturns,
             int thrustUses,
             int maxthrustUses,
             int paraTurns,
             string User)
{
    private int MaxHealth = MaxHealth;
    private int t_Defense = t_Defense;
    private int thrustUses = thrustUses;
    private int maxthrustUses = maxthrustUses;
    private int bleedturns = bleedturns;
    private int paraTurns = paraTurns;

    public int hp { get; private set; } = CurrentHealth;
    public string r { get; } = User;

    public int d { get; private set; } = Defense;

    public int s { get; private set; } = stabUses;
    public int ms { get; } = maxstabUses;

    public int a { get; } = attackPower;

    public void Attack(Enemy unitthatsgetAttacking, Player player, Enemy enemy)
    {
        double rng = Random.Shared.NextDouble() * 0.45 + 0.75;

        // Calculate the random damage
        int RandomDamage = (int)(rng * a);
        int paraChance = Random.Shared.Next(4);
        int AttackNumbers = Random.Shared.Next(1, 8);
        player.BleedCheck(player, a / 2);

        if (paraChance == 1 && paraTurns > 0)
        {
            player.ParalyzeCheck();
        }
        else
        {
            if (paraTurns > 0)
            {
                paraTurns--;
            }

            ForegroundColor = ConsoleColor.Green;
            switch (AttackNumbers)
            {
                case 1:
                    WriteLine($"{r} attacked and dealt {RandomDamage - unitthatsgetAttacking.d} damage!");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, player);
                    break;

                case 2:
                    WriteLine($"{r} launched a focused strike and dealt {RandomDamage - unitthatsgetAttacking.d} damage!");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, player);
                    break;

                case 3:
                    WriteLine($"{r} charged in confidently and dealt {RandomDamage - unitthatsgetAttacking.d} damage!");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, player);
                    break;

                case 4:
                    WriteLine($"In a bold move, {r} inflicted {RandomDamage - unitthatsgetAttacking.d} damage!");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, player);
                    break;

                case 5:
                    WriteLine($"With a calculated swing, {r} secured {RandomDamage - unitthatsgetAttacking.d} damage! ");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, player);
                    break;

                case 6:
                    WriteLine($"{r} focused their energy into a swift strike, inflicting {RandomDamage - unitthatsgetAttacking.d} damage!");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, player);
                    break;

                case 7:
                    WriteLine($"Executing a swift maneuver, {r} managed to inflict {RandomDamage - unitthatsgetAttacking.d} damage.");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, player);
                    break;

                case 8:
                    WriteLine($"{r} lunged forward confidently, resulting in a solid hit of {RandomDamage - unitthatsgetAttacking.d} damage!");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, player);
                    break;

                default:
                    WriteLine($"{r} lunged forward confidently, resulting in a solid hit of {RandomDamage - unitthatsgetAttacking.d} damage!");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, player);
                    break;

            }

            ResetColor();
        }
    }

    public void Defense_M(Enemy bleedout, Player player)
    {
        int TextsNumbers = Random.Shared.Next(1, 8);
        int paraChance = Random.Shared.Next(1, 4);
        player.BleedCheck(player, a / 2);
        if (paraChance == 1 && paraTurns > 0)
        {
            player.ParalyzeCheck();
        }
        else
        {
            if (paraTurns > 0)
            {
                paraTurns--;
            }

            if (d <= 0)
            {
                d ++;
                ForegroundColor = ConsoleColor.DarkBlue;

                switch (TextsNumbers)
                {
                    case 1:
                        WriteLine($"{r} held their weapon in a tactical grip, aimed for maximum control.  ");
                        break;

                    case 2:
                        WriteLine($"{r} twirled their weapon in a defensive dance. ");
                        break;

                    case 3:
                        WriteLine($"{r} stood at the ready, weapon anchored in a defensive position, poised for observation and protection.");
                        break;

                    case 4:
                        WriteLine($"The light glinted off {r}’s weapon, held protectively as they maintained a vigilant watch over their surroundings.");

                        break;

                    default:
                        WriteLine($"{r} steadied their weapon, maintaining balance and readiness.");
                        break;
                }

                ResetColor();
            }
        }
    }

    public void TakeDamage(int RandomDamage, Enemy enemy)
    {
        hp -= RandomDamage - d;

        if (d > 0)
        {
            t_Defense = 0;
            d = 0;
        }
    }
    public void Stab(Enemy stabnbleedenemy, Player player)
    {
        int stabtext = Random.Shared.Next(1, 4);

        double rng = Random.Shared.NextDouble() * 0.45 + 0.75;
        int StabDamage = (int)(1.15 * (int)a);
        int randStabDamage = (int)(rng * StabDamage);
        int paraChance = Random.Shared.Next(1, 4);

        bleedturns = 0;
        if (paraChance == 4 && paraTurns > 0)
        {
            player.ParalyzeCheck();
        }
        else
        {
            if (paraTurns > 0)
            {
                paraTurns--;
            }
            ForegroundColor = ConsoleColor.Red;
            switch (stabtext)
            {
                case 1:
                    WriteLine($"{r} rushed their enemy and stabbed doing {randStabDamage - d}!");
                    stabnbleedenemy.Takestab(randStabDamage);
                    stabnbleedenemy.ApplyBleed(a / 2);

                    s++;
                    break;

                case 2:
                    WriteLine($"{r} darted at their foe and thrust their weapon, dealing {randStabDamage - d} damage!");
                    stabnbleedenemy.Takestab(randStabDamage);
                    stabnbleedenemy.ApplyBleed(a / 2);
                    s++;
                    break;

                case 3:
                    WriteLine($"{r} lunged at the opponent and stabbed, inflicting {randStabDamage - d} damage!");
                    stabnbleedenemy.Takestab(randStabDamage);
                    stabnbleedenemy.ApplyBleed(a / 2);
                    s++;
                    break;

                case 4:
                    WriteLine($"{r} leaped into action and executed a stab, causing {randStabDamage - d} damage!");
                    stabnbleedenemy.Takestab(randStabDamage);
                    stabnbleedenemy.ApplyBleed(a / 2);
                    s++;
                    break;

                default:
                    WriteLine($"{r} rushed their enemy and stabbed doing {randStabDamage - d}!");
                    stabnbleedenemy.Takestab(randStabDamage);
                    stabnbleedenemy.ApplyBleed(a / 2);
                    s++;
                    break;
            }
        }
        ResetColor();
    }

    public void Takestab(int randStabDamage, Enemy enemy)
    {
        hp -= randStabDamage - d;
        if (d > 0)
        {
            t_Defense = 0;
            d = 0;
        }
    }

    public void YouCantStab()
    {
        if (s >= ms)
        {
            WriteLine("You cant use stab anymore.");
        }
    }

    public void ApplyBleed(int bleedDamage)
    {
        if (bleedturns <= 0)
        {
            bleedturns += 3;
        }
    }

    public void BleedCheck(Player bleedout, int bleedDamage)
    {
        if (bleedturns > 0)
        {
            hp -= bleedDamage;
            bleedturns--;
            WriteLine($"{r} took {bleedDamage} damage from bleeding.");
        }
        else if (bleedturns == 0)
        {
            bleedturns = 0;
        }
    }

    public void ParalyzingThrust(Player paraThrust)
    {
        int randThrustText = Random.Shared.Next(1, 4);
        double rng = Random.Shared.NextDouble() * 0.45 + 0.75;
        int ThrustDamage = (int)(1.20 * (int)a);
        int randThrustDamage = (int)(rng * ThrustDamage);

        if (thrustUses < maxthrustUses)
        {
            switch (randThrustText)
            {
                case 1:
                    WriteLine($"Like lightning, {r} dashed to their opponent and thrust their in there weakpoint doing {randThrustDamage - paraThrust.d}. ");
                    paraThrust.TakeThrust(randThrustDamage);
                    paraThrust.ApplyParalyze();
                    thrustUses++;

                    break;

                default:
                    {
                        WriteLine($"Like lightning, {r} dashed to their opponent and thrust their in there weakpoint doing {randThrustDamage - paraThrust.d} ");
                        paraThrust.TakeThrust(randThrustDamage);
                        paraThrust.ApplyParalyze();
                    }
                    thrustUses++;

                    break;

            }
        }
    }

    public void ApplyParalyze()
    {
        if (paraTurns < 1)
        {
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine($"{r} is parylyzed! They may be unable to move");
            ResetColor();
            paraTurns += 7;
        }
    }

    public void ParalyzeCheck()
    {
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine($"{r} is parylyzed!");
        WriteLine("They cant move!");
        ResetColor();
    }
    public void TakeThrust(int randThrustDamage)
    {
        hp -= randThrustDamage - d;
        if (d > 0)
        {
            t_Defense = 0;
            d = 0;
        }
    }
    public void DeathCheck(Player player)
    {
        if (hp <= 0)
        {
            hp = 0;
            WriteLine($"{r} has been defeated!");
            WriteLine("You died!");
            ReadKey();
            Environment.Exit(0);
        }
    }
}
