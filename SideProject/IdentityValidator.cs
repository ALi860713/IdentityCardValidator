using System.Collections.Generic;
using System.Linq;

namespace IdentityCardValidator
{
    internal class IdentityValidator
    {
        private readonly Dictionary<char, int> _firstIdentityCodeMapping = new Dictionary<char, int>
        {
            { 'A', 10 }, { 'B', 11 }, { 'C', 12 }, { 'D', 13 }, { 'E', 14 }, { 'F', 15 }, { 'G', 16 },
            { 'H', 17 }, { 'I', 18 }, { 'J', 19 }, { 'K', 20 }, { 'L', 21 }, { 'M', 22 }, { 'N', 23 },
            { 'O', 24 }, { 'P', 25 }, { 'Q', 26 }, { 'R', 27 }, { 'S', 28 }, { 'T', 29 }, { 'U', 30 },
            { 'V', 31 }, { 'W', 32 }, { 'X', 33 }, { 'Y', 34 }, { 'Z', 35 }
        };

        private readonly List<KeyValuePair<int, int>> _identityOperationMapping = new List<KeyValuePair<int, int>>
        {
            new KeyValuePair<int, int>(1, 0),
            new KeyValuePair<int, int>(9, 1),
            new KeyValuePair<int, int>(8, 2),
            new KeyValuePair<int, int>(7, 3),
            new KeyValuePair<int, int>(6, 4),
            new KeyValuePair<int, int>(5, 5),
            new KeyValuePair<int, int>(4, 6),
            new KeyValuePair<int, int>(3, 7),
            new KeyValuePair<int, int>(2, 8),
            new KeyValuePair<int, int>(1, 9),
            new KeyValuePair<int, int>(1, 10),
        };

        public bool Validate(string input)
        {
            var inputList = FormatToIdentityCodeList(input);

            var sum = 0;

            foreach (var (operationNumber, position) in _identityOperationMapping)
            {
                sum += operationNumber * int.Parse(inputList[position]);
            }

            return sum % 10 == 0;
        }

        private List<string> FormatToIdentityCodeList(string input)
        {
            var firstIdentityCodes = GenerateFirstIdentityCodes(input);

            var identityCodeList = GenerateIdentityCodeList(input, firstIdentityCodes);

            return identityCodeList;
        }

        private IEnumerable<string> GenerateFirstIdentityCodes(string input)
        {
            var firstIdentityCodeNumber = _firstIdentityCodeMapping[input[0]];
            var tensDigit= (firstIdentityCodeNumber / 10).ToString();
            var unitsDigit = (firstIdentityCodeNumber % 10).ToString();

            return new List<string> { unitsDigit, tensDigit };
        }

        private List<string> GenerateIdentityCodeList(string input, IEnumerable<string> firstIdentityNumber)
        {
            var otherIdentityCode = input.Skip(1).Select(x => x.ToString()).ToList();

            otherIdentityCode.Reverse();
            otherIdentityCode.InsertRange(otherIdentityCode.Count, firstIdentityNumber);
            otherIdentityCode.Reverse();

            return otherIdentityCode;
        }
    }
}