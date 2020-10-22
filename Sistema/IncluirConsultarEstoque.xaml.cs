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
       

        public IncluirConsultarEstoque(string modo, string codigo_estoque)
        {
            this.codigo_estoque = codigo_estoque;
            this.modo = modo;
           
            situacao = "EntradaEstoque";
            InitializeComponent();

            SqlConnection conexao = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");
            
                try
                {
                    conexao.Open();
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
                catch (SqlException)
                {
                    MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                    conexao.Close();
                }
              
                               
                   

                try
                {
                    conexao.Open();
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
                catch (SqlException)
                {
                    MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                    conexao.Close();
                }
                // comando SQL

              


            if (modo == "Incluir" )
            {
                DateTime data1 = DateTime.Now;
                dpEntrada.Text = data1 + "";
           
               
            }
            else 
            {              
               
                btCadastrar.IsEnabled = true;
               

                    try
                    {
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
                    catch (SqlException)
                    {
                        MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                        conexao.Close();
                    }
                   
              

                    try
                    {
                    conexao.Open();
                    String consultarCurso = "SELECT * FROM Fornecedor  where codigo_fornecedor = " + codigo_fornecedor;


                    SqlCommand codigo = new SqlCommand(consultarCurso, conexao);
                    SqlDataReader resultado = codigo.ExecuteReader();
                    resultado.Read();

                    cbFornecedor.SelectedValue = resultado["Nome"] + "";
                    conexao.Close();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                        conexao.Close();
                    }

                                 

                    try
                    {
                        conexao.Open();
                        
                    String consultarCurso = "SELECT * FROM Equipamento where codigo_equipamento = " + codigo_equipamento;


                    SqlCommand codigo = new SqlCommand(consultarCurso, conexao);
                    SqlDataReader resultado = codigo.ExecuteReader();
                    resultado.Read();

                    cbEquipamento.SelectedValue = resultado["descricao"] + "";
                    conexao.Close();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                        conexao.Close();
                    }

                               
              
            }
        }

       

        private void btCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNrSerie.Text == "")
            {
                MessageBox.Show("O campo Nº DE SÉRIE não pode ficar em branco.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else if(cbEquipamento.Text =="")
            {
                MessageBox.Show("O campo EQUIPAMENTO não pode ficar em branco.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else if (cbFornecedor.Text == "")
            {
                MessageBox.Show("O campo FORNECEDOR não pode ficar em branco.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else
            {
                SqlConnection conexao = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


                try
                {
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
                catch (SqlException)
                {
                    MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                    conexao.Close();
                }



                try
                {
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
                catch (SqlException)
                {
                    MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                    conexao.Close();
                }



                try
                {
                    conexao.Open();

                    string dataEntrada = dpEntrada.DisplayDate.ToShortDateString();
                    string sql = "";

                    // comando SQL para inserir - Insert Into

                    if (modo == "Incluir")
                    {
                        sql = @"insert into Estoque(dtEntrada,nrSerie,modelo,localizacao,codigo_fornecedor,codigo_equipamento,situacao,situacao2,estado,obsDefeito) Values( convert(smalldatetime,'" + dataEntrada.ToString() + "',103),'" + txtNrSerie.Text + "','" + txtModelo.Text + "','" + txtLocalizacao.Text + "','" + codigo_fornecedor + "','" + codigo_equipamento + "','" + situacao + "','" + situacao + "','" + cbEstado.Text + "','" + txtDefeito.Text + "')";
                        MessageBox.Show("Cadastrado com Sucesso!");
                        Close();
                    }
                    if (modo == "Editar")
                    {
                        sql = @"Update Estoque Set 
                                     dtEntrada =convert(smalldatetime,'" + dataEntrada.ToString() + "',103),nrSerie ='" + txtNrSerie.Text + "',modelo ='" + txtModelo.Text + "',localizacao ='" + txtLocalizacao.Text + "',situacao ='" + situacao + "',estado ='" + cbEstado.Text + "',obsDefeito ='" + txtDefeito.Text + "',codigo_fornecedor ='" + codigo_fornecedor + "',codigo_equipamento ='" + codigo_equipamento + "'where codigo_estoque = " + codigo_estoque;

                        MessageBox.Show("Alterado com Sucesso !");

                    }


                    SqlCommand codigo = new SqlCommand(sql, conexao);
                    codigo.ExecuteNonQuery();
                    conexao.Close();

                }
                catch (SqlException)
                {
                    MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                    conexao.Close();
                }
            }

                       
        }

        private void cbEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
                if (cbEstado.SelectedIndex==1)
                {
                    lbDefeito.Visibility = Visibility.Visible;
                    txtDefeito.Visibility = Visibility.Visible;
                 

                }
                else
                {
                    lbDefeito.Visibility = Visibility.Hidden;
                    txtDefeito.Visibility = Visibility.Hidden;
                  
                }
          
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
