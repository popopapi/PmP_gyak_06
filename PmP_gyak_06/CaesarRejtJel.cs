using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmP_gyak_06
{
    public class CaesarRejtJel
    {
        private int key;

        public CaesarRejtJel(int key)
        {
            this.key = key;
        }

        private string TransformMessage(string message, int shift)
        {
            char[] transformed = new char[message.Length];

            for (int i = 0; i < message.Length; i++)
            {
                char c = message[i];
                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    transformed[i] = (char)((((c - offset) + shift) % 26 + 26) % 26 + offset);
                }
                else
                {
                    transformed[i] = c; // nem betű karakterek nem változnak
                }
            }

            return new string(transformed);
        }

        // tiktosítás kulcscsal
        public string Encode(string message)
        {
            return TransformMessage(message, key);
        }

        // visszafejtés
        public string Decode(string message)
        {
            return TransformMessage(message, -key);
        }
    }
}
