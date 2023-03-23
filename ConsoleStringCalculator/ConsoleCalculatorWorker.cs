using StringCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleStringCalculator
{
    public class ConsoleCalculatorWorker
    {
        private readonly ICustomStringCalculator _stringCalculator;
        public ConsoleCalculatorWorker(ICustomStringCalculator calculator)
        {
            _stringCalculator = calculator;
        }

        public void Run()
        {
            Console.WriteLine("Enter comma separated numbers (enter to exit):");

            var input = Console.ReadLine();

            RunAgain(input);
        }

        private void RunAgain(string input)
        {
            if(!string.IsNullOrEmpty(input))
            {
                var sum = _stringCalculator.Add(input);

                Console.WriteLine(sum);

                Console.WriteLine("you can enter other numbers (enter to exit)?");

                var nextInput = Console.ReadLine();

                RunAgain(nextInput);
            }
        }
    }
}
