namespace DefaultNamespace
public class PolarPoint
{
    public double R { get; set; }
    public double Theta { get; set; }

    public PolarPoint(double r, double theta)
    {
        R = r;
        Theta = theta;
    }
}