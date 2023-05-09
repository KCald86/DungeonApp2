using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //make it public
    public class Player : Character
    {
        public Race PlayerRace { get; set; }
        public WeaponType WeaponType { get; set; }
        public Weapon EquippedWeapon { get; set; }


        public Player(string name, int maxLife, int block, int hitChance, Race playerRace, WeaponType weaponType, Weapon equippedWeapon)
            : base(name, maxLife, block, hitChance)
        {
            PlayerRace = playerRace;
            WeaponType = weaponType;
            EquippedWeapon = equippedWeapon;

            #region Possible Expansion - Racial Bonuses

            //In program cs, you will have to show the user a list of races and let them pick one.
            //The reference for this is in your CSF2 Enums.cs for Classic Monsters
            switch (PlayerRace)
            {
                case Race.Human:
                    Block += 5;
                    MaxLife += 10;
                    Life = MaxLife;
                    //if (EquppedWeapon.Type == Weapon.Axe)
                    //{
                    //    EquippedWeapon.MaxDamage += 5;
                    //    EquippedWeapon.MinDamage += 2;
                    //}
                    break;
                default:
                    break;
            }


            #endregion

        }//end CTOR Player

        public override string ToString()
        {
            string raceDescription = "";
            switch (PlayerRace)
            {
                case Race.Human:
                    raceDescription = "Human";
                    break;
                case Race.Wyverian:
                    raceDescription = "Wyverian";
                    break;
                case Race.Lynian:
                    raceDescription = "Lynian";
                    break;
                case Race.ShakaLaka:
                    raceDescription = "ShakaLaka";
                    break;
                default:
                    break;
            }
            return base.ToString() + $"\nWeapon: {EquippedWeapon.Name}\n" +
                $"Description: \n{raceDescription}";
        }
        public override int CalcDamage()
        {
            return new Random().Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
        }
        public override int CalcHitChance()
        {
            //              HitChance + EquippedWeapon.BonusHitChance;
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
            //HitChance - Block = chance that you hit.
            //Roll a random number between 1 and 100. If it's LESS than the hit chance, we hit.
        }

        public override int CalcBlock()
        {
            return Block;
        }

    }
}
