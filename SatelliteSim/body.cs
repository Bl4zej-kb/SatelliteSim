using Raylib_cs;

namespace SatelliteSim;

public class body
{
    public double diameter, density, mass, xPos, yPos, xVel, yVel;
    public Color color;
    

    
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="diameter">In meters</param>
    /// <param name="density">In kg/m^2</param>
    /// <param name="color"></param>
    public body(double diameter, double density, Color color, double xPos, double yPos)
    {
        this.diameter = diameter;
        this.density = density;
        this.color = color;

        mass = this.density * ((Math.PI * Math.Pow(this.diameter, 3)) / 6);

        this.xPos = xPos;
        this.yPos = yPos;
    }

    public void setVel(double xVel, double yVel)
    {
        this.xVel = xVel;
        this.yVel = yVel;
    }

    public double getAcc(double dist)
    {
        const double G = 6.67430e-11;
        return (mass * G) / Math.Pow(dist, 2);
    }

    public double howFar(body b)
    {
        return Math.Sqrt(Math.Pow(xPos - b.xPos, 2) + Math.Pow(yPos - b.yPos, 2));
    }
}

