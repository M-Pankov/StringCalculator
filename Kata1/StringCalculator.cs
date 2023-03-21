namespace Kata1;

public class StringCalculator
{
    private string delimiters = "\n,";

    public int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
            return 0;

        var numberList = new List<int>();
        for (int i = 0; i < numbers.Length; i++)
        {
            if (Char.IsDigit(numbers[i]))
            {
                numberList.Add(int.Parse(numbers[i].ToString()));

            }
            else if (delimiters.Contains(numbers[i]) && i + 1 < numbers.Length)
            {
                if (int.TryParse(numbers[i + 1].ToString(), out int result))
                {
                    numberList.Add(result);
                    i++;

                }
                else
                {
                    return 0;
                }

            }
        }

        return numberList.Sum();
    }
}

