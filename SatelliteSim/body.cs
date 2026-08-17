using Raylib_cs;


public class body
{
    public double d, dens, mass;
    public Color c;

    
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="diameter">In meters</param>
    /// <param name="density">In kg/m^2</param>
    /// <param name="color"></param>
    public body(double diameter, double density, Color color)
    {
        d = diameter;
        dens = density;
        c = color;

        mass = density * ((Math.PI * Math.Pow(d, 3)) / 6);
    }

    public double getAcc(double dist)
    {
        const double G = 6.67430e-11;
        return (mass * G) / Math.Pow(dist, 2);
    }
}

