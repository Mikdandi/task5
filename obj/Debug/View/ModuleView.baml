   M S B A M L   `   `   `  ����@  <task5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:task5.ViewModeltask5.ViewModel  5   	        task5.ViewModel.ModuleView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:task5.ViewModel     5   	   $	��450��5      $	��800��6   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid      AlternatingRowBackground
  ��� �   
IsReadOnly . $��0��6�      AutoGenerateColumns .     CanUserSortColumns .  ��. $	��350��62  $	��600��6?   J� RenderTransformOrigin$ 
0.679,0.44&�6K  $��135,0,65,-0.4q�6n   �� SelectedItem 6   �� *
Selected+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���6�   �� *
TaskList+$ OneWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *ID+6J     5      $
	 Path��6%   
 63   �� *Path+6N   5      5      5      