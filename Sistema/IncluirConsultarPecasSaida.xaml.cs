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
    /// Interaction logic for IncluirConsultarPecasSaida.xaml
    /// </summary>
    public partial class IncluirConsultarPecasSaida : Window
    {
        string modo;
        string botao;
        
        string codigo_estoquePecas;
        int qtdSaida;
        int qtdSaidaUpdate;
        int qtdSolicitada2;
        int qtdeSub;
        string codigo_spc;
        string valorUni;

        string nome_usuario;
        string codigo_usuario;
        string codigo_cliente;
        string reposicao;
        ordemServicoSaida formPai;
        public IncluirConsultarPecasSaida(string modo, string codigo_spc, string nome_usuario, ordemServicoSaida formPai)
        {
            this.modo = modo;
            this.codigo_spc = codigo_spc;
            this.nome_usuario = nome_usuario;
            this.formPai = formPai;

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

            if (modo == "AddOrdemServico")
            {
                DateTime data1 = DateTime.Now;
                dpSaida.Text = data1 + "";
                btEditar.IsEnabled = false;
                
            }
            else if (modo == "Incluir")
            {
                DateTime data1 = DateTime.Now;
                dpSaida.Text = data1 + "";
                btEditar.IsEnabled = false;

            }
            else if (modo == "Consultar" || modo == "EditarOrdemServico")
            {
                btEditar.IsEnabled = true;
                dpSaida.IsEnabled = false;
                cbPeca.IsEnabled = false;
                txtQtdeSaida.IsEnabled = false;
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

                    string _Select = "select SaidaPecasCli.dtSaida,Pecas.descricao,EstoquePecas.quantidade,motivo, observacao, qtdeSaida,reposicao, Cliente.Nome from SaidaPecasCli inner join Cliente on SaidaPecasCli.codigo_cliente = Cliente.codigo_cliente inner join EstoquePecas on SaidaPecasCli.codigo_estoquePecas = EstoquePecas.codigo_estoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas where SaidaPecasCli.codigo_spc =" + codigo_spc;

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

        private void cbPeca_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

                string _Select = "Select Pecas.descricao as descricao,EstoquePecas.Quantidade as quantidade from EstoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas where EstoquePecas.situacao ='Estoque' and Pecas.descricao='" + cbPeca.SelectedValue.ToString() + "'  group by  Pecas.descricao, EstoquePecas.Quantidade";

                // inicializa o comando e a conexão
                SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                SqlDataReader resultado = _cmdSelect.ExecuteReader();
                resultado.Read();

                qtdEstoque.Text = resultado["quantidade"] + "";


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
            cbPeca.IsEnabled = true;
            txtQtdeSaida.IsEnabled = true;
            cbCliente.IsEnabled = true;
            cbMotivo.IsEnabled = true;
            txtObservacao.IsEnabled = true;
            btCadastrar.IsEnabled = true;
            reporEstoque.Opacity = 0;
        }

        private void btCadastrar_Click(object sender, RoutedEventArgs e)
        {
             int qtd = Convert.ToInt32(qtdEstoque.Text);
            int qtdSolicitada = Convert.ToInt32(txtQtdeSaida.Text);
            if(cbMotivo.Text=="")
            {
                MessageBox.Show("Selecione o motivo da Saída!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);
               
            }
            else if(cbCliente.Text=="")
            {
                MessageBox.Show("Selecione o Cliente!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if(txtQtdeSaida.Text=="")
            {
                MessageBox.Show("Quantidade para Saída não pode ficar em branco!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (qtdSolicitada > qtd)
            {
                MessageBox.Show("A quatidade digitada não pode ser maior da quantidade em Estoque!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                txtQtdeSaida.Text = "";
            }

            else
            {
                qtdSaida = qtd - qtdSolicitada;

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
                    String descricaoPecas = cbPeca.SelectedValue.ToString();
                    string _Select = "Select Pecas.descricao as descricao,EstoquePecas.codigo_estoquePecas as Codigo, EstoquePecas.valorUni from EstoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas where EstoquePecas.situacao ='Estoque' and Pecas.descricao='" + descricaoPecas + "'  group by  Pecas.descricao, EstoquePecas.Quantidade, EstoquePecas.valorUni,  EstoquePecas.codigo_estoquePecas";

                    // inicializa o comando e a conexão
                    SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                    SqlDataReader resultado = _cmdSelect.ExecuteReader();
                    resultado.Read();

                    codigo_estoquePecas = resultado["Codigo"] + "";
                    valorUni = resultado["valorUni"] + "";

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
                   
                    if (modo == "AddOrdemServico")
                    {
                       if (cbMotivo.SelectedIndex == 1 || cbMotivo.SelectedIndex == 2 || cbMotivo.SelectedIndex == 4)
                        {

                            sql = @"insert into SaidaPecasCli(codigo_estoquePecas, codigo_cliente, codigo_usuario, motivo, observacao, qtdeSaida, dtSaida,reposicao)
                        Values('" + codigo_estoquePecas + "','" + codigo_cliente + "','" + codigo_usuario + "','" + cbMotivo.Text + "','" + txtObservacao.Text + "'," + qtdSolicitada + ",convert(smalldatetime,'" + dataSaida.ToString() + "',103),'-')"+
                           " DECLARE @LAST_ID INT;" +
                            " SET @LAST_ID = SCOPE_IDENTITY();" +
                           "select * from saidaPecasCli where codigo_spc= @LAST_ID";
                           sql2 = @"Update EstoquePecas Set quantidade=" + qtdSaida + " where codigo_estoquePecas = '" + codigo_estoquePecas + "'";
                                                       
                           
                            MessageBox.Show("Cadastrado com Sucesso!");

                        }
                        else
                        {
                            sql = @"insert into SaidaPecasCli(codigo_estoquePecas, codigo_cliente, codigo_usuario, motivo, observacao, qtdeSaida, dtSaida,reposicao)
                        Values('" + codigo_estoquePecas + "','" + codigo_cliente + "','" + codigo_usuario + "','" + cbMotivo.Text + "','" + txtObservacao.Text + "'," + qtdSolicitada + ",convert(smalldatetime,'" + dataSaida.ToString() + "',103),'Não')";
                            sql2 = @"Update EstoquePecas Set quantidade=" + qtdSaida + " where codigo_estoquePecas = '" + codigo_estoquePecas + "'";
                            MessageBox.Show("Cadastrado com Sucesso!");
                        }
                    }
                   
                    
                    if (modo == "Incluir")
                    {

                        if (cbMotivo.SelectedIndex == 1 || cbMotivo.SelectedIndex == 2 || cbMotivo.SelectedIndex == 4)
                        {

                            sql = @"insert into SaidaPecasCli(codigo_estoquePecas, codigo_cliente, codigo_usuario, motivo, observacao, qtdeSaida, dtSaida,reposicao)
                        Values('" + codigo_estoquePecas + "','" + codigo_cliente + "','" + codigo_usuario + "','" + cbMotivo.Text + "','" + txtObservacao.Text + "'," + qtdSolicitada + ",convert(smalldatetime,'" + dataSaida.ToString() + "',103),'-')";
                            sql2 = @"Update EstoquePecas Set quantidade=" + qtdSaida + " where codigo_estoquePecas = '" + codigo_estoquePecas + "'";
                           
                            MessageBox.Show("Cadastrado com Sucesso!");

                        }
                        else
                        {
                            sql = @"insert into SaidaPecasCli(codigo_estoquePecas, codigo_cliente, codigo_usuario, motivo, observacao, qtdeSaida, dtSaida,reposicao)
                        Values('" + codigo_estoquePecas + "','" + codigo_cliente + "','" + codigo_usuario + "','" + cbMotivo.Text + "','" + txtObservacao.Text + "'," + qtdSolicitada + ",convert(smalldatetime,'" + dataSaida.ToString() + "',103),'Não')";
                            sql2 = @"Update EstoquePecas Set quantidade=" + qtdSaida + " where codigo_estoquePecas = '" + codigo_estoquePecas + "'";
                            MessageBox.Show("Cadastrado com Sucesso!");
                        }
                    }
                    else if (botao == "Editar")
                    {
                        if (cbMotivo.SelectedIndex == 1 || cbMotivo.SelectedIndex == 2 || cbMotivo.SelectedIndex == 4)
                        {
                            int qtd2 = Convert.ToInt32(qtdEstoque.Text);
                            qtdSolicitada2 = Convert.ToInt32(txtQtdeSaida.Text);
                            if (txtQtdeSaida.Text == "")
                            {
                                MessageBox.Show("Quantidade para Saída não pode ficar em branco!");
                            }
                            else if (qtdSolicitada2 > qtd2)
                            {
                                MessageBox.Show("A quatidade digitada não pode ser maior da quantidade em Estoque!");
                                txtQtdeSaida.Text = "";
                            }
                            else
                            {
                                int soma = qtd2 + qtdeSub;
                                qtdSaidaUpdate = soma - qtdSolicitada2;

                                if (qtdeSub != qtdSolicitada2)
                                {
                                    // comando SQL para inserir - Insert Into
                                    sql = @"Update SaidaPecasCli Set codigo_estoquePecas='" + codigo_estoquePecas + "', codigo_cliente= '" + codigo_cliente + "',codigo_usuario='" + codigo_usuario + "',motivo='" + cbMotivo.Text + "',observacao='" + txtObservacao.Text + "',qtdeSaida=" + qtdSolicitada2 + ",dtSaida=convert(smalldatetime,'" + dataSaida.ToString() + "',103),reposicao='-' where codigo_spc='" + codigo_spc + "'" +
                                     "select * from saidaPecasCli where codigo_spc=" + codigo_spc;
                                    sql2 = @"Update EstoquePecas Set quantidade=" + qtdSaidaUpdate + " where codigo_estoquePecas = '" + codigo_estoquePecas + "'";
                                }
                                else
                                {
                                    sql = @"Update SaidaPecasCli Set codigo_estoquePecas='" + codigo_estoquePecas + "', codigo_cliente= '" + codigo_cliente + "',codigo_usuario='" + codigo_usuario + "',motivo='" + cbMotivo.Text + "',observacao='" + txtObservacao.Text + "',qtdeSaida=" + qtdeSub + ",dtSaida=convert(smalldatetime,'" + dataSaida.ToString() + "',103),reposicao='-' where codigo_spc='" + codigo_spc + "'" +
                                     "select * from saidaPecasCli where codigo_spc=" + codigo_spc;
                                    sql2 = @"Update EstoquePecas Set quantidade=" + qtd2 + " where codigo_estoquePecas = '" + codigo_estoquePecas + "'";

                                
                                }
                                MessageBox.Show("Alterado com Sucesso !");
                            }
                        }
                        else
                        {
                            int qtd2 = Convert.ToInt32(qtdEstoque.Text);
                            qtdSolicitada2 = Convert.ToInt32(txtQtdeSaida.Text);
                            if (txtQtdeSaida.Text == "")
                            {
                                MessageBox.Show("Quantidade para Saída não pode ficar em branco!");
                            }
                            else if (qtdSolicitada2 > qtd2)
                            {
                                MessageBox.Show("A quatidade digitada não pode ser maior da quantidade em Estoque!");
                                txtQtdeSaida.Text = "";
                            }
                            else
                            {
                                int soma = qtd2 + qtdeSub;
                                qtdSaidaUpdate = soma - qtdSolicitada2;

                                if (qtdeSub != qtdSolicitada2)
                                {
                                    // comando SQL para inserir - Insert Into
                                    sql = @"Update SaidaPecasCli Set codigo_estoquePecas='" + codigo_estoquePecas + "', codigo_cliente= '" + codigo_cliente + "',codigo_usuario='" + codigo_usuario + "',motivo='" + cbMotivo.Text + "',observacao='" + txtObservacao.Text + "',qtdeSaida=" + qtdSolicitada2 + ",dtSaida=convert(smalldatetime,'" + dataSaida.ToString() + "',103),reposicao='-' where codigo_spc='" + codigo_spc + "'" +
                                     "select * from saidaPecasCli where codigo_spc=" + codigo_spc;
                                    sql2 = @"Update EstoquePecas Set quantidade=" + qtdSaidaUpdate + " where codigo_estoquePecas = '" + codigo_estoquePecas + "'";
                                }
                                else
                                {
                                    sql = @"Update SaidaPecasCli Set codigo_estoquePecas='" + codigo_estoquePecas + "', codigo_cliente= '" + codigo_cliente + "',codigo_usuario='" + codigo_usuario + "',motivo='" + cbMotivo.Text + "',observacao='" + txtObservacao.Text + "',qtdeSaida=" + qtdeSub + ",dtSaida=convert(smalldatetime,'" + dataSaida.ToString() + "',103),reposicao='-' where codigo_spc='" + codigo_spc + "'" +
                                     "select * from saidaPecasCli where codigo_spc=" + codigo_spc;
                                    sql2 = @"Update EstoquePecas Set quantidade=" + qtd2 + " where codigo_estoquePecas = '" + codigo_estoquePecas + "'";


                                }
                                MessageBox.Show("Alterado com Sucesso !");
                            }
                        }
                    
                    }
                    //-------

                    if( modo=="EditarOrdemServico")
                    {
                        SqlCommand codigo = new SqlCommand(sql, conexao);
                        SqlDataReader resultado = codigo.ExecuteReader();
                        resultado.Read();
                            int linha = Convert.ToInt32(formPai.txtLinha.Text);
                          
                             formPai.listProdutos.Items.RemoveAt(formPai.listProdutos.Items.IndexOf(formPai.listProdutos.SelectedItem));
                             formPai.listProdutos.Items.Add(resultado["codigo_spc"] + "" + " | " + cbPeca.Text.ToString() + " | " + txtQtdeSaida.Text.ToString() + " | " + valorUni.ToString());
                            

          
                        conexao.Close();


                        conexao.Open();

                        SqlCommand codigoUpdate = new SqlCommand(sql2, conexao);
                        codigoUpdate.ExecuteNonQuery();

                        conexao.Close();

                        Close();
                    }
                    else if(modo=="AddOrdemServico")
                    {
                          SqlCommand codigo = new SqlCommand(sql, conexao);
                          SqlDataReader resultado = codigo.ExecuteReader();
                          resultado.Read();
                        
                          formPai.listProdutos.Items.Add(resultado["codigo_spc"] + "" + " | " + cbPeca.Text.ToString() + " | " + txtQtdeSaida.Text.ToString() + " | " + valorUni.ToString());
                          
                          conexao.Close();


                          conexao.Open();
                   
                          SqlCommand codigoUpdate = new SqlCommand(sql2, conexao);
                          codigoUpdate.ExecuteNonQuery();
                    
                          conexao.Close();

                          Close();
                    }
                    else
                    {
                          SqlCommand codigo = new SqlCommand(sql, conexao);
                          codigo.ExecuteNonQuery();
                      
                      
                          SqlCommand codigoUpdate = new SqlCommand(sql2, conexao);
                          codigoUpdate.ExecuteNonQuery();
                    
                          conexao.Close();

                          Close();
                    
                    
                    }
                  
                    

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
                String descricaoPecas = cbPeca.SelectedValue.ToString();
                string _Select = "Select Pecas.descricao as descricao,EstoquePecas.codigo_estoquePecas as Codigo from EstoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas where EstoquePecas.situacao ='Estoque' and Pecas.descricao='" + descricaoPecas + "'  group by  Pecas.descricao, EstoquePecas.Quantidade,  EstoquePecas.codigo_estoquePecas";

                // inicializa o comando e a conexão
                SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                SqlDataReader resultado = _cmdSelect.ExecuteReader();
                resultado.Read();

                codigo_estoquePecas= resultado["Codigo"] + "";


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
                int qtd2 = Convert.ToInt32(qtdEstoque.Text);
                qtdSolicitada2 = Convert.ToInt32(txtQtdeSaida.Text);
                int soma = qtd2 + qtdSolicitada2;
                int quantidade = Convert.ToInt32(soma);




                // comando SQL para inserir - Insert Into
                sql = @"Update SaidaPecasCli Set reposicao='Sim' where codigo_spc='" + codigo_spc + "'";
                sql2 = @"Update EstoquePecas Set quantidade= " + quantidade + " where codigo_estoquePecas = '" + codigo_estoquePecas+"'";

                MessageBox.Show("Reposição registrada com Sucesso ! " );

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
