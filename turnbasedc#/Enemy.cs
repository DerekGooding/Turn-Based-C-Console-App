namespace ConsoleAppTurnBased;

class Enemy
{
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

    public int t => thrustUses;
    public int mt => maxthrustUses;

    public Enemy(int attackPower, int CurrentHealth, int MaxHealth, int Defense, int t_Defense, int maxstabUses, int stabUses, int bleedturns, int thrustUses, int maxthrustUses, int paraTurns, string User)
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

    public void Attack(Player unitthatsgetAttacking, Player player, Enemy enemy)
    {
        double rng = Random.Shared.NextDouble() * 0.45 + 0.75;

        // Calculate the random damage
        int RandomDamage = (int)(rng * attackPower);
        int paraChance = Random.Shared.Next(1, 4);
        int AttackNumbers = Random.Shared.Next(1, 8);
        enemy.BleedCheck(enemy, attackPower / 2);
        ReadKey();
        if (paraChance == 4 && paraTurns > 0)
        {
            enemy.ParalyzeCheck();
        }
        else
        {
            ForegroundColor = ConsoleColor.DarkMagenta;

            switch (AttackNumbers)
            {
                case 1:
                    WriteLine($"{User} attacked and dealt {RandomDamage - player.d} damage!");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, enemy);
                    break;

                case 2:
                    WriteLine($"{User} launched a focused strike and dealt {RandomDamage - player.d} damage!");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, enemy);
                    break;

                case 3:
                    WriteLine($"{User} charged in confidently and dealt {RandomDamage - player.d} damage!");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, enemy);
                    break;

                case 4:
                    WriteLine($"In a bold move, {User} inflicted {RandomDamage - player.d} damage!");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, enemy);
                    break;

                case 5:
                    WriteLine($"With a calculated swing, {User} secured {RandomDamage - player.d} damage! ");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, enemy);
                    break;

                case 6:
                    WriteLine($"{User} focused their energy into a swift strike, inflicting {RandomDamage - player.d} damage!");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, enemy);
                    break;

                case 7:
                    WriteLine($"Executing a swift maneuver, {User} managed to inflict {RandomDamage - player.d} damage.");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, enemy);
                    break;

                case 8:
                    WriteLine($"{User} lunged forward confidently, resulting in a solid hit of {RandomDamage - player.d} damage!");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, enemy);
                    break;

                default:
                    WriteLine($"{User} lunged forward confidently, resulting in a solid hit of {RandomDamage - player.d} damage!");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, enemy);
                    break;

            }
            ResetColor();
        }
    }

    public void Defense_M(Player bleedout, Enemy enemy)
    {
        int TextsNumbers = Random.Shared.Next(1, 8);
        int paraChance = Random.Shared.Next(1, 4);
        enemy.BleedCheck(enemy, attackPower / 2);
        ReadKey();
        if (paraChance == 4 && paraTurns > 0)
        {
            enemy.ParalyzeCheck();
        }
        else
        {
            if (Defense <= 0)
            {
                Defense++;

                ForegroundColor = ConsoleColor.DarkBlue;
                switch (TextsNumbers)
                {
                    case 1:
                        WriteLine($"{User} positioned their weapon to block, eyes locked on the enemy. ");
                        break;

                    case 2:
                        WriteLine($"{User} stood resolute, weapon raised high in preparation.");
                        break;

                    case 3:
                        WriteLine($"{User} positioned their weapon at the ready, eyes scanning for danger.");
                        break;

                    case 4:
                        WriteLine($"{User} held their weapon firmly, creating an imposing stance.");
                        break;

                    case 5:
                        WriteLine($"{User} brought their weapon up to guard their body from strikes. ");
                        break;

                    case 6:
                        WriteLine($"{User} steadied their weapon, ready to deflect any attack.");
                        break;

                    case 7:
                        WriteLine($"{User} gripped their weapon, poised defensivly.");
                        break;

                    case 8:
                        WriteLine($"{User} steadied their weapon, maintaining balance and readiness.");
                        break;

                    default:
                        WriteLine($"{User} steadied their weapon, maintaining balance and readiness.");
                        break;
                }

                ResetColor();
            }
        }
    }

    public void TakeDamage(int RandomDamage, Player player)
    {
        CurrentHealth -= RandomDamage - Defense;
        if (Defense > 0)
        {
            Defense = 0;
            t_Defense = 0;
        }
    }

    public void Stab(Enemy stabnbleedenemy, Player playerthrust)
    {
        int stabtext = Random.Shared.Next(1, 4);

        double rng = Random.Shared.NextDouble() * 0.45 + 0.75;
        int StabDamage = (int)(1.15 * (int)attackPower);
        int randStabDamage = (int)(rng * StabDamage);

        stabnbleedenemy.BleedCheck(stabnbleedenemy, attackPower / 2);

        bleedturns = 0;

        int paraChance = Random.Shared.Next(1, 4);
        if (paraChance == 4 && paraTurns > 0)
        {
            playerthrust.ParalyzeCheck();
        }
        else
        {
            if (stabUses < maxstabUses)
            {
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
                        WriteLine($"{User} rushed their enemy and stabbed doing {randStabDamage - Defense} damage!");
                        stabnbleedenemy.Takestab(randStabDamage);
                        stabnbleedenemy.ApplyBleed(attackPower / 2);
                        stabUses++;

                        break;
                }
            }
            ResetColor();
        }
    }
    public void Takestab(int randStabDamage)
    {
        CurrentHealth -= randStabDamage - Defense;
        if (t_Defense > 0)
        {
            Defense = 0;
            t_Defense = 0;
        }

    }

    public void ApplyBleed(int bleeddamage)
    {
        if (bleedturns <= 0)
        {
            bleedturns += 2;
        }
    }

    public void BleedCheck(Enemy bleedout, int bleeddamage)
    {
        if (bleedturns > 0)
        {
            CurrentHealth -= bleeddamage;
            bleedturns--;
            ForegroundColor = ConsoleColor.DarkRed;
            WriteLine($"{User} took {bleeddamage} damage from bleeding.");
            ResetColor();
        }
        else if (bleedturns == 0)
        {
            bleedturns = 0;
        }
    }
    public void ParalyzingThrust(Player paraThrust, Enemy enemy)
    {
        int randThrustText = Random.Shared.Next(1, 4);
        double rng = Random.Shared.NextDouble() * 0.45 + 0.75;
        int ThrustDamage = (int)(1.20 * (int)attackPower);
        int randThrustDamage = (int)(rng * ThrustDamage);
        enemy.BleedCheck(enemy, attackPower / 2);

        if (thrustUses < maxthrustUses)
        {
            thrustUses++;
            ForegroundColor = ConsoleColor.DarkYellow;
            switch (randThrustText)
            {
                case 1:
                    WriteLine($"With the speed of lightning, {User} executed a paralyzing thrust, striking in an instant and possibly immobilizing their enemy, inflicting {randThrustDamage - paraThrust.d} damage.");
                    paraThrust.TakeThrust(randThrustDamage);
                    paraThrust.ApplyParalyze();

                    break;

                case 2:
                    WriteLine($"With a swift motion, {User} executed a paralyzing thrust, piercing through and possibly rendering their enemy immobilized, inflicting {randThrustDamage - paraThrust.d} damage.");
                    paraThrust.TakeThrust(randThrustDamage);
                    paraThrust.ApplyParalyze();
                    break;

                case 3:
                    WriteLine($"In a flash, {User} delivered a paralyzing thrust, puncturing flesh and possibly immobilizing the enemy, inflicting {randThrustDamage - paraThrust.d} damage.");
                    paraThrust.TakeThrust(randThrustDamage);
                    paraThrust.ApplyParalyze();
                    break;

                case 4:
                    WriteLine($"In a blur of action, {User} performed a paralyzing thrust, making contact and possibly immobilizing the adversary, inflicting {randThrustDamage - paraThrust.d} damage.");
                    paraThrust.TakeThrust(randThrustDamage);
                    paraThrust.ApplyParalyze();
                    break;

                default:
                    {
                        WriteLine($"Like lightning, {User} dashed to their opponent and thrust their in there weakpoint doing {randThrustDamage - paraThrust.d} ");
                        paraThrust.TakeThrust(randThrustDamage);
                        paraThrust.ApplyParalyze();
                    }
                    break;

            }
            ResetColor();
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
    public void TakeThrust(int randThrustDamage, Player player)
    {
        CurrentHealth -= randThrustDamage - Defense;
        if (t_Defense > 0)
        {
            Defense = 0;
            t_Defense = 0;
        }
    }
    public void DeathCheck(Enemy enemy)
    {
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            ForegroundColor = ConsoleColor.DarkRed;
            WriteLine($"{User} has been defeated! Nice job you deafeated your first foe.");
            ResetColor();
        }
    }
}
