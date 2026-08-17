using Raylib_cs;
using System.Threading;
using System;

class Program
{
    static void Main()
    {
        Display display = new Display(1000, 1000, "Satellite Sim", true);

        body earth = new body(12742000, 5514, Color.Green);
        
        Console.WriteLine(earth.mass);
        
        
        while (!Raylib.WindowShouldClose())
        {

        }
    }
}