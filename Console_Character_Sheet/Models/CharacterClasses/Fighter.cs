using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheet.Models.CharacterClasses
{
    public class Fighter : Class
    {
        #region Fields
        public override string Name { get; }
        public override int BaseHitPoints { get; set; }
        public override List<string> StartingProficiencies { get; set; }
        #endregion

        #region Constructors
        public Fighter()
        {
            Name = "Fighter";
            BaseHitPoints = 10;
            StartingProficiencies = new List<string> { "Light Armor", "Medium Armor", "Heavy Armor", "Shields", "Simple Weapons", "Martial Weapons" };
        }
        #endregion

        #region Methods
        public override int hitPointsOnLevelUp()
        {
            Random random = new Random();
            int random1D10 = random.Next(1, 11);
            return random1D10;
        }
        #endregion
    }
}
