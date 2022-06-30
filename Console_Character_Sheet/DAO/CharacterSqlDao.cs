using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CharacterSheet.Models;

namespace CharacterSheet.DAO
{
    public class CharacterSqlDao : ICharacterDao
    {
        private readonly string connectionString;

        public CharacterSqlDao(string connString)
        {
            connectionString = connString;
        }

        public IList<Character> GetAllSavedCharacters()
        {
            List<Character> SavedCharacters = new List<Character>();

            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                //WIP Need to build server & set up race and class tables first
            }

            return SavedCharacters;
        }
    }
}
