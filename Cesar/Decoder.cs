using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesar
{
    public class Decoder
    {
        private static char[] alpha = "AĄBCĆDEĘFGHIJKLŁMNŃOÓPQRSŚTUVWXYZŹŻ".ToCharArray();
        public static string CodeAndDecodeTheText(string text, string key, bool isCode)
        {
            var miracle = alpha.ToDictionary(k => k, k => Array.IndexOf(alpha, k));
            char[] swap = text.ToUpper().Replace(" ", String.Empty).ToCharArray();
            var keyValue = Int32.Parse(key);
            int i = 0;
            foreach (var item in swap)
            {
                var location = miracle[item];
                var moveNumber = isCode ? ((location + keyValue) % 35) : ((location - keyValue) %35);
                if (moveNumber <0)
                {
                    moveNumber = 35 - Math.Abs(moveNumber);
                }
                swap[i] = alpha[moveNumber];
                i++;
            }
            string output = new string(swap);
            return output;
        }
    }
}
