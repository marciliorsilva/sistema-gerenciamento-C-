   M S B A M L   `   `   `  ����  Sistema    Sistema.Estoque   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$?  9MH acesso - GE1.0 - Estoque de Equipamento | Dados Gerais��5   	   $	��470��6K   $	��595��6X    � 
ResizeMode$ CanMinimize=�6d    � WindowStartupLocation$ CenterScreen=�6}   $��Stretch=�6�   ���	#FFE3E3E3 � Icon$) #/Sistema;component/Images/icone.png��6�   .��5      � .+�5   
   �� -   5        $��
btCancelar��5   C   $��Cancelar��6   $��23��6$   $��	7,114,0,0q�60   $	��Top=�6U   $
��Left=�6�   $��75��6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��
dtgEstoque��5   �      AutoGenerateColumns .     CanUserResizeRows .  $��86,56,12,12q�6y   $��Stretch=�6�   $��Stretch=�6�   ���	#FFF0F0F0$	��475��6C  ��6I   ��  �� Path$ estoqueDataBinding�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5	      ,  &System.Windows.Controls.DataGridColumn   Header$ Codigo��6M   	   
Visibility$	 Hidden=�6]   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� $ codigo_estoque�6]     5
      $ Equipamento��6J      Width5  /System.Windows.Controls.DataGridLengthConverter$	 182 6_      
IsReadOnly . 
 6%   �� $ Equipamento�6k     5      $ 
Quantidade��6I   $	 182 6]    . 
 6%   �� $ 
Quantidade�6i     5      $ 
Fornecedor��6I   $	 181 6]    . 
 6%   �� $ 
Fornecedor�6i      HorizontalGridLinesBrush 5      �� 5         VerticalGridLinesBrush 5      �� 5         RowBackground 5      �� 5      5      �� 5   
   -   5        $��cbFiltro��5   R   $��23��6   $��Stretch=�6   $��86,27,366,0q�6=   $	��Top=�6b   $	��120��6z   .@�5      �� $��Tipo de Busca:��6   {�.   �� 
IsSelected . 6F   �� 5      $��Equipamento��6   �� 5      $��
Fornecedor��6   5      �� 5   
   -   5        $��txtPesquisa��5   Q   $��23��6   $��Stretch=�6   $��212,27,12,0q�6<   $	��Top=�6d   $	��349��6|   6�   �� 5    
   -   5        $��btConsultar��5    C   $��	Consultar��6   $��23��6%   $��7,85,0,0q�61   $	��Top=�6V   {�.  $
��Left=�6�   $��75��6�   �� 5!   
   -   5        $��btListaSolicitacao��5!   P   $��Lista de Solicitações��6   $��23��61   $��	7,143,0,0q�6=   $	��Top=�6j   $
��Left=�6�   $��75��6�   $y�Hidden=�6�   �� 5"   
   -   5        $��	btIncluir��5"   A   $��Incluir��6   $��23��6#   $��7,56,0,0q�6/   $	��Top=�6R   $��Center=�6�   $
��Left=�6�   $��75��6�   �� 5#   
   -   5        $��
textBlock1��5#   �   ���	#FFFF9F07$��Verdana)�6+   $��16(�6@   ���	#FF2E2E2E$��22��6e   $��Stretch=�6q   $.��(  Estoque de Equipamentos | Dados Gerais��6�   $	��Top=�6�   5$      5%      