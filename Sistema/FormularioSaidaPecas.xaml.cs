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
    /// Interaction logic for FormularioSaidaPecas.xaml
    /// </summary>
    public partial class FormularioSaidaPecas : Window
    {
        string modo;
        string botao;
        string codigo_eqptCliente;
        string codigo_estoquePecas;
        int qtdSaida;
        int qtdSaidaUpdate;
        int qtdSolicitada2;
        int qtdeSub;
        string codigo_spc;
        string codigo_pec;
        string nome_usuario;
        string codigo_usuario;
        string codigo_cliente;

        public FormularioSaidaPecas(string modo, string codigo_spc, string nome_usuario)
        {
            this.modo = modo;
            this.codigo_spc = codigo_spc;
            this.nome_usuario = nome_usuario;


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

                string _Select = "Select Pecas.descricao as descricao from EstoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas where EstoquePecas.situacao ='Estoque' group by  Pecas.descricao";

                // inicializa o comando e a conexão
                SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                SqlDataReader resultado = _cmdSelect.ExecuteReader();
                while (resultado.Read())
                {

                    cbPeca.Items.Add(resultado["descricao"] + "");

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            if (modo == "Incluir")
            {
                DateTime data1 = DateTime.Now;
                dpSaida.Text = data1 + "";


            }
            else
            {

                dpSaida.IsEnabled = false;
                cbPeca.IsEnabled = false;
                txtQtdeSaida.IsEnabled = false;
                cbCliente.IsEnabled = false;
                txtObservacao.IsEnabled = false;
                btCadastrar.IsEnabled = false;
                cbMotivo.IsEnabled = false;

                reporEstoque.Opacity = 1;

                if (cbMotivo.SelectedIndex == 1 || cbMotivo.SelectedIndex == 3)
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

                        string _Select = "select PecasEqptCliente.codigo_pec, SaidaPecasCli.dtSaida,Pecas.descricao,EstoquePecas.quantidade,motivo,SaidaPecasCli.observacao,SaidaPecasCli.qtdeSaida, Cliente.Nome,from SaidaPecasCli inner join Cliente on SaidaPecasCli.codigo_cliente = Cliente.codigo_cliente inner join EstoquePecas on SaidaPecasCli.codigo_estoquePecas = EstoquePecas.codigo_estoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas where SaidaPecasCli.codigo_spc =" + codigo_spc;

                        // inicializa o comando e a conexão
                        SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                        SqlDataReader resultado = _cmdSelect.ExecuteReader();
                        resultado.Read();

                        if (resultado.HasRows == true)
                        {
                            dpSaida.Text = resultado["dtSaida"] + "";
                            cbPeca.SelectedItem = resultado["descricao"] + "";
                            qtdEstoque.Text = resultado["quantidade"] + "";
                            txtQtdeSaida.Text = resultado["qtdeSaida"] + "";
                            qtdeSub = Convert.ToInt32(resultado["qtdeSaida"]);
                            cbCliente.SelectedItem = resultado["Nome"] + "";
                            txtObservacao.Text = resultado["observacao"] + "";
                            cbMotivo.Text = resultado["motivo"] + "";
                            codigo_pec = resultado["codigo_pec"] + "";


                        }
                        conexao.Close();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
                else
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

                        string _Select = "select SaidaPecasCli.dtSaida,Pecas.descricao,EstoquePecas.quantidade,motivo, observacao, qtdeSaida, Cliente.Nome from SaidaPecasCli inner join Cliente on SaidaPecasCli.codigo_cliente = Cliente.codigo_cliente inner join EstoquePecas on SaidaPecasCli.codigo_estoquePecas = EstoquePecas.codigo_estoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas where SaidaPecasCli.codigo_spc =" + codigo_spc;

                        // inicializa o comando e a conexão
                        SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                        SqlDataReader resultado = _cmdSelect.ExecuteReader();
                        resultado.Read();

                        if (resultado.HasRows == true)
                        {
                            dpSaida.Text = resultado["dtSaida"] + "";
                            cbPeca.SelectedItem = resultado["descricao"] + "";
                            qtdEstoque.Text = resultado["quantidade"] + "";
                            txtQtdeSaida.Text = resultado["qtdeSaida"] + "";
                            qtdeSub = Convert.ToInt32(resultado["qtdeSaida"]);
                            cbCliente.SelectedItem = resultado["Nome"] + "";
                            txtObservacao.Text = resultado["observacao"] + "";
                            cbMotivo.Text = resultado["motivo"] + "";
                            codigo_pec = resultado["codigo_pec"] + "";



                        }
                        conexao.Close();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }

        }


        private void cbPeca_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

                string _Select = "Select Pecas.descricao as descricao,EstoquePecas.Quantidade as quantidade from EstoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas where EstoquePecas.situacao ='Estoque' and Pecas.descricao='" + cbPeca.SelectedValue.ToString() + "'  group by  Pecas.descricao, EstoquePecas.Quantidade";

                // inicializa o comando e a conexão
                SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                SqlDataReader resultado = _cmdSelect.ExecuteReader();
                resultado.Read();

                qtdEstoque.Text = resultado["quantidade"] + "";


                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        private void btCadastrar_Click(object sender, RoutedEventArgs e)
        {

            int qtd = Convert.ToInt32(qtdEstoque.Text);
            int qtdSolicitada = Convert.ToInt32(txtQtdeSaida.Text);
            if (qtdSolicitada > qtd)
            {
                MessageBox.Show("A quatidade digitada não pode ser maior da quantidade em Estoque!");
                txtQtdeSaida.Text = "";
            }
            else
            {
                qtdSaida = qtd - qtdSolicitada;



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
                    String descricaoPecas = cbPeca.SelectedValue.ToString();
                    string _Select = "Select Pecas.descricao as descricao,EstoquePecas.codigo_estoquePecas as Codigo from EstoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas where EstoquePecas.situacao ='Estoque' and Pecas.descricao='" + descricaoPecas + "'  group by  Pecas.descricao, EstoquePecas.Quantidade,  EstoquePecas.codigo_estoquePecas";

                    // inicializa o comando e a conexão
                    SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                    SqlDataReader resultado = _cmdSelect.ExecuteReader();
                    resultado.Read();

                    codigo_estoquePecas = resultado["Codigo"] + "";


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
                    String descricaoPecas = cbPeca.SelectedValue.ToString();
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
                    SqlConnection conexao = new SqlConnection();
                    SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder();
                    banco.DataSource = ".\\SQLEXPRESS";
                    banco.InitialCatalog = "SISTEMA";
                    banco.IntegratedSecurity = true;
                    conexao.ConnectionString = banco.ConnectionString;

                    conexao.Open();
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

                    string sql2 = "";
                    string sql3 = "";
                    string dataSaida = dpSaida.DisplayDate.ToShortDateString();




                    if (cbMotivo.SelectedIndex == 1 || cbMotivo.SelectedIndex == 3)
                    {
                        // comando SQL para inserir - Insert Into
                        sql3 = @"insert into SaidaPecasCli(codigo_estoquePecas,codigo_cliente,codigo_usuario,motivo,observacao,qtdeSaida,dtSaida,reposicao)
                        Values('" + codigo_estoquePecas + "','" + codigo_cliente + "','" + codigo_usuario + "','" + cbMotivo.Text + "','" + txtObservacao.Text + "'," + qtdSolicitada + ",convert(smalldatetime,'" + dataSaida.ToString() + "',103),'-')";
                        sql2 = @"Update EstoquePecas Set quantidade=" + qtdSaida + ", situacao = 'Saida' where codigo_estoquePecas = '" + codigo_estoquePecas + "'";

                        MessageBox.Show("Cadastrado com Sucesso!");

                    }
                    else
                    {

                        sql3 = @"insert into SaidaPecasCli(codigo_estoquePecas, codigo_cliente, codigo_usuario, motivo, observacao, qtdeSaida, dtSaida,reposicao)
                        Values('" + codigo_estoquePecas + "','" + codigo_cliente + "','" + codigo_usuario + "','" + cbMotivo.Text + "','" + txtObservacao.Text + "'," + qtdSolicitada + ",convert(smalldatetime,'" + dataSaida.ToString() + "',103),'Não')";
                        sql2 = @"Update EstoquePecas Set quantidade=" + qtdSaida + ", situacao = 'Saida' where codigo_estoquePecas = '" + codigo_estoquePecas + "'";
                        MessageBox.Show("Cadastrado com Sucesso!");

                    }



                    if (botao == "Editar")
                    {

                        if (cbMotivo.SelectedIndex == 1 || cbMotivo.SelectedIndex == 3)
                        {
                            int qtd2 = Convert.ToInt32(qtdEstoque.Text);
                            qtdSolicitada2 = Convert.ToInt32(txtQtdeSaida.Text);
                            if (qtdSolicitada2 > qtd2)
                            {
                                MessageBox.Show("A quatidade digitada não pode ser maior da quantidade em Estoque!");
                                txtQtdeSaida.Text = "";
                            }
                            else
                            {
                                int soma = qtd2 + qtdeSub;
                                qtdSaidaUpdate = soma - qtdSolicitada2;



                                // comando SQL para inserir - Insert Into
                                sql3 = @"Update SaidaPecasCli Set codigo_estoquePecas='" + codigo_estoquePecas + "', codigo_cliente= '" + codigo_cliente + "',codigo_usuario='" + codigo_usuario + "',motivo='" + cbMotivo.Text + "',observacao='" + txtObservacao.Text + "',qtdeSaida=" + qtdSolicitada2 + ",dtSaida=convert(smalldatetime,'" + dataSaida.ToString() + "',103),reposicao='-' where codigo_spc='" + codigo_spc + "'";
                                sql2 = @"Update EstoquePecas Set quantidade=" + qtdSaidaUpdate + ",situacao = 'Saida' where codigo_estoquePecas = '" + codigo_estoquePecas + "'";

                                MessageBox.Show("Alterado com Sucesso !");
                            }
                        }
                        else
                        {

                            int qtd2 = Convert.ToInt32(qtdEstoque.Text);
                            qtdSolicitada2 = Convert.ToInt32(txtQtdeSaida.Text);
                            if (qtdSolicitada2 > qtd2)
                            {
                                MessageBox.Show("A quatidade digitada não pode ser maior da quantidade em Estoque!");
                                txtQtdeSaida.Text = "";
                            }
                            else
                            {
                                int soma = qtd2 + qtdeSub;
                                qtdSaidaUpdate = soma - qtdSolicitada2;



                                // comando SQL para inserir - Insert Into
                                sql3 = @"Update SaidaPecasCli Set codigo_estoquePecas='" + codigo_estoquePecas + "', codigo_cliente= '" + codigo_cliente + "',codigo_usuario='" + codigo_usuario + "',motivo='" + cbMotivo.Text + "',observacao='" + txtObservacao.Text + "',qtdeSaida=" + qtdSolicitada2 + ",dtSaida=convert(smalldatetime,'" + dataSaida.ToString() + "',103),reposicao='Não' codigo_spc='" + codigo_spc + "'";
                                sql2 = @"Update EstoquePecas Set quantidade=" + qtdSaidaUpdate + ", situacao = 'Saida' where codigo_estoquePecas = '" + codigo_estoquePecas + "'";

                                MessageBox.Show("Alterado com Sucesso !");
                            }

                        }


                    }

                    if (cbMotivo.SelectedIndex == 1 || cbMotivo.SelectedIndex == 3)
                    {
                        SqlCommand codigo3 = new SqlCommand(sql3, conexao);
                        codigo3.ExecuteNonQuery();

                        SqlCommand codigoUpdate = new SqlCommand(sql2, conexao);
                        codigoUpdate.ExecuteNonQuery();
                    }
                    else
                    {

                        SqlCommand codigo3 = new SqlCommand(sql3, conexao);
                        codigo3.ExecuteNonQuery();

                        SqlCommand codigoUpdate = new SqlCommand(sql2, conexao);
                        codigoUpdate.ExecuteNonQuery();
                    }





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
                SqlConnection conexao = new SqlConnection();
                SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder();
                banco.DataSource = ".\\SQLEXPRESS";
                banco.InitialCatalog = "SISTEMA";
                banco.IntegratedSecurity = true;
                conexao.ConnectionString = banco.ConnectionString;

                conexao.Open();
                int qtdeEstoque = Convert.ToInt32(qtdEstoque.Text);
                int reporSaida = Convert.ToInt32(txtQtdeSaida.Text);
                int soma = qtdeEstoque + reporSaida;
                MessageBox.Show(soma + "");
                string sql = "";


                sql = @"Update SaidaPecasCli Set reposicao='Sim' where codigo_spc='" + codigo_spc + "'" + @"Update EstoquePecas Set quantidade=" + soma + ", situacao = 'Entrada' where codigo_estoquePecas = '" + codigo_estoquePecas + "'";
                MessageBox.Show("Reposição efetuada com Sucesso !");





                SqlCommand codigoUpdate = new SqlCommand(sql, conexao);
                codigoUpdate.ExecuteNonQuery();



            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no banco!" + ex.ToString());
            }



        }

        private void btEditar_Click(object sender, RoutedEventArgs e)
        {
            botao = "Editar";
            cbCliente.IsEnabled = true;
        }




    }
}

