using System.Numerics;
using System;

namespace ConsoleAppTurnBased;

class Enemy(int attackPower,
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
    private int bleedturns = bleedturns;
    private int paraTurns = paraTurns;

    public int hp { get; private set; } = CurrentHealth;
    public string r { get; } = User;

    public int d { get; private set; } = Defense;

    public int s { get; private set; } = stabUses;
    public int ms { get; } = maxstabUses;

    public int a { get; } = attackPower;

    public int t { get; private set; } = thrustUses;
    public int mt { get; } = maxthrustUses;

    public void Attack(Player target, Player player, Enemy enemy)
    {
        double rng = Random.Shared.NextDouble() * 0.45 + 0.75;

        // Calculate the random damage
        int RandomDamage = (int)(rng * a);
        int paraChance = Random.Shared.Next(1, 4);
        int AttackNumbers = Random.Shared.Next(1, 8);
        enemy.BleedCheck(enemy, a / 2);
        ReadKey();
        if (paraChance == 4 && paraTurns > 0)
        {
            enemy.ParalyzeCheck();
        }
        else
        {
            ForegroundColor = ConsoleColor.DarkMagenta;
            int playerDamage = RandomDamage - player.d;
            string message = AttackNumbers switch
            {
                1 => $"{r} attacked and dealt {playerDamage} damage!",
                2 => $"{r} launched a focused strike and dealt {playerDamage} damage!",
                3 => $"{r} charged in confidently and dealt {playerDamage} damage!",
                4 => $"In a bold move, {r} inflicted {playerDamage} damage!",
                5 => $"With a calculated swing, {r} secured {playerDamage} damage! ",
                6 => $"{r} focused their energy into a swift strike, inflicting {playerDamage} damage!",
                7 => $"Executing a swift maneuver, {r} managed to inflict {playerDamage} damage.",
                8 => $"{r} lunged forward confidently, resulting in a solid hit of {playerDamage} damage!",
                _ => $"{r} lunged forward confidently, resulting in a solid hit of {playerDamage} damage!",
            };
            WriteLine(message);

            target.TakeDamage(RandomDamage, enemy);
            ResetColor();
        }
    }

    public void Defense_M(Player bleedout, Enemy enemy)
    {
        int TextsNumbers = Random.Shared.Next(1, 8);
        int paraChance = Random.Shared.Next(1, 4);
        enemy.BleedCheck(enemy, a / 2);
        ReadKey();
        if (paraChance == 4 && paraTurns > 0)
        {
            enemy.ParalyzeCheck();
        }
        else
        {
            if (d <= 0)
            {
                d++;

                ForegroundColor = ConsoleColor.DarkBlue;
                string message = TextsNumbers switch
                {
                    1 => $"{r} positioned their weapon to block, eyes locked on the enemy. ",
                    2 => $"{r} stood resolute, weapon raised high in preparation.",
                    3 => $"{r} positioned their weapon at the ready, eyes scanning for danger.",
                    4 => $"{r} held their weapon firmly, creating an imposing stance.",
                    5 => $"{r} brought their weapon up to guard their body from strikes. ",
                    6 => $"{r} steadied their weapon, ready to deflect any attack.",
                    7 => $"{r} gripped their weapon, poised defensivly.",
                    8 => $"{r} steadied their weapon, maintaining balance and readiness.",
                    _ => $"{r} steadied their weapon, maintaining balance and readiness.",
                };
                WriteLine(message);

                ResetColor();
            }
        }
    }

    public void TakeDamage(int RandomDamage, Player player)
    {
        hp -= RandomDamage - d;
        if (d > 0)
        {
            d = 0;
            t_Defense = 0;
        }
    }

    public void Stab(Enemy stabnbleedenemy, Player playerthrust)
    {
        int stabtext = Random.Shared.Next(1, 4);

        double rng = Random.Shared.NextDouble() * 0.45 + 0.75;
        int StabDamage = (int)(1.15 * (int)a);
        int randStabDamage = (int)(rng * StabDamage);

        stabnbleedenemy.BleedCheck(stabnbleedenemy, a / 2);

        bleedturns = 0;

        int paraChance = Random.Shared.Next(1, 4);
        if (paraChance == 4 && paraTurns > 0)
        {
            playerthrust.ParalyzeCheck();
        }
        else
        {
            if (s < ms)
            {
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
                        WriteLine($"{r} rushed their enemy and stabbed doing {randStabDamage - d} damage!");
                        stabnbleedenemy.Takestab(randStabDamage);
                        stabnbleedenemy.ApplyBleed(a / 2);
                        s++;

                        break;
                }
            }
            ResetColor();
        }
    }
    public void Takestab(int randStabDamage)
    {
        hp -= randStabDamage - d;
        if (t_Defense > 0)
        {
            d = 0;
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
            hp -= bleeddamage;
            bleedturns--;
            ForegroundColor = ConsoleColor.DarkRed;
            WriteLine($"{r} took {bleeddamage} damage from bleeding.");
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
        int ThrustDamage = (int)(1.20 * (int)a);
        int randThrustDamage = (int)(rng * ThrustDamage);
        enemy.BleedCheck(enemy, a / 2);

        if (t < mt)
        {
            t++;
            ForegroundColor = ConsoleColor.DarkYellow;
            int damage = randThrustDamage - paraThrust.d;
            string message = randThrustText switch
            {
                1 => $"With the speed of lightning, {r} executed a paralyzing thrust," +
                $" striking in an instant and possibly immobilizing their enemy, inflicting {damage} damage.",

                2 => $"With a swift motion, {r} executed a paralyzing thrust," +
                $" piercing through and possibly rendering their enemy immobilized, inflicting {damage} damage.",

                3 => $"In a flash, {r} delivered a paralyzing thrust," +
                $" puncturing flesh and possibly immobilizing the enemy, inflicting {damage} damage.",

                4 => $"In a blur of action, {r} performed a paralyzing thrust," +
                $" making contact and possibly immobilizing the adversary, inflicting {damage} damage.",

                _ => $"Like lightning, {r} dashed to their opponent and thrust their in there weakpoint doing {damage} "
            };

            WriteLine(message);

            paraThrust.TakeThrust(randThrustDamage);
            paraThrust.ApplyParalyze();
            ResetColor();
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
    public void TakeThrust(int randThrustDamage, Player player)
    {
        hp -= randThrustDamage - d;
        if (t_Defense > 0)
        {
            d = 0;
            t_Defense = 0;
        }
    }
    public void DeathCheck(Enemy enemy)
    {
        if (hp <= 0)
        {
            hp = 0;
            ForegroundColor = ConsoleColor.DarkRed;
            WriteLine($"{r} has been defeated! Nice job you deafeated your first foe.");
            ResetColor();
        }
    }
}
