   M S B A M L   `   `   `  ����  Sistema&     Sistema.ListaConsultaEqptEstoque   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  ListaConsultaEqptEstoque��5   	   $	��317��6*   $	��382��67    � 
ResizeMode$ CanMinimize=�6C    � WindowStartupLocation$ CenterScreen=�6\   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dtgListaEqpt��5   j      AutoGenerateColumns .  $	��200��6/   $
��Left=�6<   $��	12,41,0,0q�6W   $	��Top=�6~   $	��336��6�   ��6�   ��  �� Path$ listaEqptDataBinding�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Codigo��6M      
Visibility$ Hidden=�6]   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� $ codigo_estoque�6]     5	      $ Numero de Serie��6F   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 110 6_   
   
IsReadOnly
 .  6%   �� $ nrSerie�6k     5
      $ Modelo��6E   $		 110 6U   
 .  6%   �� $ modelo�6a     5      $ Localização��6J   $		 110 6_   
 .  6%   �� $ localizacao�6k      HorizontalGridLinesBrush 5      �� 5         VerticalGridLinesBrush 5      �� 5         RowBackground 5      �� 5      5      �� 5   
   -   5        $��
btCancelar��5   `   $��Cancelar��6   $��23��6$   $
��Left=�60   $��273,248,0,0q�6K   $	��Top=�6r   $��75��6�   6�   �� 5   
   -   5        $��btEditar��5   ^   $��Editar��6   $��23��6"   $
��Left=�6.   $��192,248,0,0q�6I   $	��Top=�6n   $��75��6�   {�.  6�   �� 5   
   -   5        $��cbFiltro��5   M   $��23��6   $
��Left=�6   $��	12,12,0,0q�6:   $	��Top=�6]   $	��120��6u   �� 5   
   -   5        $��txtPesquisa��5   M   $��23��6   $
��Left=�6   $��
138,12,0,0q�69   $	��Top=�6`   $	��210��6x   �� 5   
   -   5        $��btAddEqptCli��5   `   $��	Adicionar��6   $��23��6%   $
��Left=�61   $��
12,248,0,0q�6L   $	��Top=�6t   $��75��6�    J� Opacity$ 0Q�6�   6�   5      5      