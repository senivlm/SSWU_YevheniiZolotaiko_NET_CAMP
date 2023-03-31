using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace task2_exercise1;

public class WaterTower
{
    public string Name { get; } 
    public int MaxVolume { get; }
    public int CollectingPumpSpeed { get; }
    public int MaxPumpingSpeed { get; }

    private Mutex _mutex;
    private bool _isPumpRunning;

    private int _waterReserve;
    public int WaterReserve
    {
        get => _waterReserve;
        private set 
        {
            if(value >= MaxVolume)
            {
                _waterReserve = MaxVolume;
                _isPumpRunning = false;
            }
            else if(value <=0)
            {
                _waterReserve = 0;
                if (!_isPumpRunning) 
                {
                    _isPumpRunning = true;
                    StartPumpingWater(); 
                } 
            }
            else _waterReserve = value; 
        }
    }

    public WaterTower(string name,int volume)
    {
        Name = name;
        WaterReserve= volume;

        MaxVolume = 100;
        CollectingPumpSpeed = 10;
        MaxPumpingSpeed= 15;

        _mutex= new Mutex();
    }

    public WaterTower(string name, int volume, int maxVolume, int pumpPerTime, int maxPumpingSpeed) : this(name,volume)
    {
        MaxVolume = maxVolume;
        CollectingPumpSpeed = pumpPerTime;
        MaxPumpingSpeed = maxPumpingSpeed;
    }

    public int RequestWater(int volume)
    {
        if (volume <= 0) return 0;
        int actualVolume;
        _mutex.WaitOne();
        if(volume <= MaxPumpingSpeed && volume < WaterReserve) 
        {
            actualVolume = volume;
        }
        else if(volume <= MaxPumpingSpeed && volume >= WaterReserve)
        {
            actualVolume = WaterReserve;
        }
        else if (volume > MaxPumpingSpeed && volume < WaterReserve)
        {
            actualVolume = MaxPumpingSpeed;
        }
        else
        {
            actualVolume = Math.Min(MaxPumpingSpeed, WaterReserve);
        }
        WaterReserve = WaterReserve - actualVolume;
        _mutex.ReleaseMutex();
        return actualVolume;
    }

    private void StartPumpingWater()
    {
        Task.Run(() =>
        {
            while (_isPumpRunning)
            {
                _mutex.WaitOne();
                WaterReserve = WaterReserve + CollectingPumpSpeed;
                _mutex.ReleaseMutex();
                Task.Delay(1000).Wait();
            }
        });
    }


    public override string ToString()
    {
        return $"Water tower name: {Name}, current volume: {WaterReserve}";
    }
}
