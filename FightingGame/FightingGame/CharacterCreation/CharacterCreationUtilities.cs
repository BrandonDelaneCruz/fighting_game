using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingGame.CharacterCreation
{
    public class CharacterCreationUtilities
    {
        public static string UsersListOfOptionsForEditingCharacter()
        {
            Console.Clear();
            Console.WriteLine(
                "PLease select from the options below\n\n" +
                "1: Change name\n" +
                "2: Change class\n");
            Console.Write("\nSelect option: ");

            string optionUserSelected = Console.ReadLine();

            return optionUserSelected;
        }

        public static string UsersListOfOptionsForClassSelection()
        {
            Console.WriteLine(
                    "PLease select from the options below\n" +
                    "-------------------------------------------\n\n" +
                    "1: Warrior\n\n" +
                    "\t\"A sturdy and hardened fighter\n\twho does not falter in\n\tthe heat of battle.\"\n\n" +
                    "\tHealth: 150\n" +
                    "\tStrength: 20 (Increase attack power)\n" +
                    "\tDexterity: 10 (Increases the effectiveness of the dodge ability)\n\n" +
                    "-------------------------------------------\n\n" +
                    "2: Rogue\n\n" +
                    "\t\"A sly and nimble fighter\n\twho uses there quick reflexes\n\tto avoid attacks.\"\n\n" +
                    "\tHealth: 100\n" +
                    "\tStrength: 15 (Increase attack power)\n" +
                    "\tDexterity: 20 (Increases the effectiveness of the dodge ability)\n\n" +
                    "--------------------------------------------\n");

            Console.Write("\nId like to select Class: ");

            string classUserSelected = Console.ReadLine();

            return classUserSelected;
        }

        public static void AskUserToContinue()
        {
            Console.WriteLine();
            Console.Write("Press enter to continue.");
            Console.ReadLine();
        }

        public static bool IsCharcterSheetCorrect()
        {
            Console.WriteLine("\n");
            Console.Write("would you like to keep this character y/n? ");
            string UserResponce = Console.ReadLine();

            if (UserResponce == "y")
            {
                return true;
            }
            else if (UserResponce == "n")
            {
                return false;
            }

            throw new ArgumentException("Cannot parse answer into a y or n.");
        }
    }
}
