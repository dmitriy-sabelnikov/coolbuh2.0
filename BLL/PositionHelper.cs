using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class PositionHelper
    {
        private static Dictionary<int, string> _NamePosition = new Dictionary<int, string>()
        {
            { 1, "Голова"},
            { 2, "Гол. бухгалтер"}
        };
        public static string GetNamePosByCd(int cd)
        {
            if (cd > _NamePosition.Count())
                return string.Empty;

            return _NamePosition[cd];
        }
        public static List<string> GetListNamePosition()
        {
            List<string> names = new List<string>();
            foreach (var pair in _NamePosition)
            {
                names.Add(pair.Value);
            }
            return names;
        }
        public static int GetCdPosByName(string nm)
        {
            if (nm == string.Empty)
                return 0;
            foreach (var pair in _NamePosition)
            {
                if (pair.Value == nm)
                    return pair.Key;
            }
            return 0;
        }
    }
}
