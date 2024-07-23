using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingGame.Game
{
    public class RunGameUtilities
    {
        public static void RunStartScreen()
        {
            PrintUtilities.PrintLinesInCenter("Console Battle Sim","\"The most mid game ever...\"","\n\n\n","Press Enter");
            Console.ReadLine();
        }
        
        public static int RandomNumberGenerator()
        {
            Random random100 = new Random();
            int randomValue = random100.Next(1, 101);

            return randomValue;
        }

        public static int AttackChance()
        {
            Random random100 = new Random();
            int randomValue = random100.Next(1, 101);

            return randomValue;
        }

        public static int DodgeChance()
        {
            Random random100 = new Random();
            int randomValue = random100.Next(1, 50);

            return randomValue;
        }
    }
}
