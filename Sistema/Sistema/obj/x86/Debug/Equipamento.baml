   M S B A M L   `   `   `  ����  Sistema    Sistema.Equipamento   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Equipamento��5   	   $	��323��6   $	��351��6*    � 
ResizeMode$ CanMinimize=�66    � WindowStartupLocation$ CenterScreen=�6O   .��5      � .+�5   
   �� -   5        $��txtPesquisa��5   M   $��23��6   $
��Left=�6   $��
140,12,0,0q�69   $	��Top=�6`   $	��181��6x   �� 5   
   -   5        $��cbFiltro��5   M   $��23��6   $
��Left=�6   $��	12,12,0,0q�6:   $	��Top=�6]   $	��120��6u   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dtgEquipamento��5   �      AutoGenerateColumns .  $	��200��6/   $
��Left=�6<   $��	12,49,0,0q�6�   $	��Top=�6�   $	��309��6�   ���	#FFF0F0F0��6X   ��  �� Path$ equipamentoDataBinding�   VerticalGridLinesBrush 5	      �� 5
         HorizontalGridLinesBrush 5      �� 5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Codigo��6Q   	   
Visibility$	 Hidden=�6a   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� $ codigo_equipamento�6a     5      $ Equipamento��6H      Width5  /System.Windows.Controls.DataGridLengthConverter$	 152 6]      
IsReadOnly . 
 6%   �� $ 	descricao�6i     5      $ 	Categoria��6H   $	 152 6[    . 
 6%   �� $ 	Categoria�6g   5      �� 5   
   -   5        $��
btCancelar��5   `   $��Cancelar��6   $��23��6$   $
��Left=�60   $��246,255,0,0q�6K   $	��Top=�6r   $��75��6�   6�   �� 5   
   -   5        $��	btExcluir��5   _   $��Excluir��6   $��23��6#   $
��Left=�6/   $��168,255,0,0q�6J   $	��Top=�6p   $��75��6�   {�.  6�   �� 5   
   -   5        $��	btIncluir��5   ^   $��Incluir��6   $��23��6#   $
��Left=�6/   $��
12,255,0,0q�6J   $	��Top=�6o   $��75��6�   6�   �� 5   
   -   5        $��btConsultar��5   `   $��	Consultar��6   $��23��6%   $
��Left=�61   $��
90,255,0,0q�6L   $	��Top=�6s   $��75��6�   {�.  6�   5      5      