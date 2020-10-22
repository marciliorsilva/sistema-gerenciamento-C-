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
    /// Interaction logic for ClienteEqpt.xaml
    /// </summary>
    public partial class ClienteEqpt : Window
    {
        string modo;
        string codigo_estoque;
        string situacao;
        string codigo_fornecedor;
        string codigo_equipamento;
        string codigo_cliente;
        string codigo_filial;
        string botao;
        public ClienteEqpt(string modo, string codigo_cliente, string codigo_filial)
        {
            this.modo = modo;
            this.codigo_cliente = codigo_cliente;
            this.codigo_filial = codigo_filial;
            situacao = "AdicionadoCliente";
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

            if (modo == "Adicionar" || modo=="AddFilial")
            {
                btEditar.IsEnabled = false;

            }
            else if(modo=="Consultar" || modo=="ConsultarFilial")
            {

                btCadastrar.IsEnabled = false;
                cbFornecedor.IsEnabled = false;
                cbEquipamento.IsEnabled = false;
                txtNrSerie.IsEnabled = false;
                txtModelo.IsEnabled = false;
                btEditar.IsEnabled = true;



                try
                {
                    conexao.Open();
                    // comando SQL
                    string _Select="";
                    if (modo == "Consultar")
                    {
                         _Select = "Select * from Estoque inner join EqptCliente on EqptCliente.codigo_estoque = Estoque.codigo_estoque where EqptCliente.codigo_cliente=" + codigo_cliente;
                    }
                    else if (modo == "ConsultarFilial")
                    {
                        _Select = "Select * from Estoque inner join EqptFilial on EqptFilial.codigo_estoque = Estoque.codigo_estoque where EqptFilial.codigo_filial=" + codigo_filial;

                    }
                    // inicializa o comando e a conexão
                    SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                    SqlDataReader resultado = _cmdSelect.ExecuteReader();
                    resultado.Read();

                    if (resultado.HasRows == true)
                    {

                      

                        txtNrSerie.Text = resultado["nrSerie"] + "";
                        txtModelo.Text = resultado["modelo"] + "";
                        codigo_fornecedor = resultado["codigo_fornecedor"] + "";
                        codigo_equipamento = resultado["codigo_equipamento"] + "";
                        codigo_estoque = resultado["codigo_estoque"] + "";
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
        private void btEditar_Click(object sender, RoutedEventArgs e)
        {
            botao = "Editar";
            cbFornecedor.IsEnabled = true;
            cbEquipamento.IsEnabled = true;
            txtNrSerie.IsEnabled = true;
            txtModelo.IsEnabled = true;
            btCadastrar.IsEnabled = true;
            btEditar.IsEnabled = false;
            
        }

        private void btCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (cbFornecedor.Text == "")
            {
                MessageBox.Show("O campo FORNECEDOR não pode ficar em branco.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else if (cbEquipamento.Text == "")
            {

                MessageBox.Show("O campor EQUIPAMENTO não pode ficar em branco.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else if (txtNrSerie.Text=="")
            {

                MessageBox.Show("O campor Nº DE SÉRIE não pode ficar em branco.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);

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


                    string sql = "";

                    // comando SQL para inserir - Insert Into

                    if (modo == "Adicionar")
                    {
                        sql = @"insert into Estoque(dtEntrada,nrSerie,modelo,localizacao,codigo_fornecedor,codigo_equipamento,situacao,situacao2,estado,obsDefeito) Values('','" + txtNrSerie.Text + "','" + txtModelo.Text + "','','" + codigo_fornecedor + "','" + codigo_equipamento + "','" + situacao + "','" + situacao + "','','')" +
                           " DECLARE @LAST_ID INT;" +
                           " SET @LAST_ID = SCOPE_IDENTITY();" +
                            "insert into EqptCliente(codigo_estoque, codigo_cliente) values (@LAST_ID,'" + codigo_cliente + "')";


                        MessageBox.Show("Cadastrado com Sucesso!");
                        Close();
                    }
                    else if (modo == "AddFilial")
                    {
                        sql = @"insert into Estoque(dtEntrada,nrSerie,modelo,localizacao,codigo_fornecedor,codigo_equipamento,situacao,situacao2,estado,obsDefeito) Values('','" + txtNrSerie.Text + "','" + txtModelo.Text + "','','" + codigo_fornecedor + "','" + codigo_equipamento + "','" + situacao + "','" + situacao + "','','')" +
                              " DECLARE @LAST_ID INT;" +
                              " SET @LAST_ID = SCOPE_IDENTITY();" +
                               "insert into EqptFilial(codigo_estoque, codigo_filial) values (@LAST_ID,'" + codigo_filial + "')";


                        MessageBox.Show("Cadastrado com Sucesso!");
                        Close();
                    }

                    else if (botao == "Editar")
                    {
                        
                            sql = @"Update Estoque Set 
                                     nrSerie ='" + txtNrSerie.Text + "',modelo ='" + txtModelo.Text + "',situacao ='" + situacao + "',situacao2 ='" + situacao + "',codigo_fornecedor ='" + codigo_fornecedor + "',codigo_equipamento ='" + codigo_equipamento + "'where codigo_estoque = " + codigo_estoque;

                            MessageBox.Show("Alterado com Sucesso !");
                            Close();
                        
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

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

       

        
    }
}
