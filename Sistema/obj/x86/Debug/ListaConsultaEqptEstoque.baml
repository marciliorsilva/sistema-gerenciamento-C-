   M S B A M L   `   `   `  ����  Sistema&     Sistema.ListaConsultaEqptEstoque   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$   ��5   	   $	��321��6   $	��480��6    � 
ResizeMode$ CanMinimize=�6+    � WindowStartupLocation$ CenterScreen=�6D   ���	#FFE3E3E3 � Icon$) #/Sistema;component/Images/icone.png��6�   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dtgListaEqpt��5   n      AutoGenerateColumns .  $	��213��6/   $��Stretch=�6<   $��
89,57,13,0q�6Z   $	��Top=�6�   ��6�   ��  �� Path$ listaEqptDataBinding�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Codigo��6M      
Visibility$ Hidden=�6]   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6%   �� $ codigo_estoque�6]     5	      $ Numero de Serie��6F   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 110 6_      
IsReadOnly . 	 6%   �� $ nrSerie�6k     5
      $ Modelo��6E   $	
 110 6U    . 	 6%   �� $ modelo�6a     5      $ Localização��6J   $	
 110 6_    . 	 6%   �� $ localizacao�6k      HorizontalGridLinesBrush 5      �� 5         VerticalGridLinesBrush 5      �� 5         RowBackground 5      �� 5      5      �� 5   
   -   5        $��
btCancelar��5   ^   $��Cancelar��6   $��23��6$   $
��Left=�60   $��	11,87,0,0q�6K   $	��Top=�6p   $��75��6�   6�   �� 5   
   -   5        $��btEditar��5   \   $��Editar��6   $��23��6"   $
��Left=�6.   $��	11,58,0,0q�6I   $	��Top=�6l   $��75��6�   {�.  6�   �� 5   
   -   5        $��cbFiltro��5   M   $��23��6   $
��Left=�6   $��	89,28,0,0q�6:   $	��Top=�6]   $	��102��6u   .@�5      �� $��Tipo de Busca:��6   {�.   �� 
IsSelected . 6F   �� 5      $��Nº de Serie��6   �� 5      $��Modelo��6   �� 5      $��Localização��6   5       �� 5!   
   -   5        $��txtPesquisa��5!   Q   $��23��6   $��Stretch=�6   $��197,28,13,0q�6<   $	��Top=�6d   6|   �� 5"   
   -   5        $��
textBlock1��5"   �   ���	#FFFF9F07$��Verdana)�6+   $��16(�6@   ���	#FF2E2E2E$��22��6e   $��Stretch=�6q   $$�� Lista de Equipamento | Editar��6�   $	��Top=�6�   5#      5$      