using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheet.Models.CharacterRaces
{
    public class Human : Race
    {
        public override string Name { get; set; } = "Human";

        public override string Description { get; set; } = "Placeholder";

        // Ability Score Bonuses
        public override int StrengthBonus { get; set; } = 1;
        public override int DexterityBonus { get; set; } = 1;
        public override int ConstitutionBonus { get; set; } = 1;
        public override int IntelligenceBonus { get; set; } = 1;
        public override int WisdomBonus { get; set; } = 1;
        public override int CharismaBonus { get; set; } = 1;
        //

        public override List<string> Languages { get; set; }



        public override void SelectStartingLanguages()
        {
            if (Languages.Count == 0)
            {
                Languages.Add("Common");
                Console.WriteLine("The player character can speak Common and one additional Language. (Placeholder Table of Languages) Please select one of the above and type it out.");
                string secondLanguage = Console.ReadLine();
                Languages.Add(secondLanguage);
            }
            else
            {
                Console.WriteLine("The player character already has starting languages selected.");
            }
        }
    }
}
