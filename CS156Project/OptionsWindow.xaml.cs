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
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;

namespace CS156Project
{
    /// <summary>
    /// Interaction logic for OptionsWindow.xaml
    /// </summary>
    public partial class OptionsWindow : Window
    {
        private GraphControl graphControl;
        private Window mainWindow;

        public OptionsWindow(Window w, GraphControl graphControl)
        {
            InitializeComponent();
            mainWindow = w;

            this.graphControl = graphControl;

            upDownData.Value = graphControl.getDataSize();
            upDownCentroid.Value = graphControl.getCentroidSize();
            upDownKMeans.Value = graphControl.kMeansThreshold;
            upDownLeader.Value = graphControl.leaderThreshold;
        }

        private void upDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            //Feed new data back to the values in the original window
            IntegerUpDown temp = (IntegerUpDown) sender;

            if (temp == upDownData)
                graphControl.setdataSize((int) temp.Value);
            else if (temp == upDownCentroid)
                graphControl.setCentroidSize((int) temp.Value);
        }

        private void upDownAlgorithm_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            //Feed new data back to the values in the original window
            DoubleUpDown temp = (DoubleUpDown)sender;

            if (temp == upDownKMeans)
                graphControl.kMeansThreshold = (double) temp.Value;
            else if (temp == upDownLeader)
                graphControl.leaderThreshold = (double) temp.Value;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Set the options window to be located exactly in the center of the main window.
            if (mainWindow.WindowState == System.Windows.WindowState.Maximized)
            {
                this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            }
            else
            {
                this.Top = mainWindow.Top + (mainWindow.ActualHeight / 2.0) - (this.ActualHeight / 2.0);
                this.Left = mainWindow.Left + (mainWindow.ActualWidth / 2.0) - (this.Width / 2.0);
            }
        }
    }
}
