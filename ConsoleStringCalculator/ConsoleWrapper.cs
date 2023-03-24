using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleStringCalculator;

public class ConsoleWrapper
{
    public virtual string ReadLine()
    {
        return Console.ReadLine();
    }

    public virtual void WriteLine(string message)
    {
        Console.WriteLine(message);
    }

}
