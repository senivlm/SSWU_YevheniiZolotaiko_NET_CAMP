using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralMatrixGeneratorApp;

public enum Direction
{
    Down, Up, Left, Right
}

public class SpiralMatrixGenerator
{
    private bool _isClockwise;
    private Direction _currentDirection;

    public SpiralMatrixGenerator(bool isClockWise = false) 
    {
        _isClockwise= isClockWise;
        _currentDirection = isClockWise ? Direction.Right : Direction.Down;
    }

    public int[,] Generate(int height, int width)
    {
        var matrix = new int[height, width];
        matrix.Initialize();

        var elementsAmount = matrix.GetLength(0) * matrix.GetLength(1);

        int current_row = 0,current_col = 0;
        for (int counter = 1; counter <= elementsAmount; counter++)
        {
            matrix[current_row, current_col] = counter;
            if(counter < elementsAmount) Move(matrix, ref current_row, ref current_col);
        }

        return matrix;
    }

    private void ChangeDirection()
    {
        if(_isClockwise) 
        {// навіщо if, вони дорожчі, ніж просто присвоєння.
            if (_currentDirection == Direction.Down) _currentDirection = Direction.Left;
            else if (_currentDirection == Direction.Left) _currentDirection = Direction.Up;
            else if (_currentDirection == Direction.Up) _currentDirection = Direction.Right;
            else if (_currentDirection == Direction.Right) _currentDirection = Direction.Down;
        }
        else
        {
            if (_currentDirection == Direction.Down) _currentDirection = Direction.Right;
            else if (_currentDirection == Direction.Right) _currentDirection = Direction.Up;
            else if (_currentDirection == Direction.Up) _currentDirection = Direction.Left;
            else if (_currentDirection == Direction.Left) _currentDirection = Direction.Down;
        }
    }

    private void Move(int[,] matrix,ref int i, ref int j)
    {// а чому не просто ChangeDirection();Move(matrix, ref i, ref j);
        if(_currentDirection == Direction.Down)
        {
            if(i == matrix.GetLength(0) - 1 || matrix[i+1,j] != 0)
            {
                ChangeDirection();
                Move(matrix, ref i, ref j);
                return;
            }
            ++i;
        }
        else if (_currentDirection == Direction.Up)
        {
            if (i == 0 || matrix[i - 1, j] != 0) 
            {
                ChangeDirection();
                Move(matrix, ref i, ref j);
                return;
            }
            --i;
        }
        else if (_currentDirection == Direction.Left)
        {
            if (j == 0 || matrix[i, j - 1] != 0)
            {
                ChangeDirection();
                Move(matrix, ref i, ref j);
                return;
            }
            --j;
        }
        else
        {
            if (j == matrix.GetLength(1) - 1 || matrix[i, j + 1] != 0)
            {
                ChangeDirection();
                Move(matrix, ref i, ref j);
                return;
            }
            ++j;
        }
    }
}
