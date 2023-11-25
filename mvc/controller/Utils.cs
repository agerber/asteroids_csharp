namespace DefaultNamespace

using System;
using System.Collections.Generic;
 using System.Linq;

    public class Utils
    {
        public static List<PolarPoint> CartesianToPolar(Point[] pntCartesians)
        {
            Func<Point, double> hypotenuseOfPoint = pnt =>
                Math.Sqrt(Math.Pow(pnt.X, 2) + Math.Pow(pnt.Y, 2));

            double largestHyp = pntCartesians.Max(pnt => hypotenuseOfPoint(pnt));

            Func<Point, double, PolarPoint> cartToPolarTransform = (pnt, dbl) => new PolarPoint(
                hypotenuseOfPoint(pnt) / dbl, 
                Math.Atan2(pnt.Y, pnt.X) * (180 / Math.PI)
            );

            return pntCartesians.Select(pnt => cartToPolarTransform(pnt, largestHyp)).ToList();
        }
    }
