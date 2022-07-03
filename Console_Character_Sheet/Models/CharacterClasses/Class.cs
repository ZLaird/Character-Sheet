using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheet.Models.CharacterClasses
{
    public abstract class Class : IClass
    {
        #region Fields
        public abstract string Name { get; }
        public abstract int BaseHitPoints { get; set; }
        public abstract List<string> StartingProficiencies { get; set; }
        //public List<EquipmentItem> StartingEquipment { get; set; }
        #endregion

        #region Methods
        public abstract int hitPointsOnLevelUp();
        #endregion
    }
}
