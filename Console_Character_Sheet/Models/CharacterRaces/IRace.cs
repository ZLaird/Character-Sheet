using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Character_Sheet.Character_Races
{
    public interface IRace
    {
        public string Name { get; set; }

        public string Description { get; set; }

        // Ability Score Bonuses from Race
        public int StrengthBonus { get; set; }
        public int DexterityBonus { get; set; }
        public int ConstitutionBonus { get; set; }
        public int IntelligenceBonus { get; set; }
        public int WisdomBonus { get; set; }
        public int CharismaBonus { get; set; }
        //

        public string Size { get; set; }

        public int BaseSpeed { get; set; }

        public bool Darkvision { get; set; }

        public List<string> Languages { get; set; }



        public void SelectStartingLanguages();
    }
}
