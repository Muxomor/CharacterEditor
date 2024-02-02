using MongoDB.Bson;

namespace WpfApp1
{
    public interface ICharacter
    {
        ObjectId Id { get; set; }
        string Name { get; set; }
        string ClassName { get; }
        int Level { get; set; }
        int Experience { get; set; }
        int UnspendedPoints { get; set; }

        int Strength { get; set; }
        int Dexterity { get; set; }
        int Intelligence { get; set; }
        int Vitality { get; set; }

        int MinStrength { get; }
        int MinDexterity { get; }
        int MinIntelligence { get; }
        int MinVitality { get; }
        int MaxStrength { get; }
        int MaxDexterity { get; }
        int MaxIntelligence { get; }
        int MaxVitality { get; }

        int MaxHealth { get; }
        int MaxMana { get; }
        int PhysicalDamage { get; }
        int Armor { get; }
        int MagicDamage { get; }
        int MagicDefense { get; }
        int CritChance { get; }
        int CritDamage { get; }


        void OnExpUpdate();
    }
}
