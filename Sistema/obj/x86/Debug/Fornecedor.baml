   M S B A M L   `   `   `  ����  Sistema    Sistema.Fornecedor   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$3  -MH acesso - GE1.0 - Fornecedor | Dados Gerais��5   	   $	��401��6?   $	��522��6L    � 
ResizeMode$ CanMinimize=�6X    � WindowStartupLocation$ CenterScreen=�6q   ���	#FFE3E3E3 � Icon$) #/Sistema;component/Images/icone.png��6�   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dtgFornecedor��5   �      AutoGenerateColumns .     CanUserResizeRows .  $	��289��6|   $��
94,63,12,0q�6�   $	��Top=�6�   $
��Auto��6�   $��Stretch=�6�   ���	#FFF0F0F0��6I   ��  �� Path$ fornecedorDataBinding�   Columns 5	      0  *System.Windows.Controls.DataGridTextColumn  5
      ,  &System.Windows.Controls.DataGridColumn   Header$ Codigo��6P   	   
Visibility$	 Hidden=�6`   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� $ codigo_fornecedor�6`     5      $ 
Fornecedor��6C      Width5  /System.Windows.Controls.DataGridLengthConverter$	 122 6W      
IsReadOnly . 
 6%   �� $
 Nome�6c     5      $ Telefone��6G   $	 122 6Y    . 
 6%   �� $ Telefone�6e     5      $ Email��6D   $	 122 6S    . 
 6%   �� $ Email�6_      HorizontalGridLinesBrush 5      �� 5         VerticalGridLinesBrush 5      �� 5         RowBackground 5      �� 5      5      �� 5   
   -   5        $��txtPesquisa��5   Q   $��23��6   $��Stretch=�6   $��220,34,12,0q�6<   $	��Top=�6d   $	��268��6|   6�   �� 5   
   -   5        $��cbFiltro��5   2   $��23��6   $��	94,34,0,0q�6   $	��Top=�6B   $
��Left=�6Z   $	��120��6u   .@�5      �� $��Tipo de Busca:��6   {�.   �� 
IsSelected . 6F   �� 5      $
��Nome��6   �� 5      $
��CNPJ��6   5      �� 5    
   -   5        $��	btIncluir��5    ]   $��Incluir��6   $��23��6#   $
��Left=�6/   $��	12,64,0,0q�6J   $	��Top=�6n   $��75��6�   6�   �� 5!   
   -   5        $��btConsultar��5!   _   $��	Consultar��6   $��23��6%   $
��Left=�61   $��	12,93,0,0q�6L   $	��Top=�6r   $��75��6�   {�.  6�   �� 5"   
   -   5        $��	btExcluir��5"   C   $��Excluir��6   $��23��6#   $��
11,122,0,0q�6/   $	��Top=�6T   {�.  $
��Left=�6�   $��76��6�   �� 5#   
   -   5        $��
btCancelar��5#   D   $��Cancelar��6   $��23��6$   $��
12,151,0,0q�60   $	��Top=�6V   $
��Left=�6�   $��76��6�   �� 5$   
   -   5        $��
textBlock1��5$   �   ���	#FFFF9F07$��Verdana)�6+   $��16(�6@   ���	#FF2E2E2E$��22��6e   $��Stretch=�6q   $ �� Fornecedor | Dados Gerais��6�   $	��Top=�6�   5%      5&      