using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.IO;
using System;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading;
using DungeonLibrary;
using MonsterLibrary;

namespace MonsterHunting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //background music?
            Console.Title = "Monster Hunting World";
            Console.WriteLine("\n\n");
            Console.WriteLine(@"         _________________________________________
        /                                         \
       /  /\                                   /\  \
      /  /  \                                 /  \  \
     /  /    \                               /    \  \
    /  /      \       Monster Hunting       /      \  \
   /  /________\                           /________\  \
  /_____________\                         /_____________\
");
            Console.WriteLine("\n\n");
            Console.WriteLine(@"    As a new hunter walked through the bustling streets of the big city, they couldn't help but feel a mixture of excitement and nervousness. The buildings loomed overhead, and the sounds of the city were overwhelming after spending so much time in the wild. The hunter knew that registering with the hunting guild was the first step   towards establishing their reputation as a formidable warrior. As they made their way to the guild hall, they couldn't help but feel a sense of awe at the sheer size and grandeur  of the building. Inside, the hunter was met with the bustling energy of other hunters preparing for their next mission. As they approached the registration desk, the hunter took a deep breath, ready to begin their new career as a monster hunter.");

            //score variable. create variables for crafting rewards.
            int score = 0;
            bool questComplete = false;
            Monster monster = Monster.GetMonsterForest();
            Wyvern wyvern = (Wyvern)Wyvern.GetQuestWyvern();


            //Player customization - name, race
            Console.WriteLine("\nWelcome to the Guild Registration. Please fill out this form to become an official Guild Hunter.\n");
            Console.Write("What is your Name? ");
            string userName = Console.ReadLine();

            #region Race Selection
            var races = Enum.GetValues(typeof(Race));
            int index = 1;

            foreach (var race in races)
            {
                Console.WriteLine($"{index}) {race}");
                index++;
            }
            Console.WriteLine("What hunting tribe do you come from? (Number listed or first letter of the tribe)");
            Race tribeChoice = (Race)Console.ReadKey(true).Key;

            switch (tribeChoice)
            {
                case (Race)ConsoleKey.H:
                case (Race)ConsoleKey.D1:
                    tribeChoice = Race.Human;
                    Console.WriteLine($"A {tribeChoice} huh? ");
                    break;
                case (Race)ConsoleKey.W:
                case (Race)ConsoleKey.D2:
                    tribeChoice = Race.Wyverian;
                    Console.WriteLine($"A {tribeChoice} huh? ");
                    break;
                case (Race)ConsoleKey.L:
                case (Race)ConsoleKey.D3:
                    tribeChoice = Race.Lynian;
                    Console.WriteLine($"A {tribeChoice} huh? ");
                    break;
                case (Race)ConsoleKey.S:
                case (Race)ConsoleKey.D4:
                    tribeChoice = Race.ShakaLaka;
                    Console.WriteLine($"A {tribeChoice} huh? ");
                    break;
                default:
                    Console.WriteLine("ShakaLaka's never figure this one out");
                    tribeChoice = Race.ShakaLaka;
                    break;
            }
            Race userRace = (Race)tribeChoice;
            Console.WriteLine("Next...");
            Console.ReadKey();
            

            #endregion

            #region Weapon Select



            index = 1;
            var weps = Enum.GetValues(typeof(WeaponType));
            //Weapon selection - starting weapon class
            Console.WriteLine("What weapon do you want to start with? (Number listed or first letter of the weapon)");
            foreach (WeaponType weapon in weps)
            {
                Console.WriteLine($"{index}) {weapon}");
                index++;
            }
            WeaponType weaponClass = (WeaponType)Console.ReadKey(true).Key;
            Weapon starter = new();
            switch (weaponClass)
            {
                case (WeaponType)ConsoleKey.S:
                case (WeaponType)ConsoleKey.D1:
                    weaponClass = WeaponType.SwordAndShield;
                    Weapon ironSword = new Weapon("Iron Sword", WeaponType.SwordAndShield, false, 5, 8, 3);
                    starter = ironSword;
                    Console.WriteLine($"A {weaponClass} huh? ");
                    break;
                case (WeaponType)ConsoleKey.B:
                case (WeaponType)ConsoleKey.D4:
                    weaponClass = WeaponType.Bow;
                    Weapon ironBow = new Weapon("Iron Bow", WeaponType.Bow, true, 10, 9, 2);
                    starter = ironBow;
                    Console.WriteLine($"A {weaponClass} huh? ");
                    break;
                case (WeaponType)ConsoleKey.G:
                case (WeaponType)ConsoleKey.D2:
                    weaponClass = WeaponType.GreatSword;
                    Weapon ironGrtSwrd = new Weapon("Iron Great Sword", WeaponType.GreatSword, true, 0, 18, 5);
                    starter = ironGrtSwrd;
                    Console.WriteLine($"A {weaponClass} huh? ");
                    break;
                case (WeaponType)ConsoleKey.H:
                case (WeaponType)ConsoleKey.D3:
                    weaponClass = WeaponType.Hammer;
                    Weapon ironHammer = new Weapon("Iron Hammer", WeaponType.Hammer, true, 8, 12, 8);
                    starter = ironHammer;
                    Console.WriteLine($"A {weaponClass} huh? ");
                    break;
                default:
                    Console.WriteLine("The person at the counter pulls out a rusty sword and shield for you");
                    weaponClass = WeaponType.SwordAndShield;
                    Weapon rustSword = new Weapon("Iron Sword", WeaponType.SwordAndShield, false, 0, 5, 3);
                    starter = rustSword;
                    break;
            }
            WeaponType userClass = weaponClass;
            Console.ReadKey();
            Console.Clear();
            Weapon equippedWeapon = starter;

            //if (weaponClass == WeaponType.SwordAndShield)
            //{
            //    equippedWeapon = 
            //}
            #endregion

            Player player = new Player(userName, 50, 35, 55, userRace, userClass, equippedWeapon);







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
                        "I) Craft Items\n" +
                        "P) Player Info\n" +
                        "H) Heal\n" +
                        "D) Depart on Quest\n" +
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
                                        Console.ReadKey();
                                        break;
                                    case ConsoleKey.N:
                                        Console.WriteLine("Then you must depart from the city to begin your quest back at the Hub.\n" +
                                            "Press any key to return there.");
                                        Console.ReadKey();
                                        break;
                                }//end switch activeQuestChoice

                            }//end if activeQuest true
                            else
                            {
                                Console.WriteLine("\nWelcome to the Hunting Guild! Here are the quests available: \n" +
                                    "||   1) Hunt a Great Jagras!   ||" +
                                    "\n");
                                Console.Write("Select a Quest above to accept the request. (1-4) ");
                                ConsoleKey questSelect = Console.ReadKey(true).Key;
                                Console.WriteLine();
                                switch (questSelect)
                                {
                                    case ConsoleKey.D1:
                                        quest = 1;
                                        activeQuest = true;
                                        Console.WriteLine("Quest registration complete!\nReturn to the hub and depart from there when you are ready!.");
                                        Console.ReadKey();
                                        break;
                                    case ConsoleKey.D2:
                                        quest = 2;
                                        Console.WriteLine("Sorry this quest isn't available yet.");
                                        Console.ReadKey();
                                        break;
                                    case ConsoleKey.D3:
                                        quest = 3;
                                        Console.WriteLine("Sorry this quest isn't available yet.");
                                        Console.ReadKey();
                                        break;
                                    case ConsoleKey.D4:
                                        quest = 4;
                                        Console.WriteLine("Sorry this quest isn't available yet.");
                                        Console.ReadKey();
                                        break;
                                    default:
                                        Console.WriteLine("That quest is not available");
                                        Console.ReadKey();
                                        break;
                                }//end switch questSelect


                            }//end else to select quest


                            break;
                        case ConsoleKey.I://craft rewards from quests
                            Console.WriteLine("\nSorry Pal, The workshop isn't finished yet!\n");
                            break;
                        case ConsoleKey.P:
                            Console.WriteLine("Player Info");
                            Console.WriteLine(player);
                            Console.WriteLine($"You have completed {score} contract{(score == 1 ? "" : "s")}.");
                            break;
                        case ConsoleKey.H://set life to maxLife
                            player.Life = player.MaxLife;
                            Console.WriteLine("\nYou rest in your bed.\n");
                            break;
                        case ConsoleKey.D://depart on selected quest
                            if (activeQuest == true)
                            {
                                Console.Write("\nAre you ready to depart on your quest? (Y)es/(N)o: ");
                                ConsoleKey departConfirm = Console.ReadKey(true).Key;
                                switch (departConfirm)
                                {
                                    case ConsoleKey.Y:
                                        Console.WriteLine("\nPreparing for quest...\nPress any key to continue\n");
                                        Console.ReadKey();
                                        Console.WriteLine("\nDeparting on quest...\nPress any to begin\n");
                                        depart = true;
                                        Console.ReadKey();
                                        break;
                                    case ConsoleKey.N:
                                        Console.WriteLine("Make sure you are prepared before you depart.\nReturning to the Hub...Press" +
                                            "any key to continue");
                                        Console.ReadKey();
                                        break;
                                }//end switch activeQuestChoice

                            }//end if quest is active
                            else
                            {
                                Console.WriteLine("You must go to the quest board to accept a quest!\n" +
                                    "Press any key to return to the Hub...");
                                Console.ReadKey();
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
                                    Console.ReadKey();
                                    Console.WriteLine("\nYou completed " + score + " contract" + (score == 1 ? "" : "s") + "...But that's all behind you now" +
                                        "\nPress any key to quit\n");
                                    gameOver = true;
                                    depart = true;
                                    Console.ReadKey();
                                    break;
                                case ConsoleKey.N:
                                    Console.WriteLine("Returning to the Hub...Press" +
                                        "any key to continue");
                                    Console.ReadKey();
                                    break;
                            }//end switch exit game
                            break;
                        default://You're just pressing things aren't you
                            Console.WriteLine("You run into the pub and slam down a few ales");
                            break;
                    }//end switch hubChoice


                } while (!depart);//end dowhile hub


                //refactor to a quest zone that can pull the boss of the quest so it's DRY'er by calling on the
                //boss of the quest to a zone. Would want a GetRoomZone() and GetMonsterZone()
                int tracking = 0;

                while (quest == 1 && depart && !gameOver) //Quest 1 While loop
                {
                    Console.WriteLine(GetRoom());
                    //bool bossDead = false;
                    bool reload = false;
                    if (tracking >= 4)//Quest boss encounter
                    {
                        //create boss
                        monster = Monster.GetQuestWyvern();
                        Console.WriteLine($"You have finally tracked {monster.Name} down. It has spotted you and is now charging towards you!\n Continue...");
                        Console.ReadKey();
                    }//end if that confirms quest selected
                    else
                    {
                        monster = Monster.GetMonsterForest();
                        Console.WriteLine($"You spot a {monster.Name} while on the hunt" );
                    }
                    
                    do//encounter menu/loop
                    {
                        Console.WriteLine($"{monster.Name} targets you!");
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
                                Console.ResetColor();
                                //check if the monster is dead
                                if (monster.Life <= 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"\nYou killed {monster.Name}!\nPress any key to continue...");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                    if (monster.QuestTarget == true)
                                    {
                                        Console.WriteLine($"The {monster.Name} lets out a final roar before falling over and going limp.\n\n*****|| QUEST COMPLETE! ||*****\n\nReturning to town...");
                                        //bossDead = true;
                                        score++;
                                        depart = false;
                                        //wyvernToken to take to the hub and craft rewards
                                        reload = true;
                                    }
                                    else
                                    {
                                        tracking++;
                                        reload = true;
                                    }
                                }
                                if (player.Life <= 0)
                                {
                                    Console.WriteLine($"{player.Name} has fainted!\nA squad of highly trained Palicos from the guild pull you to safety!" +
                                        $"\nThey pack you in a cart and take you back to town");
                                    reload = true;
                                    depart = false;
                                    tracking = 0;
                                    Console.ReadKey(); 
                                    Console.Clear();
                                }
                                break;
                            case ConsoleKey.R: 
                                Console.WriteLine("Run Away!!\nBut " + monster.Name + " is right behind you!");
                                //Attack of opportunity
                                Combat.DoAttack(monster, player);

                                break;

                            case ConsoleKey.P: 
                                Console.WriteLine("Player Info");
                                Console.WriteLine(player);
                                Console.WriteLine($"Tracking level: {tracking}");
                                Console.WriteLine($"You have completed {score} contract{(score == 1 ? "" : "s")}.");
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
                                        Console.ReadKey();
                                        depart = false;//hub loop
                                        reload = true;
                                        break;
                                    case ConsoleKey.N:
                                        Console.WriteLine("Continuing the hunt...Press" +
                                            "any key to continue");
                                        Console.ReadKey();
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
                                        Console.ReadKey();
                                        Console.WriteLine("\nYou completed " + score + " contract" + (score == 1 ? "" : "s") + "...But that's all behind you now" +
                                    "\nPress any key to quit\n");
                                        gameOver = true;
                                        depart = true;
                                        reload = true;
                                        Console.ReadKey();
                                        break;
                                    case ConsoleKey.N:
                                        Console.WriteLine("Continuing the hunt...Press any key to continue");
                                        Console.ReadKey();
                                        break;
                                }//end switch quit game
                                break;
                            default:
                                Console.WriteLine("You dive out of the way.\n");
                                break;
                        }//end encounter switch

                    } while (!reload);//end quest boss

                }//end quest 1

                /*
                while (quest == 2 && depart && !gameOver)
                {

                }//end quest 2
                while (quest == 3 && depart && !gameOver)
                {

                }//end quest 3
                while (quest == 4 && depart && !gameOver)
                {

                }//end quest 4
                */

            } while (!gameOver);
        }//end Main()

        private static string GetRoom()
        {
            Random randRoom = new Random();
            string[] roomType =
            {
                "A trickling stream: Amidst the green foliage of the forest, a gentle stream flows through the rocks and boulders, creating a peaceful and soothing sound that can be heard from afar.",

                "A sunlit clearing: A bright beam of sunlight illuminates a small clearing, revealing a vibrant mix of wildflowers and grasses. It's a perfect spot for creatures to sit and soak up the warmth of the sun.",

                "A great mossy log: A large, moss-covered log provides a perfect spot for a peaceful rest amidst the lush forest.The moss adds a softness to the rough exterior of the log.",

                "A rocky outcrop: A jagged rocky outcrop provides a stunning vista over the surrounding forest, with breathtaking views that stretch out as far as the eye can see.",

                "A flying wyvern's nest: Nestled in the branches of a towering tree, a nest provides a glimpse into the lives of the forest's inhabitants. It's a reminder of the delicate balance of life within the forest.",

                "A mushroom patch: A patch of mushrooms thrives on the damp, shaded forest floor, adding a pop of color and texture to the otherwise muted greens and browns of the forest.",

                "A towering tree: A towering tree reaches towards the sky, its old trunk scuffed from rampaging monsters, covered in moss and lichen.It stands as a testament to the strength and resilience of the forest ecosystem."
            };
            int room = randRoom.Next(roomType.Length);
            string roomDescription = roomType[room];
            return roomDescription;
        }//end GetRoom()

    }//end class
}//end namespace