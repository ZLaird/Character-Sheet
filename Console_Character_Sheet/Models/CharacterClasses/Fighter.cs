using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheet.Models.CharacterClasses
{
    public class Fighter : Class
    {
        public Fighter()
        {
            Name = "Fighter";
            HitPoints = 10;
            Proficiencies = new List<string> { "Light Armor", "Medium Armor", "Heavy Armor", "Shields", "simple Weapons", "martial Weapons" };

        }

        public override string Name { get; }

        public override string AsciiArt { get; set; } = @"
  / \
  | |
  |.|
  |.|
  |:|      __
,_|:|_,   /  )
  (Oo    / _I_
   +\ \  || __|
      \ \||___|
        \ /.:.\-\
         |.:. /-----\
         |___|::oOo::|
         /   |:<_T_>:|
        |_____\ ::: /
         | |  \ \:/
         | |   | |
         \ /   | \___
         / |   \_____\
         `-'";

        public override int HitPoints { get; set; }
        //need method to "roll" for it in each class

        public override List<string> Proficiencies { get; set; }
        //maybe split proficiencies into individual categories
        //need to prompt for and get bonus skills

        //public override List<string Equipment { get; set; } WIP
        //prompt for starting gear
        //need to check for proficiencies

        //include spells interface not on blueprint class for magic users

        //include unique skills/traits/abilities in each unique class


        public override int hitPointsOnLevelUp()
        {
            Random random = new Random();
            int random1D10 = random.Next(1, 11);
            return random1D10;
        }
    }
}
