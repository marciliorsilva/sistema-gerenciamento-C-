   M S B A M L   `   `   `  ����  Sistema)    #Sistema.IncluirConsultarApontamento   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$!  IncluirConsultarApontamento��5   	   $	��507��6-   $	��542��6:   .��5      � .+�5   
   �� -   5        $��	cbCliente��5   M   $��23��6   $
��Left=�6   $��	12,46,0,0q�6:   $	��Top=�6^   $	��225��6v   6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��dtPeriodoInicial��5   P   $��23��6   $
��Left=�6!   $��
243,46,0,0q�6<   $	��Top=�6h   $	��133��6�   �� 5   
   -   5        $��
textBlock1��5   �   ���	#FFFF9F07$��Verdana)�6+   $��16(�6@   ���	#FF2E2E2E$��22��6e   $��Stretch=�6q   $%�� Apontamento | Incluir - Editar��6�   $	��Top=�6�   �� 5	   
   -   5        $��label1��5	   ]   $��Clientes��6   $��28��6#   $
��Left=�6/   $��	10,26,0,0q�6J   $	��Top=�6k   �� 5
   
   -   5        $��label2��5
   e   $��Período Inicial��6   $��28��6*   $
��Left=�66   $��
239,26,0,0q�6Q   $	��Top=�6s     5   
   -   5        $��dtPeriodoFinal��5   P   $��23��6   $
��Left=�6!   $��
382,46,0,0q�6<   $	��Top=�6f   $	��131��6~   �� 5   
   -   5        $��label3��5   W   $��Período Final��6   $
��Left=�6(   $��
377,26,0,0q�6C   $��28��6e   $	��Top=�6q   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dtgApontFilial��5   �      AutoGenerateColumns .  $	��156��6/   $
��Left=�6p   $��	12,75,0,0q�6�   $	��Top=�6�   $	��501��6�   ��6<   ��  �� Path$ apontamentoDataBinding�   Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Clientes��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6;      CellTemplate 5      �� 5      .R�5      �� $��Cliente��6(   ��67   �� $
 Nome�5      5        5      $ Tratado até��6)   $	 150 6>    5      �� 5      .R�5      �� $��dtTratamento��6(   ��6<   �� $ dtTratamento�5         CellEditingTemplate 5      �� 5      .R�5        $��dtTratamento��6)      Text 6=   �� $ dtTratamento�5       5"        5$      $  ��6)   $ 80 63    5%      �� 5&      .R�5'      �� $��btCadastrar��6%   -	   5        $��	Cadastrar��5'   8   6h   5(      5*      	   HorizontalGridLinesBrush	 5-      �� 5.      
   VerticalGridLinesBrush
 50      �� 51         RowBackground 53      �� 54      56      �� 57   
   -
   5        $��txtObservacao��57   M   $��68��6   $
��Left=�6   $��
12,249,0,0q�69   $	��Top=�6b   $	��501��6z    �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6�   " �� VerticalScrollBarVisibility$ Visible=�6�   �� 58   
   -   5        $��label4��58   h   $��Observações Gerais��6   $��28��6-   $
��Left=�69   $��
10,227,0,0q�6T   $	��Top=�6v   � 59   
   -   5        $��GridApontamento��59   K   $	��133��6   $
��Left=�6   $��
16,325,0,0q�67   $	��Top=�6b   $	��488��6z    � ColumnDefinitions 5:      �� 5;      -   5         �Name$ teste��5;   #   5=      5>      5?      