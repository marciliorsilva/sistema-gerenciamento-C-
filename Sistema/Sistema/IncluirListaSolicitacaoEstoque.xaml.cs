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
    /// Interaction logic for IncluirListaSolicitacaoEstoque.xaml
    /// </summary>
    public partial class IncluirListaSolicitacaoEstoque : Window
    {
       
        string Fornecedor;
        string Equipamento;
        string Quantidade;
        string codigo_entrada;
        string codigo_fornecedor;
        string codigo_equipamento;
        double resultado;
        string botao;
        string situacao;
        public IncluirListaSolicitacaoEstoque(string Fornecedor, string Equipamento, string Quantidade, string codigo_entrada)
        {
            
            this.Fornecedor = Fornecedor;
            this.Equipamento = Equipamento;
            this.Quantidade = Quantidade;
            this.codigo_entrada = codigo_entrada;
            situacao = "Estoque";
            InitializeComponent();
            DateTime data = DateTime.Now;
            dpEntrada.Text = data + "";

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

                string _Select = "Select * from Equipamento";

                // inicializa o comando e a conexão
                SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                SqlDataReader resultado = _cmdSelect.ExecuteReader();
                while (resultado.Read())
                {

                    cbEquipamento.Items.Add(resultado["descricao"] + "");

                }
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

                  
                cbFornecedor.SelectedItem = Fornecedor;
                cbEquipamento.SelectedItem = Equipamento;
                txtQuantidade.Text = Quantidade;

        
           
        }

        private void btCadastrar_Click(object sender, RoutedEventArgs e)
        {
            botao = "Cadastrar";
           
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
                String nomeEquipamento = cbEquipamento.SelectedValue.ToString();
                string _Select = "Select * from Equipamento where descricao='" + nomeEquipamento + "'";

                // inicializa o comando e a conexão
                SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                SqlDataReader resultado = _cmdSelect.ExecuteReader();
                resultado.Read();

                codigo_equipamento = resultado["codigo_equipamento"] + "";


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
               
                    try
                    {

                        sql = @"insert into Estoque(dtEntrada,nrSerie,modelo,localizacao,codigo_fornecedor,codigo_equipamento,situacao,estado,obsDefeito) Values('" + dataEntrada.ToString() + "','" + txtNrSerie.Text + "','" + txtModelo.Text + "','" + txtLocalizacao.Text + "','" + codigo_fornecedor + "','" + codigo_equipamento + "','" + situacao + "',' ','')";
                                                }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Erro no banco!" + ex.ToString());
                    }


                    // inicializa o comando e a conexão            
                                
                SqlCommand codigo = new SqlCommand(sql, conexao);
                double valor = 1;
                double qt = double.Parse(txtQuantidade.Text);
                resultado = qt - valor;
                txtQuantidade.Text = resultado.ToString();
                txtNrSerie.Text = string.Empty;
                txtModelo.Text = string.Empty;
                txtLocalizacao.Text = string.Empty;
                codigo.ExecuteNonQuery();
                MessageBox.Show("Cadastrado com Sucesso!");

                if (txtQuantidade.Text=="0")
                {
                    string recebido=@"Update EntradaEqpt Set 
                    situacao = 'Equipamento Recebido' where numeroPedido = " + codigo_entrada;
                    SqlCommand codigo2 = new SqlCommand(recebido, conexao);
                    codigo2.ExecuteNonQuery();
                    MessageBox.Show("Todos Equipamentos foram Cadastrados!");
                    Close();
                }

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
