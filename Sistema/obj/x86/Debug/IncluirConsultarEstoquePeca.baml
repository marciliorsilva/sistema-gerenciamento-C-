   M S B A M L   `   `   `  ����  Sistema)    #Sistema.IncluirConsultarEstoquePeca   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$>  8MH acesso - GE1.0 - Estoque de Peças | Incluir - Editar��5   	   $	��220��6I   $	��490��6V    � 
ResizeMode$ CanMinimize=�6b    � WindowStartupLocation$ CenterScreen=�6{   ���	#FFE3E3E3 � Icon$) #/Sistema;component/Images/icone.png��6�   .��5      � .+�5   
   (  "System.Windows.Controls.DatePicker  -   5        $��	dpEntrada��5   O   $��25��6   $
��Left=�6!   $��	15,56,0,0q�6<   $	��Top=�6`   $	��128��6x   �� 5   
   -   5        $��label1��5   d   $��Data de Entrada��6   $��28��6*   $
��Left=�66   $��	10,35,0,0q�6Q   $	��Top=�6r   �� 5   
   -   5        $��cbFornecedor��5   _   $��23��6   $
��Left=�6   {�. $��
149,58,0,0q�6K   $	��Top=�6s   $	��152��6�   �� 5	   
   -   5        $��cbPecas��5	   _   $��23��6   $
��Left=�6   {�. $��
307,58,0,0q�6K   $	��Top=�6n   $	��154��6�   �� 5
   
   -   5        $��label2��5
   _   $��	Forncedor��6   $��28��6$   $
��Left=�60   $��
145,36,0,0q�6K   $	��Top=�6m   �� 5   
   -   5        $��label3��5   [   $��Peças��6   $��28��6    $
��Left=�6,   $��
305,37,0,0q�6G   $	��Top=�6i   �� 5   
   -   5        $��txtQuantidade��5   M   $��23��6   $
��Left=�6   $��
15,111,0,0q�69   $	��Top=�6b   $	��146��6z   �� 5   
   -   5        $��txtValorUni��5   N   $��23��6   $
��Left=�6   $��167,111,0,0q�69   $	��Top=�6a   $	��120��6y   �� 5   
   -	   5        $��label5��5   d   $��Valor Unitário��6   $��28��6)   $
��Left=�65   $��
163,90,0,0q�6P   $	��Top=�6r   �� 5   
   -
   5        $��label6��5   _   $��
Quantidade��6   $��28��6%   $
��Left=�61   $��	10,90,0,0q�6L   $	��Top=�6m   �� 5   
   -   5        $��txtLocalizacao��5   N   $��23��6   $
��Left=�6   $��293,111,0,0q�69   $	��Top=�6d   $	��168��6|   �� 5   
   -   5        $��label7��5   a   $��Localização��6   $��28��6&   $
��Left=�62   $��
289,90,0,0q�6M   $	��Top=�6o   �� 5   
   -   5        $��
btCancelar��5   ^   $��Cancelar��6   $��23��6$   $��Right=�60   $��0,0,7,12q�6L   $��Bottom=�6p   $��75��6�   6�   �� 5   
   -   5        $��btCadastrar��5   a   $��	Cadastrar��6   $��23��6%   $��Right=�61   $��
0,0,167,12q�6M   $��Bottom=�6t   $��75��6�   6�   �� 5   
   -   5        $��btEditar��5   ]   $��Editar��6   $��23��6"   $��Right=�6.   $��	0,0,86,12q�6J   $��Bottom=�6m   $��75��6�   6�   �� 5   
   -   5        $��
textBlock1��5   �   ���	#FFFF9F07$��Verdana)�6+   $��16(�6@   ���	#FF2E2E2E$��22��6e   $��Stretch=�6q   $��0,0,-2,0q�6�   $+��% Estoque de Peças | Incluir - Editar��6�   $	��Top=�6�   5      5      