   M S B A M L   `   `   `  ����  Sistema    Sistema.Pecas   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Pecas��5   	   $	��321��6   $	��354��6$    � 
ResizeMode$ CanMinimize=�60    � WindowStartupLocation$ CenterScreen=�6I   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dtgPecas��5   �      AutoGenerateColumns .     CanUserResizeRows .  $	��164��6w   $��	12,81,0,0q�6�   $	��Top=�6�   $	��307��6�   $
��Left=�6�   ��6I   ��  �� Path$ pecasDataBinding�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Codigo��6K      
Visibility$ Hidden=�6[   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6%   �� $ codigo_pecas�6[     5	      $ Peça��6H   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 288 6V      
IsReadOnly . 	 6%   �� $ 	descricao�6b      HorizontalGridLinesBrush 5      �� 5         VerticalGridLinesBrush 5      �� 5         RowBackground 5      �� 5      5      �� 5   
   -   5        $��txtDescricao��5   L   $��23��6   $
��Left=�6   $��	11,24,0,0q�69   $	��Top=�6`   $	��308��6x   �� 5   
   -   5        $��	btExcluir��5   ^   $��Excluir��6   $��23��6#   $
��Left=�6/   $��
213,53,0,0q�6J   $	��Top=�6o   $��75��6�   {�.  6�   �� 5   
   -   5        $��
btCancelar��5   `   $��Cancelar��6   $��23��6$   $
��Left=�60   $��245,253,0,0q�6K   $	��Top=�6r   $��75��6�   6�   �� 5   
   -   5        $��btAdicionar��5   _   $��	Adicionar��6   $��23��6%   $
��Left=�61   $��	51,53,0,0q�6L   $	��Top=�6r   $��75��6�   6�   �� 5   
   -   5        $��	btAlterar��5   ^   $��Alterar��6   $��23��6#   $
��Left=�6/   $��
132,53,0,0q�6J   $	��Top=�6o   $��75��6�   {�.  6�   �� 5   
   -   5        $��label1��5   F   $��Peça��6   $��28��6   $
��Left=�6+   $	��Top=�6T   $��8,3,0,0q�6l   5      5      