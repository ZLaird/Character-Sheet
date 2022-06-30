using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterSheet.Models.CharacterClasses;
using CharacterSheet.Models.CharacterRaces;

namespace CharacterSheet.Models
{
    public class Menu
    {
        /// <summary>
        /// First user prompt, handles whether an existing character is loaded or new one made.
        /// </summary>
        public Character GetNewOrReturningCharacter()
        {
            Console.WriteLine("Hey, you! You're finally awake! You were crossing the border right?");

            string response = "";
            Character playerCharacter = new Character();

            while (response != "1" && response != "2")
            {
                Console.WriteLine("Returning Character(1)\nNew Character(2)\nQuit (0)");

                response = Console.ReadLine();
                if (response == "0")
                {
                    Environment.Exit(0);
                }
                else if (response == "1")
                {
                    playerCharacter = LoadCharacter();
                }
                else if (response == "2")
                {
                    playerCharacter = CreateNewCharacter();
                }
                else
                {
                    Console.WriteLine("Please enter either a 0,1,or 2");
                }
            }
            return playerCharacter;
        }

        /// <summary>
        /// Handles process and methods for loading an existing character.
        /// </summary>
        public Character LoadCharacter()
        {
            //WIP not implemented, workaround
            Character character = new Character();
            return character;
        }

        /// <summary>
        /// Handles process and methods for creating a new character.
        /// </summary>
        public Character CreateNewCharacter()
        {
            Console.WriteLine("WIP, character creation intro text.");
            Console.WriteLine("What is your name?");
            string characterName = Console.ReadLine();

            IRace characterRace = pickCharacterRace(characterName);

            IClass characterClass = pickCharacterClass(characterName);

            Character playerCharacter = new Character(characterName, characterRace, characterClass);
            return playerCharacter;
        }

        public IRace pickCharacterRace(string characterName)
        {
            Console.WriteLine("Please select a race(by number) from the following:");
            Console.WriteLine("1.) Human\n2.) Half-Elf\n3.) Elf\n4.) Dwarf");
            string characterRace = Console.ReadLine();
            if (characterRace == "1")
            {
                Console.WriteLine($"{characterName} is a Human.");
                Human humanCharacterRace = new Human();
                return humanCharacterRace;
            }
            else
            {
                //This is just so the code works for testing
                Console.WriteLine("WIP, you didn't pick a human but you got one because that's all I got so far.");
                Human humanCharacterRace = new Human();
                return humanCharacterRace;
            }
            //WIP add more races
        }

        public IClass pickCharacterClass(string characterName)
        {
            Console.WriteLine("Please select a class(by number) from the following:");
            Console.WriteLine("1.) Fighter\n2.) Rogue\n3.) Wizard");
            string characterClass = Console.ReadLine();

            if (characterClass == "1")
            {
                Console.WriteLine($"{characterName} is a Fighter.");
                Fighter fighterCharacterClass = new Fighter();
                return fighterCharacterClass;
            }
            else if (characterClass == "2")
            {
                //WIP
                Console.WriteLine($"{characterName} is a Fighter.");
                Fighter fighterCharacterClass = new Fighter();
                return fighterCharacterClass;
            }
            else if (characterClass == "3")
            {
                //WIP
                Console.WriteLine($"{characterName} is a Fighter.");
                Fighter fighterCharacterClass = new Fighter();
                return fighterCharacterClass;
            }
            else
            {
                //WIP
                Console.WriteLine($"{characterName} is a Fighter.");
                Fighter fighterCharacterClass = new Fighter();
                return fighterCharacterClass;
            }
        }

        //Test Methods
        
        public void characterTestMenu(Character character)
        {
            Console.WriteLine("Please Select an Option");
            Console.WriteLine("0.) Exit Program\n1.) Display Full Stats\n2.) Level Up\n3.) View Inventory");
            string response = "";
            response = Console.ReadLine();
            if(response == "0")
            {
                Environment.Exit(0);
            }
            else if(response == "1")
            {
                Console.WriteLine($"Level: {character.Level}");
                Console.WriteLine($"Current HitPoints: {character.CurrentHitPoints} | Max HitPoints: {character.MaxHitPoints}");
                Console.WriteLine("Ability Scores and Modifiers");
                foreach(KeyValuePair<string,int> score in character.AbilityScores)
                {
                    Console.WriteLine($"{score.Key}: {score.Value}, +{character.Modifiers[score.Key]}");
                }
            }
            else if (response == "2")
            {
                character.levelUp();
            }
            else if (response == "3")
            {
                //implement later
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
            characterTestMenu(character);
        }
    }
}
