using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Warrior :ICharacter
    {
        private ObjectId _id;

        public ObjectId Id { get => _id; set => _id = value; }
        public string Name { get; set; }

        public string ClassName => "Warrior";
        private int experience;
        private int level;
        public int Level
        {
            get => level;
            set
            {
                UnspendedPoints += (value - level) * 5;
                level = value;
            }
        }
        public int Experience
        {
            get => experience;
            set
            {
                experience = value;
                OnExpUpdate();
            }
        }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public int Vitality { get; set; }

        public int MinStrength => 30;
        public int MinDexterity => 15;
        public int MinIntelligence => 10;
        public int MinVitality => 25;
        public int MaxStrength => 250;
        public int MaxDexterity => 80;
        public int MaxIntelligence => 50;
        public int MaxVitality => 100;

        public int MaxHealth => 2 * Vitality + Strength;

        public int MaxMana => Intelligence;

        public int PhysicalDamage => Strength;

        public int Armor => Dexterity;

        public int MagicDamage => Intelligence / 5;

        public int MagicDefense => Intelligence / 2;

        public int CritChance => Dexterity / 5;

        public int CritDamage => Dexterity / 10;
        public int UnspendedPoints { get; set; }
        public Warrior()
        {
            Strength = MinStrength;
            Dexterity = MinDexterity;
            Intelligence = MinIntelligence;
            Vitality = MinVitality;
            Level = 1;
        }

        public void OnExpUpdate()
        {
            while(Experience >=this.TotalExpToNextLevel())
            {
                Level++;
            }
        }
    }
}
