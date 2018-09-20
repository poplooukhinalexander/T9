using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Codec
{
    public static class T9Codec
    {
        private static readonly IDictionary<char, string> SymbolToT9Mapper = new Dictionary<char, string>()
        {
            { 'a', "2" },
            { 'b', "22" },
            { 'c', "222" },
            { 'd', "3" },
            { 'e', "33" },
            { 'f', "333" },
            { 'g', "4"},
            { 'h', "44" },
            { 'i', "444" },
            { 'j', "5" },
            { 'k', "55" },
            { 'l', "555"},
            { 'm', "6" },
            { 'n', "66" },
            { 'o', "666" },
            { 'p', "7" },
            { 'q', "77"},
            { 'r', "777" },
            { 's', "7777" },
            { 't', "8" },
            { 'u', "88" },
            { 'v', "888" },
            { 'w', "9" },
            { 'x', "99" },
            { 'y', "999" },
            { 'z', "9999" },
            { ' ', "0" }
        };

        public static string ConvertToT9(this string source)
        {
            if (string.IsNullOrWhiteSpace(source))
                return string.Empty;

            var message = source.Trim().ToLower().Replace('\t', ' ');
            var regex = new Regex(@"^[a-z]+(\s+[a-z]+)*$");
            if (!regex.IsMatch(message))
                throw new ArgumentException(@"Invalid income string. Income string should satisfy the pattern: ^[a-z]+(\s+[a-z]+)*$");

            var encodedSymbols = message.Select(c => SymbolToT9Mapper[c]);
            var result = string.Join("", encodedSymbols);

            return result;
        }
    }
}
