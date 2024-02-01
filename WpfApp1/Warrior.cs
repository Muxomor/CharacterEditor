using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Warrior :ICharacter
    {
        private ObjectId _id;

        public ObjectId Id { get => _id; set => _id = value; }
        public string Name { get; set; }

        public string ClassName => "Warrior";

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Inteligence { get; set; }
        public int Vitality { get; set; }

        public int MinStrength => 30;
        public int MinDexterity => 15;
        public int MinInteligence => 10;
        public int MinVitality => 25;
        public int MaxStrength => 250;
        public int MaxDexterity => 80;
        public int MaxInteligence => 50;
        public int MaxVitality => 100;

        public int MaxHealth => 2 * Vitality + Strength;

        public int MaxMana => Inteligence;

        public int PhysicalDamage => Strength;

        public int Armor => Dexterity;

        public int MagicDamage => Inteligence / 5;

        public int MagicDafence => Inteligence / 2;

        public int CritChanse => Dexterity / 5;

        public int CritDamage => Dexterity / 10;

        public int Level { get; }
        public int TotalExp { get; set; }
        public int NeededExp { get; }
    }
}
