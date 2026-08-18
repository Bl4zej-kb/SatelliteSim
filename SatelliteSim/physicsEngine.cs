using System.Diagnostics;
using Raylib_cs;

namespace SatelliteSim;
using SatelliteSim;

public static class physicsEngine
{
    public static bool on = true;
    public static int speed = 50, fpss = 10000;
    
    public static void simGravity(body[] bodies)
    {
        foreach (body bodyThis in bodies)
        {
            foreach (body bodyNotThis in bodies)
            {
                if (bodyThis == bodyNotThis) continue;
                double r = bodyThis.howFar(bodyNotThis);
                if (r == 0) continue;

                double dx = bodyThis.xPos - bodyNotThis.xPos;
                double dy = bodyThis.yPos - bodyNotThis.yPos;

                double factor = 6.67430e-11 * bodyThis.mass / Math.Pow(r, 3);

                double accX = factor * dx;
                double accY = factor * dy;

                bodyNotThis.xVel += accX / fpss;
                bodyNotThis.yVel += accY / fpss;
            }
        }
    }
    
    public static void Move(body[] sat)
    {
        foreach (body satellite in sat)
        {
            satellite.xPos += satellite.xVel / fpss;
            satellite.yPos += satellite.yVel / fpss;
        }
    }

    public static void startPhysics(body[] satellites)
    {
        Stopwatch sw = Stopwatch.StartNew();

        long next = sw.ElapsedTicks;
        long interval = (long)(Stopwatch.Frequency / speed / fpss);

        while (on)
        {
            simGravity(satellites);
            Move(satellites);

            next += interval;

            while (sw.ElapsedTicks < next)
                Thread.SpinWait(1);
        }
    }
}

