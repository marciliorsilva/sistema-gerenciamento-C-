   M S B A M L   `   `   `  ����  Sistema    Sistema.Equipamento   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$4  .MH acesso - GE1.0 - Equipamento | Dados Gerais��5   	   $	��347��6@   $	��420��6M    � 
ResizeMode$ CanMinimize=�6Y    � WindowStartupLocation$ CenterScreen=�6r   ���	#FFE3E3E3 � Icon$) #/Sistema;component/Images/icone.png��6�   .��5      � $��Stretch=�6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dtgEquipamento��5   �      AutoGenerateColumns .  $	��259��6/   $��Stretch=�6<   $��
93,41,12,0q�6�   $	��Top=�6�   ���	#FFF0F0F0��6[   ��  �� Path$ equipamentoDataBinding�   VerticalGridLinesBrush 5      �� 5         HorizontalGridLinesBrush 5
      �� 5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Codigo��6Q   
   
Visibility$
 Hidden=�6a   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� $ codigo_equipamento�6a     5      $	 Equipamento��6H      Width5  /System.Windows.Controls.DataGridLengthConverter$	 152 6]      
IsReadOnly .  6%   �� $ 	descricao�6i     5      $	 	Categoria��6H   $	 152 6[    .  6%   �� $ 	Categoria�6g   5      �� 5   
   -   5        $��
btCancelar��5   D   $��Cancelar��6   $��23��6$   $��
12,129,0,0q�60   $	��Top=�6V   $
��Left=�6�   $��73��6�   �� 5   
   -   5        $��	btExcluir��5   ^   $��Excluir��6   $��23��6#   $
��Left=�6/   $��
12,100,0,0q�6J   $	��Top=�6o   $��73��6�   {�.  6�   �� 5   
   -   5        $��	btIncluir��5   ]   $��Incluir��6   $��23��6#   $
��Left=�6/   $��	12,42,0,0q�6J   $	��Top=�6n   $��73��6�   6�   �� 5   
   -   5        $��btConsultar��5   _   $��	Consultar��6   $��23��6%   $
��Left=�61   $��	12,71,0,0q�6L   $	��Top=�6r   $��73��6�   {�.  6�   �� 5   
   -   5        $��
textBlock1��5   �   ���	#FFFF9F07$��Verdana)�6+   $��16(�6@   ���	#FF2E2E2E$��22��6e   $��Stretch=�6q   $!�� Equipamento | Dados Gerais��6�   $	��Top=�6�   5      5      