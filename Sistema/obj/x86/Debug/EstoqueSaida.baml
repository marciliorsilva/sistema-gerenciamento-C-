   M S B A M L   `   `   `  ����  Sistema    Sistema.EstoqueSaida   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$I  CMH acesso - GE1.0 - Saída do Estoque de Equipamento | Dados Gerais��5   	   $	��323��6T   $	��593��6a    � 
ResizeMode$ CanMinimize=�6m    � WindowStartupLocation$ CenterScreen=�6�    � Icon$) #/Sistema;component/Images/icone.png��6�   .��5      � .+�5   
   �� -   5        $��cbFiltro��5   M   $��23��6   $
��Left=�6   $��	93,37,0,0q�6:   $	��Top=�6]   $	��108��6u   .@�5      �� $��Tipo de Busca:��6   {�.   �� 
IsSelected . 6F   �� 5      $
��Data��6   �� 5	      $��Equipamento��6   �� 5
      $��Nº de Série��6   �� 5      $��Motivo��6   �� 5      $��Cliente��6   �� 5      $��Usuario��6   5      �� 5   
   -   5        $��txtPesquisa��5   M   $��23��6   $
��Left=�6   $��
207,37,0,0q�69   $	��Top=�6`   $	��352��6x   6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dtgSaidaEstoque��5   �      AutoGenerateColumns .     CanUserResizeRows .  $	��210��6~   $��	93,64,0,0q�6�   $	��Top=�6�   $	��466��6�   $
��Left=�6�   ���	#FFF0F0F0��6I   ��  �� Path$ saidaEstoqueDataBinding�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Codigo��6H   
   
Visibility$
 Hidden=�6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� $ 	codigo_se�6X     5      $	 Data de Saida��6H      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6_      
IsReadOnly .  6%   �� $ 	DataSaida�6k     5      $	 Equipamento��6H   $	 100 6]    .  6%   �� $ 	descricao�6i     5      $	 Nº de Série��6F   $	 100 6[    .  6%   �� $ nrSerie�6g     5      $	 Motivo��6E   $	 120 6U    .  6%   �� $ motivo�6a     5      $	 Cliente��6C   $	 100 6T    .  6%   �� $
 Nome�6`     5      $	 Observação��6I   $	 120 6]    .  6%   �� $ 
observacao�6i     5      $	 Usuário��6F   $	 120 6W    .  6%   �� $ Usuario�6c     5      $	 Repôs ao Estoque��6H   $	 130 6b    .  6%   �� $ 	reposicao�6n      HorizontalGridLinesBrush 5      �� 5         VerticalGridLinesBrush 5       �� 5!         RowBackground 5#      �� 5$      5&      �� 5'   
   -   5        $��	btIncluir��5'   ]   $��Incluir��6   $��23��6#   $
��Left=�6/   $��	12,65,0,0q�6J   $	��Top=�6n   $��75��6�   6�   �� 5(   
   -   5        $��btConsultar��5(   _   $��	Consultar��6   $��23��6%   $
��Left=�61   $��	12,94,0,0q�6L   $	��Top=�6r   $��75��6�   {�.  6�   �� 5)   
   -   5        $��
btCancelar��5)   _   $��Cancelar��6   $��23��6$   $
��Left=�60   $��
12,123,0,0q�6K   $	��Top=�6q   $��75��6�   6�   �� 5*   
   -   5        $��
textBlock1��5*   �   ���	#FFFF9F07$��Verdana)�6+   $��16(�6@   ���	#FF2E2E2E$��22��6e   $��Stretch=�6q   $2��,  Saída do Estoque de Peças | Dados Gerais��6�   $	��Top=�6�   5+      5,      