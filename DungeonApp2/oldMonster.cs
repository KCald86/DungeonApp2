//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DungeonLibrary
//{
//    public class Monster : Character
//    {
//        //Props
//        //MinDamage int - Field - Business Rule : > 0 && < MaxDamage
//        //MaxDamage int
//        //Description string
//        #region Potential Expansion
//        //Add a WeaponType for a weakness. Or a resistance.
//        //You could then add
//        #endregion

//        //Unique Fields/Properties
//        public int MaxDamage { get; set; }
//        private int _minDamage;
//        public int MinDamage
//        {
//            get { return _minDamage; }
//            set
//            {
//                //if (value > 0 && value <= MaxDamage)
//                //{
//                //    _minDamage = value;
//                //}//end if
//                //else
//                //{
//                //    _minDamage = 1;
//                //}//end else
//                _minDamage = value > MaxDamage || value < 1 ? 1 : value;
//            }//end set
//        }//end MinDamage
//        public MonsterRace MonsterRace { get; set; }
//        public string Description { get; set; }


//        public Monster(string name, int maxLife, int block, int hitChance, MonsterRace monsterRace,  int maxDamage, int minDamage, string description) : base(name, maxLife, block, hitChance)
//        {
//            MonsterRace = monsterRace;
//            MaxDamage = maxDamage;
//            MinDamage = minDamage;
//            Description = description;
//        }

//        public Monster()
//        {
//            //Character fields
//            Name = "Aptonoth";
//            MaxLife = 8;
//            Block = 5;
//            HitChance = 8;
//            //Monster Fields
//            MonsterRace = MonsterRace.Herbivore;
//            MaxDamage = 3;
//            MinDamage = 1;
//            Description = "Aptonoth are cow-like creatures with leathery gray skin. They have a large, two-pronged crest protruding from their heads and a flat, spiked tail. These docile creatures are hunted for their meat by humans and other monsters. They always travel in groups. When one Aptonoth is threatened, others will run away for safety, but sometimes the alpha male of the herd will attempt to fight back before fleeing himself.";
//        }//default ctor

        
//        public override string ToString()
//        {
//            return $@"
//==========* {Name} *==========
//~~~~~~~ {MonsterRace} ~~~~~~~
//Health: {Life}/{MaxLife}
//Damage: {MinDamage} - {MaxDamage}
//Avoidance: {Block}
//Description:
//{Description}";
//        }//end ToString()

//        public override int CalcDamage()
//        {
//            return new Random().Next(MinDamage, MaxDamage + 1);
//        }//end CalcDamage()

//        //return a random number between your min and max dmg properties

//        public override int CalcBlock()
//        {
//            return Block;
//        }

//        public static Monster GetMonster()
//        {
//            Monster mTracks = new Monster();


//            List<Monster> monsters = new List<Monster>()
//            {
//                mTracks,
//            };
//            return monsters[new Random().Next(monsters.Count)];
//        }//end GetMonster()
//        public static Monster GetWyvern()
//        {
//            Monster grtJagaras = new Wyver
//        }


//    }
//}
