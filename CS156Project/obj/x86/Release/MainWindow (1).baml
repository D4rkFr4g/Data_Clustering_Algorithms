   M S B A M L   `   `   `  ����   DataClusteringAlgorithms    CS156Project.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     b ^DynamicDataDisplay.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=5b7d744a7263923fY UDynamicDataDisplay, Version=0.3.0.0, Culture=neutral, PublicKeyToken=5b7d744a7263923f?d34http://research.microsoft.com/DynamicDataDisplay/1.0     � Title$   Data Clustering Algorithms��$	��370��$	��525�� � 
ResizeMode$ CanResizeWithGrip=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$ SingleBorderWindow=� � Icon$4 ./DataClusteringAlgorithms;component/Icon32.ico��$	��525��$	��370��.���  � RowDefinitions �� $
��Auto ��� �� $
��Auto � � ColumnDefinitions �� $
��Auto ��� $��2* �.+�o�  o� 
IsMainMenu . $��0��$��0��$��2��.@�m� $
��File��.@�m� -   $��Start���� m� -   $��Reset���� m� -   $
��Exit��m� $��Graph��.@�m� $��Fit to View�� m� CommandParameter$
 Home��m� $��
Screenshot��m� $��Copy to Clipboard��m� $
��Help��.@�m� $��About��8  2Microsoft.Research.DynamicDataDisplay.ChartPlotter  -   $��plotter��$��1��$��1��$��0,5,5,0q�5  /Microsoft.Research.DynamicDataDisplay.Plotter2D	   Visible	 � 
 � X$
 -3Q� � Y$ -3Q� � Width$	 110Q� � Height$	 110Q�3  -Microsoft.Research.DynamicDataDisplay.Plotter   Children. =  7Microsoft.Research.DynamicDataDisplay.MarkerPointsGraph  -   $��graph���� -   $��
buttonBack��$��Center=�$��Bottom=�$��2��$��1��$��	10,0,10,0q�$��120,0,174,3q�$��9��.��<<�� -   $��buttonForward��$��Center=�$��Bottom=�$��2��$��1��$��	10,0,10,0q�$��176,0,118,3q�$��10��.��>>�� -   $��debugMousePosition��$��	215,0,0,0q�$
��Left=�$��2��$��1��$��Right=�$y�Hidden=�.��Mouse (0,0)�� -	   $��graphNumber��$��2��$��1��$��Center=��� -
   $��gb��$��Input��$��1��$��2��$	��312��$	��170��$
��Left=�$	��Top=�$	��170��$	��312��.��� 
����ح�$��0�� �� �� �� ��  �� �� .+��� $��Center=�$��Center=�.��Data Points�� -   $��textBoxData��$��1��$��Center=�$��Right=�$��5q�$��0��.��0�� -   $��buttonDataRandomize��$��1��$��5,0,5,1q�$��22��$��Bottom=�$��2��.��	Randomize�� $��1��$��Center=�$��Center=�.��
Clusters�� -   $��textBoxClusters��$��1��$��1��$��Center=�$��Right=�$��5q�$��3��.��0�� -   $��buttonClusterRandomize��$��1��$��1��$��Bottom=�$��5,0,5,1q�$��4��.��	Randomize�� $��2��$��0��$��2�� J� SnapsToDevicePixels . 
������� �� Stretch$
 Fill=�	 �� X1$ 0��	 �� X2$ 1��$	��Top=�$��5q��� $��2��$��2��$��Center=�$	��Top=�$��	47,7,47,0q�.��	Algorithm	� -   $��radioKMeans��$��Bottom=�$��Center=�$��2��$��Center=�$��Center=� d� 	IsChecked$
 TrueY�$��5��	� -   $��radioLeader��$��2��$��1��$��Center=�$��Center=�$��6���� $��2��$��Bottom=�$��Center=�.��	K-Means�� $��2��$��1��$��Bottom=�$��Center=�.��Leader�� $��3��$��0��$��2�� . 
�������$
 Fill=�$ 0��$ 1��$	��Top=�$��5q��� -   $��buttonStart��$��3��$��Center=�$��Stretch=�$��	5,0,2.5,0q�$��7��.��Start�� -   $��buttonReset��$��3��$��1��$��Center=�$��Stretch=�$��0,0,5,0q�$��8��.��Reset�� -   $��checkKeepData��$��3��$��1��$��Bottom=�$��0,5,5,5q�.��	Keep Data