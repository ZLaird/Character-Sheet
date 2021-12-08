using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Character_Sheet.Character_Classes
{
    public interface IClass
    {
        public string Name { get; }
        public string AsciiArt { get; set; }
        public int HitPoints { get; set; }
        public List<string> Proficiencies { get; set; }
        //public List< Equipment { get; set; } WIP

        public int hitPointsOnLevelUp();
    }
}
