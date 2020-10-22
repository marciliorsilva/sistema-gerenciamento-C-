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
    /// Interaction logic for IncluirConsultarEstoquePeca.xaml
    /// </summary>
    public partial class IncluirConsultarEstoquePeca : Window
    {
        string modo;
        string codigo_estoquePecas;
        string situacao;
        string codigo_fornecedor;
        string codigo_pecas;
        string botao;
        public IncluirConsultarEstoquePeca(string modo, string codigo_estoquePecas)
        {
            this.codigo_estoquePecas = codigo_estoquePecas;
            this.modo = modo;
            situacao = "Estoque";
            InitializeComponent();
            try
            {
                SqlConnection conexao = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


                try
                {
                    conexao.Open();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                    conexao.Close();
                }
                // comando SQL

                string _Select = "Select * from Fornecedor";

                // inicializa o comando e a conexão
                SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                SqlDataReader resultado = _cmdSelect.ExecuteReader();
                while (resultado.Read())
                {

                    cbFornecedor.Items.Add(resultado["Nome"] + "");

                }
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            try
            {
                SqlConnection conexao = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


                try
                {
                    conexao.Open();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                    conexao.Close();
                }
                // comando SQL

                string _Select = "Select * from Pecas";

                // inicializa o comando e a conexão
                SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                SqlDataReader resultado = _cmdSelect.ExecuteReader();
                while (resultado.Read())
                {

                    cbPecas.Items.Add(resultado["descricao"] + "");

                }
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           //------------------------------------
            if (modo == "Incluir")
            {
                DateTime data1 = DateTime.Now;
                dpEntrada.Text = data1 + "";
                btEditar.IsEnabled = false;


            }
            else
            {


                btEditar.IsEnabled = true;
                btCadastrar.IsEnabled = false;
                dpEntrada.IsEnabled = false;
                cbFornecedor.IsEnabled = false;
                cbPecas.IsEnabled = false;
                txtQuantidade.IsEnabled = false;
                txtValorUni.IsEnabled = false;
                txtLocalizacao.IsEnabled = false;
                try
                {
                    SqlConnection conexao = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


                    try
                    {
                        conexao.Open();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                        conexao.Close();
                    }
                    // comando SQL

                    string _Select = "Select * from EstoquePecas where codigo_estoquePecas=" + codigo_estoquePecas;

                    // inicializa o comando e a conexão
                    SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                    SqlDataReader resultado = _cmdSelect.ExecuteReader();
                    resultado.Read();

                    if (resultado.HasRows == true)
                    {

                        dpEntrada.Text = resultado["dtEntrada"] + "";

                        txtQuantidade.Text = resultado["quantidade"] + "";
                        txtValorUni.Text = resultado["valorUni"] + "";
                        txtLocalizacao.Text = resultado["localizacao"] + "";
                        codigo_fornecedor = resultado["codigo_fornecedor"] + "";
                        codigo_pecas = resultado["codigo_pecas"] + "";
                        
                    }
                    conexao.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                try
                {
                    SqlConnection conexao = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


                    try
                    {
                        conexao.Open();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                        conexao.Close();
                    }

                    String consultarCurso = "SELECT * FROM Fornecedor  where codigo_fornecedor = " + codigo_fornecedor;


                    SqlCommand codigo = new SqlCommand(consultarCurso, conexao);
                    SqlDataReader resultado = codigo.ExecuteReader();
                    resultado.Read();

                    cbFornecedor.SelectedValue = resultado["Nome"] + "";
                    conexao.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                try
                {
                    SqlConnection conexao = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


                    try
                    {
                        conexao.Open();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                        conexao.Close();
                    }

                    String consultarCurso = "SELECT * FROM Pecas where codigo_pecas = " + codigo_pecas;


                    SqlCommand codigo = new SqlCommand(consultarCurso, conexao);
                    SqlDataReader resultado = codigo.ExecuteReader();
                    resultado.Read();

                    cbPecas.SelectedValue = resultado["descricao"] + "";
                    conexao.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }
        private void btEditar_Click(object sender, RoutedEventArgs e)
        {
            botao = "Editar";
            btEditar.IsEnabled = false;
            btCadastrar.IsEnabled = true;
            dpEntrada.IsEnabled = true;
            cbFornecedor.IsEnabled = true;
            cbPecas.IsEnabled = true;
            txtQuantidade.IsEnabled = true;
            txtValorUni.IsEnabled = true;
            txtLocalizacao.IsEnabled = true;

        }
        private void btCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (txtQuantidade.Text == "")
            {
                MessageBox.Show("O campo QUANTIDADE não pode ficar em branco.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else if (cbFornecedor.Text == "")
            {
                MessageBox.Show("O campo FORNECEDOR não pode ficar em branco.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else if (cbPecas.Text == "")
            {
                MessageBox.Show("O campo PEÇAS não pode ficar em branco.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else
            {
                try
                {
                    SqlConnection conexao = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


                    try
                    {
                        conexao.Open();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                        conexao.Close();
                    }
                    // comando SQL
                    String nomeFornecedor = cbFornecedor.SelectedValue.ToString();
                    string _Select = "Select * from Fornecedor where Nome='" + nomeFornecedor + "'";

                    // inicializa o comando e a conexão
                    SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                    SqlDataReader resultado = _cmdSelect.ExecuteReader();
                    resultado.Read();

                    codigo_fornecedor = resultado["codigo_fornecedor"] + "";


                    conexao.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                try
                {
                    SqlConnection conexao = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


                    try
                    {
                        conexao.Open();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                        conexao.Close();
                    }
                    // comando SQL
                    String nomePecas = cbPecas.SelectedValue.ToString();
                    string _Select = "Select * from Pecas where descricao='" + nomePecas + "'";

                    // inicializa o comando e a conexão
                    SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                    SqlDataReader resultado = _cmdSelect.ExecuteReader();
                    resultado.Read();

                    codigo_pecas = resultado["codigo_pecas"] + "";


                    conexao.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                try
                {
                    SqlConnection conexao = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


                    try
                    {
                        conexao.Open();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                        conexao.Close();
                    }


                    string dataEntrada = dpEntrada.DisplayDate.ToShortDateString();
                    string sql = "";

                    // comando SQL para inserir - Insert Into

                    if (modo == "Incluir")
                    {
                        sql = @"insert into EstoquePecas(dtEntrada,dtSaida,quantidade,valorUni,localizacao,codigo_fornecedor,codigo_pecas,situacao) Values( convert(smalldatetime,'" + dataEntrada.ToString() + "',103),'','" + txtQuantidade.Text + "','" + txtValorUni.Text + "','" + txtLocalizacao.Text + "','" + codigo_fornecedor + "','" + codigo_pecas + "','" + situacao + "')";
                        MessageBox.Show("Cadastrado com Sucesso!");
                        Close();
                    }
                    if (botao == "Editar")
                    {
                        sql = @"Update EstoquePecas Set 
                                     dtEntrada =convert(smalldatetime,'" + dataEntrada.ToString() + "',103),dtSaida ='',quantidade ='" + txtQuantidade.Text + "',valorUni ='" + txtValorUni.Text + "',localizacao ='" + txtLocalizacao.Text + "',situacao ='" + situacao + "',codigo_fornecedor ='" + codigo_fornecedor + "',codigo_pecas ='" + codigo_pecas + "'where codigo_estoquePecas = " + codigo_estoquePecas;

                        MessageBox.Show("Alterado com Sucesso !");
                        Close();

                    }

                    SqlCommand codigo = new SqlCommand(sql, conexao);
                    codigo.ExecuteNonQuery();
                    conexao.Close();


                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Erro no banco!" + ex.ToString());
                }
            }
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        
    }
}
