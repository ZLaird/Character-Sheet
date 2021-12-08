using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Character_Sheet.DAO
{
    public interface ICharacterDao
    {
        IList<Character> GetAllSavedCharacters();
    }
}
