   M S B A M L   `   `   `  ����  Sistema"    Sistema.RelatorioAtendimento   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$3  -MH acesso - GE1.0 - Histórico de Atendimento��5   	   $	��482��6>   $	��619��6K    � WindowStartupLocation$ CenterScreen=�6W    � 
ResizeMode$ CanMinimize=�6|    � Icon$) #/Sistema;component/Images/icone.png��6�   .��5      � .+�5   
   �� -   5        $��cbFiltro��5   M   $��23��6   $
��Left=�6   $��	12,34,0,0q�6:   $	��Top=�6]   $	��120��6u   .@�5      �� $��Tipo de Busca:��6   {�.   �� 
IsSelected . 6F   �� 5      $
��Data��6   �� 5	      $��Cliente��6   �� 5
      $��Usuario��6   �� 5      $��Motivo��6   5      �� 5   
   -   5        $��txtPesquisa��5   Q   $��23��6   $��Stretch=�6   $��138,34,12,0q�6<   $	��Top=�6d   6|   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dtgAtendimento��5   �      AutoGenerateColumns .     CanUserResizeRows .  $	��340��6I   $��Stretch=�6V   $��
12,63,12,0q�6�   $	��Top=�6�   ��6t   ��  �� Path$ atendimentoDataBinding�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 codigo��6Q   
   
IsReadOnly
 .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6s      
Visibility$ Hidden=�6   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� $ codigo_atendimento�6     5      $	 Data do Atendimento��6K   
 . $	 100 6z    6%   �� $ DataEntrada2�6z     5      $
	 Hora��6J   
 . $ 70 6j    6%   �� $ horaEntrada�6j     5      $	 Atendido por��6F   
 . $	 110 6n    6%   �� $ Usuario�6n     5      $	 Cliente��6F   
 . $	 110 6i    6%   �� $ cliente�6i     5      $	 Motivo��6E   
 . $	 100 6g    6%   �� $ motivo�6g     5      $	 Descricao do Atd.��6H   
 . $	 110 6u    6%   �� $ 	descricao�6u     5      $	 
Situação��6G   
 . $	 100 6k    6%   �� $ situacao�6k     5      $	 Data do Resolvimento ��6M   
 . $	 110 6~    6%   �� $ DataResolvido2�6~     5      $	 Resolvido Por��6K   
 . $	 100 6t    6%   �� $ resolvidoPor�6t      HorizontalGridLinesBrush 5      �� 5         RowBackground 5      �� 5          VerticalGridLinesBrush 5"      �� 5#      5%      �� 5&   
   -   5        $��
btCancelar��5&   _   $��Cancelar��6   $��23��6$   $��Right=�60   $��	0,0,12,12q�6L   $��Bottom=�6q   $��75��6�   6�   �� 5'   
   -   5        $��btConsultar��5'   `   $��	Consultar��6   $��23��6%   $��Right=�61   $��	0,0,93,12q�6M   $��Bottom=�6s   $��75��6�   {�.  6�   �� 5(   
   -   5        $��
textBlock1��5(   �   ���	#FFFF9F07$��Verdana)�6+   $��16(�6@   ���	#FF2E2E2E$��22��6e   $��Stretch=�6q   $ �� Histórico de Atendimento��6�   $	��Top=�6�   5)      5*      