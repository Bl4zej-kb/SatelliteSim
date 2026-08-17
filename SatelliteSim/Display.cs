using System.Numerics;
using Raylib_cs;

namespace SatelliteSim;

public class Display
{
    private int X, Y, camX = 0, camY = 0, camXOld, camYOld;
    private string Name;
    private double scaleDef = 0.000005, scale;
    private Vector2 old, now;
    private bool hold = false, holdNow;
    

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
        scale = scaleDef;
        Raylib.SetConfigFlags(ConfigFlags.ResizableWindow);
        Raylib.InitWindow(X, Y, Name);
    }

    public void render(body[] satellite)
    {
        X = Raylib.GetScreenWidth();
        Y = Raylib.GetScreenHeight();
        
        
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Black);
        foreach (body sat in satellite)
        {
            int radius = (int)(sat.diameter / 2 * scale);

            if (radius < 5) radius = 5;
            
            Raylib.DrawCircle((int)(X / 2 + (sat.xPos + camX) * scale), (int)(Y / 2 + (sat.yPos + camY) * scale), radius, sat.color);
        }
        Raylib.EndDrawing();
    }

    public void camInput()
    {
        now = Raylib.GetMousePosition();
        holdNow = Raylib.IsMouseButtonDown(MouseButton.Left);

        if (!hold && holdNow)
        {
            old = now;
            hold = true;
            camXOld = camX;
            camYOld = camY;
        }
        else if (hold && holdNow)
        {
            camX = camXOld + (int)((now.X - old.X) / scale);
            camY = camYOld + (int)((now.Y - old.Y) / scale);
        }
        else if (hold && !holdNow)
        {
            hold = false;
        }




        scale += Raylib.GetMouseWheelMove() * 0.5 * scale;

        if (scale < 0.000000001) scale = 0.000000001;

        if (Raylib.IsKeyPressed(KeyboardKey.Zero))
        {
            camX = 0;
            camY = 0;
        }

        if (Raylib.IsKeyPressed(KeyboardKey.Nine))
        {
            scale = scaleDef;
        }
    }
    
}