   M S B A M L   `   `   `  ����  Sistema"    Sistema.HistoricoEqptCliente   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  HistoricoEqptCliente��5   	   $	��394��6&   $	��602��63    � 
ResizeMode$ CanMinimize=�6?    � WindowStartupLocation$ CenterScreen=�6X   .��5      � .+�5   
   �� -   5        $��tabControl1��5   P   $	��331��6   $
��Left=�6"   $��	12,12,0,0q�6=   $	��Top=�6c   $	��556��6{   .@�5      �� -   5        $��tabItem1��5   0   $��Ordem de Serviço��6   .��5      � 5	      �� 5
      -   5        $��tabItem2��5
   @   $��Peças��6   $
��Left=�6%   $	��Top=�6P   .��5      � .+�5      &   System.Windows.Controls.DataGrid  -   5        $��dtgHistoricoPecas��5   �      AutoGenerateColumns .     CanUserResizeRows .  $	��224��6�   $��8,36,0,0q�6�   $	��Top=�6�   $	��532��6�   $
��Left=�6�   ���	#FFF0F0F0��6U   ��  �� Path$ historicoPecasDataBinding�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Dt. de Saída(Estoque)��6R      Width5  /System.Windows.Controls.DataGridLengthConverter$	 123 6q   	   
IsReadOnly	 . 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� $ dtSaida�6}     5      $ Peça��6T   $	 100 6b   	 . 
 61   �� $ 	descricao�6n     5      $ 
Quantidade��6T   $	 102 6h   	 . 
 61   �� $ 	qtdeSaida�6t     5      $ 
Fornecedor��6O   $	 100 6c   	 . 
 61   �� $
 Nome�6o     5      $ Observação��6U   $	 182 6i   	 . 
 61   �� $ 
observacao�6u      HorizontalGridLinesBrush 5      �� 5         VerticalGridLinesBrush 5      �� 5         RowBackground 5      �� 5      5      �� 5       -   5        $��	comboBox1��5    W   $��23��6   $
��Left=�6+   $��8,6,0,0q�6F   $	��Top=�6h   $	��120��6�   �� 5!      -   5        $��textBox1��5!   X   $��23��6   $
��Left=�6*   $��	134,6,0,0q�6E   $	��Top=�6h   $	��406��6�   5"      5#      5$      5%      5&      