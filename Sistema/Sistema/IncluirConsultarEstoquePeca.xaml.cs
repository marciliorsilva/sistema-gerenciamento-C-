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
        public IncluirConsultarEstoquePeca(string modo, string codigo_estoquePecas)
        {
            this.codigo_estoquePecas = codigo_estoquePecas;
            this.modo = modo;
            situacao = "Estoque";
            InitializeComponent();
            try
            {
                SqlConnection conexao = new SqlConnection();
                SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder();
                banco.DataSource = ".\\SQLEXPRESS";
                banco.InitialCatalog = "SISTEMA";
                banco.IntegratedSecurity = true;
                conexao.ConnectionString = banco.ConnectionString;

                conexao.Open();
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
                SqlConnection conexao = new SqlConnection();
                SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder();
                banco.DataSource = ".\\SQLEXPRESS";
                banco.InitialCatalog = "SISTEMA";
                banco.IntegratedSecurity = true;
                conexao.ConnectionString = banco.ConnectionString;

                conexao.Open();
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
            if (modo == "Incluir")
            {
                DateTime data1 = DateTime.Now;
                dpEntrada.Text = data1 + "";


            }
            else
            {


                btCadastrar.IsEnabled = true;
                try
                {
                    SqlConnection conexao = new SqlConnection();
                    SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder();
                    banco.DataSource = ".\\SQLEXPRESS";
                    banco.InitialCatalog = "SISTEMA";
                    banco.IntegratedSecurity = true;
                    conexao.ConnectionString = banco.ConnectionString;

                    conexao.Open();
                    // comando SQL

                    string _Select = "Select * from EstoquePecas where codigo_estoque=" + codigo_estoquePecas;

                    // inicializa o comando e a conexão
                    SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                    SqlDataReader resultado = _cmdSelect.ExecuteReader();
                    resultado.Read();

                    if (resultado.HasRows == true)
                    {

                        dpEntrada.Text = resultado["dtEntrada"] + "";

                        txtNrSerie.Text = resultado["nrSerie"] + "";
                        txtModelo.Text = resultado["modelo"] + "";
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
                    SqlConnection conexao = new SqlConnection();
                    SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder();
                    banco.DataSource = ".\\SQLEXPRESS";
                    banco.InitialCatalog = "SISTEMA";
                    banco.IntegratedSecurity = true;
                    conexao.ConnectionString = banco.ConnectionString;
                    conexao.Open();

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
                    SqlConnection conexao = new SqlConnection();
                    SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder();
                    banco.DataSource = ".\\SQLEXPRESS";
                    banco.InitialCatalog = "SISTEMA";
                    banco.IntegratedSecurity = true;
                    conexao.ConnectionString = banco.ConnectionString;
                    conexao.Open();

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

        private void btCadastrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection conexao = new SqlConnection();
                SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder();
                banco.DataSource = ".\\SQLEXPRESS";
                banco.InitialCatalog = "SISTEMA";
                banco.IntegratedSecurity = true;
                conexao.ConnectionString = banco.ConnectionString;

                conexao.Open();
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
                SqlConnection conexao = new SqlConnection();
                SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder();
                banco.DataSource = ".\\SQLEXPRESS";
                banco.InitialCatalog = "SISTEMA";
                banco.IntegratedSecurity = true;
                conexao.ConnectionString = banco.ConnectionString;

                conexao.Open();
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
                SqlConnection conexao = new SqlConnection();
                SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder();
                banco.DataSource = ".\\SQLEXPRESS";
                banco.InitialCatalog = "SISTEMA";
                banco.IntegratedSecurity = true;
                conexao.ConnectionString = banco.ConnectionString;

                conexao.Open();


                string dataEntrada = dpEntrada.DisplayDate.ToShortDateString();
                string sql = "";

                // comando SQL para inserir - Insert Into

                if (modo == "Incluir")
                {
                    sql = @"insert into EstoquePecas(dtEntrada,nrSerie,modelo,localizacao,codigo_fornecedor,codigo_pecas,situacao) Values('" + dataEntrada.ToString() + "','" + txtNrSerie.Text + "','" + txtModelo.Text + "','" + txtLocalizacao.Text + "','" + codigo_fornecedor + "','" + codigo_pecas + "','" + situacao + "')";
                    MessageBox.Show("Cadastrado com Sucesso!");
                    Close();
                }
                if (modo == "Editar")
                {
                    sql = @"Update Estoque Set 
                                     dtEntrada ='" + dataEntrada.ToString() + "',nrSerie ='" + txtNrSerie.Text + "',modelo ='" + txtModelo.Text + "',localizacao ='" + txtLocalizacao.Text + "',situacao ='" + situacao + "',codigo_fornecedor ='" + codigo_fornecedor + "',codigo_pecas ='" + codigo_pecas + "'where codigo_estoquePecas = " + codigo_estoquePecas;

                    MessageBox.Show("Alterado com Sucesso !");

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

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
