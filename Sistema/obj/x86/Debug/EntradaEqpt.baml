   M S B A M L   `   `   `  ����  Sistema    Sistema.EntradaEqpt   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  EntradaEqpt��5   	   $	��313��6   $	��537��6*    � 
ResizeMode$ CanMinimize=�66    � WindowStartupLocation$ CenterScreen=�6O   .��5      � .+�5   
   �� -   5        $��txtPesquisa��5   Q   $��23��6   $��Stretch=�6   $��212,24,12,0q�6<   $	��Top=�6d   �� 5   
   -   5        $��cbFiltro��5   4   $��23��6   $��94,24,309,0q�6   $	��Top=�6D   $��Stretch=�6\   &   System.Windows.Controls.DataGrid  5   
   -   5        $��
dtgEntrada��5   �      AutoGenerateColumns .  $	��213��6/   $��Stretch=�6<   $��93,49,12,12q�6�   $��Stretch=�6�   ���	#FFF0F0F0��6[   ��  �� Path$ entradaDataBinding�   VerticalGridLinesBrush 5	      �� 5
         HorizontalGridLinesBrush 5      �� 5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Codigo��6E   	   
Visibility$	 Hidden=�6U   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� $ Codigo�6U     5      $ Nota Fiscal��6I      Width5  /System.Windows.Controls.DataGridLengthConverter$ 75 6^      
IsReadOnly . 
 6%   �� $ 
NotaFiscal�6i     5      $ Data da Solicitação��6C   $	 115 6`    . 
 6%   �� $
 Data�6l     5      $ 
Fornecedor��6I   $ 85 6]    . 
 6%   �� $ 
Fornecedor�6h     5      $ Equipamento��6J   $	 102 6_    . 
 6%   �� $ Equipamento�6k     5      $ 
Quantidade��6I   $	 152 6]    . 
 6%   �� $ 
Quantidade�6i     5      $ Observação��6I   $	 152 6]    . 
 6%   �� $ Observação�6i     5      $ 
Situação��6G   $	 152 6Y    . 
 6%   �� $ 
Situação�6e   5      �� 5   
   -   5        $��btConsultar��5   _   $��	Consultar��6   $��23��6%   $
��Left=�61   $��	12,78,0,0q�6L   $	��Top=�6r   $��75��6�   {�.  6�   �� 5   
   -   5        $��	btIncluir��5   ]   $��Incluir��6   $��23��6#   $
��Left=�6/   $��	12,49,0,0q�6J   $	��Top=�6n   $��75��6�   6�   �� 5   
   -   5        $��	btExcluir��5   ^   $��Excluir��6   $��23��6#   $
��Left=�6/   $��
12,107,0,0q�6J   $	��Top=�6o   $��75��6�   {�.  6�   �� 5   
   -   5        $��
btCancelar��5   _   $��Cancelar��6   $��23��6$   $
��Left=�60   $��
12,136,0,0q�6K   $	��Top=�6q   $��75��6�   6�   5      5       