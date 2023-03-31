using task2_exercise1;


var waterTower = new WaterTower("Kharkiv tower", 50);
var user = new WaterUser("John",waterTower,10);

PrintInfoAsync(user);

while (true)
{
    var random = new Random();
    await Task.Delay(random.Next(1,3) * 1000);
    user.GetWaterFromTower();
    Console.WriteLine("user got water from water tower");
}

static async Task PrintInfoAsync(WaterUser user)
{
    while (true)
    {
        Console.WriteLine(user);
        Console.WriteLine(user.WaterTower);
        Console.WriteLine();

        await Task.Delay(1000);
    }
}