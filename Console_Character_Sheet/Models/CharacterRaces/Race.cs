using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Character_Sheet.Character_Races
{
    public abstract class Race : IRace
    {
        public abstract string Name { get; set; }

        public abstract string Description { get; set; }

        // Ability Score Bonuses from Race
        public virtual int StrengthBonus { get; set; } = 0;
        public virtual int DexterityBonus { get; set; } = 0;
        public virtual int ConstitutionBonus { get; set; } = 0;
        public virtual int IntelligenceBonus { get; set; } = 0;
        public virtual int WisdomBonus { get; set; } = 0;
        public virtual int CharismaBonus { get; set; } = 0;
        //

        public virtual string Size { get; set; } = "Medium";

        public virtual int BaseSpeed { get; set; } = 30;

        public virtual bool Darkvision { get; set; } = false;

        public abstract List<string> Languages { get; set; }



        public abstract void SelectStartingLanguages();
    }
}
