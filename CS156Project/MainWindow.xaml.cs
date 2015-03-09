using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using Microsoft.Research.DynamicDataDisplay.PointMarkers;
using Microsoft.Research.DynamicDataDisplay.Charts;
using Microsoft.Research.DynamicDataDisplay.Common;

namespace CS156Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private bool debug = false;
        private bool algorithmRun = false;
        private List<clusterPoint> dataList;
        private List<clusterPoint> centroidList;
        private int dataPoints;
        private int centroidPoints;
        private RandomColor randomColor;
        private RandomClusterPoint randomClusterPoint;
        public GraphControl graphControl;

        public MainWindow()
        {
            InitializeComponent();

            dataList = new List<clusterPoint>();
            centroidList = new List<clusterPoint>();
            dataPoints = Int32.Parse(textBoxData.Text);
            centroidPoints = Int32.Parse(textBoxClusters.Text);
            randomColor = new RandomColor();
            randomClusterPoint = new RandomClusterPoint();
            graphControl = new GraphControl(plotter, dataList, centroidList);
            
            plotter.Viewport.PropertyChanged += adjustView;

            textBoxData.Focus();
        }

        private void plotter_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!algorithmRun)
            {
                //Gather coordinates from Mouse and save as a point
                Point p = Mouse.GetPosition(plotter.CentralGrid).ScreenToViewport(plotter.Transform);
                clusterPoint c = new clusterPoint(p);

                //Process a Centroid Addition
                if (e.MiddleButton == MouseButtonState.Pressed && (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift)))
                {
                    c.color = randomColor.getColor();
                    centroidList.Add(c);
                    c.parent = centroidList.Count - 1;
                }
                //Process a Data Point Addition
                else if (e.MiddleButton == MouseButtonState.Pressed)
                    dataList.Add(c);

                //Update the Text fields based on the stored values
                textBoxData.Text = dataList.Count().ToString();
                textBoxClusters.Text = centroidList.Count().ToString();

                graphControl.updateGraph(algorithmRun, null);
            }

        }

        private void plotter_KeyUp(object sender, KeyEventArgs e)
        {
            if (!algorithmRun)
            {
                //Gather coordinates from Mouse and save as a point
                Point p = Mouse.GetPosition(plotter.CentralGrid).ScreenToViewport(plotter.Transform);
                clusterPoint c = new clusterPoint(p);

                //Process a Centroid Addition
                if (e.Key == Key.C)
                {
                    c.color = randomColor.getColor();
                    centroidList.Add(c);
                    c.parent = centroidList.Count - 1;
                }
                //Process a Data Point Addition
                else if (e.Key == Key.D)
                    dataList.Add(c);

                //Update the Text fields based on the stored values
                textBoxData.Text = dataList.Count().ToString();
                textBoxClusters.Text = centroidList.Count().ToString();

                graphControl.updateGraph(algorithmRun, null);
            }
        }

        private void plotter_MouseMove(object sender, MouseEventArgs e)
        {
            //Debug information for mouse/graph coordinates
            Point p = Mouse.GetPosition(plotter.CentralGrid).ScreenToViewport(plotter.Transform);

            debugMousePosition.Content = "Mouse (" + Math.Round(p.X,2) + "," + Math.Round(p.Y,2) + ")";
        }

        private void buttonReset_Click(object sender, RoutedEventArgs e)
        {
            algorithmRun = false;

            plotter.RemoveUserElements();
            centroidList.Clear();

            //Either save centroids or delete centroids
            if (checkKeepCentroid.IsChecked == true)
            {
                if (graphControl.getOriginalCentroid() != null)
                    centroidList.AddMany(graphControl.getOriginalCentroid().ToArray());
            }
            else
                textBoxClusters.Text = "0";
            
            //Either save data points or delete data points
            if (checkKeepData.IsChecked == false)
            {
                dataList.Clear();
                plotter.Visible = new Rect(-3, -3, 110, 110);
                textBoxData.Text = "0";
            }
            else
            {
                foreach (clusterPoint c in dataList)
                    c.clearParent();
            }
            
            //Clear Values from Window
            graphNumber.Content = "";
            sse.Content = "";

            graphControl.clearList();
            graphControl.updateGraph(algorithmRun, null);
            
            //Reset boolean variables
            textBoxData.Focus();
            buttonStart.IsEnabled = true;
            buttonClusterRandomize.IsEnabled = true;
            buttonDataRandomize.IsEnabled = true;
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            runAlgorithm();

            //I believe I deprecated this functionality of being able to run the algorithm multiple times in a row.
            int temp = graphControl.graphCount();
            if (temp != 0)
                graphNumber.Content = temp.ToString();
            else
                graphNumber.Content = "";
        }

        private void buttonRandomize_Click(object sender, RoutedEventArgs e)
        {
            //Place Random Data Points
            if (e.Source.Equals(buttonDataRandomize))
            {
                for (int i = 0; i < dataPoints; i++)
                    dataList.Add(randomClusterPoint.getPoint());
            }
            //Place Random Centroids
            else if (e.Source.Equals(buttonClusterRandomize))
            {
                for (int i = 0; i < centroidPoints; i++)
                {
                    clusterPoint c = randomClusterPoint.getPoint();
                    c.color = randomColor.getColor();
                    c.parent = centroidList.Count;
                    centroidList.Add(c);
                }
            }
            graphControl.updateGraph(algorithmRun, null);
            plotter.FitToView();
        }

        private void runAlgorithm()
        {
            //Run the algorithm based on which radio box was selected
            if (radioKMeans.IsChecked == true)
            {
                KMeans.run(dataList, centroidList, graphControl, graphControl.kMeansThreshold);
                graphControl.markIterator();
            }
            else if (radioLeader.IsChecked == true)
            {
                //Clear centroidList if it was forgotten
                centroidList.Clear();

                Leader.run(dataList, centroidList, graphControl, graphControl.leaderThreshold);
                graphControl.markIterator();
            }
            else if (radioRadial.IsChecked == true)
            {
                AvgRadial.run(dataList, centroidList, graphControl, graphControl.kMeansThreshold);
                //AvgRadial2.run(dataList, centroidList, graphControl, graphControl.kMeansThreshold);
                graphControl.markIterator();
            }
                
            //Set booleans
            algorithmRun = true;
            buttonStart.IsEnabled = false;
            buttonClusterRandomize.IsEnabled = false;
            buttonDataRandomize.IsEnabled = false;

            //Update Cluster field for Leader Algorithm
            textBoxClusters.Text = centroidList.Count.ToString();

            sse.Content = "SSE: " + Math.Round(graphControl.calculateSSE(), 0);
        }

        private void buttonForward_Click(object sender, RoutedEventArgs e)
        {
            //Cycle to the next list of points in the Graph Control to be displayed
            int temp = graphControl.nextGraph();
            if (temp != 0)
                graphNumber.Content = temp.ToString();
            else
                graphNumber.Content = "";
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            //Cycle to the previous list of points in the Graph Control to be displayed
            int temp = graphControl.previousGraph();
            if (temp != 0)
                graphNumber.Content = temp.ToString();
            else
                graphNumber.Content = "";
        }

        private void textBoxData_LostFocus(object sender, RoutedEventArgs e)
        {
            //Set the value of the centroids and data points to be randomized based on the textbox strings. This insures the fields are only set once the user has navigated away from the textbox itself.
            // This also checks and ensures valid data was put into the fields or returns an error.
            if (e.Source == textBoxData)
            {
                if (!textBoxData.Text.Equals(""))
                {
                    try
                    {
                        dataPoints = Int32.Parse(textBoxData.Text);
                    }
                    catch (Exception exp)
                    {
                        System.Media.SystemSounds.Exclamation.Play();
                        MessageBox.Show(this, "Invalid Input", "Error");
                        
                        //Reset TextBox to data value
                        textBoxData.Text = dataPoints.ToString();
                    }
                }
                else
                    dataPoints = 0;
            }
            else if (e.Source == textBoxClusters)
            {
                if (!textBoxClusters.Text.Equals(""))
                {
                    try
                    {
                        centroidPoints = Int32.Parse(textBoxClusters.Text);
                    }
                    catch (Exception exp)
                    {
                        System.Media.SystemSounds.Exclamation.Play();
                            
                        MessageBox.Show(this, "Invalid Input", "Error");

                        //Reset TextBox to data value
                        textBoxClusters.Text = centroidPoints.ToString();
                    }
                }
                else
                    centroidPoints = 0;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void graphMenu_Click(object sender, RoutedEventArgs e)
        {   
            //Menu bar features for Fit to View and screenshot
            if (e.Source.Equals(fit))
                plotter.FitToView();
            else if (sender.Equals(screenshot))
            {
                plotter.CopyScreenshotToClipboard();
                MessageBox.Show("Screenshot Saved to Clipboard", "Screenshot");
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox windows for the about and how to information
            if (sender == about)
                MessageBox.Show("\tData Clustering Algorithms\n\t  Created by Zane Melcho\n\n             Open-Source Graphing Software:\n\tDynamic Data Display D3\n     http://dynamicdatadisplay.codeplex.com/", "About");
            else if (sender == howTo)
                MessageBox.Show("Add a Data Point:\tWith graph selected press \"D\" key\n\t\tOr\n\t\tMiddle mouse click on graph\n\nAdd a Centroid:\tWith graph selected press \"C\" key\n\t\tOr\n\t\tShift + middle mouse click on graph", "How To");
        }

        private void options_Click(object sender, RoutedEventArgs e)
        {
            //New window created for the options/settings
            OptionsWindow w = new OptionsWindow(this, graphControl);
            w.ShowDialog();
        }

        protected void adjustView(object sender, EventArgs e)
        {
            //This function deals with a bug in the D3 graphing utility. Upon switching graphs the scale of the axis' change slightly causing the graph to jump.
            // By forcing it to check it's size and set itself to the current size it somehow removes this bug.
            if (!plotter.Visible.Equals(new Rect(0, 0, 1, 1)))
            {
                Rect rect = plotter.Visible;

                plotter.Visible = new Rect(rect.X, rect.Y, rect.Width, rect.Height);
            }
        }

        private void radio_Checked(object sender, RoutedEventArgs e)
        {
            //Disable non-essential features if the selected Algorithm is Leader
            if (sender == radioLeader)
            {
                buttonClusterRandomize.IsEnabled = false;
                textBoxClusters.IsEnabled = false;
            }
            else if (sender == radioKMeans || sender == radioRadial)
            {
                buttonClusterRandomize.IsEnabled = true;
                textBoxClusters.IsEnabled = true;
            }
        }
    }
}
