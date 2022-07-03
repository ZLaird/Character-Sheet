using System;
using CharacterSheet.Models;

namespace Console_Character_Sheet
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load/Make Character
            Menu menu = new Menu();
            Character currentCharacter = menu.GetNewOrReturningCharacter();

            //Display Character Overview
            Console.WriteLine($"{currentCharacter.Name}, Level {currentCharacter.Level} {currentCharacter.Race.Name} {currentCharacter.Class.Name}");

            //Character tests
            menu.characterTestMenu(currentCharacter);
        }
    }
}
