using System.Collections.Generic;

namespace StringCalculator;

public class DelimitersAndUserStringContainer
{
    public IList<string> delimiters;
    public string userNumberString;

    public DelimitersAndUserStringContainer(string userString, IList<string> sandartDelimiters)
    {
        userNumberString = userString;
        delimiters = sandartDelimiters;
    }

}

