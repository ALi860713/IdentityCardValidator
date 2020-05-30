using System;

namespace IdentityCardValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            var identityValidator = new IdentityValidator();
            var result = identityValidator.Validate(Console.ReadLine());
            Console.WriteLine(result ? "CORRECT" : "WRONG");
            Console.ReadKey();
        }
    }
}
