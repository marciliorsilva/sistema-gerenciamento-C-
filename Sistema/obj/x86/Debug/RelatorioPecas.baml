   M S B A M L   `   `   `  ����  Sistema    Sistema.RelatorioPecas   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$8  2MH acesso - GE1.0 - Historico do Estoque de Peças��5   	   $	��531��6C   $	��666��6P    � 
ResizeMode$ CanMinimize=�6\    � WindowStartupLocation$ CenterScreen=�6u    � Icon$) #/Sistema;component/Images/icone.png��6�   .��5      � .+�5   
   �� -   5        $��cbTipo��5   M   $��23��6   $
��Left=�6   $��	14,36,0,0q�6:   $	��Top=�6[   $	��110��6s   .@�5      �� $
��Tipo��6   {�.   �� 
IsSelected . 6<   �� 5      $��Entrada��6   �� 5	      $��Saída��6   5
      �� 5   
   -   5        $��cbFiltro��5   N   $��23��6   $
��Left=�6   $��
130,36,0,0q�6:   $	��Top=�6^   $	��110��6v   {�.  .@�5      �� $��Tipo de Busca:��6   {�.   . 6F   5      �� 5   
   -   5        $��txtPesquisa��5   Q   $��23��6   $��Stretch=�6   $��246,36,12,0q�6<   $	��Top=�6d   6|   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dtgRelatorioPecas��5   �      AutoGenerateColumns .     CanUserResizeRows .  $	��369��6{   $��Stretch=�6�   $��
14,65,12,0q�6�   $	��Top=�6�   ��6I   ��  �� Path$ relatorioDataBinding�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Data de Entrada��6J   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 125 6c      
IsReadOnly .    
Visibility$ Hidden=�6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� $ DataEntrada�6�     5      $	 Peça��6D   $	
 125 6R    . $ Hidden=�6p    6%   �� $ Pecas�6p     5      $	 
Quantidade��6I   $	
 112 6]    . $ Hidden=�6{    6%   �� $ 
quantidade�6{     5      $	 Valor Unitário��6G   $	
 112 6_    . $ Hidden=�6}    6%   �� $ valorUni�6}     5      $	 
Fornecedor��6I   $	
 111 6]    . $ Hidden=�6{    6%   �� $ 
Fornecedor�6{     5      $	 Localização��6J    . $	
 111 6q   $ Hidden=�6}    6%   �� $ localizacao�6}     5      $	 Data de Saída��6H   $	
 100 6_    . $ Hidden=�6}    6%   �� $ 	DataSaida�6}     5      $	 Peça��6H   $	
 100 6V    . $ Hidden=�6t    6%   �� $ 	descricao�6t     5      $	 
Quantidade��6H   $	
 100 6\    . $ Hidden=�6z    6%   �� $ 	qtdeSaida�6z     5      $	 Motivo��6E   $	
 120 6U    . $ Hidden=�6s    6%   �� $ motivo�6s     5      $	 Cliente��6C   $	
 100 6T    . $ Hidden=�6r    6%   �� $
 Nome�6r     5      $	 Observação��6I   $	
 120 6]    . $ Hidden=�6{    6%   �� $ 
observacao�6{     5       $	 Usuário��6F   $	
 120 6W    . $ Hidden=�6u    6%   �� $ Usuario�6u     5!      $	 Repôs ao Estoque��6H   $	
 130 6b    . $ Hidden=�6�    6%   �� $ 	reposicao�6�      HorizontalGridLinesBrush 5#      �� 5$         VerticalGridLinesBrush 5&      �� 5'         RowBackground 5)      �� 5*      5,      �� 5-   
   -   5        $��
btCancelar��5-   _   $��Cancelar��6   $��23��6$   $��Right=�60   $��	0,0,12,12q�6L   $��Bottom=�6q   $��75��6�   6�   �� 5.   
   -   5        $��
textBlock1��5.   �   ���	#FFFF9F07$��Verdana)�6+   $��16(�6@   ���	#FF2E2E2E$��22��6e   $��Stretch=�6q   $&��  Histórico do Estoque de Peças��6�   $	��Top=�6�   5/      50      