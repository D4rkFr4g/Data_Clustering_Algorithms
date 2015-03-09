Data Clustering Algorithms:

This program is an unsupervised approach to clustering or grouping data points based on Euclidean distance. It's assumed that data points closest to each other share traits and characteristics.

Any number of data points and clusters can be chosen, but with additional data the program will run slower. No visible indication of processing is shown so it can be confused with the program being frozen. Please allow time for the algorithm to finish if using large amounts of data.

Control information can be found in the Help menu button under How To.

Algorithms:

K-means Algorithm Information:
http://en.wikipedia.org/wiki/K-means

Leader Algorithm Information:
Clusters are selected by looking at each data point and assigning it to the closest centroid if it is within the threshold. If it outside the threshold a new cluster is created. The process is repeated until all data points have been assigned to a cluster

Radial Average:
An algorithm of my own creation similar to K-means algorithm but specialized for clusters of varying size. In this algorithm the distance used to compare a data point to different clusters is the distance from the data point to the centroid minus the average radius of all the cluster points not allowing for negative distance. This allows a very dense cluster to not try and pull data points from a cluster that has it's data points spread out.


Open Source:

Dynamic Data Display D3:
http://dynamicdatadisplay.codeplex.com/

Extended WPF Toolkit:
http://wpftoolkit.codeplex.com/