using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        //This is NOT a datatype class, so we will not have fields, properties, or constructors.
        //It's a warehouse of combat methods.

        //Handle one side of an attack.
        public static void DoAttack(Character attacker, Character defender)
        {
            //Adjust the hit chance
            int chance = attacker.CalcHitChance() - defender.CalcBlock();
            //Roll a random number between 1-100
            Random rand = new Random();
            int roll = rand.Next(1, 101);
            //The attacker "hits" if the roll is less than the adjusted hit chance.
            if (roll <= chance)
            {
                //Calculate the damage
                int damage = attacker.CalcDamage();
                #region Potential expansion - crits
                //if Roll > 80 or == 1, then increase damage by something.
                //damage *=2
                //if they fail, with a 100, maybe hurt the attacker instead of the defender(do this in the else)
                #endregion


                //Subtract that damage from the defender's life.
                defender.Life -= damage;
                //output the result.
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{attacker.Name} hit {defender.Name} for {damage} damage!");
            }
            else// the attacker "missed"
            {
                Console.WriteLine($"{attacker.Name} missed!");
                Console.WriteLine("Roll: " + roll);
                Console.WriteLine("Chance: " + chance);
            }

        }
        //Handle one round of battle, attacks from both sides
        public static void DoBattle(Player player, Monster monster)
        {
            //For this example, we will grant the player "initiative" by default.
            DoAttack(player, monster);
            //if the monster survives, let them attack.
            if (monster.Life > 0)
            {
                DoAttack(monster, player);
            }
        }
    }
}
