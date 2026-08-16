using System.Data;
using Raylib_cs;

public class Display
{
    private int X, Y;
    private string Name;

    public Display(int x, int y, string name, bool Init)
    {
        X = x;
        Y = y;
        Name = name;

        if (Init)
        {
            init();
        }
    }
    
    public void init()
    {
        Raylib.InitWindow(X, Y, Name);
    }

    public void render()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Black);
        
        Raylib.DrawCircle(500, 500, 100, Color.Green);
        
        Raylib.EndDrawing();
    }
}