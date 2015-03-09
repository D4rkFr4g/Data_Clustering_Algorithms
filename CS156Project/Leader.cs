using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS156Project
{
    public static class Leader
    {
        public static void run(List<clusterPoint> dataList, List<clusterPoint> centroidList, GraphControl graphControl, double threshold)
        {
            //double centroidMaxMovement = double.PositiveInfinity;
            RandomColor randomColor = new RandomColor();

            //Go through each data point and assign a centroid or create a new centroid
            if (dataList.Count > 0)
            {
                foreach (clusterPoint c in dataList)
                {
                    //Update Graph
                    graphControl.updateGraphFromAlgorithm();

                    // Add first point to centroidList
                    if (centroidList.Count == 0)
                    {
                        c.color = randomColor.getColor();
                        centroidList.Add(new clusterPoint(c.x, c.y, centroidList.Count, c.color));
                        c.parent = 0;
                    }
                    else
                    {
                        double minDistance = double.PositiveInfinity;
                        int minCentroid = -1;

                        //Assign dataPoint to the closest centroid
                        for (int i = 0; i < centroidList.Count; i++)
                        {
                            double temp = distance(c, centroidList.ElementAt(i));
                            if (temp < minDistance)
                            {
                                minDistance = temp;
                                minCentroid = i;
                            }
                        }

                        if (minDistance < threshold)
                        {
                            c.parent = minCentroid;
                            c.color = centroidList.ElementAt(minCentroid).color;
                            updateCentroids(dataList, centroidList);
                        }
                        else
                        {
                            //Set dataPoint to the new Centroid
                            c.color = randomColor.getColor();
                            c.parent = centroidList.Count;

                            //Add the new Centroid
                            centroidList.Add(new clusterPoint(c.x, c.y, centroidList.Count, c.color));
                        }
                    }
                }
                //Update Graph one final time
                graphControl.updateGraphFromAlgorithm();
            }
        }

        private static double distance(clusterPoint a, clusterPoint b)
        {
            return Math.Sqrt(Math.Pow(b.x - a.x, 2) + Math.Pow(b.y - a.y, 2));
        }

        private static void updateCentroids(List<clusterPoint> dataList, List<clusterPoint> centroidList)
        {
            double x = 0;
            double y = 0;
            double count = 0;

            for (int i = 0; i < centroidList.Count; i++)
            {
                x = 0;
                y = 0;
                count = 0;

                //Calculate central point for cluster
                foreach (clusterPoint dataPoint in dataList)
                {
                    if (dataPoint.parent == i)
                    {
                        x += dataPoint.x;
                        y += dataPoint.y;
                        count++;
                    }
                }
                //Determine the average central position of the new centroid
                if (count > 0)
                {
                    x = x / count;
                    y = y / count;
                }
                //If centroid didn't change use it's original coordinates. Prevents 0,0 errors
                else
                {
                    x = centroidList.ElementAt(i).x;
                    y = centroidList.ElementAt(i).y;
                }

                //Update new centroid coordinates
                if (count > 0)
                {
                    centroidList.ElementAt(i).x = x;
                    centroidList.ElementAt(i).y = y;
                }
            }
        }

    }
}
