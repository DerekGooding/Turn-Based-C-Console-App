namespace ConsoleAppTurnBased;

class Player
{
    //tommrow make list of text for all text in atack and defend
    private int attackPower;
    private int CurrentHealth;
    private int MaxHealth;
    private int Defense;
    private int t_Defense;
    private string User;

    private int stabUses;
    private int maxstabUses;
    private int thrustUses;
    private int maxthrustUses;
    private int bleedturns;
    private int paraTurns;

    public int hp => CurrentHealth;
    public string r => User;

    public int d => Defense;

    public int s => stabUses;
    public int ms => maxstabUses;

    public int a => attackPower;

    // ininiliaze fields
    public Player(int attackPower, int CurrentHealth, int MaxHealth, int Defense, int t_Defense, int maxstabUses, int stabUses, int bleedturns, int thrustUses, int maxthrustUses, int paraTurns, string User)
    {
        this.attackPower = attackPower;
        this.CurrentHealth = CurrentHealth;
        this.MaxHealth = MaxHealth;
        this.Defense = Defense;
        this.t_Defense = t_Defense;
        this.User = User;

        this.thrustUses = thrustUses;
        this.maxthrustUses = maxthrustUses;

        this.bleedturns = bleedturns;
        this.paraTurns = paraTurns;

        this.stabUses = stabUses;
        this.maxstabUses = maxstabUses;
    }

    public void Attack(Enemy unitthatsgetAttacking, Player player, Enemy enemy)
    {
        double rng = Random.Shared.NextDouble() * 0.45 + 0.75;

        // Calculate the random damage
        int RandomDamage = (int)(rng * attackPower);
        int paraChance = Random.Shared.Next(4);
        int AttackNumbers = Random.Shared.Next(1, 8);
        player.BleedCheck(player, attackPower / 2);

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
                    WriteLine($"{User} attacked and dealt {RandomDamage - unitthatsgetAttacking.d} damage!");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, player);
                    break;

                case 2:
                    WriteLine($"{User} launched a focused strike and dealt {RandomDamage - unitthatsgetAttacking.d} damage!");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, player);
                    break;

                case 3:
                    WriteLine($"{User} charged in confidently and dealt {RandomDamage - unitthatsgetAttacking.d} damage!");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, player);
                    break;

                case 4:
                    WriteLine($"In a bold move, {User} inflicted {RandomDamage - unitthatsgetAttacking.d} damage!");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, player);
                    break;

                case 5:
                    WriteLine($"With a calculated swing, {User} secured {RandomDamage - unitthatsgetAttacking.d} damage! ");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, player);
                    break;

                case 6:
                    WriteLine($"{User} focused their energy into a swift strike, inflicting {RandomDamage - unitthatsgetAttacking.d} damage!");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, player);
                    break;

                case 7:
                    WriteLine($"Executing a swift maneuver, {User} managed to inflict {RandomDamage - unitthatsgetAttacking.d} damage.");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, player);
                    break;

                case 8:
                    WriteLine($"{User} lunged forward confidently, resulting in a solid hit of {RandomDamage - unitthatsgetAttacking.d} damage!");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, player);
                    break;

                default:
                    WriteLine($"{User} lunged forward confidently, resulting in a solid hit of {RandomDamage - unitthatsgetAttacking.d} damage!");
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
        player.BleedCheck(player, attackPower / 2);
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

            if (Defense <= 0)
            {
                Defense ++;
                ForegroundColor = ConsoleColor.DarkBlue;

                switch (TextsNumbers)
                {
                    case 1:
                        WriteLine($"{User} held their weapon in a tactical grip, aimed for maximum control.  ");
                        break;

                    case 2:
                        WriteLine($"{User} twirled their weapon in a defensive dance. ");
                        break;

                    case 3:
                        WriteLine($"{User} stood at the ready, weapon anchored in a defensive position, poised for observation and protection.");
                        break;

                    case 4:
                        WriteLine($"The light glinted off {User}’s weapon, held protectively as they maintained a vigilant watch over their surroundings.");

                        break;

                    default:
                        WriteLine($"{User} steadied their weapon, maintaining balance and readiness.");
                        break;
                }

                ResetColor();
            }
        }
    }

    public void TakeDamage(int RandomDamage, Enemy enemy)
    {
        CurrentHealth -= RandomDamage - Defense;

        if (Defense > 0)
        {
            t_Defense = 0;
            Defense = 0;
        }
    }
    public void Stab(Enemy stabnbleedenemy, Player player)
    {
        int stabtext = Random.Shared.Next(1, 4);

        double rng = Random.Shared.NextDouble() * 0.45 + 0.75;
        int StabDamage = (int)(1.15 * (int)attackPower);
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
                    WriteLine($"{User} rushed their enemy and stabbed doing {randStabDamage - Defense}!");
                    stabnbleedenemy.Takestab(randStabDamage);
                    stabnbleedenemy.ApplyBleed(attackPower / 2);

                    stabUses++;
                    break;

                case 2:
                    WriteLine($"{User} darted at their foe and thrust their weapon, dealing {randStabDamage - Defense} damage!");
                    stabnbleedenemy.Takestab(randStabDamage);
                    stabnbleedenemy.ApplyBleed(attackPower / 2);
                    stabUses++;
                    break;

                case 3:
                    WriteLine($"{User} lunged at the opponent and stabbed, inflicting {randStabDamage - Defense} damage!");
                    stabnbleedenemy.Takestab(randStabDamage);
                    stabnbleedenemy.ApplyBleed(attackPower / 2);
                    stabUses++;
                    break;

                case 4:
                    WriteLine($"{User} leaped into action and executed a stab, causing {randStabDamage - Defense} damage!");
                    stabnbleedenemy.Takestab(randStabDamage);
                    stabnbleedenemy.ApplyBleed(attackPower / 2);
                    stabUses++;
                    break;

                default:
                    WriteLine($"{User} rushed their enemy and stabbed doing {randStabDamage - Defense}!");
                    stabnbleedenemy.Takestab(randStabDamage);
                    stabnbleedenemy.ApplyBleed(attackPower / 2);
                    stabUses++;
                    break;
            }
        }
        ResetColor();
    }

    public void Takestab(int randStabDamage, Enemy enemy)
    {
        CurrentHealth -= randStabDamage - Defense;
        if (Defense > 0)
        {
            t_Defense = 0;
            Defense = 0;
        }
    }

    public void YouCantStab()
    {
        if (stabUses >= maxstabUses)
        {
            WriteLine("You cant use stab anymore.");
        }
    }

    public void ApplyBleed(int bleeddamage)
    {
        if (bleedturns <= 0)
        {
            bleedturns += 3;
        }
    }

    public void BleedCheck(Player bleedout, int bleeddamage)
    {
        if (bleedturns > 0)
        {
            CurrentHealth -= bleeddamage;
            bleedturns--;
            WriteLine($"{User} took {bleeddamage} damage from bleeding.");
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
        int ThrustDamage = (int)(1.20 * (int)attackPower);
        int randThrustDamage = (int)(rng * ThrustDamage);

        if (thrustUses < maxthrustUses)
        {
            switch (randThrustText)
            {
                case 1:
                    WriteLine($"Like lightning, {User} dashed to their opponent and thrust their in there weakpoint doing {randThrustDamage - paraThrust.d}. ");
                    paraThrust.TakeThrust(randThrustDamage);
                    paraThrust.ApplyParalyze();
                    thrustUses++;

                    break;

                default:
                    {
                        WriteLine($"Like lightning, {User} dashed to their opponent and thrust their in there weakpoint doing {randThrustDamage - paraThrust.d} ");
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
            WriteLine($"{User} is parylyzed! They may be unable to move");
            ResetColor();
            paraTurns += 7;
        }
    }

    public void ParalyzeCheck()
    {
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine($"{User} is parylyzed!");
        WriteLine("They cant move!");
        ResetColor();
    }
    public void TakeThrust(int randThrustDamage)
    {
        CurrentHealth -= randThrustDamage - Defense;
        if (Defense > 0)
        {
            t_Defense = 0;
            Defense = 0;
        }
    }
    public void DeathCheck(Player player)
    {
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            WriteLine($"{User} has been defeated!");
            WriteLine("You died!");
            ReadKey();
            Environment.Exit(0);
        }
    }
}
