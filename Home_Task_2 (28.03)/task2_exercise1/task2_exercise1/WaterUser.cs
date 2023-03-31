using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2_exercise1;

public class WaterUser
{
    public string Name { get; }
    public int WaterReserve { get; private set; }
    public int Consumption { get; set; }

    public WaterUser(string name, int consumption = 15)
    {
        Name = name;
        WaterReserve = 0;
        Consumption = consumption;
    }

    public void GetWaterFromTower(WaterTower waterTower)
    {
        WaterReserve += waterTower.RequestWater(Consumption);
    }

    public override string ToString()
    {
        return $"User name: {Name}, current volume: {WaterReserve}, consumption: {Consumption}";
    }
}