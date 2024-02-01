using MongoDB.Bson;

namespace WpfApp1
{
    public interface ICharacter
    {
        ObjectId Id { get; set; }
        string Name { get; set; }
        string ClassName { get; }
        int Strength { get; set; }
        int Dexterity { get; set; }
        int Inteligence { get; set; }
        int Vitality { get; set; }

        int MinStrength { get; }
        int MinDexterity { get; }
        int MinInteligence { get; }
        int MinVitality { get; }
        int MaxStrength { get; }
        int MaxDexterity { get; }
        int MaxInteligence { get; }
        int MaxVitality { get; }

        int MaxHealth { get; }
        int MaxMana { get; }
        int PhysicalDamage { get; }
        int Armor { get; }
        int MagicDamage { get; }
        int MagicDafence { get; }
        int CritChanse { get; }
        int CritDamage { get; }
        int Level { get; }
        int TotalExp { get; set; }
        int NeededExp { get; }
    
}
