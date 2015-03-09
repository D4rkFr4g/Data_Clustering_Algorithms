using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace CS156Project
{
    public class clusterPoint
    {

        public Point p
        {
            get;
            private set;
        }

        public Color color
        {
            get;
            set;
        }

        public int parent
        {
            get;
            set;
        }

        public double x
        {
            get
            {
                return p.X;
            }
            set
            {
                p = new Point(value, p.Y);
            }
        }
        public double y
        {
            get
            {
                return p.Y;
            }
            set
            {
                p = new Point(p.X, value);
            }
        } 

        public clusterPoint(double x, double y)
        {
            p = new Point(x, y);
            parent = -1;
        }

        public clusterPoint(Point p)
        {
            this.p = new Point(p.X, p.Y);
            parent = -1;
        }

        public clusterPoint(double x, double y, int parent)
        {
            p = new Point(x, y);
            this.parent = parent;
        }

        public clusterPoint(double x, double y, int parent, Color color)
        {
            p = new Point(x, y);
            this.parent = parent;
            this.color = color;
        }

        public void clearParent()
        {
            parent = -1;
        }
    }
}
