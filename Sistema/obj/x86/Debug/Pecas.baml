   M S B A M L   `   `   `  ����  Sistema    Sistema.Pecas   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$5  /MH acesso - GE1.0 - Peças | Adicionar - Editar��5   	   $	��312��6@   $	��411��6M    � 
ResizeMode$ CanMinimize=�6Y    � WindowStartupLocation$ CenterScreen=�6r    � Icon$) #/Sistema;component/Images/icone.png��6�   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dtgPecas��5   �      AutoGenerateColumns .     CanUserResizeRows .  $	��192��6w   $��
12,76,93,0q�6�   $	��Top=�6�   $��Stretch=�6�   ��6I   ��  �� Path$ pecasDataBinding�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Codigo��6K   	   
Visibility$	 Hidden=�6[   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� $ codigo_pecas�6[     5	      $ Peça��6H      Width5  /System.Windows.Controls.DataGridLengthConverter$	 288 6V      
IsReadOnly . 
 6%   �� $ 	descricao�6b      HorizontalGridLinesBrush 5      �� 5         VerticalGridLinesBrush 5      �� 5         RowBackground 5      �� 5      5      �� 5   
   -   5        $��txtDescricao��5   P   $��23��6   $��Stretch=�6   $��
12,47,93,0q�6<   $	��Top=�6d   �� 5   
   -   5        $��	btExcluir��5   _   $��Excluir��6   $��23��6#   $��Right=�6/   $��
0,106,12,0q�6K   $	��Top=�6p   $��75��6�   {�.  6�   �� 5   
   -   5        $��
btCancelar��5   `   $��Cancelar��6   $��23��6$   $��Right=�60   $��
0,135,12,0q�6L   $	��Top=�6r   $��75��6�   6�   �� 5   
   -   5        $��btAdicionar��5   `   $��	Adicionar��6   $��23��6%   $��Right=�61   $��	0,47,12,0q�6M   $	��Top=�6s   $��75��6�   6�   �� 5   
   -   5        $��	btAlterar��5   ]   $��Editar��6   $��23��6"   $��Right=�6.   $��	0,77,12,0q�6J   $	��Top=�6n   $��75��6�   {�.  6�   �� 5   
   -   5        $��label1��5   F   $��Peça��6   $��28��6   $
��Left=�6+   $	��Top=�6T   $��	12,23,0,0q�6l   �� 5   
   -   5        $��
textBlock1��5   �   ���	#FFFF9F07$��Verdana)�6+   $��16(�6@   ���	#FF2E2E2E$��22��6e   $��Stretch=�6q   $"�� Peças | Adicionar - Editar��6�   $	��Top=�6�   5      5      