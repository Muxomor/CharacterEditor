using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal static class Experience
    {
        private static Dictionary<int, int> TotalExpDictionary = new Dictionary<int, int>() { { 1, 0 } };
        private static int NeededExpToLevel(int level)
        {
            return (level - 1) * 1000;
        }

        public static int TotalExpToNextLevel(this ICharacter character)
        {
            return TotalExpForLevel(character.Level +1);
        }
        public static int TotalExpForLevel(int level)
        {
            if(TotalExpDictionary.Keys.Contains(level))
            {
                return TotalExpDictionary[level];
            }
            else
            {
                int Exp = NeededExpToLevel(level) + TotalExpForLevel(level - 1);
                TotalExpDictionary[level] = Exp;
                return Exp;
            }
        }
    }
}
