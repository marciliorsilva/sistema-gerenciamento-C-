   M S B A M L   `   `   `  ����  Sistema    Sistema.CategoriaEqpt   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$H  BMH acesso - GE1.0 - Categoria de Equipamento | Adicionar - Editar ��5   	   $	��317��6T   $	��398��6a    � 
ResizeMode$ CanMinimize=�6m    � WindowStartupLocation$ CenterScreen=�6�   ���	#FFE3E3E3 � Icon$) #/Sistema;component/Images/icone.png��6�   .��5      � .+�5   
   �� -   5        $��txtDescricao��5   P   $��23��6   $��Stretch=�6   $��
12,41,99,0q�6<   $	��Top=�6d   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dtgCategoria��5   �      AutoGenerateColumns .     CanUserResizeRows .  $	��196��6{   $��	8,73,99,0q�6�   $	��Top=�6�   $��Stretch=�6�   ��6I   ��  �� Path$ categoriaDataBinding�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5	      ,  &System.Windows.Controls.DataGridColumn   Header$ Codigo��6O   	   
Visibility$	 Hidden=�6_   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� $ codigo_categoria�6_     5
      $ 	Categoria��6H      Width5  /System.Windows.Controls.DataGridLengthConverter$	 288 6[      
IsReadOnly . 
 6%   �� $ 	descricao�6g      HorizontalGridLinesBrush 5      �� 5         VerticalGridLinesBrush 5      �� 5         RowBackground 5      �� 5      5      �� 5   
   -   5        $��	btExcluir��5   _   $��Excluir��6   $��23��6#   $��Right=�6/   $��
0,102,12,0q�6K   $	��Top=�6p   $��75��6�   {�.  6�   �� 5   
   -   5        $��	btAlterar��5   ]   $��Editar��6   $��23��6"   $��Right=�6.   $��	0,73,12,0q�6J   $	��Top=�6n   $��75��6�   {�.  6�   �� 5   
   -   5        $��btAdd��5   `   $��	Adicionar��6   $��23��6%   $��Right=�61   $��	0,41,12,0q�6M   $	��Top=�6m   $��75��6�   6�   �� 5   
   -   5        $��button4��5   `   $��Cancelar��6   $��23��6$   $��Right=�60   $��
0,131,12,0q�6L   $	��Top=�6o   $��75��6�   6�   �� 5   
   -   5        $��label2��5   ]   $��	Categoria��6   $��28��6$   $
��Left=�60   $��8,20,0,0q�6K   $	��Top=�6k   �� 5   
   -   5        $��
textBlock1��5   �   ���	#FFFF9F07$��Verdana)�6+   $��16(�6@   ���	#FF2E2E2E$��22��6e   $��Stretch=�6q   $2��, Categoria de Equipamento | Incluir - Editar��6�   $	��Top=�6�   5      5      