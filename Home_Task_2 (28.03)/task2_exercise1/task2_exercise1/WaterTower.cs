using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace task2_exercise1;

public class WaterTower
{
    public int MaxVolume { get; }
    public int PumpPerTime { get; }

    private Mutex _mutex;
    private bool _isPumpRunning;

    public string Name { get; }

    private int _waterReserve;
    public int WaterReserve
    {
        get => _waterReserve;
        private set 
        {
            if(value > MaxVolume)
            {
                _waterReserve = MaxVolume;
            }
            else if(value <=0)
            {
                _waterReserve = 0;
                if(!_isPumpRunning) Task.Run(() => PumpWater()); 
            }
            _waterReserve = value; 
        }
    }

    public WaterTower(string name,int volume)
    {
        Name = name;
        WaterReserve= volume;
        _mutex= new Mutex();
        MaxVolume = 100;
        PumpPerTime = 10;
    }

    public WaterTower(string name, int volume, int maxVolume, int pumpPerTime) : this(name,volume)
    {
        MaxVolume= maxVolume;
        PumpPerTime= pumpPerTime;
    }

    public int RequestWater(int volume)
    {
        if (volume <= 0) return 0;
        int actualVolume;
        _mutex.WaitOne();
        if(WaterReserve <= volume)
        {
            actualVolume = WaterReserve;
            WaterReserve = 0;
        }
        else
        {
            actualVolume = volume;
            WaterReserve -= volume;
        }
        _mutex.ReleaseMutex();
        return actualVolume;
    }

    private async Task PumpWater()
    {
        if (_isPumpRunning) return;
        _isPumpRunning= true;
        while (WaterReserve < MaxVolume)
        {
            _mutex.WaitOne();
            WaterReserve = WaterReserve + PumpPerTime;
            _mutex.ReleaseMutex();
            await Task.Delay(1000);
        }
        _isPumpRunning = false;
    }

    public override string ToString()
    {
        return $"Water tower name: {Name}, current volume: {WaterReserve}, ";
    }
}
