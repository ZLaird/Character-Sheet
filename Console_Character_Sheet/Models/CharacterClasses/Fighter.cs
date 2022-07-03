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
        public override int HitPoints { get; set; }
        public override List<string> Proficiencies { get; set; }
        #endregion

        #region Constructors
        public Fighter()
        {
            Name = "Fighter";
            HitPoints = 10;
            Proficiencies = new List<string> { "Light Armor", "Medium Armor", "Heavy Armor", "Shields", "simple Weapons", "martial Weapons" };
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
