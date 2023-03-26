using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralMatrixGeneratorApp;

public static class InputParser
{
    private static void ExitIfEmptyInput(string? input)
    {
        if(string.IsNullOrWhiteSpace(input)) Environment.Exit(0);
    }

    public static bool TryParseToOrientation(string? input, out bool isClockwise)
    {
        ExitIfEmptyInput(input);

        input = input!.ToLower();
        isClockwise = false;

        if(input != "y" && input != "n")
        {
            return false;
        }

        if(input == "y")
        {
            isClockwise= true;
        }

        return true;
    }

    public static bool TryParseToSize(string? input, out Tuple<int,int> size)
    {
        ExitIfEmptyInput(input);

        size = new(0, 0);
        var splittedInput = input!.Split(' ');

        if(splittedInput.Length != 2)
        {
            return false;
        }

        int height, width;
        if (!int.TryParse(splittedInput[0],out height) || !int.TryParse(splittedInput[1],out width))
        {
            return false;
        }

        size = new(height, width);

        return true;
    }
}
