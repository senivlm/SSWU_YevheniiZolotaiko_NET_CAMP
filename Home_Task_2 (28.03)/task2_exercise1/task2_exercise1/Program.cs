using task2_exercise1;


var waterTower = new WaterTower("Kharkiv tower", 50,100,30,30);
var user = new WaterUser("John",30);

PrintInfoAsync(user, waterTower);

while (true)
{
    var random = new Random();
    await Task.Delay(random.Next(2,4) * 1000);
    user.GetWaterFromTower(waterTower);
    Console.WriteLine("user got water from water tower");
}

static async Task PrintInfoAsync(WaterUser user, WaterTower waterTower)
{
    while (true)
    {
        Console.WriteLine(user);
        Console.WriteLine(waterTower);
        Console.WriteLine();

        await Task.Delay(1000);
    }
}