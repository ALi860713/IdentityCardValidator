using System.Collections.Generic;
using System.Linq;

namespace IdentityCardValidator
{
    class IdentityValidator
    {
        private readonly Dictionary<char, int> _idMapping = new Dictionary<char, int>
        {
            { 'A', 10 }, { 'B', 11 }, { 'C', 12 }, { 'D', 13 }, { 'E', 14 }, { 'F', 15 }, { 'G', 16 },
            { 'H', 17 }, { 'I', 18 }, { 'J', 19 }, { 'K', 20 }, { 'L', 21 }, { 'M', 22 }, { 'N', 23 },
            { 'O', 24 }, { 'P', 25 }, { 'Q', 26 }, { 'R', 27 }, { 'S', 28 }, { 'T', 29 }, { 'U', 30 },
            { 'V', 31 }, { 'W', 32 }, { 'X', 33 }, { 'Y', 34 }, { 'Z', 35 }
        };

        public bool Validate(string input)
        {
            var inputArray = GetInputArray(input);

            var sum = 0;
            var idStartIndex = 0;
            for (var index = 10; index > 0; index--, idStartIndex ++)
            {
                sum += int.Parse(index.ToString().First().ToString()) * int.Parse(inputArray[idStartIndex]);
            }

            sum += int.Parse(inputArray[idStartIndex]);

            return sum % 10 == 0;
        }

        private List<string> GetInputArray(string input)
        {
            var firstIdentityCode = input.Take(1).First();
            var otherIdentityCode = input.Skip(1).Select(x => x.ToString()).ToList();
            var firstIdentityCodeNumber = _idMapping[firstIdentityCode];
            var x1 = (firstIdentityCodeNumber / 10).ToString();
            var x2 = (firstIdentityCodeNumber % 10).ToString();
            otherIdentityCode.Reverse();
            otherIdentityCode.InsertRange(otherIdentityCode.Count, new List<string> { x2, x1 });
            otherIdentityCode.Reverse();

            return otherIdentityCode;
        }
    }
}