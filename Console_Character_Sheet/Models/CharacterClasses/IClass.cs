using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheet.Models.CharacterClasses
{
    public interface IClass
    {
        public string Name { get; }
        public string AsciiArt { get; set; }
        public int HitPoints { get; set; }
        public List<string> Proficiencies { get; set; }
        public List< Equipment { get; set; } //need to make item class

        public int hitPointsOnLevelUp();
    }
}
