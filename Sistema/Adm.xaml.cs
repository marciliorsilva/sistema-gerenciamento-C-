using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace Sistema
{
    /// <summary>
    /// Interaction logic for Adm.xaml
    /// </summary>
    public partial class Adm : Window
    {
        string codigo_cliente;
        string modo;
        string tipo_usuario;
        string codigo_usuario;
        string nome_usario;
        string cargo;
        NovoConsultarAtendimento formaPai;
        OrdemServicoEntrada formPaiOS;

        public Adm(string tipo_usuario, string codigo_usuario, string nome_usario,string cargo)
        {
            this.tipo_usuario = tipo_usuario;
            this.codigo_usuario = codigo_usuario;
            this.nome_usario = nome_usario;
            this.cargo = cargo;
            
            InitializeComponent();

            SqlConnection conexao = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


            
            if (tipo_usuario != "Administrador")
            {

                Title = "MH acesso - GE1.0 - Usuário";
                relatorioEstoque.Visibility = Visibility.Hidden;
                relatorioAtend.Visibility = Visibility.Hidden;

                MenuSistema.Visibility = Visibility.Hidden;
            }
            else
            {
                Title = "MH acesso - GE1.0 - Administrador";
               
            
            }
            stbAdm.Items.Add(nome_usario);
            stbAdm2.Items.Add(" "+cargo);

            try
            {
                conexao.Open();
                // comando SQL

                string _Select = "Select nome from Usuario where nome != '"+nome_usario+"'";

                // inicializa o comando e a conexão
                SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                SqlDataReader resultado = _cmdSelect.ExecuteReader();
                while (resultado.Read())
                {

                    cbPara.Items.Add(resultado["nome"] + "");

                }
                conexao.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                conexao.Close();
            }

            
        }

       

        public void VinculaDados()
        {
            SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


            try
            {
                Con.Open();
                SqlDataAdapter _Adapter = new SqlDataAdapter("select Aviso.assunto, Aviso.texto, Usuario.nome from Aviso inner join Usuario on Aviso.codigo_usuario = Usuario.codigo_usuario where Aviso.para = '" + nome_usario + "' order by codigo_aviso desc", Con);

                DataSet _ds = new DataSet();
                _Adapter.Fill(_ds, "avisoDataBinding");

               

                dtgAviso.DataContext = _ds;
            }
            catch (SqlException)
            {
                MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                Con.Close();
            }




        }

        private void FornecedorCadastro_MenuClick(object sender, RoutedEventArgs e)
        {
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.ShowDialog();
        }

        private void EquipamentoCadastro_MenuClick(object sender, RoutedEventArgs e)
        {
            Equipamento equipamento = new Equipamento();
            equipamento.ShowDialog();
        }

        private void CategoriaCadastro_MenuClick(object sender, RoutedEventArgs e)
        {
            CategoriaEqpt categoriaEqpt = new CategoriaEqpt();
            categoriaEqpt.ShowDialog();
        }

        private void EntradaEqpt_MenuClick(object sender, RoutedEventArgs e)
        {
            EntradaEqpt entrada = new EntradaEqpt();
            entrada.ShowDialog();
        }

        private void ReceberEqpt_MenuClick(object sender, RoutedEventArgs e)
        {
            Estoque receberEqpt = new Estoque(modo,codigo_cliente);
            receberEqpt.ShowDialog();
        }

        private void CadastrarCliente_MenuClick(object sender, RoutedEventArgs e)
        {
            string atend = "null";
            Cliente cliente = new Cliente(atend, nome_usario, formaPai,formPaiOS);
            cliente.ShowDialog();
        }

        private void Atendimento_MenuClick(object sender, RoutedEventArgs e)
        {
         
            Atendimento atendimento = new Atendimento(nome_usario);
            atendimento.ShowDialog();

        }
                
        private void Pecas_MenuClick(object sender, RoutedEventArgs e)
        {
            Pecas pecas = new Pecas();
            pecas.ShowDialog();
        }

        private void ReceberPecas_MenuClick(object sender, RoutedEventArgs e)
        {
            EstoquePecas estoquePecas = new EstoquePecas();
            estoquePecas.ShowDialog();
        }

        private void SaidaPeca_MenuClick(object sender, RoutedEventArgs e)
        {
            EstoquePecasSaida saida = new EstoquePecasSaida(nome_usario);
            saida.ShowDialog();
        }

        private void SaidaEstoque_MenuClick(object sender, RoutedEventArgs e)
        {
            EstoqueSaida saida = new EstoqueSaida(nome_usario);
            saida.ShowDialog();

        }

        private void btCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (txtAssunto.Text == "")
            {
                MessageBox.Show("Digite o Assunto.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else if (Texto.Text == "")
            {
                MessageBox.Show("Digite o Aviso.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else
            {

                SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


                try
                {
                    Con.Open();

                    string sql = "";


                    // comando SQL para inserir - Insert Into
                    sql = @"insert into Aviso
                    (assunto,para,texto,codigo_usuario)
                    Values('" + txtAssunto.Text + "','" + cbPara.Text + "','" + Texto.Text + "','" + codigo_usuario + "')";


                    MessageBox.Show("Aviso enviado com Sucesso!");

                    SqlCommand codigo = new SqlCommand(sql, Con);
                    codigo.ExecuteNonQuery();
                    txtAssunto.Text = string.Empty;
                    Texto.Text = string.Empty;
                    cbPara.Text = string.Empty;
                    this.VinculaDados();
                    Con.Close();

                }
                catch (SqlException)
                {
                    MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                    Con.Close();
                }
            }
        }

        private void dtgAviso_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.VinculaDados();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RelatorioEqpt_MenuClick(object sender, RoutedEventArgs e)
        {
            RelatorioEstoqueEqpt relatorio = new RelatorioEstoqueEqpt();
            relatorio.ShowDialog();
        }

        private void RelatorioAtendimento_MenuClick(object sender, RoutedEventArgs e)
        {
            RelatorioAtendimento realtorio = new RelatorioAtendimento();
            realtorio.ShowDialog();
        }

        private void RelatorioPecas_MenuClick(object sender, RoutedEventArgs e)
        {
            RelatorioPecas relatorio = new RelatorioPecas();
            relatorio.ShowDialog();
        }

        private void CadastroUsuario_MenuClick(object sender, RoutedEventArgs e)
        {
            CadastroUsuario cadastro = new CadastroUsuario();
            cadastro.ShowDialog();
        }

        private void Apontamento_MenuIClick(object sender, RoutedEventArgs e)
        {
            Apontamento apont = new Apontamento(nome_usario);
            apont.ShowDialog();
        }

        private void OS_MenuIClick(object sender, RoutedEventArgs e)
        {
            OrdemServico os = new OrdemServico(nome_usario);
            os.ShowDialog();
        }

        private void OrdemServSaida_MenuClick(object sender, RoutedEventArgs e)
        {
            OrdemSaida saida = new OrdemSaida(nome_usario);
            saida.ShowDialog();
        }
       
        
    }
}
