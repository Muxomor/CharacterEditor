using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Wizard :ICharacter
    {
        private ObjectId _id;

        public ObjectId Id { get => _id; set => _id = value; }
        public string Name { get; set; }

        public string ClassName => "Wizard";

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Inteligence { get; set; }
        public int Vitality { get; set; }

        public int MinStrength => 15;
        public int MinDexterity => 20;
        public int MinInteligence => 35;
        public int MinVitality => 15;
        public int MaxStrength => 45;
        public int MaxDexterity => 80;
        public int MaxInteligence => 250;
        public int MaxVitality => 70;

        public int MaxHealth => (int)Math.Ceiling(Vitality * 1.4f) + Strength;

        public int MaxMana => Inteligence + Inteligence / 2;

        public int PhysicalDamage => Strength / 2;

        public int Armor => Dexterity;

        public int MagicDamage => Inteligence;

        public int MagicDafence => Inteligence;

        public int CritChanse => Dexterity / 5;

        public int CritDamage => Dexterity / 10;

        public int Level { get; }
        public int TotalExp { get; set; }
        public int NeededExp { get; }
    }
}
