using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheet.Models.CharacterClasses
{
    public abstract class Class : IClass
    {
        public abstract string Name { get; }
        //will already have at this point

        public virtual string AsciiArt {get;set;}

        public abstract int HitPoints { get; set; }
        //need method to "roll" for it in each class

        public abstract List<string> Proficiencies { get; set; }
        //maybe split proficiencies into individual categories
        //need to prompt for and get bonus skills

        public abstract string Equipment { get; set; } //WIP
        //prompt for starting gear
        //need to check for proficiencies

        //include spells interface not on blueprint class for magic users

        //include unique skills/traits/abilities in each unique class

        public abstract int hitPointsOnLevelUp();
    }
}
