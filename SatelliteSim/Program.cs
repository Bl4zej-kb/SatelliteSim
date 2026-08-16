using Raylib_cs;
using System.Threading;

class Program
{
    static void Main()
    {
        Display display = new Display(1000, 1000, "Satellite Sim", true);

        while (!Raylib.WindowShouldClose())
        {
            display.render();
        }
    }
}