   M S B A M L   `   `   `  ����  Sistema"    Sistema.RelatorioEstoqueEqpt   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$=  7MH acesso - GE1.0 - Historico do Estoque de Equipamento��5   	   $	��517��6I   $	��656��6V    � 
ResizeMode$ CanMinimize=�6b    � WindowStartupLocation$ CenterScreen=�6{    � Icon$) #/Sistema;component/Images/icone.png��6�   .��5      � .+�5   
   �� -   5        $��cbTipo��5   M   $��23��6   $
��Left=�6   $��	12,40,0,0q�6:   $	��Top=�6[   $	��110��6�   .@�5      �� $
��Tipo��6   {�.   �� 
IsSelected . 6<   �� 5      $��Entrada��6   �� 5	      $��Saída��6   5
      �� 5   
   -   5        $��cbFiltro��5   N   $��23��6   $
��Left=�6   $��
128,40,0,0q�6:   $	��Top=�6^   $	��110��6v   {�.  .@�5      �� $��Tipo de Busca:��6   {�.   . 6F   5      �� 5   
   -   5        $��txtPesquisa��5   Q   $��23��6   $��Stretch=�6   $��244,40,12,0q�6<   $	��Top=�6d   6|   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dtgRelatorioEqpt��5   �      AutoGenerateColumns .     CanUserResizeRows .  $	��368��6{   $��Stretch=�6�   $��
12,71,12,0q�6�   $	��Top=�6�   ��6I   ��  �� Path$ relatorioDataBinding�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Codigo��6M   
   
Visibility$
 Hidden=�6]   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� $ codigo_estoque�6]     5      $	 Data de Entrada��6J      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 115 6u   $
 Hidden=�6�    6%   �� $ DataEntrada�6�     5      $	 
Fornecedor��6I    . $	 115 6o   $
 Hidden=�6{    6%   �� $ 
fornecedor�6{     5      $	 Equipamento��6J    . $	 100 6q   $
 Hidden=�6}    6%   �� $ equipamento�6}     5      $	 Nº de Série��6F    . $	 115 6m   $
 Hidden=�6z    6%   �� $ nrSerie�6z     5      $	 Modelo��6E    . $	 100 6g   $
 Hidden=�6s    6%   �� $ modelo�6s     5      $	 Localização��6J    . $	 115 6q   $
 Hidden=�6}    6%   �� $ localizacao�6}     5      $	 Codigo��6H   $
 Hidden=�6X    6%   �� $ 	codigo_se�6X     5      $	 Data de Saida��6H   $	 100 6_    . $
 Hidden=�6}    6%   �� $ 	DataSaida�6}     5      $	 Equipamento��6H   $	 100 6]    . $
 Hidden=�6{    6%   �� $ 	descricao�6{     5      $	 Nº de Série��6F   $	 100 6[    . $
 Hidden=�6y    6%   �� $ nrSerie�6y     5      $	 Motivo��6E   $	 120 6U    . $
 Hidden=�6s    6%   �� $ motivo�6s     5      $	 Cliente��6C   $	 100 6T    . $
 Hidden=�6r    6%   �� $
 Nome�6r     5       $	 Observação��6I   $	 120 6]    . $
 Hidden=�6{    6%   �� $ 
observacao�6{     5!      $	 Usuário��6F   $	 120 6W    . $
 Hidden=�6u    6%   �� $ Usuario�6u     5"      $	 Repôs ao Estoque��6H   $	 130 6b    . $
 Hidden=�6�    6%   �� $ 	reposicao�6�      HorizontalGridLinesBrush 5%      �� 5&         VerticalGridLinesBrush 5(      �� 5)         RowBackground 5+      �� 5,      5.      �� 5/   
   -   5        $��
btCancelar��5/   _   $��Cancelar��6   $��23��6$   $��Right=�60   $��	0,0,12,12q�6L   $��Bottom=�6q   $��75��6�   6�   �� 50   
   -   5        $��
textBlock1��50   �   ���	#FFFF9F07$��Verdana)�6+   $��16(�6@   ���	#FF2E2E2E$��22��6e   $��Stretch=�6q   $+��% Histórico do Estoque de Equipamento��6�   $	��Top=�6�   51      52      