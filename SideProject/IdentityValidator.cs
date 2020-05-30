using System.Collections.Generic;

namespace IdentityCardValidator
{
    class IdentityValidator
    {
        public bool Validate(string input)
        {
            var idMapping = new Dictionary<char, int>
            {
                { 'A', 10 }, { 'B', 11 }, { 'C', 12 }, { 'D', 13 }, { 'E', 14 }, { 'F', 15 }, { 'G', 16 },
                { 'H', 17 }, { 'I', 18 }, { 'J', 19 }, { 'K', 20 }, { 'L', 21 }, { 'M', 22 }, { 'N', 23 },
                { 'O', 24 }, { 'P', 25 }, { 'Q', 26 }, { 'R', 27 }, { 'S', 28 }, { 'T', 29 }, { 'U', 30 },
                { 'V', 31 }, { 'W', 32 }, { 'X', 33 }, { 'Y', 34 }, { 'Z', 35 }
            };

            var inputArray = input.ToCharArray();
            var firstIdentityCodeNumber = idMapping[inputArray[0]];
            var x1 = firstIdentityCodeNumber / 10;
            var x2 = firstIdentityCodeNumber % 10;

            var sum = x1 + 9 * x2;
            var index = 8;
            var idStartIndex = 1;

            while (index > 0)
            {
                sum += index * int.Parse(inputArray[idStartIndex].ToString());
                index--;
                idStartIndex++;
            }

            sum += inputArray[idStartIndex];

            return sum % 10 == 0;
        }
    }
}