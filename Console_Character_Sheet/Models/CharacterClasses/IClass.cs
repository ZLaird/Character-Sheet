using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheet.Models.CharacterClasses
{
    public interface IClass
    {
        #region Fields
        public string Name { get; }
        public int HitPoints { get; set; }
        public List<string> Proficiencies { get; set; }
        //public List< Equipment { get; set; } //need to make item class
        #endregion

        #region Methods
        public int hitPointsOnLevelUp();
        #endregion
    }
}
