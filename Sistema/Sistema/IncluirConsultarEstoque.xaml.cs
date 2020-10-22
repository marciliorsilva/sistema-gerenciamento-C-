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
    /// Interaction logic for IncluirConsultarEstoque.xaml
    /// </summary>
    public partial class IncluirConsultarEstoque : Window
    {
        string modo;
        string codigo_estoque;
        string situacao;
        string codigo_fornecedor;
        string codigo_equipamento;
        string codigo_cliente;

        public IncluirConsultarEstoque(string modo, string codigo_estoque, string codigo_cliente)
        {
            this.codigo_estoque = codigo_estoque;
            this.modo = modo;
            this.codigo_cliente = codigo_cliente;
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



            if (modo == "Incluir" || modo == "NovoEqptCliente")
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

                    string _Select = "Select * from Estoque where codigo_estoque=" + codigo_estoque;

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
                        cbEstado.Text = resultado["estado"] + "";
                        txtDefeito.Text = resultado["obsDefeito"] + "";
                        codigo_fornecedor = resultado["codigo_fornecedor"] + "";
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

                    String consultarCurso = "SELECT * FROM Equipamento where codigo_equipamento = " + codigo_equipamento;


                    SqlCommand codigo = new SqlCommand(consultarCurso, conexao);
                    SqlDataReader resultado = codigo.ExecuteReader();
                    resultado.Read();

                    cbEquipamento.SelectedValue = resultado["descricao"] + "";
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

               if (modo == "Incluir")
                {
                    sql = @"insert into Estoque(dtEntrada,nrSerie,modelo,localizacao,codigo_fornecedor,codigo_equipamento,situacao,estado,obsDefeito) Values('" + dataEntrada.ToString() + "','" + txtNrSerie.Text + "','" + txtModelo.Text + "','" + txtLocalizacao.Text + "','" + codigo_fornecedor + "','" + codigo_equipamento + "','" + situacao + "','"+cbEstado.Text+"','"+txtDefeito.Text+"')";
                    MessageBox.Show("Cadastrado com Sucesso!");
                    Close();
               }
               if(modo=="Editar") 
               {
                   sql = @"Update Estoque Set 
                                     dtEntrada ='" + dataEntrada.ToString() + "',nrSerie ='" + txtNrSerie.Text + "',modelo ='" + txtModelo.Text + "',localizacao ='" + txtLocalizacao.Text + "',situacao ='" + situacao + "',estado ='" + cbEstado.Text + "',obsDefeito ='" + txtDefeito.Text + "',codigo_fornecedor ='" + codigo_fornecedor + "',codigo_equipamento ='" + codigo_equipamento + "'where codigo_estoque = " + codigo_estoque;

                   MessageBox.Show("Alterado com Sucesso !");   
                   
               }
               if (modo == "NovoEqptCliente")
               {
                   situacao = "NovoEqptCliente";
                   sql = @"insert into Estoque(dtEntrada,nrSerie,modelo,localizacao,codigo_fornecedor,codigo_equipamento,situacao,estado,obsDefeito) Values('" + dataEntrada.ToString() + "','" + txtNrSerie.Text + "','" + txtModelo.Text + "','" + txtLocalizacao.Text + "','" + codigo_fornecedor + "','" + codigo_equipamento + "','" + situacao + "','" + cbEstado.Text + "','" + txtDefeito.Text + "')"+
                   " DECLARE @LAST_ID INT;"+
                   " SET @LAST_ID = SCOPE_IDENTITY();"+
                   "insert into EqptCliente(codigo_estoque, codigo_cliente) Values(@LAST_ID,'"+codigo_cliente+"')";
                   MessageBox.Show("Cadastrado com Sucesso!");
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

        private void cbEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
                if (cbEstado.SelectedIndex==1)
                {
                    lbDefeito.Opacity = 1;
                    txtDefeito.Opacity = 1;
                 

                }
                else
                {
                    lbDefeito.Opacity = 0;
                    txtDefeito.Opacity =0;
                  
                }
          
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
