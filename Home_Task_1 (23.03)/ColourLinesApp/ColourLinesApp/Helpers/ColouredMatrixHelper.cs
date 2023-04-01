using ColourLinesApp.Entities;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColourLinesApp.Helpers;

public static class ColouredMatrixHelper
{
    public static LongestColourLineInfo FindLongestColourLine(this int[,] colouredMatrix)
    {

        var longestLineInfo = new LongestColourLineInfo();
        LongestColourLineInfo currentLineInfo;

        for (int i = 0; i < colouredMatrix.GetLength(0); i++)
        {
            currentLineInfo = new(colouredMatrix[i,0], new Point(i,0), new Point(i, 0), 1);
            for(int j = 1; j < colouredMatrix.GetLength(1); j++)
            { У Вас на кожній точці відбувається уточнення можливого кінця лінії. Це лишнє. Достатньо на зміні кольору.
                if (colouredMatrix[i, j] == currentLineInfo.Colour) 
                { 
                    currentLineInfo.Length++;
                    currentLineInfo.EndCoordinates = new Point(i, j);
                }
                else currentLineInfo = new(colouredMatrix[i, j], new Point(i, j), new Point(i, j), 1);
            }
            if (currentLineInfo.Length > longestLineInfo.Length) longestLineInfo = currentLineInfo;
        }

        return longestLineInfo;
    }

    public static int[,] GenerateColouredMatrix(int height, int width)
    {
        var matrix = new int[height, width];
        var random = new Random();

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = random.Next(0,16);
            }
        }

        return matrix;
    }
}
