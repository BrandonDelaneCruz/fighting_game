using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FightingGame.CharacterCreation
{
    public class CharacterInformation
    {
        public string characterName;
        public string characterClass;

        public int health;
        public int strength;
        public int dexterity;

        public void AskUserToCreateCharacter()
        {
            UserAssignsCharcterName();
            UserAssignsClassValuesForCharacter();
            PrintUsersCharacterSheet();
            AllowUserToEditCharacter();
            CharacterCreationUtilities.AskUserToContinue();
        }

        public void UserAssignsCharcterName()
        {
            Console.Clear();

            Console.WriteLine("Please Name your character.\n");
            Console.Write("Character name: ");
            characterName = Console.ReadLine();
        }

        public void UserAssignsClassValuesForCharacter()
        {
            Console.Clear();

            GameClasses usersClass = new GameClasses();

            string classUserSelected = CharacterCreationUtilities.UsersListOfOptionsForClassSelection();
            switch (classUserSelected)
            {
                case "1":
                    usersClass.Warrior();
                    characterClass = usersClass.className;
                    health = usersClass.health;
                    strength = usersClass.strength;
                    dexterity = usersClass.dexterity;
                    break;
                case "2":
                    usersClass.Rogue();
                    characterClass = usersClass.className;
                    health = usersClass.health;
                    strength = usersClass.strength;
                    dexterity = usersClass.dexterity;
                    break;
                default:
                    throw new ArgumentException("invalid");
            }
        }

        public void PrintUsersCharacterSheet()
        {
            Console.Clear();

            Console.WriteLine(
                $"Character Sheet\n" +
                "------------------\n\n" +
                $"Name: {characterName}\n" +
                $"Class: {characterClass}\n" +
                "------------------\n" +
                $"Health: {health}\n" +
                $"Strength: {strength}\n" +
                $"Dexterity: {dexterity}\n");
        }

        public void AllowUserToEditCharacter()
        {
            bool userWantsToKeepCharacter = CharacterCreationUtilities.IsCharcterSheetCorrect();

            UserSelectsFieldsToEdit(userWantsToKeepCharacter);
        }

        private void UserSelectsFieldsToEdit(bool userWantsToKeepCharacter)
        {
            while (!userWantsToKeepCharacter)
            {
                string usersSelectionOfFieldToEdit = CharacterCreationUtilities.UsersListOfOptionsForEditingCharacter();

                UserEditingFields(usersSelectionOfFieldToEdit);
                PrintUsersCharacterSheet();

                userWantsToKeepCharacter = CharacterCreationUtilities.IsCharcterSheetCorrect();
            }
        }

        private void UserEditingFields(string usersSelectionOfFieldToEdit)
        {
            switch (usersSelectionOfFieldToEdit)
            {
                case "1":
                    UserAssignsCharcterName();
                    break;
                case "2":
                    UserAssignsClassValuesForCharacter();
                    break;
                default:
                    throw new ArgumentException("Invalid Selection");
            }
        }
    }
}
