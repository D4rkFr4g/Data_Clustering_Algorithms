using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS156Project
{
    public class Graph
    {
        List<clusterPoint> centroidList;
        List<clusterPoint> dataList;

        public Graph(List<clusterPoint> centroidList, List<clusterPoint> dataList)
        {
            this.centroidList = graphCopy(centroidList);
            this.dataList = graphCopy(dataList);
        }

        public List<clusterPoint> getCentroidList()
        {
            return centroidList;
        }

        public List<clusterPoint> getDataList()
        {
            return dataList;
        }

        public List<clusterPoint> copyCentroidList()
        {
            return graphCopy(centroidList);
        }

        private List<clusterPoint> graphCopy(List<clusterPoint> cList)
        {
            List<clusterPoint> temp = new List<clusterPoint>();

            foreach (clusterPoint c in cList)
            {
                temp.Add(new clusterPoint(c.x, c.y, c.parent, c.color));
            }

            return temp;
        }
    }
}
