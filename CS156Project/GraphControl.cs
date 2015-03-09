using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using Microsoft.Research.DynamicDataDisplay.PointMarkers;
using Microsoft.Research.DynamicDataDisplay.Charts;
using Microsoft.Research.DynamicDataDisplay.Common;
using System.Windows.Media;
using System.Windows;


namespace CS156Project
{
    public class GraphControl
    {
        ChartPlotter plotter;
        List<clusterPoint> dataList;
        List<clusterPoint> centroidList;
        List<Graph> graphList;

        int itr = -1;
        int itrMarker = -1;
        private int dataSize = 7;
        private int centroidSize = 10;
        public double kMeansThreshold
        {
            get;
            set;
        }
        public double leaderThreshold
        {
            get;
            set;
        }

        public GraphControl(ChartPlotter plotter, List<clusterPoint> dataList, List<clusterPoint> centroidList)
        {
            this.plotter = plotter;
            this.dataList = dataList;
            this.centroidList = centroidList;
            graphList = new List<Graph>();
            kMeansThreshold = .001;
            leaderThreshold = 200;
        }

        public void setdataSize(int size)
        {
            dataSize = size;
        }

        public void setCentroidSize(int size)
        {
            centroidSize = size;
        }

        public int getDataSize()
        {
            return dataSize;
        }

        public int getCentroidSize()
        {
            return centroidSize;
        }

        public void updateGraph(bool algorithmRun, Graph graph)
        {
            //Clear the Graph of previous data.
            plotter.RemoveUserElements();

            List<clusterPoint> cList;

            //Update graph according to the current data in the lists
            if (graph == null)
                cList = centroidList;
            else
                cList = graph.getCentroidList();

            if (cList.Count() == 0)
                updateDataPoints(-1, algorithmRun, graph);
            else
            {
                for (int i = -1; i < cList.Count(); i++)
                {
                    updateDataPoints(i, algorithmRun, graph);
                    updateCentroidPoints(i, graph);
                }
            }
            
        }

        public void markIterator()
        {
            itrMarker = itr;
        }

        public void updateGraphFromAlgorithm()
        {
            //Updates and stores the current set of lists
            updateGraph(true, null);

            graphList.Add(new Graph(centroidList, dataList));
            itr = graphList.Count - 1;
        }

        private void updateDataPoints(int i, bool algorithmRun, Graph graph)
        {
            //Use CentroidList from either the saved Graph or the current List
            List<clusterPoint> cList, dList;
            if (graph == null)
            {
                cList = centroidList;
                dList = dataList;
            }
            else
            {
                cList = graph.getCentroidList();
                dList = graph.getDataList();
            }

            //Convert the lists into usable data for the D3 Graph
            MarkerPointsGraph myGraph = new MarkerPointsGraph();
            var xDataSource = convertToXArray(dList, i).AsXDataSource();
            var yDataSource = convertToYArray(dList, i).AsYDataSource();

            CompositeDataSource compositeDataSource = xDataSource.Join(yDataSource);
            myGraph.DataSource = compositeDataSource;

            //Get the centroid color
            Color color;
            if (cList.Count > 0 && algorithmRun && itr > -1 && i != -1)
                color = cList.ElementAt(i).color;
            else
                color = Colors.Black;

            //Set the graph colors
            CirclePointMarker mrk = new CirclePointMarker();
            mrk.Size = dataSize;
            mrk.Fill = new SolidColorBrush(color);
            mrk.Pen = new Pen(new SolidColorBrush(Colors.Black), 1.0);
            myGraph.Marker = mrk;

            myGraph.AddToPlotter(plotter);
        }

        private void updateCentroidPoints(int i, Graph graph)
        {
            //Use CentroidList from either the saved Graph or the current List
            List<clusterPoint> cList;
            if (graph == null)
                cList = centroidList;
            else
                cList = graph.getCentroidList();

            //Convert the lists into usable data for the D3 Graph
            MarkerPointsGraph myGraph = new MarkerPointsGraph();
            var xDataSource = convertToXArray(cList, i).AsXDataSource();
            var yDataSource = convertToYArray(cList, i).AsYDataSource();

            CompositeDataSource compositeDataSource = xDataSource.Join(yDataSource);
            myGraph.DataSource = compositeDataSource;

            //Get the centroid color
            Color color;
            if (cList.Count > 0 && i != -1)
                color = cList.ElementAt(i).color;
            else
                color = Colors.Black;

            //Set the graph colors
            TrianglePointMarker mrk = new TrianglePointMarker();
            mrk.Size = centroidSize;
            mrk.Fill = new SolidColorBrush(color);
            mrk.Pen = new Pen(new SolidColorBrush(Colors.Black), 1.0);
            myGraph.Marker = mrk;

            myGraph.AddToPlotter(plotter);
        }

        private double[] convertToXArray(List<clusterPoint> list, int i)
        {
            List<double> temp = new List<double>();

            foreach (clusterPoint p in list)
            {
                if (p.parent == i)
                    temp.Add(p.x);
            }

            return temp.ToArray();
        }

        private double[] convertToYArray(List<clusterPoint> list, int i)
        {
            List<double> temp = new List<double>();

            foreach (clusterPoint p in list)
            {
                if (p.parent == i)
                    temp.Add(p.y);
            }

            return temp.ToArray();
        }

        public int nextGraph()
        {

            if (itr < graphList.Count - 1)
                itr++;
            else
                itr = 0;

            updateGraph(true, graphList.ElementAt(itr));
             
            return itr + 1;
        }

        public int previousGraph()
        {

            if (itr > 0)
                itr--;
            else
                itr = graphList.Count - 1;

            updateGraph(true, graphList.ElementAt(itr));

            return itr + 1;
        }

        public void clearList()
        {
            graphList.Clear();
            itr = -1;
            itrMarker = -1;
        }

        public int graphCount()
        {
            return graphList.Count;
        }

        public double calculateSSE()
        {
            //Calculate the Sum of Squared error. SSE = E(dist(a,b)^2)
            double sum = 0;

            for (int i = 0; i < centroidList.Count; i++)
            {
                clusterPoint c = centroidList.ElementAt(i);

                foreach (clusterPoint d in dataList)
                {
                    if (d.parent == i)
                        sum += Math.Pow(distance(c, d), 2);
                }
            }

            return sum;
        }

        private double distance(clusterPoint a, clusterPoint b)
        {
            return Math.Sqrt(Math.Pow(b.x - a.x, 2) + Math.Pow(b.y - a.y, 2));
        }

        public List<clusterPoint> getOriginalCentroid()
        {
            if (graphList.Count > 0)
                return graphList.ElementAt(0).getCentroidList();
            else
                return null;
        }
    }
}
