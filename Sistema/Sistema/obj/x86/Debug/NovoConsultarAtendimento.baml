   M S B A M L   `   `   `  ����  Sistema&     Sistema.NovoConsultarAtendimento   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  NovoConsultarAtendimento��5   	   $	��347��6*   $	��466��67    � 
ResizeMode$ CanMinimize=�6C    � WindowStartupLocation$ CenterScreen=�6\   .��5      � .+�5   
   �� -   5        $��txtAtendente��5   K   $��23��6   $
��Left=�6   $��7,22,0,0q�69   $	��Top=�6_   $	��224��6w   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��dpData��5   P   $��23��6   $
��Left=�6!   $��
237,21,0,0q�6<   $	��Top=�6^   $	��115��6v   �� 5   
   -   5        $��txtHora��5   M   $��23��6   $
��Left=�6   $��
358,21,0,0q�69   $	��Top=�6\   $��81��6t   �� 5	   
   -   5        $��
cbClientes��5	   L   $��23��6   $
��Left=�6   $��7,68,0,0q�6:   $	��Top=�6^   $	��273��6v   �� 5
   
   -   5        $��cbMotivo��5
   N   $��23��6   $
��Left=�6   $��
286,68,0,0q�6:   $	��Top=�6^   $	��153��6v   .@�5      �� $��Dúvida��6   �� 5      $��Visita��6   �� 5      $��Defeito��6   �� 5      $��Reclamação��6   �� 5      $��Solicitação��6   �� 5      $��Informação��6   �� 5      $��Treinamento��6   �� 5      $��Sistema Secullum��6   5      �� 5   
   -   5        $��	groupBox1��5   u   $&�� Informaçõe sobre a Ocorrência��6   $	��172��6:   $
��Left=�6G   $��	5,100,0,0q�6b   $	��Top=�6�   $	��434��6�   .��5      � .+�5      �� -   5        $��txtDescricao��5   S   $��23��6   $
��Left=�6&   $��6,20,0,0q�6A   $	��Top=�6g   $	��408��6   �� 5      -   5        $��
cbSituacao��5   T   $��23��6   $
��Left=�6'   $��6,66,0,0q�6B   $	��Top=�6f   $	��248��6~   .@�5      �� $��Aberto��6#   �� 5      $��Aguardando cliente��6#   �� 5      $��	Resolvido��6#   �� 5      $��	Cancelado��6#   5        5      -	   5        $��dpResolvido��5   X   $��23��6   $
��Left=�6)   $��
262,66,0,0q�6D   $	��Top=�6k   $	��151��6�   {�.  6�   �� 5      -
   5        $��txtResolvidoPor��5   T   $��23��6   $
��Left=�6&   $��	7,113,0,0q�6A   $	��Top=�6k   $	��282��6�   {�.  6�   �� 5      -   5        $��label5��5   a   $ ��Descrição da Ocorrência��6   $��28��6:   $
��Left=�6F   $	��Top=�6o   �� 5       -   5        $��label6��5    d   $��
Situação��6   $��28��6+   $
��Left=�67   $��4,45,0,0q�6R   $	��Top=�6r   �� 5!      -   5        $��label7��5!   j   $��Resolvido em��6   $��28��6/   $
��Left=�6;   $��
258,45,0,0q�6V   $	��Top=�6x   �� 5"      -   5        $��label8��5"   i   $��Resolvido por��6   $��28��60   $
��Left=�6<   $��4,93,0,0q�6W   $	��Top=�6w   �� 5#      -   5        $��label11��5#   W   $��Tempo��6   $
��Left=�6(   $��
319,97,0,0q�6C   $��28��6f   $	��Top=�6r   �� 5$      -   5        $��tbTempo��5$   X   $��23��6   $
��Left=�6(   $��322,120,0,0q�6C   $��00:00:00��6g   $	��Top=�6w   5%      5&      �� 5'   
   -   5        $��btCadastrar��5'   a   $��	Cadastrar��6   $��23��6%   $
��Left=�61   $��284,277,0,0q�6L   $	��Top=�6t   $��75��6�   �� 5(   
   -   5        $��
btCancelar��5(   `   $��Cancelar��6   $��23��6$   $
��Left=�60   $��362,277,0,0q�6K   $	��Top=�6r   $��75��6�   �� 5)   
   -   5        $��label2��5)   \   $��	Atendente��6   $��28��6$   $
��Left=�60   $��3,2,0,0q�6K   $	��Top=�6j   �� 5*   
   -   5        $��label3��5*   Y   $
��Data��6   $��28��6   $
��Left=�6+   $��	232,1,0,0q�6F   $	��Top=�6g   �� 5+   
   -   5        $��label4��5+   Y   $
��Hora��6   $��28��6   $
��Left=�6+   $��	355,1,0,0q�6F   $	��Top=�6g   �� 5,   
   -   5        $��label9��5,   [   $��Cliente��6   $��28��6"   $
��Left=�6.   $��5,47,0,0q�6I   $	��Top=�6i   �� 5-   
   -   5        $��label10��5-   \   $��Motivo��6   $��28��6!   $
��Left=�6-   $��
284,48,0,0q�6H   $	��Top=�6k   5.      5/      