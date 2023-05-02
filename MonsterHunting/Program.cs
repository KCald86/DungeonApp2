using System.Numerics;
using System.Threading;

namespace MonsterHunting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //background music?
            Console.Title = "Monster Hunting World";
            Console.WriteLine("fluff text entering the hub");

            //score variable. create variables for crafting rewards.
            int score = 0;

            //Player customization - name, race
            

            //Weapon selection - starting weapon class

            
            bool gameOver = false;
            do//Main Game Loop
            {
                bool depart = false;//initialize depart for hubChoice
                int quest = 0;//initialize quest to track what quest was selected
                bool activeQuest = false;//initialize activeQuest to keep track of having a selected quest
                
                do//Hub - select quest, craft items, heal between quests
                {

                    Console.Write("You find yourself at the Hunter's Guild Hub. From here you can:\n " +
                        "Q) Check out the Quest Board\n" +
                        "I) Craft Items" +
                        "H) Heal," +
                        "D) Depart on Quest" +
                        "X) Quit.");

                    //capture selection
                    ConsoleKey hubChoice = Console.ReadKey(true).Key;

                    Console.Clear();

                    switch (hubChoice)
                    {
                        case ConsoleKey.Q://quest select but can stay in the hub
                            if (activeQuest == true)//if a quest was selected ask user if they want to cancel the quest
                            {
                                Console.Write("Do you want to Cancel your quest? \t(Y)es/(N)o");
                                ConsoleKey activeQuestChoice = Console.ReadKey(true).Key;
                                switch (activeQuestChoice)
                                {
                                    case ConsoleKey.Y:
                                        Console.WriteLine("You have canceled your selected quest\nPress any key to return to the hub...");
                                        activeQuest = false;
                                        Console.ReadKey(true);
                                        break;
                                    case ConsoleKey.N:
                                        Console.WriteLine("Then you must depart from the city to begin your quest back at the Hub.\n" +
                                            "Press any key to return there.");
                                        Console.ReadKey(true);
                                        break;
                                }//end switch activeQuestChoice

                            }//end if activeQuest true
                            else
                            {
                                Console.WriteLine("Welcome to the Hunting Guild! Here are the quests available: " +
                                    "\n\n\t");
                                Console.Write("Select a Quest above to accept the request. (1-4) ");
                                ConsoleKey questSelect = Console.ReadKey(true).Key;
                                switch (questSelect)
                                {
                                    case ConsoleKey.Oem1:
                                        quest = 1;
                                        Console.WriteLine("Quest registration complete. Depart from the hub to begin your hunt.");
                                        Console.ReadKey (true);
                                        break;
                                    case ConsoleKey.Oem2:
                                        quest = 2;
                                        Console.WriteLine("Quest registration complete. Depart from the hub to begin your hunt.");
                                        Console.ReadKey(true);
                                        break;
                                    case ConsoleKey.Oem3:
                                        quest = 3;
                                        Console.WriteLine("Quest registration complete. Depart from the hub to begin your hunt.");
                                        Console.ReadKey(true);
                                        break;
                                    case ConsoleKey.Oem4:
                                        quest = 4;
                                        Console.WriteLine("Quest registration complete. Depart from the hub to begin your hunt.");
                                        Console.ReadKey(true);
                                        break;
                                    default:
                                        Console.WriteLine("That quest is not available");
                                        Console.ReadKey(true);
                                        break;
                                }//end switch questSelect


                            }//end else to select quest


                            break;
                        case ConsoleKey.I://craft rewards from quests

                            break;
                        case ConsoleKey.H://set life to maxLife

                            break;
                        case ConsoleKey.D://depart on selected quest
                            if (activeQuest == true)
                            {
                                Console.Write("Are you ready to depart on your quest? (Y)es/(N)o");
                                ConsoleKey departConfirm = Console.ReadKey(true).Key;
                                switch (departConfirm)
                                {
                                    case ConsoleKey.Y:
                                        Console.WriteLine("\nPreparing for quest...\nPress any key to continue\n");
                                        Console.ReadKey(true);
                                        Console.WriteLine("\nDeparting on quest...\nPress any to begin\n");
                                        depart = true;
                                        Console.ReadKey(true);
                                        break;
                                    case ConsoleKey.N:
                                        Console.WriteLine("Make sure you are prepared before you depart.\nReturning to the Hub...Press" +
                                            "any key to continue");
                                        Console.ReadKey(true);
                                        break;
                                }//end switch activeQuestChoice

                            }//end if quest is active
                            else
                            {
                                Console.WriteLine("You must go to the quest board to accept a quest!\n" +
                                    "Press any key to return to the Hub...");
                                Console.ReadKey(true);
                            }//end else no quest selected

                            break;
                        case ConsoleKey.X://quit game make sure it quits out completely below by checking for gameOver and depart
                        case ConsoleKey.Escape:
                            Console.Write("Retire from the Hunting Guild? (Y)es/(N)o");
                            ConsoleKey quitConfirm = Console.ReadKey(true).Key;
                            switch (quitConfirm)
                            {
                                case ConsoleKey.Y:
                                    Console.WriteLine("\nYou turn in your badge and weapon...\nPress any key to continue\n");
                                    Console.ReadKey(true);
                                    Console.WriteLine("\nYou completed " +score+"contracts...But that's all behind you now" +
                                        "\nPress any key to quit\n");
                                    gameOver = true;
                                    depart = true;
                                    Console.ReadKey(true);
                                    break;
                                case ConsoleKey.N:
                                    Console.WriteLine("Returning to the Hub...Press" +
                                        "any key to continue");
                                    Console.ReadKey(true);
                                    break;
                            }//end switch exit game
                            break;
                        default://You're just pressing things aren't you
                            Console.WriteLine("You run into the pub and slam down a few ales");
                                break;
                    }//end switch hubChoice


                } while (!depart || !gameOver);//end dowhile hub


                //refactor to a quest zone that can pull the boss of the quest so it's DRY'er by calling on the
                //boss of the quest to a zone. Would want a GetRoomZone() and GetMonsterZone()
                int tracking = 0;
                while (quest == 1 && depart && !gameOver)
                {
                    Console.WriteLine("fluff text to start the hunt/about monster");
                    //Generate a room

                    //Generate a Monster

                    bool reload = false;//controll the encounter loop
                    do//encounter menu/loop
                    {
                        //print the menu
                        Console.WriteLine("\nPlease choose an action:\n" +
                            "A) Attack\n" +
                            "R) Run Away\n" +
                            "P) Player Info\n" +
                            "M) Monster Info\n" +
                            "X) Exit\n");
                        //capture their selection
                        ConsoleKey choice = Console.ReadKey(true).Key;
                        //clear the console
                        Console.Clear();

                        switch (choice)
                        {
                            case ConsoleKey.A: //TODO Combat
                                #region exp: Racial/weapon bonus
                                //Give certain races or characters with acertain weapon an advantage.
                                //if the player race is dark elf, then combat.doattack(player, monster)
                                #endregion
                                Combat.DoBattle(player, monster);

                                //check if the monster is dead
                                if (monster.Life <= 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"\nYou killed {monster.Name}!\n");
                                    Console.ResetColor();
                                    reload = true;
                                    score++;
                                    //combat rewards, exp, loot, money, chance to heal
                                }
                                break;
                            case ConsoleKey.R: //TODO Run Away
                                Console.WriteLine("Run Away!!");
                                //Attack of opportunity
                                Combat.DoAttack(monster, player);

                                break;

                            case ConsoleKey.P: //TODO Player
                                Console.WriteLine("Player Info");
                                Console.WriteLine(player);
                                Console.WriteLine("You have defeated " + score + " monsters.");
                                break;

                            case ConsoleKey.M: //TODO Monster
                                Console.WriteLine("Monster Info");
                                Console.WriteLine(monster);

                                break;


                            case ConsoleKey.X://abandon quest
                                Console.Write("Abandon Quest and return to town? (Y)es/(N)o");
                                ConsoleKey abandonConfirm = Console.ReadKey(true).Key;
                                switch (abandonConfirm)
                                {
                                    case ConsoleKey.Y:
                                        Console.WriteLine("\nYou crumple up the quest paper. This monster is someone else's problem now!...\nPress any key to continue\n");
                                        Console.ReadKey(true);
                                        //Console.WriteLine("\nYou completed " + score + "contracts...But that's all behind you now.\nPress any key to quit\n");
                                        //gameOver = true;
                                        depart = false;
                                        reload = true;
                                        Console.ReadKey(true);
                                        break;
                                    case ConsoleKey.N:
                                        Console.WriteLine("Continuing the hunt...Press" +
                                            "any key to continue");
                                        Console.ReadKey(true);
                                        break;
                                }//end switch abandon quest
                                break;

                            case ConsoleKey.Escape://quit game
                                Console.Write("Are you giving up the life of a Hunter? (Y)es/(N)o");
                                ConsoleKey quitConfirm = Console.ReadKey(true).Key;
                                switch (quitConfirm)
                                {
                                    case ConsoleKey.Y:
                                        Console.WriteLine("\nYou run for the hills abandoning all your gear...\nPress any key to continue\n");
                                        Console.ReadKey(true);
                                        Console.WriteLine("\nYou completed " + score + "contracts...But that's all behind you now" +
                                            "\nPress any key to quit\n");
                                        gameOver = true;
                                        depart = true;
                                        reload = true;
                                        Console.ReadKey(true);
                                        break;
                                    case ConsoleKey.N:
                                        Console.WriteLine("Continuing the hunt...Press any key to continue");
                                        Console.ReadKey(true);
                                        break;
                                }//end switch quit game
                                break;


                               

                            default:
                                Console.WriteLine("You dive out of the way.\n");
                                break;
                        }//end encounter switch

                    } while (!reload);//end quest encounters
                    if (tracking == 4 && !depart && !gameOver)//Quest boss encounter
                    {
                        //create boss nest

                        //create boss

                        bool bossDead = false;
                        do//encounter menu/loop
                        {
                            //print the menu
                            Console.WriteLine("\nPlease choose an action:\n" +
                                "A) Attack\n" +
                                "R) Run Away\n" +
                                "P) Player Info\n" +
                                "M) Monster Info\n" +
                                "X) Exit\n");
                            //capture their selection
                            ConsoleKey choice = Console.ReadKey(true).Key;
                            //clear the console
                            Console.Clear();

                            switch (choice)
                            {
                                case ConsoleKey.A: //TODO Combat
                                    #region exp: Racial/weapon bonus
                                    //Give certain races or characters with acertain weapon an advantage.
                                    //if the player race is dark elf, then combat.doattack(player, monster)
                                    #endregion
                                    Combat.DoBattle(player, monster);

                                    //check if the monster is dead
                                    if (monster.Life <= 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($"\nYou killed {monster.Name}!\n");
                                        Console.ResetColor();
                                        bossDead = true;
                                        score++;
                                        //combat rewards, exp, loot, money, chance to heal
                                    }
                                    break;
                                case ConsoleKey.R: //TODO Run Away
                                    Console.WriteLine("Run Away!!");
                                    //Attack of opportunity
                                    Combat.DoAttack(monster, player);

                                    break;

                                case ConsoleKey.P: //TODO Player
                                    Console.WriteLine("Player Info");
                                    Console.WriteLine(player);
                                    Console.WriteLine("You have defeated " + score + " monsters.");
                                    break;

                                case ConsoleKey.M: //TODO Monster
                                    Console.WriteLine("Monster Info");
                                    Console.WriteLine(monster);

                                    break;


                                case ConsoleKey.X://abandon quest
                                    Console.Write("Abandon Quest and return to town? (Y)es/(N)o");
                                    ConsoleKey abandonConfirm = Console.ReadKey(true).Key;
                                    switch (abandonConfirm)
                                    {
                                        case ConsoleKey.Y:
                                            Console.WriteLine("\nYou crumple up the quest paper. This monster is someone else's problem now!...\nPress any key to continue\n");
                                            Console.ReadKey(true);
                                            //Console.WriteLine("\nYou completed " + score + "contracts...But that's all behind you now.\nPress any key to quit\n");
                                            //gameOver = true;//main loop
                                            depart = false;//hub loop
                                            reload = true;//encounter loop
                                            bossDead = true;//boss loop
                                            Console.ReadKey(true);
                                            break;
                                        case ConsoleKey.N:
                                            Console.WriteLine("Continuing the hunt...Press" +
                                                "any key to continue");
                                            Console.ReadKey(true);
                                            break;
                                    }//end switch abandon quest
                                    break;

                                case ConsoleKey.Escape://quit game
                                    Console.Write("Are you giving up the life of a Hunter? (Y)es/(N)o");
                                    ConsoleKey quitConfirm = Console.ReadKey(true).Key;
                                    switch (quitConfirm)
                                    {
                                        case ConsoleKey.Y:
                                            Console.WriteLine("\nYou run for the hills abandoning all your gear...\nPress any key to continue\n");
                                            Console.ReadKey(true);
                                            Console.WriteLine("\nYou completed " + score + "contracts...But that's all behind you now" +
                                                "\nPress any key to quit\n");
                                            gameOver = true;
                                            depart = true;
                                            reload = true;
                                            Console.ReadKey(true);
                                            break;
                                        case ConsoleKey.N:
                                            Console.WriteLine("Continuing the hunt...Press any key to continue");
                                            Console.ReadKey(true);
                                            break;
                                    }//end switch quit game
                                    break;




                                default:
                                    Console.WriteLine("You dive out of the way.\n");
                                    break;
                            }//end encounter switch

                        } while (!bossDead);//end quest boss
                    }//end if that confirms quest selected




                }//end quest 1
                while (quest == 2 && depart && !gameOver)
                {

                }//end quest 2
                while (quest == 3 && depart && !gameOver)
                {

                }//end quest 3
                while (quest == 4 && depart && !gameOver)
                {

                }//end quest 4


            } while (!gameOver);



        }
    }
}