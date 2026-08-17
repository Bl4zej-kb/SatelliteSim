using Raylib_cs;
using System.Threading;
using SatelliteSim;

class Program
{
    static void Main()
    {
        Display display = new Display(1000, 1000, "Satellite Sim", true);

        body[] satellite = new[]
            { new body(12742000, 5514, Color.Green, 0, 0), new body(3474800, 3344, Color.Gray, 384400000, 0) };
        
        Console.WriteLine(satellite[0].mass);
        Console.WriteLine(satellite[1].mass);
        
        
        while (!Raylib.WindowShouldClose())
        {
            display.camInput();
            display.render(satellite);
        }
    }
}