   M S B A M L   `   `   `  ����  Sistema    Sistema.Fornecedor   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
Fornecedor��5   	   $	��307��6   $	��419��6)    � 
ResizeMode$ CanMinimize=�65    � WindowStartupLocation$ CenterScreen=�6N   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dtgFornecedor��5   �      AutoGenerateColumns .     CanUserResizeRows .  $	��175��6|   $��	12,55,0,0q�6�   $	��Top=�6�   $	��373��6�   $
��Left=�6�   ���	#FFF0F0F0��6I   ��  �� Path$ fornecedorDataBinding�   Columns 5	      0  *System.Windows.Controls.DataGridTextColumn  5
      ,  &System.Windows.Controls.DataGridColumn   Header$ Codigo��6P      
Visibility$ Hidden=�6`   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6%   �� $ codigo_fornecedor�6`     5      $ 
Fornecedor��6C   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 122 6W      
IsReadOnly . 	 6%   �� $
 Nome�6c     5      $ Telefone��6G   $	
 122 6Y    . 	 6%   �� $ Telefone�6e     5      $ Email��6D   $	
 122 6S    . 	 6%   �� $ Email�6_      HorizontalGridLinesBrush 5      �� 5         VerticalGridLinesBrush 5      �� 5         RowBackground 5      �� 5      5      �� 5   
   -   5        $��txtPesquisa��5   M   $��23��6   $
��Left=�6   $��
138,26,0,0q�69   $	��Top=�6`   $	��247��6x   6�   �� 5   
   -   5        $��cbFiltro��5   M   $��23��6   $
��Left=�6   $��	12,26,0,0q�6:   $	��Top=�6]   $	��120��6u   .@�5      �� $��Tipo de Busca:��6   {�.   �� 
IsSelected . 6F   �� 5      $
��Nome��6   �� 5      $
��CNPJ��6   5      �� 5    
   -   5        $��	btIncluir��5    ^   $��Incluir��6   $��23��6#   $
��Left=�6/   $��
41,237,0,0q�6J   $	��Top=�6o   $��75��6�   6�   �� 5!   
   -   5        $��btConsultar��5!   a   $��	Consultar��6   $��23��6%   $
��Left=�61   $��121,237,0,0q�6L   $	��Top=�6t   $��75��6�   {�.  6�   �� 5"   
   -   5        $��	btExcluir��5"   D   $��Excluir��6   $��23��6#   $��202,237,0,0q�6/   $	��Top=�6U   {�.  $
��Left=�6�   $��76��6�   �� 5#   
   -   5        $��
btCancelar��5#   E   $��Cancelar��6   $��23��6$   $��284,237,0,0q�60   $	��Top=�6W   $
��Left=�6�   $��76��6�   5$      5%      