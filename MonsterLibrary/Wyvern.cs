using DungeonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MonsterLibrary
{
    public class Wyvern : Monster
    {
        private bool _enraged;
        public bool Enraged
        {
            get { return _enraged; }
            set => _enraged = Life < MaxLife % 20 ? true : false;
        }
        public Wyvern() { }

        public Wyvern (string name, int maxLife, int block, int hitChance, MonsterRace monsterRace, int maxDamage, int minDamage, bool questTarget , string description, bool enraged) : base(name,maxLife, block, hitChance, monsterRace, maxDamage, minDamage, questTarget, description)
        {
            QuestTarget = questTarget;
            Enraged = enraged;
        }
        public override string ToString()
        {
            return $@"
==========* {Name} *==========
~~~~~~~ {MonsterRace} ~~~~~~~
Health: {Life}/{MaxLife}
Damage: {MinDamage} - {MaxDamage}
Avoidance: {Block}
{(QuestTarget ? "Quest Target" : "")}
{(Enraged? "The monster is charging you in a blind rage!" : "The monster spots you!")}
Description:
{Description}";
        }//end ToString()

        public override int CalcDamage()
        {
            if (Enraged)
            {
                return new Random().Next(MinDamage+2, MaxDamage+5);
            }
            return base.CalcDamage();
        }
        public override int CalcHitChance()
        {
            if (Enraged)
            {
                return HitChance - 8;
            }
            return base.CalcHitChance();
        }


    }
}
