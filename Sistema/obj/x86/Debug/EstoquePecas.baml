   M S B A M L   `   `   `  ����  Sistema    Sistema.EstoquePecas   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$9  3MH acesso - GE1.0 - Estoque de Pecas | Dados Gerais��5   	   $	��379��6E   $	��519��6R    � 
ResizeMode$ CanMinimize=�6^    � WindowStartupLocation$ CenterScreen=�6w   ���	#FFE3E3E3 � Icon$) #/Sistema;component/Images/icone.png��6�   .��5      � .+�5   
   �� -   5        $��cbFiltro��5   M   $��23��6   $
��Left=�6   $��	96,28,0,0q�6:   $	��Top=�6]   $	��120��6u   .@�5      �� $��Tipo de Busca:��6   {�.   �� 
IsSelected . 6F   �� 5      $
��Data��6   �� 5	      $��Peças��6   �� 5
      $��
Fornecedor��6   �� 5      $��Localização��6   5      �� 5   
   -   5        $��txtPesquisa��5   Q   $��23��6   $��Stretch=�6   $��222,28,12,0q�6<   $	��Top=�6d   6|   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dtgEstoquePecas��5   �      AutoGenerateColumns .     CanUserResizeRows .  $	��278��6~   $��
96,55,12,0q�6�   $	��Top=�6�   $��Stretch=�6�   ���	#FFF0F0F0��6I   ��  �� Path$ estoquePecasDataBinding�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Codigo��6R   
   
Visibility$
 Hidden=�6b   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� $ codigo_estoquePecas�6b     5      $	 Data de Entrada��6J      Width5  /System.Windows.Controls.DataGridLengthConverter$	 125 6c      
IsReadOnly .  6%   �� $ DataEntrada�6o     5      $	 Peça��6D   $	 125 6R    .  6%   �� $ Pecas�6^     5      $	 
Quantidade��6I   $	 132 6]    .  6%   �� $ 
quantidade�6i     5      $	 Valor Unitário��6G   $	 132 6_    .  6%   �� $ valorUni�6k     5      $	 
Fornecedor��6I   $	 141 6]    .  6%   �� $ 
Fornecedor�6i     5      $	 Localização��6J   $	 141 6_    .  6%   �� $ localizacao�6k      HorizontalGridLinesBrush 5      �� 5         VerticalGridLinesBrush 5      �� 5         RowBackground 5!      �� 5"      5$      �� 5%   
   -   5        $��
btCancelar��5%   _   $��Cancelar��6   $��23��6$   $
��Left=�60   $��
12,113,0,0q�6K   $	��Top=�6q   $��75��6�   6�   �� 5&   
   -   5        $��btConsultar��5&   _   $��	Consultar��6   $��23��6%   $
��Left=�61   $��	12,84,0,0q�6L   $	��Top=�6r   $��75��6�   6�   �� 5'   
   -   5        $��	btIncluir��5'   ]   $��Incluir��6   $��23��6#   $
��Left=�6/   $��	12,55,0,0q�6J   $	��Top=�6n   $��75��6�   6�   �� 5(   
   -   5        $��
textBlock1��5(   �   ���	#FFFF9F07$��Verdana)�6+   $��16(�6@   ���	#FF2E2E2E$��22��6e   $��Stretch=�6q   $(��"  Estoque de Peças | Dados Gerais��6�   $	��Top=�6�   5)      5*      