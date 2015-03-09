using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS156Project
{
    //AvgRadial variant that updates the average radius after each data point is entered
    public static class AvgRadial
    {
        public static void run(List<clusterPoint> dataList, List<clusterPoint> centroidList, GraphControl graphControl, double threshold)        
        {
            double centroidMaxMovement = double.PositiveInfinity;
            
            if (dataList.Count > 0 && centroidList.Count > 0)
            {
                while (centroidMaxMovement > threshold)
                {
                    //Update Graph
                    graphControl.updateGraphFromAlgorithm();

                    //Assign all data points to the closest centroid
                    for (int j = 0; j < dataList.Count; j++)
                    {
                        double minDistance = double.PositiveInfinity;
                        int minIndex = -1;
                        for (int k = 0; k < centroidList.Count; k++)
                        {
                            double temp = distance(dataList.ElementAt(j), dataList, centroidList.ElementAt(k));
                            if (temp < minDistance)
                            {
                                minDistance = temp;
                                minIndex = k;
                            }
                        }
                        dataList.ElementAt(j).parent = minIndex;
                    }
                    // Adjust the location of the centroid to the middle of the cluster
                    centroidMaxMovement = updateCentroids(dataList, centroidList, centroidMaxMovement);
                }
                //Update Graph one final time
                graphControl.updateGraphFromAlgorithm();
            }
        }

        private static double distance(clusterPoint a, List<clusterPoint> dataList, clusterPoint centroid)
        {
            int count = 0;
            double sum = 0;
            double avgRadial = 0;

            //Calculate Average Radial Distance of Centroid
            foreach (clusterPoint c in dataList)
            {
                if (c.parent == centroid.parent)
                {
                    sum += distance(c, centroid);
                    count++;
                }

                if (count > 0)
                    avgRadial = sum / count;
            }
            
            //Distance must be greater than zero to prevent larger graphs from overpowering small graphs
            double temp = Math.Sqrt(Math.Pow(centroid.x - a.x, 2) + Math.Pow(centroid.y - a.y, 2)) - avgRadial;
            if (temp < 0)
                temp =.001;

            return temp;
        }

        private static double distance(clusterPoint a, clusterPoint b)
        {
            return Math.Sqrt(Math.Pow(b.x - a.x, 2) + Math.Pow(b.y - a.y, 2));
        }

        private static double updateCentroids(List<clusterPoint> dataList, List<clusterPoint> centroidList, double centroidMaxMovement)
        {
            double x = 0;
            double y = 0;
            double count = 0;
            double longestCentroidMovement = 0;

            for (int i = 0; i < centroidList.Count; i++)
            {
                x = 0;
                y = 0;
                count = 0;
                //longestCentroidMovement = 0;

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
                if (count > 0)
                {
                    x = x / count;
                    y = y / count;
                }
                else
                {
                    x = centroidList.ElementAt(i).x;
                    y = centroidList.ElementAt(i).y;
                }

                //Calculate distance moved by centroid
                double temp = distance(new clusterPoint(x,y), centroidList.ElementAt(i));

                if (temp > longestCentroidMovement)
                    longestCentroidMovement = temp;
 
                //Update new centroid coordinates
                if (count > 0)
                {
                    centroidList.ElementAt(i).x = x;
                    centroidList.ElementAt(i).y = y;
                }
            }

            //Update the maximum amount centroids moved this run
            if (longestCentroidMovement < centroidMaxMovement)
                centroidMaxMovement = longestCentroidMovement;

            return centroidMaxMovement;
        }

    }
}
