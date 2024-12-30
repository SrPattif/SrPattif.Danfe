using System;
using System.Text.RegularExpressions;

namespace DanfeSharp
{
    internal static class Utils
    {
        /// <summary>
        /// Verifica se uma string contém outra string no formato chave: valor.
        /// </summary>
        public static bool StringContainsAccessKey(string str, string accessKey, string value)
        {
            if (string.IsNullOrWhiteSpace(accessKey)) throw new ArgumentException(nameof(accessKey));
            if (string.IsNullOrWhiteSpace(str)) return false;

            return Regex.IsMatch(str, $@"({accessKey}):?\s*{value}", RegexOptions.IgnoreCase);
        } 
        
        public static string AccessKeyDFeType(string accessKey)
        {
            if (string.IsNullOrWhiteSpace(accessKey)) throw new ArgumentException(nameof(accessKey));

            if(accessKey.Length == 44)
            {
                var f = accessKey.Substring(20, 2);

                if (f == "55") return "NF-e";
                else if (f == "57") return "CT-e";
                else if (f == "65") return "NFC-e";
            }

            return "DF-e Desconhecido";
        }
    }
}
