   M S B A M L   `   `   `  ����  Sistema    Sistema.Cliente   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Cliente��5   	   $	��300��6   $	��576��6&    � 
ResizeMode$ CanMinimize=�62    � WindowStartupLocation$ CenterScreen=�6K   .��5      � .+�5   
   �� -   5        $��cbFiltro��5   M   $��23��6   $
��Left=�6   $��	12,22,0,0q�6:   $	��Top=�6]   $	��120��6u   .@�5      �� $��Tipo de Busca:��6   {�.   �� 
IsSelected . 6F   �� 5      $
��Nome��6   �� 5	      $��CNPJ/CPF��6   �� 5
      $
��Tipo��6   �� 5      $��Numero Estadual��6   5      �� 5   
   -   5        $��txtPesquisa��5   M   $��23��6   $
��Left=�6   $��
138,22,0,0q�69   $	��Top=�6`   $	��404��6x   6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��
dtgCliente��5   �      AutoGenerateColumns .     CanUserResizeRows .  $	��175��6y   $��	12,47,0,0q�6�   $	��Top=�6�   $	��530��6�   $
��Left=�6�   ���	#FFF0F0F0��6I   ��  �� Path$ clienteDataBinding�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Codigo��6M   	   
Visibility$	 Hidden=�6]   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� $ codigo_cliente�6]     5      $
 Tipo��6C      Width5  /System.Windows.Controls.DataGridLengthConverter$	 197 6Q      
IsReadOnly . 
 6%   �� $
 Tipo�6]     5      $
 Nome��6C   $	 197 6Q    . 
 6%   �� $
 Nome�6]     5      $ Contato��6F   $	 197 6W    . 
 6%   �� $ Contato�6c     5      $ Email��6D   $	 197 6S    . 
 6%   �� $ Email�6_     5      $ Telefone��6G   $	 197 6Y    . 
 6%   �� $ Telefone�6e      HorizontalGridLinesBrush 5      �� 5         VerticalGridLinesBrush 5      �� 5         RowBackground 5      �� 5      5!      �� 5"   
   -   5        $��
btCancelar��5"   `   $��Cancelar��6   $��23��6$   $
��Left=�60   $��467,228,0,0q�6K   $	��Top=�6r   $��75��6�   6�   �� 5#   
   -   5        $��	btExcluir��5#   _   $��Excluir��6   $��23��6#   $
��Left=�6/   $��386,228,0,0q�6J   $	��Top=�6p   $��75��6�   {�.  6�   �� 5$   
   -   5        $��btConsultar��5$   a   $��	Consultar��6   $��23��6%   $
��Left=�61   $��305,228,0,0q�6L   $	��Top=�6t   $��75��6�   {�.  6�   �� 5%   
   -   5        $��	btIncluir��5%   _   $��Incluir��6   $��23��6#   $
��Left=�6/   $��224,228,0,0q�6J   $	��Top=�6p   $��75��6�   6�   5&      5'      