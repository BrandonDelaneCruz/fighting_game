using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using FightingGame.CharacterCreation;

namespace FightingGame.Game
{
    public class FightingGameFactory
    {
        public static void GameApplication()
        {
            RunGameUtilities.RunStartScreen();

            CharacterInformation player1 = new CharacterInformation();
            CharacterInformation player2 = new CharacterInformation();

            PlayersCreateThierCharacters(player1 , player2);
            PrintThePlayersCharacterSheets(player1, player2);
            WhichPlayerGoesFirst(player1, player2);

        }

        public static void PlayersCreateThierCharacters(CharacterInformation player1, CharacterInformation player2)
        {
            Console.Clear();
            PrintUtilities.PrintLinesInCenter("First player please press enter to create character.");
            Console.ReadLine();

            player1.AskUserToCreateCharacter();

            Console.Clear();
            PrintUtilities.PrintLinesInCenter("Second player please press enter to create character.");
            Console.ReadLine();

            player2.AskUserToCreateCharacter();
        }

        public static void PrintThePlayersCharacterSheets(CharacterInformation player1, CharacterInformation player2)
        {
            Console.Clear();
            Console.WriteLine("Player 1:");
            Console.WriteLine("------------------------");
            player1.PrintUsersCharacterSheet();

            Console.WriteLine("Player 2:");
            Console.WriteLine("------------------------");
            player2.PrintUsersCharacterSheet();
            CharacterCreationUtilities.AskUserToContinue();
        }

        public static void WhichPlayerGoesFirst(CharacterInformation player1, CharacterInformation player2)
        {
            int playerOrderSelector = RunGameUtilities.RandomNumberGenerator();

            if (playerOrderSelector <= 50)
            {

                CharacterInformation firstPLayer = player1;
                CharacterInformation secondPlayer = player2;
            }
            else if (playerOrderSelector >= 51)
            {
                CharacterInformation firstPLayer = player2;
                CharacterInformation secondPlayer = player1;
            }
        }

        public static void FightLoop(CharacterInformation player1, CharacterInformation player2)
        {
            while (player1.health <= 0 || player2.health <= 0)
            {
                Console.Clear();

                player1.PrintUsersCharacterSheet();
                Console.WriteLine();
                Console.WriteLine(
                    $"What will {player1.characterName} do?\n\n" +
                    "1: Attack\n" +
                    "2: Dodge\n");
                Console.Write("Select action: ");
                string player1Action = Console.ReadLine();
                
               if (player1Action == "1")
                {
                    int attackChanceofSucceeding = RunGameUtilities.AttackChance();
                    
                    if(attackChanceofSucceeding >= player2.dodgeChance)
                    {
                        player2.health -= player1.strength;
                        
                        if (player2.dodgeChance != 50)
                        {
                            player2.dodgeChance -= (player2.dexterity * 2);
                        }
                    }
                    else
                    {
                        Console.WriteLine(
                            "\n--------------------------\n" +
                            "Attack Missed!\n");
                        CharacterCreationUtilities.AskUserToContinue();
                    }
                    
                }
               else if(player1Action == "2")
                {
                    player1.dodgeChance += (player1.dodgeChance * 2);
                }
            }

            EndGame(player1, player2);
        }
        public static void EndGame(CharacterInformation player1, CharacterInformation player2)
        {
            if (player1.health <= 0)
            {

            }
            else if (player2.health <= 0)
            {

            }
        }
    }
}
