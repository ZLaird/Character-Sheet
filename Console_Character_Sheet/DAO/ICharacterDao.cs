using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterSheet.Models;

namespace CharacterSheet.DAO
{
    public interface ICharacterDao
    {
        IList<Character> GetAllSavedCharacters();
    }
}
