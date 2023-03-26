using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColourLinesApp.Entities;

public struct LongestColourLineInfo
{
    public int Colour { get; set; }
    public Point StartCoordinates { get; set; }
    public Point EndCoordinates { get; set; }
    public int Length { get; set; }

    public LongestColourLineInfo()
    {
        Colour = 0;
        StartCoordinates = new Point();
        EndCoordinates = new Point();
        Length = 0;
    }

    public LongestColourLineInfo(int colour) : this()
    {
        Colour = colour;
    }

    public LongestColourLineInfo(int colour,Point startCoordinates, Point endCoordinates, int length)
    {
        Colour= colour;
        StartCoordinates = startCoordinates;
        EndCoordinates = endCoordinates;
        Length = length;
    }

    public override string ToString()
    {
        return $"colour: {Colour}\n" +
            $"start: [{StartCoordinates.X},{StartCoordinates.Y}]\n" +
            $"end: [{EndCoordinates.X},{EndCoordinates.Y}]\n" +
            $"length: {Length}";
    }
}
