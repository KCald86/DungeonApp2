namespace DungeonLibrary
{
    //abstract marks a class as "incomplete" it MUST be inherited somewhere to be used.
    //abstract classes cannot be created as an object using the "new()"
    public abstract class Character
    {
        //Funny People Collect Monkeys

        //Fields

        /*
            Create Fields and Properties for each of the following attributes.         
            life – int
            name – string
            hitChance – int
            block – int
            maxLife – int

            INCLUDE a business rule that Life cannot be more than MaxLife. If it is, set it equal to MaxLife.
         */

        //Properties

        //Constructors - Life = life; -> Life = MaxLife
        //No matter what, assign MaxLife BEFORE Life.

        //Methods

        //Field
        private int _maxLife;
        private string _name;
        private int _life;
        private int _hitChance;
        private int _block;


        //Props

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }//end Name

        public int MaxLife
        {
            get { return _maxLife; }
            set { _maxLife = value; }
        }//end MaxLife

        public int Life
        {
            get { return _life; }
            set
            {
                //if (value <= MaxLife)
                //{
                //    _life = value;
                //}//end if
                //else if (value > MaxLife)
                //{
                //    _life = _maxLife;
                //}//end else if
                _life = value <= MaxLife ? value : MaxLife;//Ternarie'd
            }//end set
        }//end Life

        public int Block
        {
            get { return _block; }
            set { _block = value; }
        }//end block

        public int HitChance
        {
            get { return _hitChance; }
            set { _hitChance = value; }
        }//end HitChance


        //CTOR
        public Character(string name, int maxLife, int block, int hitChance)
        {
            Name = name;
            Life = MaxLife = maxLife;
            //Life = life;
            Block = block;
            HitChance = hitChance;
        }//end FQ CTOR

        public Character() { }//default CTOR

        public abstract int CalcBlock();

        public virtual int CalcHitChance()
        {
            return HitChance;
        }//end HitChance()
        public virtual int CalcDamage()
        {
            return 0;
        }//end CalcDamage()
        public override string ToString()
        {
            return string.Format(//zero exception
                "{0}\n" +
                " Life: {2} / MaxLife: {1}\n" +
                "Block: {3}\t" +
                "HitChance: {4}",
                Name,
                MaxLife,
                Life,
                Block,
                HitChance);
        }//end ToString() 

        //an abstract method will have no functinality, no scopes;
        //it makes override MANDATORY

    }
}