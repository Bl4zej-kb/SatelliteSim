using Raylib_cs;
using System.Threading;
using SatelliteSim;

class Program
{
    static void Main()
    {
        display display = new display(1000, 1000, "Satellite Sim", true);

        body[] satellite = new[]
            { new body(12742000, 5514, Color.Green, 0, 0), new body(5, 7850, Color.Gray, 6771000, 0) };
        
        satellite[1].setVel(0, 7660);
        
        Console.WriteLine(satellite[0].mass);
        Console.WriteLine(satellite[1].mass);

        Thread physics = new Thread(() => physicsEngine.startPhysics(satellite));
        physics.Start();
        
        while (!Raylib.WindowShouldClose())
        {
            display.camInput();
            display.render(satellite);
        }

        physicsEngine.on = false;
        
    }
}