using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS156Project
{
    public class RandomClusterPoint
    {
        Random rand = new Random();
        int scale = 1000;

        public clusterPoint getPoint()
        {
            double x = rand.NextDouble() * scale;
            double y = rand.NextDouble() * scale;
            
            return new clusterPoint(x,y);
        }
    }
}
