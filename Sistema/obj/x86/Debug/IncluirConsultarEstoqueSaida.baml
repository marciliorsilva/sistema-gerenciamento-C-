   M S B A M L   `   `   `  ����  Sistema*    $Sistema.IncluirConsultarEstoqueSaida   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$M  GMH acesso - GE1.0 - Saída do Estoque de Equipamento | Incluir - Editar��5   	   $	��371��6X   $	��442��6e    � 
ResizeMode$ CanMinimize=�6q    � WindowStartupLocation$ CenterScreen=�6�   ���	#FFE3E3E3 � Icon$) #/Sistema;component/Images/icone.png��6�   .��5      � .+�5   
   �� -   5        $��cbMotivo��5   Q   $��23��6   $��Stretch=�6   $��
155,41,4,0q�6=   $	��Top=�6a   .@�5      �� $��Precaução��6   �� 5      $��Troca��6   �� 5	      $��Venda��6   �� 5
      $��Aluguel��6   �� 5      $��Defeito��6   5      (  "System.Windows.Controls.DatePicker  5   
   -   5        $��dpSaida��5   O   $��23��6   $
��Left=�6!   $��	14,41,0,0q�6<   $	��Top=�6^   $	��135��6v   �� 5   
   -   5        $��cbEquipamento��5   P   $��23��6   $��Stretch=�6   $��	14,87,4,0q�6=   $	��Top=�6e   6}   �� 5   
   -   5        $��	cbCliente��5   Q   $��23��6   $��Stretch=�6   $��
14,171,4,0q�6=   $	��Top=�6b   �� 5   
   -   5        $��txtObservacao��5   P   $��87��6   $��Stretch=�6   $��
14,210,4,0q�6<   $	��Top=�6e    �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6�   " �� VerticalScrollBarVisibility$ Visible=�6�   �� 5   
   -   5        $��
btCancelar��5   _   $��Cancelar��6   $��23��6$   $��Right=�60   $��	264,0,4,5q�6L   $��Bottom=�6q   $��75��6�   6�   �� 5   
   -   5        $��btEditar��5   ^   $��Editar��6   $��23��6"   $��Right=�6.   $��
186,0,82,5q�6J   $��Bottom=�6n   $��75��6�   6�   �� 5   
   -   5        $��btCadastrar��5   b   $��	Cadastrar��6   $��23��6%   $��Right=�61   $��105,0,163,5q�6M   $��Bottom=�6u   $��75��6�   6�   �� 5   
   -	   5        $��label1��5   ^   $��
Dt. saída��6   $��28��6$   $
��Left=�60   $��	10,20,0,0q�6K   $	��Top=�6l   �� 5   
   -
   5        $��label2��5   \   $��Motivo��6   $��28��6!   $
��Left=�6-   $��
152,22,0,0q�6H   $	��Top=�6j   �� 5   
   -   5        $��label3��5   `   $��Equipamento��6   $��28��6&   $
��Left=�62   $��	11,67,0,0q�6M   $	��Top=�6n   �� 5   
   -   5        $��label6��5   ]   $��Cliente��6   $��28��6"   $
��Left=�6.   $��
12,152,0,0q�6I   $	��Top=�6k   �� 5   
   -   5        $��label7��5   i   $��Observação da saída��6   $��28��6.   $
��Left=�6:   $��
10,190,0,0q�6U   $	��Top=�6w   �� 5   
   -   5        $��reporEstoque��5   _   $��Repor��6   $��23��6!   $��Stretch=�6-   $��
10,0,258,5q�6K    J� Opacity$ 0Q�6s   $��Bottom=�6   $��75��6�   6�   �� 5   
   -   5        $��label8��5   a   $��Nº de Série��6   $��28��6&   $
��Left=�62   $��
11,109,0,0q�6M   $	��Top=�6o   �� 5   
   -   5        $��	cbNrSerie��5   Q   $��23��6   $��Stretch=�6   $��
14,129,4,0q�6=   $	��Top=�6b   �� 5   
   -   5        $��
textBlock1��5   �   ���	#FFFF9F07$��Verdana)�6+   $��16(�6@   ���	#FF2E2E2E$��22��6e   $��Stretch=�6q   $:��4 Saída do Estoque de Equipamento | Incluir - Editar��6�   $	��Top=�6�   5      5      