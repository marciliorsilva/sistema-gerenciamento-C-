   M S B A M L   `   `   `  ����  Sistema    Sistema.CadastroUsuario   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$.  (MH acesso - GE1.0 - Cadastro de Usuário��5   	   $	��515��69   $	��312��6F    � 
ResizeMode$ CanMinimize=�6R    � WindowStartupLocation$ CenterScreen=�6k   ���	#FFE3E3E3 � Icon$) #/Sistema;component/Images/icone.png��6�   .��5      � .+�5   
   �� -   5        $��txtNome��5   P   $��23��6   $��Stretch=�6   $��
12,56,12,0q�6<   $	��Top=�6_   �� 5   
   -   5        $��cbTipoAcesso��5   R   $��23��6   $��Stretch=�6   $��12,143,12,0q�6=   $	��Top=�6f   .@�5      �� $��Administrador��6   �� 5	      $��Usuário��6   5
      �� 5   
   -   5        $��
txtUsuario��5   Q   $��23��6   $��Stretch=�6   $��12,191,12,0q�6<   $	��Top=�6c   �� 5   
   -   5        $��	txtFuncao��5   P   $��23��6   $��Stretch=�6   $��
12,98,12,0q�6<   $	��Top=�6a   &   System.Windows.Controls.DataGrid  5   
   -   5        $��
dtgUsuario��5   �      AutoGenerateColumns .     CanUserResizeRows .  $	��120��6y   $��Stretch=�6�   $��12,311,12,0q�6�   $	��Top=�6�   ��6I   ��  �� Path$ usuarioDataBinding�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Codigo��6M   	   
Visibility$	 Hidden=�6]   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� $ codigo_usuario�6]     5      $
 Nome��6C      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6Q      
IsReadOnly . 
 6%   �� $
 nome�6]     5      $ Função��6D   $	 100 6T    . 
 6%   �� $ cargo�6`     5      $ Tipo de Acesso��6C   $	 100 6[    . 
 6%   �� $
 tipo�6g      HorizontalGridLinesBrush 5      �� 5         VerticalGridLinesBrush 5      �� 5         RowBackground 5      �� 5      5      �� 5   
   -   5        $��btEditar��5   ^   $��Editar��6   $��23��6"   $
��Left=�6.   $��105,273,0,0q�6I   $	��Top=�6n   {�.  $��88��6�   �� 5   
   -   5        $��btCadastrar��5   `   $��	Cadastrar��6   $��23��6%   $
��Left=�61   $��
12,273,0,0q�6L   $	��Top=�6s   $��87��6�   6�   �� 5    
   -   5        $��label1��5    X   $
��Nome��6   $��28��6   $
��Left=�6+   $��9,36,0,0q�6F   $	��Top=�6f   �� 5!   
   -	   5        $��label2��5!   Z   $��Função��6   $��28��6!   $
��Left=�6-   $��9,77,0,0q�6H   $	��Top=�6h   �� 5"   
   -
   5        $��label3��5"   c   $��Tipo de Acesso��6   $��28��6)   $
��Left=�65   $��	9,123,0,0q�6P   $	��Top=�6q   �� 5#   
   -   5        $��label4��5#   \   $��Usuário��6   $��28��6"   $
��Left=�6.   $��	8,171,0,0q�6I   $	��Top=�6j   �� 5$   
   -   5        $��txtSenha��5$   Q   $��23��6   $��Stretch=�6   $��12,232,12,0q�6<   $	��Top=�6a   �� 5%   
   -   5        $��label5��5%   Z   $��Senha��6   $��28��6    $
��Left=�6,   $��	9,211,0,0q�6G   $	��Top=�6h   �� 5&   
   -   5        $��
btCancelar��5&   _   $��Cancelar��6   $��23��6$   $��Right=�60   $��	0,0,12,12q�6L   $��Bottom=�6q   $��75��6�   6�   �� 5'   
   -   5        $��label6��5'   u   $(��"Todos os campos são obrigatório.��6   $��28��6;   $��Right=�6G   $��0,22,8,0q�6c   $	��Top=�6�   ���	#FFFF9F07$��10(�6�   �� 5(   
   -   5        $��
textBlock1��5(   �   ���	#FFFF9F07$��Verdana)�6+   $��16(�6@   ���	#FF2E2E2E$��22��6e   $��Stretch=�6q   $#�� Usuário |  Incluir - Editar��6�   $	��Top=�6�   �� 5)   
   -   5        $��	btExcluir��5)   _   $��Excluir��6   $��23��6#   $
��Left=�6/   $��199,273,0,0q�6J   $	��Top=�6p   $��79��6�   {�.  6�   5*      5+      