using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterSheet.Models.CharacterClasses;
using CharacterSheet.Models.CharacterRaces;
//using CharacterSheet.Models.CharacterRpTraits;

namespace CharacterSheet.Models
{
    public class Character
    {
        public Character(string characterName, IRace characterRace, IClass characterClass)
        {
            Name = characterName;
            Race = characterRace;
            Class = characterClass;
            AbilityScores = new Dictionary<string, int>
            {
                {"Strength", rollAbilityScore() + Race.StrengthBonus},
                {"Dexterity", rollAbilityScore() + Race.DexterityBonus},
                {"Constitution", rollAbilityScore() + Race.ConstitutionBonus},
                {"Intelligence", rollAbilityScore() + Race.IntelligenceBonus},
                {"Wisdom", rollAbilityScore() + Race.WisdomBonus},
                {"Charisma", rollAbilityScore() + Race.CharismaBonus}
            };
            Modifiers = new Dictionary<string, int>
            {
                {"Strength", findModifier(AbilityScores["Strength"])},
                {"Dexterity", findModifier(AbilityScores["Dexterity"])},
                {"Constitution", findModifier(AbilityScores["Constitution"])},
                {"Intelligence", findModifier(AbilityScores["Intelligence"])},
                {"Wisdom", findModifier(AbilityScores["Wisdom"])},
                {"Charisma", findModifier(AbilityScores["Charisma"])}
            };
            updateMaxHitPoints(); //also works to set initial(level 1) health
            CurrentHitPoints = MaxHitPoints;
            
        }
        /// <summary>
        /// Overflow for testing with incomplete methods
        /// </summary>
        public Character()
        {
            //used for testing, delete when character load implemented
        }

        /// <summary>
        /// I am Sparticus.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// PC's race and associated gameplay stats/mechanics.
        /// </summary>
        public IRace Race{ get; set; }
        //includes speed, size(both l/m/s and in feet)
        //languages and prompt for selecting starting contained within object
        //needs to have base stat modifiers to add to class
        //summary of race

        /// <summary>
        /// IClass object containing PC's combat focused stats, proficiencies, and abilities as well as class specific mechanics and initial set up prompts.
        /// </summary>
        public IClass Class { get; set; }
        //need to include method that acounts for level up stats/proficiencies/abilities here
        //will contain all stats/proficiencies/equipment/abilities/spells and methods to select and set them
        //should probably have level also

        public Dictionary<string, int> AbilityScores { get; set; }

        public Dictionary<string, int> Modifiers { get; set; }

        public int Level { get; set; } = 1;

        public int MaxHitPoints { get; set; }

        public int CurrentHitPoints { get; set; }

        /// <summary>
        /// PC's physical characteristics that are purely roleplay oriented.
        /// </summary>
        //public Appearance Appearance { get; set; } //WIP

        /// <summary>
        /// PC's personality traits, beliefs, and worldview.
        /// </summary>
        //public PersonalityAndBeliefs Personality { get; set; } //WIP

        /// <summary>
        /// PC's history prior to the current adventure.
        /// </summary>
        //public Backstory Backstory { get; set; } //WIP

        //methods

        /// <summary>
        /// Used to roll the various dice required for character creation and play. 
        /// This method accounts for max random size needing to be one larger than needed.
        /// E.G. Rolling a D6 would take 6 as max.
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        public int rollDice(int max)
        {
            Random random = new Random();
            return random.Next(1, max+1);
        }

        /// <summary>
        /// Simulates rolling 4D6 and summing the top 3 to determine ability scores in the Character constructor.
        /// </summary>
        /// <returns></returns>
        public int rollAbilityScore()
        {
            List<int> rolls = new List<int>();
            int smallestIndex = 100;
            int smallestNumber = 100;
            for(int i = 0; i < 4; i++)
            {
                int number = rollDice(6);
                if(number < smallestNumber)
                {
                    smallestIndex = i;
                    smallestNumber = number;
                }
                rolls.Add(number);
            }

            int sumOfTopThree = 0;
            for(int i = 0; i < 4; i++)
            {
                if(i != smallestIndex)
                {
                    sumOfTopThree += rolls[i];
                }
            }
            return sumOfTopThree;
        }

        /// <summary>
        /// Used to find/assign ability score modifiers in the constructors
        /// </summary>
        /// <param name="abilityScoreValue"></param>
        /// <returns></returns>
        public int findModifier(int abilityScoreValue)
        {
            int modifier = 0;
            if(abilityScoreValue == 18)
            {
                modifier = 4;
            }
            else if(abilityScoreValue >= 16)
            {
                modifier = 3;
            }
            else if(abilityScoreValue >= 14)
            {
                modifier = 2;
            }
            else if(abilityScoreValue >= 12)
            {
                modifier = 1;
            }
            return modifier;
        }

        /// <summary>
        /// Used to update character max health on character creation and level up.
        /// </summary>
        public void updateMaxHitPoints()
        {
            int maxhitpoints = Class.HitPoints + Modifiers["Constitution"];
            for(int i = 1; i < Level; i++)
            {
                maxhitpoints += Class.hitPointsOnLevelUp();
            }
            MaxHitPoints = maxhitpoints;
        }

        /// <summary>
        /// Handles leveling and associated dice roles for the character.
        /// </summary>
        public void levelUp()
        {
            Level++;
            updateMaxHitPoints();
            //add abilities/etc. later
        }

        public void displayStats()
        {
            Console.WriteLine($"{Name}, Level {Level} {Race.Name} {Class.Name}");
            Console.WriteLine($"Max Hit Points: {MaxHitPoints} | Current Hit Points");
        }
    }
}
