using System;
using System.Collections.Generic;
using System.Data;
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
            StartFightScreen(player1, player2);
            FightLoop(player1, player2);
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
        
        public static void FightLoop(CharacterInformation player1, CharacterInformation player2)
        {
            int orderNum = RunGameUtilities.RandomNumberGenerator();

            if (orderNum >= 50)
            {
                while (player1.health > 0 && player2.health > 0)
                {
                    Player1Fightactions(player1, player2);
                    Player2FightActions(player1, player2);
                }
            }
            else
            {
                while (player1.health > 0 && player2.health > 0)
                {
                    Player2FightActions(player1, player2);
                    Player1Fightactions(player1, player2);
                }
            }
            

            EndGame(player1, player2);
        }
        public static void EndGame(CharacterInformation player1, CharacterInformation player2)
        {
            if (player1.health <= 0)
            {
                Console.Clear();

                PrintUtilities.PrintLinesInCenter($"{player2.characterName} Wins!");
            }
            else if (player2.health <= 0)
            {
                Console.Clear();

                PrintUtilities.PrintLinesInCenter($"{player1.characterName} Wins!");
            }
        }
        public static void Player1Fightactions(CharacterInformation player1, CharacterInformation player2)
        {
                if (player1.health > 0 && player2.health > 0)
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

                    if (attackChanceofSucceeding >= player2.dodgeChance)
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
                else if (player1Action == "2")
                {
                    player1.dodgeChance += (player1.dodgeChance * 2);
                }
        }
            
        }
        public static void Player2FightActions(CharacterInformation player1, CharacterInformation player2)
        {
                if (player1.health > 0 && player2.health > 0)
                {
                Console.Clear();

                player2.PrintUsersCharacterSheet();
                Console.WriteLine();
                Console.WriteLine(
                    $"What will {player2.characterName} do?\n\n" +
                    "1: Attack\n" +
                    "2: Dodge\n");
                Console.Write("Select action: ");
                string player1Action = Console.ReadLine();

                if (player1Action == "1")
                {
                    int attackChanceofSucceeding = RunGameUtilities.AttackChance();

                    if (attackChanceofSucceeding >= player1.dodgeChance)
                    {
                        player1.health -= player2.strength;

                        if (player1.dodgeChance != 50)
                        {
                            player1.dodgeChance -= (player1.dexterity * 2);
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
                else if (player1Action == "2")
                {
                    player2.dodgeChance += (player2.dodgeChance * 2);
                }
        }
        }

        public static void StartFightScreen(CharacterInformation player1, CharacterInformation player2)
        {
            Console.Clear();

            PrintUtilities.PrintLinesInCenter($"{player1.characterName} and {player2.characterName} see each other on the field of battle.", 
                "Who will win this fight to the death?", "\n\n\n", "PRESS ENTER TO FIGHT!");
            Console.ReadLine();
        }
    }
}
