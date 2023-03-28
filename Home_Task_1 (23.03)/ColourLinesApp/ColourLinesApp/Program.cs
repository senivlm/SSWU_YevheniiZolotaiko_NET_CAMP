// See https://aka.ms/new-console-template for more information
using ColourLinesApp.Helpers;
using System.Runtime.CompilerServices;
//Вітаю. Перше завдання по створенню репозиторію Ви виконали.
var testMatrix = new int[,]
{
    {1,2,2,15,13 },
    {2,2,2,15,3 },
    {10,3,5,1,13 },
    {1,13,13,13,13 },
    {1,2,2,15,13 },
};

PrintMatrix(testMatrix);
Console.WriteLine();

Console.WriteLine(ColouredMatrixHelper.FindLongestColourLine(testMatrix));
Console.WriteLine();
Console.WriteLine();

var testMatrix2 = ColouredMatrixHelper.GenerateColouredMatrix(5, 5);

PrintMatrix(testMatrix2);
Console.WriteLine();

Console.WriteLine(ColouredMatrixHelper.FindLongestColourLine(testMatrix2));


static void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]}\t");
        }
        Console.WriteLine();
    }
}
