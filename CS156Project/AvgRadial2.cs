using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS156Project
{
    //Variant on AvgRadial that updates the centroid list after all points have been added to determine the new average radius
    class AvgRadial2
    {
        public static void run(List<clusterPoint> dataList, List<clusterPoint> centroidList, GraphControl graphControl, double threshold)
        {
            double centroidMaxMovement = double.PositiveInfinity;
            List<double> radialList = new List<double>();

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
                            double temp = distance(dataList.ElementAt(j), radialList, centroidList.ElementAt(k));
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
                    calculateRadials(dataList, centroidList, radialList);
                }
                //Update Graph one final time
                graphControl.updateGraphFromAlgorithm();
            }
        }

        private static void calculateRadials(List<clusterPoint> dataList, List<clusterPoint> centroidList, List<double> radialList)
        {
            for (int i = 0; i < centroidList.Count; i++)
            {
                int count = 0;
                double sum = 0;

                foreach (clusterPoint d in dataList)
                {
                    //Calculate Average Radial Distance of Centroid
                    if (d.parent == centroidList.ElementAt(i).parent)
                    {
                        sum += distance(d, centroidList.ElementAt(i));
                        count++;
                    }
                }
                
                if (count > 0)
                    radialList.Add(sum / count);
            }
        }

        private static double distance(clusterPoint a, List<double> radialList, clusterPoint centroid)
        {
            double radius = 0;

            try
            {
                radius = radialList.ElementAt(centroid.parent);
            }
            catch
            {
                radius = 0;
            }
            
            double temp = Math.Sqrt(Math.Pow(centroid.x - a.x, 2) + Math.Pow(centroid.y - a.y, 2)) - radius;

            if (temp < 0)
                temp = 0;

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
                double temp = distance(new clusterPoint(x, y), centroidList.ElementAt(i));

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
