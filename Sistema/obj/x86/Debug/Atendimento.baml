   M S B A M L   `   `   `  ����  Sistema    Sistema.Atendimento   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$4  .MH acesso - GE1.0 - Atendimento | Dados Gerais��5   	   $	��417��6@   $	��522��6M    � 
ResizeMode$ CanMinimize=�6Y    � WindowStartupLocation$ CenterScreen=�6r   ���	#FFE3E3E3 � Icon$) #/Sistema;component/Images/icone.png��6�   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dtgAtendimento��5   �      AutoGenerateColumns .     CanUserResizeRows .  $	��309��6}   $��Stretch=�6�   $��
97,58,12,0q�6�   $	��Top=�6�   ��6I   ��  �� Path$ atendimentoDataBinding�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Codigo��6Q   	   
Visibility$	 Hidden=�6a   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� $ codigo_atendimento�6a     5	      $
 Data��6K      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6Y      
IsReadOnly . 
 6%   �� $ DataEntrada2�6e     5
      $
 Hora��6J   $ 70 6X    . 
 6%   �� $ horaEntrada�6c     5      $ Atendido por��6F   $	 110 6\    . 
 6%   �� $ Usuario�6h     5      $ Cliente��6F   $	 110 6W    . 
 6%   �� $ cliente�6c     5      $ Motivo��6E   $	 100 6U    . 
 6%   �� $ motivo�6a     5      $ Descricao do Atd.��6H   $	 110 6c    . 
 6%   �� $ 	descricao�6o     5      $ 
Situação��6G   $	 100 6Y    . 
 6%   �� $ situacao�6e     5      $ Resolvido Por��6K   $	 100 6b    . 
 6%   �� $ resolvidoPor�6n      HorizontalGridLinesBrush 5      �� 5         VerticalGridLinesBrush 5      �� 5         RowBackground 5      �� 5      5      �� 5   
   -   5        $��
btCancelar��5   S   $��Cancelar��6   $
��Left=�6$   $��
12,116,0,0q�6?   $��79��6e   $��23��6p   $	��Top=�6|   6�   �� 5   
   -   5        $��btConsultar��5   S   $��	Consultar��6   $
��Left=�6%   $��	12,87,0,0q�6@   $��79��6f   $��23��6q   $	��Top=�6}   {�.  6�   �� 5    
   -   5        $��btNovo��5    N   $
��Novo��6   $
��Left=�6    $��	12,58,0,0q�6;   $��79��6q   $��23��6|   $	��Top=�6�   �� 5!   
   -   5        $��cbFiltro��5!   R   $��23��6   $��Stretch=�6   $��96,29,284,0q�6=   $	��Top=�6b   $
��Auto��6z   .@�5"      �� $��Tipo de Busca:��6   {�.   �� 
IsSelected . 6F   �� 5#      $
��Data��6   �� 5$      $��Cliente��6   �� 5%      $��Usuario��6   �� 5&      $��Motivo��6   5(      �� 5)   
   -   5        $��txtPesquisa��5)   1   $��23��6   $��	0,29,12,0q�6   $	��Top=�6D   $��Right=�6\   $	��266��6x   6�   �� 5*   
   -   5        $��
textBlock1��5*   >   $��22��6   $��Stretch=�6    $!�� Atendimento | Dados Gerais��6P   $	��Top=�6s   $
��Auto��6�   $��16(�6�   ���	#FFFF9F07$��Verdana)�6�   ���	#FF2E2E2E6�   5+      5,      