using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator;

public class CustomStringCalculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
        {
            return 0;
        }

        IList<string> delimiters = new List<string>() { "\n", ",", @"\n" };

        if (numbers.StartsWith("//"))
        {
            int slashesEndIndex = 2;

            numbers = numbers.Remove(0, slashesEndIndex);

            var container = new DelimitersAndUserStringContainer(numbers, delimiters);

            AddCustomDelimiters(container);

            numbers = container.userNumberString;
        }

        var stringsToSum = numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

        var sumResult = CalculateSum(stringsToSum);

        return sumResult;
    }

    private int CalculateSum(string[] numberStrings)
    {
        IList<int> validNumbers = new List<int>();

        IList<int> negativeNumbers = new List<int>();

        foreach (var numberString in numberStrings)
        {

            int.TryParse(numberString, out int numberParsResult);

            if (numberParsResult < 0)
            {
                negativeNumbers.Add(numberParsResult);

                continue;
            }

            validNumbers.Add(numberParsResult);
        }


        IsNegativeNumbersExsist(negativeNumbers);

        return validNumbers.Where(x => x <= 1000).Sum();
    }

    private void IsNegativeNumbersExsist(IList<int> negativeNumbers)
    {
        if (negativeNumbers.Any())
        {
            var negativeNumbersExceptionStrings = ((List<int>)negativeNumbers).ConvertAll(x => x.ToString());

            throw new Exception("Negatives not allowed: " + string.Join(", ", negativeNumbersExceptionStrings));
        }
    }


    private void AddCustomDelimiters(DelimitersAndUserStringContainer container)
    {
        int delimitersEndIndex = container.userNumberString.IndexOf('\n');

        if (delimitersEndIndex == -1)
        {
            delimitersEndIndex = container.userNumberString.IndexOf(@"\n");
        }

        var delimitersInString = container.userNumberString.Substring(0, delimitersEndIndex);

        container.userNumberString = container.userNumberString.Substring(delimitersEndIndex);

        if (!delimitersInString.StartsWith('[') | !delimitersInString.EndsWith(']'))
        {
            container.delimiters.Add(delimitersInString);

            return;
        }

        var customDelimiters = delimitersInString.Split("][", StringSplitOptions.RemoveEmptyEntries);

        var lastDelimiterIndex = customDelimiters.Length - 1;

        var firstDelimiter = customDelimiters.First().Remove(0, 1);

        customDelimiters[0] = firstDelimiter;

        var lastDelimiter = customDelimiters.Last();

        customDelimiters[lastDelimiterIndex] = lastDelimiter.Remove(lastDelimiter.Length - 1);

        foreach (string customDelimiter in customDelimiters)
        {
            container.delimiters.Add(customDelimiter);
        }
    }
}

