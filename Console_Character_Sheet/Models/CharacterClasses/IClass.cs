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
        public int BaseHitPoints { get; }
        public List<string> StartingProficiencies { get; set; }
        //public List<EquipmentItem> StartingEquipment { get; set; }
        #endregion

        #region Methods
        public int hitPointsOnLevelUp();
        #endregion
    }
}
