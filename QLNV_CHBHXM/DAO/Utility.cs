using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNV_CHBHXM.DAO
{
    public static class Utility
    {
        public static string Standardlize(string fullName)
        {
            fullName.Trim();
            StringBuilder builder = new StringBuilder();
            string[] words = fullName.Split(' ');
            foreach (string word in words)
            {
                if (string.IsNullOrEmpty(word))
                {
                    continue;
                }
                builder.Append(word.Substring(0, 1).ToUpper()).Append(word.Substring(1).ToLower()).Append(" ");
            }

            return builder.ToString().Trim();
        }
    }
}
