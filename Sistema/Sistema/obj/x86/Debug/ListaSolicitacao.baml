   M S B A M L   `   `   `  ����  Sistema    Sistema.ListaSolicitacao   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  ListaSolicitacao��5   	   $	��290��6"   $	��547��6/    � 
ResizeMode$ CanMinimize=�6;    � WindowStartupLocation$ CenterScreen=�6T   .��5      � .+�5   
   �� -   5        $��textBox1��5   M   $��23��6   $
��Left=�6   $��
138,12,0,0q�69   $	��Top=�6]   $	��375��6u   �� 5   
   -   5        $��	comboBox1��5   M   $��23��6   $
��Left=�6   $��	12,12,0,0q�6:   $	��Top=�6^   $	��120��6v   �� 5	   
   -   5        $��
btCancelar��5	   `   $��Cancelar��6   $��23��6$   $
��Left=�60   $��438,221,0,0q�6K   $	��Top=�6r   $��75��6�   6�   �� 5
   
   -   5        $��btCadastrarEqpt��5
   n   $��Cadastrar Equipamentos��6   $��23��62   $
��Left=�6>   $��296,221,0,0q�6Y   $	��Top=�6�   $	��136��6�   {�.  6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��
dtgEntrada��5   �      AutoGenerateColumns .  ���	#FFF0F0F0$	��171��6F   $
��Left=�6S   $��	12,41,0,0q�6�   $	��Top=�6�   $	��501��6�   ��6n   ��  �� Path$ entradaDataBinding�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Codigo��6E      
Visibility$ Hidden=�6U   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� $ Codigo�6U     5      $ Nota Fiscal��6I   	   
IsReadOnly	 . 
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 75 6p    6%   �� $ 
NotaFiscal�6p     5      $ Data da Solicitação��6C   	 . $	
 115 6r    6%   �� $
 Data�6r     5      $ 
Fornecedor��6I   	 . $
 85 6o    6%   �� $ 
Fornecedor�6o     5      $ Equipamento��6J   	 . $	
 102 6q    6%   �� $ Equipamento�6q     5      $ 
Quantidade��6I   	 . $	
 152 6o    6%   �� $ 
Quantidade�6o     5      $ Observação��6I   	 . $	
 152 6o    6%   �� $ Observação�6o     5      $ 
Situação��6G   	 . $	
 152 6k    6%   �� $ 
Situação�6k      HorizontalGridLinesBrush 5      �� 5         VerticalGridLinesBrush 5      �� 5      5      5      5      