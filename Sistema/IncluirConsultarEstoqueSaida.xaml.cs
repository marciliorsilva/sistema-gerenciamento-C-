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
    /// Interaction logic for IncluirConsultarEstoqueSaida.xaml
    /// </summary>
    public partial class IncluirConsultarEstoqueSaida : Window
    {
        string modo;
        string botao;

        string codigo_estoque;
        string codigo_se;
        string codigo_eqptCliente;

        string nome_usuario;
        string codigo_usuario;
        string codigo_cliente;
        string reposicao;
        public IncluirConsultarEstoqueSaida(string modo, string codigo_se, string nome_usuario)
        {
            this.modo = modo;
            this.codigo_se = codigo_se;
            this.nome_usuario = nome_usuario;
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

                string _Select = "Select Equipamento.descricao as descricao from Estoque inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento where Estoque.situacao2 ='EntradaEstoque' group by  Equipamento.descricao";

                // inicializa o comando e a conexão
                SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                SqlDataReader resultado = _cmdSelect.ExecuteReader();
                while (resultado.Read())
                {

                    cbEquipamento.Items.Add(resultado["descricao"] + "");

                }
                conexao.Close();
            }
             catch (SqlException ex)
            {
                MessageBox.Show("Erro no banco!" + ex.ToString());
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

                string _Select = "Select * from Cliente ";

                // inicializa o comando e a conexão
                SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                SqlDataReader resultado = _cmdSelect.ExecuteReader();
                while (resultado.Read())
                {

                    cbCliente.Items.Add(resultado["Nome"] + "");
                    
                }

                conexao.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no banco!" + ex.ToString());
            }

            if (modo == "Incluir")
            {
                DateTime data1 = DateTime.Now;
                dpSaida.Text = data1 + "";
                btEditar.IsEnabled = false;

            }
            else
            {
                btEditar.IsEnabled = true;
                dpSaida.IsEnabled = false;
                cbEquipamento.IsEnabled = false;
                cbNrSerie.IsEnabled = false;
                cbCliente.IsEnabled = false;
                txtObservacao.IsEnabled = false;
                btCadastrar.IsEnabled = false;
                cbMotivo.IsEnabled = false;
                reporEstoque.Opacity = 1;

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

                    string _Select = "select SaidaEstoqueCli.dtSaida, SaidaEstoqueCli.motivo, Equipamento.descricao, Estoque.nrSerie, Cliente.Nome, SaidaEstoqueCli.observacao from SaidaEstoqueCli inner join Estoque on SaidaEstoqueCli.codigo_estoque = Estoque.codigo_estoque inner join Equipamento on Estoque.codigo_estoque = Equipamento.codigo_equipamento inner join Cliente on SaidaEstoqueCli.codigo_cliente = Cliente.codigo_cliente where SaidaEstoqueCli.codigo_se =" + codigo_se;

                    // inicializa o comando e a conexão
                    SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                    SqlDataReader resultado = _cmdSelect.ExecuteReader();
                    resultado.Read();

                    if (resultado.HasRows == true)
                    {
                        dpSaida.Text = resultado["dtSaida"] + "";
                        cbEquipamento.Text = resultado["descricao"] + "";
                        cbNrSerie.Text = resultado["nrSerie"] + "";
                        cbCliente.SelectedItem = resultado["Nome"] + "";
                        txtObservacao.Text = resultado["observacao"] + "";
                        cbMotivo.Text = resultado["motivo"] + "";
                        reposicao = resultado["reposicao"] + "";


                    }

                    if (reposicao == "Sim")
                    {
                        reporEstoque.Opacity = 0;
                    }
                    conexao.Close();


                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Erro no banco!" + ex.ToString());
                }

            }

        }

        private void cbEquipamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbNrSerie.Items.Clear();
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

                string _Select = "Select  nrSerie from Estoque inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento where Equipamento.descricao = '" + cbEquipamento.SelectedItem.ToString() +"' and Estoque.situacao2='EntradaEstoque'";

                // inicializa o comando e a conexão
                SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                SqlDataReader resultado = _cmdSelect.ExecuteReader();
                while (resultado.Read())
                {

                    cbNrSerie.Items.Add(resultado["nrSerie"] + "");

                }

                conexao.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no banco!" + ex.ToString());
            }

        }

        private void btEditar_Click(object sender, RoutedEventArgs e)
        {

            botao = "Editar";
            btEditar.IsEnabled = false;
            dpSaida.IsEnabled = true;
            cbCliente.IsEnabled = true;
            cbMotivo.IsEnabled = true;
            cbEquipamento.IsEnabled = true;
            cbNrSerie.IsEnabled = true;
            txtObservacao.IsEnabled = true;
            btCadastrar.IsEnabled = true;
            reporEstoque.Opacity = 0;

        }

        private void btCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (cbMotivo.Text == "")
            {
                MessageBox.Show("Selecione o motivo da Saída!" ,"Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);
               
            }
            else if (cbCliente.Text == "")
            {
                MessageBox.Show("Selecione o Cliente!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (cbEquipamento.Text == "")
            {
                MessageBox.Show("Selecione o Equipamento!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (cbNrSerie.Text == "")
            {
                MessageBox.Show("Selecione o Numero de série do equipamento!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);
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
                    String nrSerie = cbNrSerie.SelectedValue.ToString();
                    string _Select = "Select * from Estoque where nrSerie='"+nrSerie+"'" ;

                    // inicializa o comando e a conexão
                    SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                    SqlDataReader resultado = _cmdSelect.ExecuteReader();
                    resultado.Read();

                    codigo_estoque = resultado["codigo_estoque"] + "";


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

                    string _Select = "Select * from usuario where nome='" + nome_usuario + "'";

                    // inicializa o comando e a conexão
                    SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                    SqlDataReader resultado = _cmdSelect.ExecuteReader();
                    resultado.Read();

                    codigo_usuario = resultado["codigo_usuario"] + "";


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
                    String nomeCliente = cbCliente.SelectedValue.ToString();
                    string _Select = "Select * from Cliente where Nome='" + nomeCliente + "'";

                    // inicializa o comando e a conexão
                    SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                    SqlDataReader resultado = _cmdSelect.ExecuteReader();
                    resultado.Read();

                    codigo_cliente = resultado["codigo_cliente"] + "";


                    conexao.Close();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Erro no banco!" + ex.ToString());
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

                    string sql = "";
                    string sql2 = "";
                   
                    string dataSaida = dpSaida.DisplayDate.ToShortDateString();

                    if (modo == "Incluir")
                    {

                        if (cbMotivo.SelectedIndex != 2)
                        {

                            sql = @"insert into SaidaEstoqueCli(codigo_estoque, codigo_cliente, codigo_usuario, motivo, observacao, dtSaida,reposicao)
                        Values('" + codigo_estoque + "','" + codigo_cliente + "','" + codigo_usuario + "','" + cbMotivo.Text + "','" + txtObservacao.Text + "',convert(smalldatetime,'" + dataSaida.ToString() + "',103),'Não')";
                            sql2 = @"Update Estoque Set situacao2='" + cbMotivo.Text + "' where codigo_estoque = '" + codigo_estoque + "'";
                            MessageBox.Show("Cadastrado com Sucesso!");

                        }
                        else
                        {
                            sql = @"insert into SaidaEstoqueCli(codigo_estoque, codigo_cliente, codigo_usuario, motivo, observacao, dtSaida,reposicao)
                        Values('" + codigo_estoque + "','" + codigo_cliente + "','" + codigo_usuario + "','" + cbMotivo.Text + "','" + txtObservacao.Text + "',convert(smalldatetime,'" + dataSaida.ToString() + "',103),'-')"+
                              "insert into EqptCliente(codigo_estoque, codigo_cliente) values ('" + codigo_estoque + "','" + codigo_cliente + "')";
                            sql2 = @"Update Estoque Set situacao2='" + cbMotivo.Text + "' where codigo_estoque = '" + codigo_estoque + "'";
                           // sql3 = @"insert into EqptCliente(codigo_estoque, codigo_cliente) values ('" + codigo_estoque + "','" + codigo_cliente + "')";
                            MessageBox.Show("Cadastrado com Sucesso!");
                        }
                    }
                    else if (botao == "Editar")
                    {
                        try
                        {                                                       

                            conexao.Open();
                            // comando SQL

                            string _Select = "Select * from EqptCliente where codigo_estoque='" + codigo_estoque + "'";

                            // inicializa o comando e a conexão
                            SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                            SqlDataReader resultado = _cmdSelect.ExecuteReader();
                            resultado.Read();

                            codigo_eqptCliente = resultado["codigo_eqptCliente"] + "";


                            conexao.Close();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }


                        if (cbMotivo.SelectedIndex != 2)
                        {
                            sql = @"Update SaidaEstoqueCli Set codigo_estoque='" + codigo_estoque + "', codigo_cliente= '" + codigo_cliente + "',codigo_usuario='" + codigo_usuario + "',motivo='" + cbMotivo.Text + "',observacao='" + txtObservacao.Text + "',dtSaida=convert(smalldatetime,'" + dataSaida.ToString() + "',103),reposicao='Não' where codigo_se='" + codigo_se + "'";
                            sql2 = @"Update Estoque Set situacao2='" + cbMotivo.Text + "' where codigo_estoque = '" + codigo_estoque + "'";
                            MessageBox.Show("Alterado com Sucesso!");
                        }
                        else
                        {
                            sql = @"Update SaidaEstoqueCli Set codigo_estoque='" + codigo_estoque + "', codigo_cliente= '" + codigo_cliente + "',codigo_usuario='" + codigo_usuario + "',motivo='" + cbMotivo.Text + "',observacao='" + txtObservacao.Text + "',dtSaida=convert(smalldatetime,'" + dataSaida.ToString() + "',103),reposicao='-' where codigo_se='" + codigo_se + "'"+
                            "Update EqptCliente set codigo_estoque='" + codigo_estoque + "', codigo_cliente'" + codigo_cliente + "'where codigo_eqptCliente ='" + codigo_eqptCliente + "')";
                            sql2 = @"Update Estoque Set situacao2='" + cbMotivo.Text + "' where codigo_estoque = '" + codigo_estoque + "'";
                           // sql3 = @"Update EqptCliente set codigo_estoque='" + codigo_estoque + "', codigo_cliente'" + codigo_cliente + "'where codigo_eqptCliente ='"+codigo_eqptCliente+"')";
                            MessageBox.Show("Alterado com Sucesso!");
                        }
                    }
                     
                     
                     
                    SqlCommand codigo = new SqlCommand(sql, conexao);
                    codigo.ExecuteNonQuery();
                    SqlCommand codigoUpdate = new SqlCommand(sql2, conexao);
                    codigoUpdate.ExecuteNonQuery();

                    conexao.Close();

                    Close();

                }
                catch (SqlException ex)
                {
                     MessageBox.Show("Erro no banco!" + ex.ToString());
                }
            
            }
                

        }

        private void reporEstoque_Click(object sender, RoutedEventArgs e)
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
                String descricaoEquipamento = cbEquipamento.SelectedValue.ToString();
                string _Select = "Select Equipamento.descricao as descricao,Estoque.codigo_estoque as Codigo from Estoque inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento where Estoque.situacao ='Estoque' and Equipamento.descricao='" + descricaoEquipamento + "'  group by  Pecas.descricao, EstoquePecas.Quantidade,  EstoquePecas.codigo_estoquePecas";

                // inicializa o comando e a conexão
                SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                SqlDataReader resultado = _cmdSelect.ExecuteReader();
                resultado.Read();

                codigo_estoque = resultado["Codigo"] + "";


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


                string sql = "";
                string sql2 = "";
               




                // comando SQL para inserir - Insert Into
                sql = @"Update SaidaEstoqueCli Set reposicao='Sim' where codigo_se='" + codigo_se + "'";
                sql2 = @"Update Estoque Set situacao2= 'EntradaEstoque' where codigo_estoque = '" + codigo_estoque + "'";

                MessageBox.Show("Reposição registrada com Sucesso ! ");

                SqlCommand codigo = new SqlCommand(sql, conexao);
                codigo.ExecuteNonQuery();
                SqlCommand codigoUpdate = new SqlCommand(sql2, conexao);
                codigoUpdate.ExecuteNonQuery();

                conexao.Close();

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
