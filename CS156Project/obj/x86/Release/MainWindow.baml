   M S B A M L   `   `   `  ����   DataClusteringAlgorithms    CS156Project.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     b ^DynamicDataDisplay.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=5b7d744a7263923fY UDynamicDataDisplay, Version=0.3.0.0, Culture=neutral, PublicKeyToken=5b7d744a7263923f?d34http://research.microsoft.com/DynamicDataDisplay/1.0     � Title$   Data Clustering Algorithms��$	��370��$	��550�� � 
ResizeMode$ CanResizeWithGrip=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$ SingleBorderWindow=� � Icon$4 ./DataClusteringAlgorithms;component/Icon32.ico��$	��550��$	��370��.���  � RowDefinitions �� $
��Auto ��� �� $
��Auto � � ColumnDefinitions �� $
��Auto ��� $��2* �.+�o�  o� 
IsMainMenu . $��0��$��0��$��2��.@�m� $
��File��$��0��.@�m� -   $��Start���� m� -   $��Reset���� m� -   $
��Exit��m� $��Graph��$��2��.@�m� -   $	��fit��$��Fit to View���� m� -   $��
screenshot��$��
Screenshot���� m� -   $��Options��m� $
��Help��$��3��.@�m� -   $��howTo��$��How To��m� -   $��about��$��About��8  2Microsoft.Research.DynamicDataDisplay.ChartPlotter  -	   $��plotter��$��1��$��1��$��0,5,5,0q�$��12��5  /Microsoft.Research.DynamicDataDisplay.Plotter2D   Visible � 	 � X$	 -3Q�
 � Y$
 -3Q� � Width$	 110Q� � Height$	 110Q�3  -Microsoft.Research.DynamicDataDisplay.Plotter   Children. =  7Microsoft.Research.DynamicDataDisplay.MarkerPointsGraph  -
   $��graph��|�. �� -   $��
buttonBack��$��Center=�$��Bottom=�$��2��$��1��$��	10,0,10,0q�$��120,0,174,3q�$��13�� � ToolTip$  Click to see previous step��.��<<�� -   $��buttonForward��$��Center=�$��Bottom=�$��2��$��1��$��	10,0,10,0q�$��176,0,118,3q�$��14��$ Click to see next step��.��>>�� -   $��graphNumber��$��2��$��1��$��Center=��� -   $��debugMousePosition��$��	215,0,0,0q�$
��Left=�$��2��$��1��$��Right=�$y�Hidden=�.��Mouse (0,0)�� -   $	��sse��$��Right=�$��2��$��1��$
��Left=�$y�Visible=�$��0,0,5,0q��� -   $��gb��$��Input��$��1��$��2��$	��312��$	��200��$
��Left=�$	��Top=�$	��170��$	��312��.��� 
����ح�$��0�� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � �� $
��Auto ��� $
��Auto �.+��� $��Center=�$��Center=�.��Data Points�� -   $��textBoxData��$��1��$��Center=�$��Right=�$��5q�$��4�� � ForceCursor .  .��0�� -   $��buttonDataRandomize��$��1��$��1��$��5,0,5,10q�$��22��$��Bottom=�$��Center=�$��5��$. (Click to add the # of random data points��.��	Randomize�� $��2��$��Center=�$��Center=�.��
Clusters�� -   $��textBoxClusters��$��2��$��1��$��Center=�$��Right=�$��5q�$��6��.��0�� -   $��buttonClusterRandomize��$��3��$��1��$��Center=�$��Center=�$��5,0,5,10q�$��7��$, &Click to add the # of random centroids��.��	Randomize�� $��4��$��0��$��2�� J� SnapsToDevicePixels . 
������� �� Stretch$
 Fill=�	 �� X1$ 0��	 �� X2$ 1��$	��Top=�$��5q�� $��4��$��2��$��0,0,0,5q� �� $
��Auto ��� $
��Auto ��� $
��Auto � �� $��1* ��� $��1* ��� $��1* �.+��� $��0��$��3��$��Center=�$��Center=�$��5q�.��	Algorithm�� $��1��$��Bottom=�$��Center=�.��	K-Means	� -   $��radioKMeans��$��Bottom=�$��Center=�$��2��$��0��$��Center=�$��Center=� d� 	IsChecked$
 TrueY�$��8���� $��1��$��1��$��Bottom=�$��Center=�.��Radial	� -   $��radioRadial��$��2��$��1��$��Center=�$��Center=�$��9���� $��1��$��2��$��Bottom=�$��Center=�.��Leader	� -   $��radioLeader��$��2��$��2��$��Center=�$��Center=�$��10���� $��5��$��0��$��2�� . 
�������$
 Fill=�$ 0��$ 1��$	��Top=�$��2q��� -   $��buttonStart��$��5��$��Center=�$��Center=�$��	5,15,5,15q�$��	20,0,20,0q�$��10��$- 'Click to run the algorithm chosen above��.��Start�� -   $��buttonReset��$��5��$��1��$��Center=�$��Center=�$��	5,15,5,15q�$��	20,0,20,0q�$��11��$ Click to clear the graph��.��Reset�� -   $��checkKeepCentroid��$��6��$��0��$��Bottom=�$��0,5,5,5q�$��12��$C =Check to keep data points when using reset to clear the graph��.��Keep Centroid�� -   $��checkKeepData��$��6��$��1��$��Bottom=�$��0,5,5,5q�$��13��$C =Check to keep data points when using reset to clear the graph��.��	Keep Data