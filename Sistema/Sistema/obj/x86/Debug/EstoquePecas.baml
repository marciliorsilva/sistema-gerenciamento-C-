   M S B A M L   `   `   `  ����  Sistema    Sistema.EstoquePecas   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  EstoquePecas��5   	   $	��282��6   $	��447��6+    � 
ResizeMode$ CanMinimize=�67    � WindowStartupLocation$ CenterScreen=�6P   .��5      � .+�5   
   �� -   5        $��cbFiltro��5   M   $��23��6   $
��Left=�6   $��	12,12,0,0q�6:   $	��Top=�6]   $	��120��6u   �� 5   
   -   5        $��txtPesquisa��5   M   $��23��6   $
��Left=�6   $��
138,12,0,0q�69   $	��Top=�6`   $	��275��6x   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dtgEstoquePecas��5   �      AutoGenerateColumns .     CanUserResizeRows .  $	��169��6~   $��	12,39,0,0q�6�   $	��Top=�6�   $	��401��6�   $
��Left=�6�   ���	#FFF0F0F0��6I   ��  �� Path$ estoquePecasDataBinding�   Columns 5	      0  *System.Windows.Controls.DataGridTextColumn  5
      ,  &System.Windows.Controls.DataGridColumn   Header$ Codigo��6R      
Visibility$ Hidden=�6b   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6%   �� $ codigo_estoquePecas�6b     5      $ Peça��6C   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 125 6Q      
IsReadOnly . 	 6%   �� $
 Peca�6]     5      $ 
Quantidade��6I   $	
 132 6]    . 	 6%   �� $ 
Quantidade�6i     5      $ 
Fornecedor��6I   $	
 141 6]    . 	 6%   �� $ 
Fornecedor�6i      HorizontalGridLinesBrush 5      �� 5         VerticalGridLinesBrush 5      �� 5         RowBackground 5      �� 5      5      �� 5   
   -   5        $��
btCancelar��5   `   $��Cancelar��6   $��23��6$   $
��Left=�60   $��338,214,0,0q�6K   $	��Top=�6r   $��75��6�   �� 5   
   -   5        $��btConsultar��5   a   $��	Consultar��6   $��23��6%   $
��Left=�61   $��257,214,0,0q�6L   $	��Top=�6t   $��75��6�   6�   �� 5   
   -   5        $��	btIncluir��5   _   $��Incluir��6   $��23��6#   $
��Left=�6/   $��176,214,0,0q�6J   $	��Top=�6p   $��75��6�   6�   5      5      