   M S B A M L   `   `   `  ����  Sistema    Sistema.Estoque   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Estoque��5   	   $	��234��6   $	��595��6&    � 
ResizeMode$ CanMinimize=�62    � WindowStartupLocation$ CenterScreen=�6K   .��5      � .+�5   
   �� -   5        $��
btCancelar��5   `   $��Cancelar��6   $��23��6$   $
��Left=�60   $��486,164,0,0q�6K   $	��Top=�6r   $��75��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��
dtgEstoque��5   �      AutoGenerateColumns .     CanUserResizeRows .  $	��119��6y   $��	12,39,0,0q�6�   $	��Top=�6�   $	��549��6�   $
��Left=�6�   ���	#FFF0F0F0��6I   ��  �� Path$ estoqueDataBinding�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5	      ,  &System.Windows.Controls.DataGridColumn   Header$ Codigo��6M      
Visibility$ Hidden=�6]   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6%   �� $ codigo_estoque�6]     5
      $ Equipamento��6J   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 182 6_      
IsReadOnly . 	 6%   �� $ Equipamento�6k     5      $ 
Quantidade��6I   $	
 182 6]    . 	 6%   �� $ 
Quantidade�6i     5      $ 
Fornecedor��6I   $	
 181 6]    . 	 6%   �� $ 
Fornecedor�6i      HorizontalGridLinesBrush 5      �� 5         VerticalGridLinesBrush 5      �� 5         RowBackground 5      �� 5      5      �� 5   
   -   5        $��	comboBox1��5   M   $��23��6   $
��Left=�6   $��	12,11,0,0q�6:   $	��Top=�6^   $	��120��6v   �� 5   
   -   5        $��textBox1��5   M   $��23��6   $
��Left=�6   $��
138,11,0,0q�69   $	��Top=�6]   $	��423��6u   �� 5   
   -   5        $��btConsultar��5   a   $��	Consultar��6   $��23��6%   $
��Left=�61   $��405,164,0,0q�6L   $	��Top=�6t   $��75��6�   {�.  6�   �� 5   
   -   5        $��btListaSolicitacao��5   l   $��Lista de Solicitações��6   $��23��61   $
��Left=�6=   $��
12,164,0,0q�6X   $	��Top=�6�   $	��120��6�   6�   �� 5   
   -   5        $��	btIncluir��5   _   $��Incluir��6   $��23��6#   $
��Left=�6/   $��324,164,0,0q�6J   $	��Top=�6p   $��75��6�   6�   5      5      