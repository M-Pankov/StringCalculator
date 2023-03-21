using StringCalculator.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorProject;

public class CustomStringCalculator
{
    private List<string> _delimiters = new() { "\n", "," };

    private List<int> _validNumbersList = new();

    private List<int> _negativeNumbersList = new();

    public int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
        {
            return 0;
        }

        CheckNewDelimiters(numbers);

        var stringsToSum = numbers.Split(_delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

        var sumResult = GetSumOfNumbers(stringsToSum);

        return sumResult;
    }

    private int GetSumOfNumbers(string[] numberStrings)
    {
        foreach (var numberString in numberStrings)
        {

            int.TryParse(numberString, out int numberStringParsResult);

            int parseValue = numberStringParsResult;

            if (CheckValidValues(parseValue))
            {
                _validNumbersList.Add(parseValue);
            }
        }

        CheckNegativeNumbers();

        return _validNumbersList.Sum();
    }

    private bool CheckValidValues(int number)
    {
        if (number > 1000)
        {
            return false;

        }
        else if (number < 0)
        {
            _negativeNumbersList.Add(number);

            return false;

        }

        return true;
    }

    private void CheckNegativeNumbers()
    {
        if (_negativeNumbersList.Count > 0)
        {
            var negativeNumbersExceptionStrings = _negativeNumbersList.ConvertAll(x => x.ToString());

            throw new NegativeNumberException("Negatives not allowed: " + String.Join(", ", negativeNumbersExceptionStrings));
        }
    }

    private void CheckNewDelimiters(string numbers)
    {
        if (numbers.StartsWith("//"))
        {
            AddNewDelimiter(numbers.TrimStart('/'));
        }

    }

    private void AddNewDelimiter(string numbers)
    {
        int delimitersEndIndex = numbers.IndexOf('\n');

        var delimitersInString = numbers.Substring(0, delimitersEndIndex);

        var delimitersToAdd = delimitersInString.Split(']', StringSplitOptions.RemoveEmptyEntries);

        foreach (var delimiter in delimitersToAdd)
        {
            _delimiters.Add(delimiter.TrimStart('['));
        }
    }
}

