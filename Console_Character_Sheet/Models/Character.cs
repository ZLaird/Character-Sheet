using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterSheet.Models.CharacterClasses;
using CharacterSheet.Models.CharacterRaces;

namespace CharacterSheet.Models
{
    public class Character
    {
        #region Fields
        /// <summary>
        /// Player Character's name.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Player Character's current level.
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// Player Character's race and associated stats/mechanics.
        /// </summary>
        public IRace Race{ get; set; }
        /// <summary>
        /// Player Character's class and associated stats/mechanics.
        /// </summary>
        public IClass Class { get; set; }
        /// <summary>
        /// Player Character's ability scores.
        /// </summary>
        public Dictionary<string, int> AbilityScores { get; set; }
        /// <summary>
        /// Player Character's ability score modifiers.
        /// </summary>
        public Dictionary<string, int> Modifiers { get; set; }
        /// <summary>
        /// Player Character's maximum hitpoints.
        /// </summary>
        public int MaxHitPoints { get; set; }
        /// <summary>
        /// Player Character's current hitpoints.
        /// </summary>
        public int CurrentHitPoints { get; set; }
        //WIP Additional Fields
        /*
         * Backstory
         * PhysicalCharacteristics/Personality
         */
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor for brand new Player Character.
        /// </summary>
        /// <param name="characterName"></param>
        /// <param name="characterRace"></param>
        /// <param name="characterClass"></param>
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
        /// Constructor for saved Player Character.
        /// </summary>
        public Character()
        {
            //WIP
        }
        #endregion

        #region Methods
        /// <summary>
        /// Simulates rolling a single die with the specified number of sides.
        /// </summary>
        /// <param name="dieSides"></param>
        /// <returns></returns>
        public int rollDx(int dieSides)
        {
            Random random = new Random();
            return random.Next(1, dieSides+1);
        }

        /// <summary>
        /// Simulates rolling for ability score when creating a character. Four d6 are rolled and the three highest values are added together to determine the value of the given ability score.
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
        /// Determines ability score modifiers to be applied to various character actions.
        /// </summary>
        /// <param name="abilityScoreValue"></param>
        /// <returns></returns>
        public int findModifier(int abilityScoreValue)
        {
            int modifier = 0;
            if(abilityScoreValue >= 18)
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
        ///Updates Player Character maximum hitpoints when leveling up.
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

        //Method used for initial testing. Remove later.
        /*
        public void displayStats()
        {
            Console.WriteLine($"{Name}, Level {Level} {Race.Name} {Class.Name}");
            Console.WriteLine($"Max Hit Points: {MaxHitPoints} | Current Hit Points");
        }
        */
        #endregion
    }
}
