using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingGame.CharacterCreation
{
    public class GameClasses
    {
        public string className;
        public int health;
        public int strength;
        public int dexterity;
        public int weaponDamage;
        public int dodgeChance;

        public void Warrior()
        {
            className = "Warrior";
            health = 150;
            strength = 20;
            dexterity = 10;
            weaponDamage = 20;
            dodgeChance = 25;
        }

        public void Rogue()
        {
            className = "Rogue";
            health = 100;
            strength = 10;
            dexterity = 20;
            weaponDamage = 15;
            dodgeChance = 25;
        }

    }
}
