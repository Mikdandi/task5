   M S B A M L   `   `   `  ����@  <task5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:task5.View
task5.View  5   	       task5.View.TaskListView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:task5.View     5   	   $	��450��5   
   $	��800��6   .��5	      � .+�5   
   �� -   5          ��Name$  comboBox��5   2   $��25��6E   $	��120��6Q   $��10,110,670,314.6q�6]    �� Text 6   �� *SelectedSort+.@�5      �� .��6   None6"   �� 5      .��6   Sort by Name6*   �� 5      .��6   
Sort by ID6'   �� 5      .��6   Sort by Activity6-   �� 5      .��6   Sort by CPU6(   �� 5      .��6   Sort by RAM%6)   �� 5      .��6   Sort by RAM6(   �� 5      .��6   Sort by number of flows64   �� 5      .��6   Sort by UserName6-   �� 5      .��6   Sort by path6)   �� 5      .��6   Sort by date6)   5      �� 5   
   $
��Sort��65   $��10,140,670,284.6q�6D   $��25��6^   $	��120��6j   ��6   �� *SortCommand+6y   &   System.Windows.Controls.DataGrid  5   
      AlternatingRowBackground
 ��� �   
IsReadOnly . $��0��6�      AutoGenerateColumns .     CanUserSortColumns .  ��. $	��350��62  $	��600��6?   J� RenderTransformOrigin$ 
0.679,0.44&�6K  $��135,0,65,-0.4q�6n   �� SelectedItem 6   �� *
Selected+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=���6�   �� *
TaskList+$ OneWay=�
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Name of Process��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *NameOfProcess+6b     5      $ ID��6%    61   �� *ID+6J     5      $ Activity of Process��6%    6B   �� *ActivityofProcess+6j     5      $	 CPU��6%    62   �� *CPU+6L     5      $
 RAM%��6%    63   �� *RAM%+6N     5       $	 RAM��6%    62   �� *RAM+6L     5!      $ Number of Flows��6%    6>   �� *NumberOfFlows+6b     5"      $ UserName��6%    67   �� *
UserName+6V     5#      $
 Path��6%    63   �� *Path+6N     5$      $
 Date��6%    63   �� *Date+6N    � ContextMenu 5'      �� 5(      .@�5)      m� $��Show Threads��6    m� Command 65   �� *ShowThreadsCommand+ m� CommandParameter 6\   ��  �� RelativeSource �� *Self+ �� Path$ Parent�m� 5*      $��Show modules��6    65   �� *ShowModulesCommand+ 6\   ��  �� *Self+$ Parent�m� 5+      $��Open folder��6    64   �� *OpenFolderCommand+ 6Z   ��  �� *Self+$ Parent�5-      5/      50      51      