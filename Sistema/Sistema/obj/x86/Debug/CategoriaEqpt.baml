   M S B A M L   `   `   `  ����  Sistema    Sistema.CategoriaEqpt   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  CategoriaFornecedor��5   	   $	��307��6%   $	��344��62    � 
ResizeMode$ CanMinimize=�6>    � WindowStartupLocation$ CenterScreen=�6W   .��5      � .+�5   
   �� -   5        $��txtDescricao��5   L   $��23��6   $
��Left=�6   $��	12,28,0,0q�69   $	��Top=�6`   $	��298��6x   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dtgCategoria��5   �      AutoGenerateColumns .     CanUserResizeRows .  $	��142��6{   $��	12,91,0,0q�6�   $	��Top=�6�   $	��298��6�   $
��Left=�6�   ��6I   ��  �� Path$ categoriaDataBinding�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5	      ,  &System.Windows.Controls.DataGridColumn   Header$ Codigo��6O      
Visibility$ Hidden=�6_   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6%   �� $ codigo_categoria�6_     5
      $ 	Categoria��6H   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 288 6[      
IsReadOnly . 	 6%   �� $ 	descricao�6g      HorizontalGridLinesBrush 5      �� 5         VerticalGridLinesBrush 5      �� 5         RowBackground 5      �� 5      5      �� 5   
   -   5        $��	btExcluir��5   ^   $��Excluir��6   $��23��6#   $
��Left=�6/   $��
207,61,0,0q�6J   $	��Top=�6o   $��75��6�   {�.  6�   �� 5   
   -   5        $��	btAlterar��5   ^   $��Alterar��6   $��23��6#   $
��Left=�6/   $��
126,61,0,0q�6J   $	��Top=�6o   $��75��6�   {�.  6�   �� 5   
   -   5        $��btAdd��5   _   $��	Adicionar��6   $��23��6%   $
��Left=�61   $��	45,61,0,0q�6L   $	��Top=�6l   $��75��6�   6�   �� 5   
   -   5        $��button4��5   `   $��Cancelar��6   $��23��6$   $
��Left=�60   $��235,239,0,0q�6K   $	��Top=�6o   $��75��6�   6�   �� 5   
   -   5        $��label2��5   \   $��	Categoria��6   $��28��6$   $
��Left=�60   $��8,7,0,0q�6K   $	��Top=�6j   5      5      