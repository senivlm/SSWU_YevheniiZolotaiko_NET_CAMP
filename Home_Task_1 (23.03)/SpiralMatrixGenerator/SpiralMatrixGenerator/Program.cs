using SpiralMatrixGeneratorApp;

while (true)
{
    Console.WriteLine("enter if generated matrix must be clockwise (y/n)");

    var isClockwiseInput = Console.ReadLine();

    bool isClockwise;
    if (!InputParser.TryParseToOrientation(isClockwiseInput,out isClockwise))
    {
        Console.WriteLine("invalid input!");
        await Task.Delay(1000);
        continue;
    }
    var matrixGenerator = new SpiralMatrixGenerator(isClockwise);

    Console.WriteLine("enter height and width, separated by space or click enter to exit");
    var sizeInput = Console.ReadLine();
    Tuple<int, int> size;
    if (!InputParser.TryParseToSize(sizeInput,out size))
    {
        Console.WriteLine("invalid input!");
        await Task.Delay(1000);
        continue;
    }

    var spiralMatrix = matrixGenerator.Generate(size.Item1, size.Item2);
    PrintMatrix(spiralMatrix);
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    await Task.Delay(1000);
}



static void PrintMatrix(int[,] matrix)
{
    for(int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]} \t");
        }
        Console.WriteLine();
    }
}