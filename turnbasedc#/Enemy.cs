using System;
using System.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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





    Random random = new Random();

    public int hp { get { return CurrentHealth; } }
    public string r { get { return User; } }

    public int d { get { return Defense; } }

    public int s { get { return stabUses; } }
    public int ms { get { return maxstabUses; } }

    public int a { get { return attackPower; } }

    public int t { get { return thrustUses; } }
    public int mt { get { return maxthrustUses; } 
    }


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
        double rng = random.NextDouble() * 0.45 + 0.75;

        // Calculate the random damage
        int RandomDamage = (int)(rng * attackPower);
        int paraChance = random.Next(1, 4);
        int AttackNumbers = random.Next(1, 8);
        enemy.bleedCheck(enemy, attackPower / 2);
        Console.ReadKey();
        if (paraChance == 4 & paraTurns > 0)
        {
            enemy.paralyzeCheck();
        }
        else
        {



            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            switch (AttackNumbers)
            {
                case 1:
                    Console.WriteLine($"{User} attacked and dealt {RandomDamage - player.d} damage!");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, enemy);
                    break;

                case 2:
                    Console.WriteLine($"{User} launched a focused strike and dealt {RandomDamage - player.d} damage!");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, enemy);
                    break;

                case 3:
                    Console.WriteLine($"{User} charged in confidently and dealt {RandomDamage - player.d} damage!");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, enemy);
                    break;

                case 4:
                    Console.WriteLine($"In a bold move, {User} inflicted {RandomDamage - player.d} damage!");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, enemy);
                    break;

                case 5:
                    Console.WriteLine($"With a calculated swing, {User} secured {RandomDamage - player.d} damage! ");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, enemy);
                    break;

                case 6:
                    Console.WriteLine($"{User} focused their energy into a swift strike, inflicting {RandomDamage - player.d} damage!");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, enemy);
                    break;

                case 7:
                    Console.WriteLine($"Executing a swift maneuver, {User} managed to inflict {RandomDamage - player.d} damage.");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, enemy);
                    break;


                case 8:
                    Console.WriteLine($"{User} lunged forward confidently, resulting in a solid hit of {RandomDamage - player.d} damage!");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, enemy);
                    break;

                default:
                    Console.WriteLine($"{User} lunged forward confidently, resulting in a solid hit of {RandomDamage - player.d} damage!");
                    unitthatsgetAttacking.TakeDamage(RandomDamage, enemy);
                    break;







            }
            Console.ResetColor();

        }
    }


    public void Defense_M(Player bleedout, Enemy enemy)
    {
        int TextsNumbers = random.Next(1, 8);
        int paraChance = random.Next(1, 4);
        enemy.bleedCheck(enemy, attackPower / 2);
        Console.ReadKey();
        if (paraChance == 4 & paraTurns > 0)
        {
            enemy.paralyzeCheck();
        }
        else
        {
            if (Defense <= 0)
            {
                Defense++;

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                switch (TextsNumbers)
                {
                    case 1:
                        Console.WriteLine($"{User} positioned their weapon to block, eyes locked on the enemy. ");
                        break;

                    case 2:
                        Console.WriteLine($"{User} stood resolute, weapon raised high in preparation.");
                        break;

                    case 3:
                        Console.WriteLine($"{User} positioned their weapon at the ready, eyes scanning for danger.");
                        break;

                    case 4:
                        Console.WriteLine($"{User} held their weapon firmly, creating an imposing stance.");
                        break;

                    case 5:
                        Console.WriteLine($"{User} brought their weapon up to guard their body from strikes. ");
                        break;

                    case 6:
                        Console.WriteLine($"{User} steadied their weapon, ready to deflect any attack.");
                        break;

                    case 7:
                        Console.WriteLine($"{User} gripped their weapon, poised defensivly.");
                        break;

                    case 8:
                        Console.WriteLine($"{User} steadied their weapon, maintaining balance and readiness.");
                        break;

                    default:
                        Console.WriteLine($"{User} steadied their weapon, maintaining balance and readiness.");
                        break;
                }

                Console.ResetColor();
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

        int stabtext = random.Next(1, 4);


        double rng = random.NextDouble() * 0.45 + 0.75;
        int StabDamage = (int)(1.15 * (int)attackPower);
        int randStabDamage = (int)(rng * StabDamage);

        stabnbleedenemy.bleedCheck(stabnbleedenemy, attackPower / 2);

        bleedturns = 0;

        int paraChance = random.Next(1, 4);
        if (paraChance == 4 & paraTurns > 0)
        {
            playerthrust.paralyzeCheck();
        }
        else
        {

            if (stabUses < maxstabUses)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                switch (stabtext)
                {
                    case 1:
                        Console.WriteLine($"{User} rushed their enemy and stabbed doing {randStabDamage - Defense}!");
                        stabnbleedenemy.takestab(randStabDamage);
                        stabnbleedenemy.ApplyBleed(attackPower / 2);
                        stabUses++;
                        break;

                    case 2:
                        Console.WriteLine($"{User} darted at their foe and thrust their weapon, dealing {randStabDamage - Defense} damage!");
                        stabnbleedenemy.takestab(randStabDamage);
                        stabnbleedenemy.ApplyBleed(attackPower / 2);
                        stabUses++;
                        break;

                    case 3:
                        Console.WriteLine($"{User} lunged at the opponent and stabbed, inflicting {randStabDamage - Defense} damage!");
                        stabnbleedenemy.takestab(randStabDamage);
                        stabnbleedenemy.ApplyBleed(attackPower / 2);
                        stabUses++;
                        break;

                    case 4:
                        Console.WriteLine($"{User} leaped into action and executed a stab, causing {randStabDamage - Defense} damage!");
                        stabnbleedenemy.takestab(randStabDamage);
                        stabnbleedenemy.ApplyBleed(attackPower / 2);
                        stabUses++;
                        break;




                    default:
                        Console.WriteLine($"{User} rushed their enemy and stabbed doing {randStabDamage - Defense} damage!");
                        stabnbleedenemy.takestab(randStabDamage);
                        stabnbleedenemy.ApplyBleed(attackPower / 2);
                        stabUses++;

                        break;
                }
            } Console.ResetColor();

        }
    }
    public void takestab(int randStabDamage)
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


    public void bleedCheck(Enemy bleedout, int bleeddamage)
    {


        if (bleedturns > 0)
        {
            CurrentHealth -= bleeddamage;
            bleedturns--;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"{User} took {bleeddamage} damage from bleeding.");
            Console.ResetColor();

        }
        else if (bleedturns == 0)
        {
            bleedturns = 0;


        }
    }
    public void paralyzingThrust(Player paraThrust, Enemy enemy)
    {

        int randThrustText = random.Next(1, 4);
        double rng = random.NextDouble() * 0.45 + 0.75;
        int ThrustDamage = (int)(1.20 * (int)attackPower);
        int randThrustDamage = (int)(rng * ThrustDamage);
        enemy.bleedCheck(enemy, attackPower / 2);

        if (thrustUses < maxthrustUses)
        {
            thrustUses++;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            switch (randThrustText)
            {
                case 1:
                    Console.WriteLine($"With the speed of lightning, {User} executed a paralyzing thrust, striking in an instant and possibly immobilizing their enemy, inflicting {randThrustDamage - paraThrust.d} damage.");
                    paraThrust.takeThrust(randThrustDamage);
                    paraThrust.applyParalyze();

                    break;

                case 2:
                    Console.WriteLine($"With a swift motion, {User} executed a paralyzing thrust, piercing through and possibly rendering their enemy immobilized, inflicting {randThrustDamage - paraThrust.d} damage.");
                    paraThrust.takeThrust(randThrustDamage);
                    paraThrust.applyParalyze();
                    break;

                case 3:
                    Console.WriteLine($"In a flash, {User} delivered a paralyzing thrust, puncturing flesh and possibly immobilizing the enemy, inflicting {randThrustDamage - paraThrust.d} damage.");
                    paraThrust.takeThrust(randThrustDamage);
                    paraThrust.applyParalyze();
                    break;

                case 4:
                    Console.WriteLine($"In a blur of action, {User} performed a paralyzing thrust, making contact and possibly immobilizing the adversary, inflicting {randThrustDamage - paraThrust.d} damage.");
                    paraThrust.takeThrust(randThrustDamage);
                    paraThrust.applyParalyze();
                    break;

                default:
                    {
                        Console.WriteLine($"Like lightning, {User} dashed to their opponent and thrust their in there weakpoint doing {randThrustDamage - paraThrust.d} ");
                        paraThrust.takeThrust(randThrustDamage);
                        paraThrust.applyParalyze();
                    }
                    break;

            }
            Console.ResetColor();
        }
    }

    public void applyParalyze()
    {
        if (paraTurns < 1)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{User} is parylyzed! They may be unable to move");
            Console.ResetColor();
            paraTurns += 7;
        }

    }

    public void paralyzeCheck()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"{User} is parylyzed!");
        Console.WriteLine("They cant move!");
        Console.ResetColor();

    }
    public void takeThrust(int randThrustDamage, Player player)
    {
        CurrentHealth -= randThrustDamage - Defense;
        if (t_Defense > 0)
        {
            Defense = 0;
            t_Defense = 0;

        }

    }
    public void deathCheck(Enemy enemy)
    {
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"{User} has been defeated! Nice job you deafeated your first foe.");
            Console.ResetColor();
        }

    }
}
