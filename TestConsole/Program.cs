using FileHolder.DataAccess;
using FileHolder.Models;
using System;
using System.Linq;

namespace TestConsole
{
    class Program
    {
        public static Func<int> Random = () => new Random().Next(1, 100);

        static void Main(string[] args)
        {
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(Random.Invoke());
            }

            Console.WriteLine($"The sum of digits for 981 is {DigitSum(981)}");
        }

        public static int DigitSum(int number)
        {
            var sum = 0;

            while (number != 0)
            {
                sum += number % 10;
                number /= 10;
            }

            return sum;
        }
    }
}
