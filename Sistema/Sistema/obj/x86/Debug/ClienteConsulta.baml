   M S B A M L   `   `   `  ����  Sistema    Sistema.ClienteConsulta   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  ClienteConsulta��5   	   $	��511��6!   $	��617��6.    � 
ResizeMode$ CanMinimize=�6:    � WindowStartupLocation$ CenterScreen=�6S   .��5      � ���	#FFF8F8F8.+�5   
   �� -   5        $��
btCancelar��5   `   $��Cancelar��6   $��23��6$   $
��Left=�60   $��507,440,0,0q�6K   $	��Top=�6r   $��75��6�   6�   �� 5   
   -   5        $��btEditar��5   ^   $��Editar��6   $��23��6"   $
��Left=�6.   $��426,440,0,0q�6I   $	��Top=�6n   $��75��6�   {�. 6�   �� 5   
   -   5        $��btCadastrar��5   a   $��	Cadastrar��6   $��23��6%   $
��Left=�61   $��344,440,0,0q�6L   $	��Top=�6t   $��75��6�   6�   �� 5	   
   -   5        $��tabControl1��5	   P   $	��422��6   $
��Left=�6"   $��	12,12,0,0q�6=   $	��Top=�6c   $	��571��6{   .@�5
      �� -   5        $��tabItem1��5
      $��Cadastro��6&   .��5      � .+�5      �� -   5        $��txtNome��5   Y   $��23��6   $
��Left=�6*   $��
114,32,0,0q�6E   $	��Top=�6h   $	��433��6�   �� 5      -   5        $��
txtCpfCnpj��5   Y   $��23��6   $
��Left=�6*   $��
404,81,0,0q�6E   $	��Top=�6k   $	��143��6�   �� 5      -   5        $��cbTipo��5   Y   $��23��6   $
��Left=�6+   $��	16,32,0,0q�6F   $	��Top=�6g   $��94��6   .@�5      �� $��FÍSICO��6'   �� 5      $��	JURÍDICO��6'   5      �� 5      -	   5        $��txtNomeFantasia��5   X   $��23��6   $
��Left=�6*   $��	15,81,0,0q�6E   $	��Top=�6o   $	��383��6�   �� 5      -
   5        $��txtIE��5   Y   $��23��6   $
��Left=�6*   $��
15,128,0,0q�6E   $	��Top=�6f   $	��120��6~   �� 5      -   5        $��cbAtivo��5   m   $��23��6   $
��Left=�6+   {�.  $��172,220,0,0q�6X   $	��Top=�6|   $��84��6�   .@�5      �� $	��SIM��6'   �� 5      $
��NÃO��6'   5      (  "System.Windows.Controls.DatePicker  5      -   5        $��dpDtCadastro��5   \   $��23��6!   $
��Left=�6-   $��
16,221,0,0q�6H   $	��Top=�6p   $	��149��6�   �� 5      -   5        $��label1��5   f   $
��Nome��6   $��28��6+   $
��Left=�67   $��
110,12,0,0q�6R   $	��Top=�6t   �� 5      -   5        $��label2��5   n   $��Nome Fantasia��6   $��28��64   $
��Left=�6@   $��	12,61,0,0q�6[   $	��Top=�6|   �� 5      -   5        $��label3��5   e   $
��Tipo��6   $��28��6+   $
��Left=�67   $��	13,10,0,0q�6R   $	��Top=�6s   �� 5      -   5        $��label4��5   j   $��CPF/CNPJ��6   $��28��6/   $
��Left=�6;   $��
400,61,0,0q�6V   $	��Top=�6x   �� 5      -   5        $��label5��5   h   $��Ativo��6   $��28��6,   $
��Left=�68   $��170,201,0,0q�6S   $	��Top=�6v   �� 5      -   5        $��label6��5   r   $��Data de Cadastro��6   $��28��67   $
��Left=�6C   $��
12,200,0,0q�6^   $	��Top=�6�   �� 5      -   5        $��label7��5   t   $��Inscrição Estudual��6   $��28��69   $
��Left=�6E   $��
11,108,0,0q�6`   $	��Top=�6�   �� 5       -   5        $��txtIdentidade��5    Z   $��23��6   $
��Left=�6*   $��141,128,0,0q�6E   $	��Top=�6o   $	��131��6�   �� 5!      -   5        $��cbSexo��5!   [   $��23��6   $
��Left=�6+   $��427,128,0,0q�6F   $	��Top=�6i   $	��120��6�   .@�5"      �� $��	MASCULINO��6'   �� 5#      $��FEMININO��6'   5$      �� 5%      -   5        $��label16��5%   m   $��
Identidade��6   $��28��61   $
��Left=�6=   $��137,108,0,0q�6X   $	��Top=�6|   �� 5&      -   5        $��label17��5&   u   $��Data de Nascimento��6   $��28��69   $
��Left=�6E   $��274,108,0,0q�6`   $	��Top=�6�   �� 5'      -   5        $��label18��5'   g   $
��Sexo��6   $��28��6+   $
��Left=�67   $��424,108,0,0q�6R   $	��Top=�6v     5(      -   5        $��dpNascimento��5(   ]   $��23��6!   $
��Left=�6-   $��279,128,0,0q�6H   $	��Top=�6q   $	��142��6�   �� 5)      -   5        $��txtEmail��5)   Y   $��23��6   $
��Left=�6*   $��
15,176,0,0q�6E   $	��Top=�6i   $	��245��6�   �� 5*      -   5        $��label19��5*   g   $��Email��6   $��28��6,   $
��Left=�68   $��
11,156,0,0q�6S   $	��Top=�6v   �� 5+      -   5        $��txtTelefone��5+   Z   $��23��6   $
��Left=�6*   $��267,176,0,0q�6E   $	��Top=�6m   $	��140��6�   �� 5,      -   5        $��
txtContato��5,   Z   $��23��6   $
��Left=�6*   $��413,176,0,0q�6E   $	��Top=�6l   $	��134��6�   �� 5-      -   5        $��label8��5-   k   $��Telefone��6   $��28��6/   $
��Left=�6;   $��263,156,0,0q�6V   $	��Top=�6y   �� 5.      -   5        $��label20��5.   j   $��Contato��6   $��28��6.   $
��Left=�6:   $��409,156,0,0q�6U   $	��Top=�6y   �� 5/      -    5        $��txtCep��5/   Z   $��23��6   $
��Left=�6*   $��439,267,0,0q�6E   $	��Top=�6h   $	��108��6�   �� 50      -!   5        $��txtEndereco��50   @   $��23��6   $��14,267,197,0q�6*   $	��Top=�6S   �� 51      -"   5        $��	txtNumero��51   Z   $��23��6   $
��Left=�6*   $��370,267,0,0q�6E   $	��Top=�6k   $��63��6�   �� 52      -#   5        $��txtComplemento��52   Y   $��23��6   $
��Left=�6*   $��
13,355,0,0q�6E   $	��Top=�6o   $	��109��6�   �� 53      -$   5        $��	txtBairro��53   Z   $��23��6   $
��Left=�6*   $��249,312,0,0q�6E   $	��Top=�6k   $	��184��6�   �� 54      -%   5        $
��cbUF��54   [   $��23��6   $
��Left=�6+   $��439,312,0,0q�6F   $	��Top=�6g   $	��108��6   .@�55      �� $��AC��6'   �� 56      $��AL��6'   �� 57      $��AP��6'   �� 58      $��AM��6'   �� 59      $��BA��6'   �� 5:      $��CE��6'   �� 5;      $��DF��6'   �� 5<      $��ES��6'   �� 5=      $��ES��6'   �� 5>      $��GO��6'   �� 5?      $��MA��6'   �� 5@      $��MT��6'   �� 5A      $��MS��6'   �� 5B      $��MG��6'   �� 5C      $��PA��6'   �� 5D      $��PB��6'   �� 5E      $��PR��6'   �� 5F      $��PE��6'   �� 5G      $��PI��6'   �� 5H      $��RJ��6'   �� 5I      $��RN��6'   �� 5J      $��RS��6'   �� 5K      $��RO��6'   �� 5L      $��RR��6'   �� 5M      $��SC��6'   �� 5N      $��SP��6'   �� 5O      $��SP��6'   �� 5P      $��SE��6'   �� 5Q      $��TO��6'   5R      �� 5S      -&   5        $��label9��5S   i   $��Numero��6   $��28��6-   $
��Left=�69   $��366,247,0,0q�6T   $	��Top=�6w   �� 5T      -'   5        $��label10��5T   m   $��Complemento��6   $��28��62   $
��Left=�6>   $��
10,332,0,0q�6Y   $	��Top=�6|   �� 5U      -(   5        $��label11��5U   e   $��UF��6   $��28��6)   $
��Left=�65   $��438,292,0,0q�6P   $	��Top=�6t   �� 5V      -)   5        $��label12��5V   j   $��	Endereço��6   $��28��6/   $
��Left=�6;   $��
10,247,0,0q�6V   $	��Top=�6y   �� 5W      -*   5        $��label13��5W   i   $��Bairro��6   $��28��6-   $
��Left=�69   $��246,292,0,0q�6T   $	��Top=�6x   �� 5X      -+   5        $��label14��5X   f   $	��CEP��6   $��28��6*   $
��Left=�66   $��435,247,0,0q�6Q   $	��Top=�6u   �� 5Y      -,   5        $��	txtCidade��5Y   Y   $��23��6   $
��Left=�6*   $��
14,312,0,0q�6E   $	��Top=�6j   $	��229��6�   �� 5Z      --   5        $��label15��5Z   h   $��Cidade��6   $��28��6-   $
��Left=�69   $��
11,290,0,0q�6T   $	��Top=�6w   5[      5\      �� 5]      -.   5        $��tbiEquipamentos��5]   G   $��Equipamentos��6   $
��Left=�6,   $	��Top=�6^   {�.  .��5^      � .+�5_      �� -/   5        $��btAdicionarEqpt��5_   X   $��	Adicionar��6   $��23��61   $
��Left=�6=   $	��Top=�6o   $��98��6�   $��6,45,0,0q�6�   6�   �� 5`      -0   5        $��btConsultarEqpt��5`   j   $��	Consultar��6   $��23��61   $
��Left=�6=   $��6,74,0,0q�6X   $	��Top=�6�   $��98��6�   {�.  6�   �� 5a      -1   5        $��btExcluirEqpt��5a   i   $��Excluir��6   $��23��6/   $
��Left=�6;   $��	6,103,0,0q�6V   $	��Top=�6~   $��98��6�   {�.  6�   &   System.Windows.Controls.DataGrid  5b      -2   5        $��dtgEqptCliente��5b   w      AutoGenerateColumns .  $	��339��6;   $
��Left=�6H   $��
110,45,0,0q�6c   $	��Top=�6�   $	��445��6�   ��6�   ��  �� Path$ eqptClienteDataBinding�   Columns 5c      0  *System.Windows.Controls.DataGridTextColumn  5d      ,  &System.Windows.Controls.DataGridColumn   Header$ Codigo��6]      
Visibility$ Hidden=�6m   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� $ codigo_eqptCliente�6m     5e      $ Equipamento��6V   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 147 6k   
   
IsReadOnly
 .  61   �� $ Equipamento�6w     5f      $ Numero de Serie��6R   $		 157 6k   
 .  61   �� $ nrSerie�6w     5g      $ Modelo��6Q   $		 197 6a   
 .  61   �� $ Modelo�6m      HorizontalGridLinesBrush 5j      �� 5k         VerticalGridLinesBrush 5m      �� 5n         RowBackground 5p      �� 5q      5s      �� 5t      -3   5        $��txtPesquisaEqpt��5t   Y   $��23��6   $
��Left=�6*   $��
110,16,0,0q�6E   $	��Top=�6p   $	��445��6�   �� 5u      -4   5        $��cbFiltroEqpt��5u   X   $��23��6   $
��Left=�6+   $��6,16,0,0q�6F   $	��Top=�6l   $��98��6�   .@�5v      �� $��
Busca por:��6'   {�.   �� 
IsSelected . 6N   �� 5w      $��Numero de Serie��6'   �� 5x      $��Modelo��6'   5y      5z      5{      �� 5|      -5   5        $��tbiHistorico��5|   T   $��Historico de Atendimentos��6   $
��Left=�69   $	��Top=�6h   {�.  .��5}      � .+�5~        -6   5        $��	dataGrid1��5~   u    .  $	��342��6;   $
��Left=�6H   $��6,35,0,0q�6c   $	��Top=�6�   $	��549��6�   �� 5      -7   5        $��cbFiltroAtend��5   W   $��23��6   $
��Left=�6+   $��6,6,0,0q�6F   $	��Top=�6l   $	��120��6�   �� 5�      -8   5        $��txtPesquisaAtend��5�   =   $��23��6   $��	132,6,0,0q�6*   $	��Top=�6U   $
��Left=�6m   $	��423��6�   5�      5�      5�      5�      5�      