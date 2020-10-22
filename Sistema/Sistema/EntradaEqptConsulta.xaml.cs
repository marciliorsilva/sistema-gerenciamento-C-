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
    /// Interaction logic for EntradaEqpt.xaml
    /// </summary>
    public partial class EntradaEqptConsulta : Window
    {
        string modo;
        string botao;
        string codigo_fornecedor="";
        string codigo_equipamento="";
        string codigo_entrada;
      
        public EntradaEqptConsulta(string modo,string codigo_entrada)
        {
            this.modo = modo;
            this.codigo_entrada = codigo_entrada;
            InitializeComponent();

           
                cbSituacao.SelectedIndex = 0;
                DateTime data = DateTime.Now;
                dtPedido.Text = data + "";
               
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


            if (modo == "Consultar")
             {
                txtNrPedido.IsEnabled = false;
                txtNotaFiscal.IsEnabled = false;
                dtPedido.IsEnabled = false;
                cbFornecedor.IsEnabled = false;
                cbEquipamento.IsEnabled = false;
                txtQuantidade.IsEnabled = false;
                txtValorUni.IsEnabled = false;
                txtValorTotal.IsEnabled = false;
                cbSituacao.IsEnabled = false;
                txtObservacao.IsEnabled = false;
                btEditar.IsEnabled = true;
                btCadastrar.IsEnabled = false;
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

                    string _Select = "Select * from Entrada where codigo_entrada=" + codigo_entrada;

                    // inicializa o comando e a conexão
                    SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                    SqlDataReader resultado = _cmdSelect.ExecuteReader();
                    resultado.Read();

                    if (resultado.HasRows == true)
                    {

                        txtNrPedido.Text = resultado["numeroPedido"] + "";
                        txtNotaFiscal.Text = resultado["notaFiscal"] + "";
                        dtPedido.Text = resultado["dtPedido"] + "";
                        codigo_fornecedor = resultado["codigo_fornecedor"] + "";
                        

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

                    String consultarFornecedor = "SELECT * FROM Fornecedor where codigo_fornecedor = " + codigo_fornecedor;


                    SqlCommand codigo = new SqlCommand(consultarFornecedor, conexao);
                    SqlDataReader resultado = codigo.ExecuteReader();
                    resultado.Read();

                    cbFornecedor.SelectedValue = resultado["Nome"] + "";
              /*
                    int posicao = 0;
                    int valor = 0;

                    String nomeFornecedor= resultado["Nome"] + "";
                    while (resultado.Read())
                    {
                        cbFornecedor.Items.Add(resultado["Nome"] + "");


                        String nome = resultado["Nome"] + "";
                        MessageBox.Show(nome);
                        if (nome.CompareTo(nomeFornecedor) == 1)
                        {
                            valor = posicao;

                         }

                        posicao = posicao + 1;
                    }

                   
                    cbFornecedor.SelectedIndex = valor;
                */   
                    conexao.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                //------------------- EntradaEqpt --------------
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

                    string _Select = "Select * from EntradaEqpt where numeroPedido=" + codigo_entrada;

                    // inicializa o comando e a conexão
                    SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                    SqlDataReader resultado = _cmdSelect.ExecuteReader();
                    resultado.Read();

                    if (resultado.HasRows == true)
                    {

                        txtQuantidade.Text = resultado["quantidade"] + "";
                        txtValorUni.Text = resultado["valorUni"] + "";
                        txtValorTotal.Text = resultado["valorTotal"] + "";
                        cbSituacao.Text = resultado["situacao"] + "";
                        txtObservacao.Text = resultado["observacao"] + "";
                        codigo_equipamento = resultado["codigo_equipamento"] + "";
                       

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

                    String consultarEquipamento = "SELECT * FROM Equipamento where codigo_equipamento = " + codigo_equipamento;


                    SqlCommand codigo = new SqlCommand(consultarEquipamento, conexao);
                    SqlDataReader resultado = codigo.ExecuteReader();
                    resultado.Read();

                    cbEquipamento.SelectedValue = resultado["descricao"] + "";
                    /*
                    int posicao = 0;
                    int valor = 1;

                    String nomeEquipamento = resultado["descricao"] + "";

                    while (resultado.Read())
                    {
                        cbEquipamento.Items.Add(resultado["descricao"] + "");


                        String nome = resultado["descricao"] + "";

                        if (nome.CompareTo(nomeEquipamento) == 0)
                        {
                            valor = posicao;


                        }

                        posicao = posicao + 1;
                    }


                    cbEquipamento.SelectedIndex = valor;
                    */
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
            txtNrPedido.IsEnabled = true;
            txtNotaFiscal.IsEnabled = true;
            dtPedido.IsEnabled = true;
            cbFornecedor.IsEnabled = true;
            cbEquipamento.IsEnabled = true;
            txtQuantidade.IsEnabled = true;
            txtValorUni.IsEnabled = true;
            txtValorTotal.IsEnabled = true;
            cbSituacao.IsEnabled = true;
            txtObservacao.IsEnabled = true;
            btEditar.IsEnabled = false;
            btCadastrar.IsEnabled = true;
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

                string dataPedido = dtPedido.DisplayDate.ToShortDateString();
                string sql = "";
                            
                // comando SQL para inserir - Insert Into
                if (modo == "Incluir")
                {
                    try
                    {
                      
                        sql = @"insert into Entrada(numeroPedido,notaFiscal,dtPedido,codigo_fornecedor) Values('" + txtNrPedido.Text + "','" + txtNotaFiscal.Text + "','" + dataPedido.ToString() + "','" +codigo_fornecedor + "')"+
                            " DECLARE @LAST_ID INT;"+
                            " SET @LAST_ID = SCOPE_IDENTITY();"+
                            "insert into entradaEqpt(numeroPedido,codigo_equipamento,quantidade,valorUni,valorTotal,situacao,observacao) Values(@LAST_ID,'" + codigo_equipamento + "','" + txtQuantidade.Text + "','" + txtValorUni.Text + "','" + txtValorTotal.Text + "','" + cbSituacao.Text + "','" + txtObservacao.Text + "')";
                                               
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Erro no banco!" + ex.ToString());
                    }
                                      

                    // inicializa o comando e a conexão

                    MessageBox.Show("Cadastrado com Sucesso!");
                    Close();
                }
                else if (botao == "Editar")
                {
                    sql = @"Update Entrada Set 
                          numeroPedido ='" + txtNrPedido.Text + "',notaFiscal ='" + txtNotaFiscal.Text + "',dtPedido ='" + dataPedido.ToString() + "',codigo_fornecedor ='" + codigo_fornecedor + "'where codigo_entrada = " + codigo_entrada;
                    sql = @"Update EntradaEqpt Set 
                          quantidade ='" + txtQuantidade.Text + "',valorUni ='" + txtValorUni.Text + "',valorTotal ='" + txtValorTotal.Text + "',situacao ='" + cbSituacao.Text + "',observacao ='" + txtObservacao.Text + "',codigo_equipamento ='" + codigo_equipamento + "'where numeroPedido = " + codigo_entrada;
                    MessageBox.Show("Alterado com Sucesso!");
                }
                SqlCommand codigo = new SqlCommand(sql, conexao);
                codigo.ExecuteNonQuery();
                conexao.Close();
                Close();
               
               

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no banco!"+ex.ToString());
            }

        }

        private void txtValorTotal_SelectionChanged(object sender, RoutedEventArgs e)
        {
            double n1, n2, calculo;
            n1 = double.Parse(txtQuantidade.Text); 
            n2 = double.Parse(txtValorUni.Text); 
            calculo = n1 * n2; 
            txtValorTotal.Text = calculo.ToString(); 

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

       

 

       
    }
}
