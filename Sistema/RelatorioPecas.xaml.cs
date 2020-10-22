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
    /// Interaction logic for RelatorioPecas.xaml
    /// </summary>
    public partial class RelatorioPecas : Window
    {
        public RelatorioPecas()
        {
            InitializeComponent();
        }

        private void cbTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbTipo.SelectedIndex == 1)
            {
                cbFiltro.IsEnabled = true;
                cbFiltro.Items.Clear();
                cbFiltro.Items.Add("Tipo de Busca:");
                cbFiltro.SelectedIndex = 0;
                cbFiltro.Items.Add("Data");
                cbFiltro.Items.Add("Peça");
                cbFiltro.Items.Add("Quantidade");
                cbFiltro.Items.Add("Valor Unitário");
                cbFiltro.Items.Add("Fornecedor");
                cbFiltro.Items.Add("Localização");

                dtgRelatorioPecas.Columns[0].Visibility = Visibility.Visible;
                dtgRelatorioPecas.Columns[1].Visibility = Visibility.Visible;
                dtgRelatorioPecas.Columns[2].Visibility = Visibility.Visible;
                dtgRelatorioPecas.Columns[3].Visibility = Visibility.Visible;
                dtgRelatorioPecas.Columns[4].Visibility = Visibility.Visible;
                dtgRelatorioPecas.Columns[5].Visibility = Visibility.Visible;

                dtgRelatorioPecas.Columns[6].Visibility = Visibility.Hidden;
                dtgRelatorioPecas.Columns[7].Visibility = Visibility.Hidden;
                dtgRelatorioPecas.Columns[8].Visibility = Visibility.Hidden;
                dtgRelatorioPecas.Columns[9].Visibility = Visibility.Hidden;
                dtgRelatorioPecas.Columns[10].Visibility = Visibility.Hidden;
                dtgRelatorioPecas.Columns[11].Visibility = Visibility.Hidden;
                dtgRelatorioPecas.Columns[12].Visibility = Visibility.Hidden;
                dtgRelatorioPecas.Columns[13].Visibility = Visibility.Hidden;



                SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


                try
                {

                    Con.Open();
                    SqlDataAdapter _Adapter = new SqlDataAdapter("select estoquePecas.*,convert(CHAR,dtEntrada,101) as DataEntrada,Pecas.descricao as Pecas, Fornecedor.Nome as Fornecedor  from EstoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas  inner join Fornecedor on EstoquePecas.codigo_fornecedor=Fornecedor.codigo_fornecedor order by DataEntrada", Con);

                    DataSet _ds = new DataSet();
                    _Adapter.Fill(_ds, "relatorioDataBinding");



                    dtgRelatorioPecas.DataContext = _ds;
                }
                catch (SqlException)
                {
                    MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                    Con.Close();
                }




            }
            else if (cbTipo.SelectedIndex == 2)
            {
                cbFiltro.IsEnabled = true;
                cbFiltro.Items.Clear();
                cbFiltro.Items.Add("Tipo de Busca:");
                cbFiltro.SelectedIndex = 0;
                cbFiltro.Items.Add("Data");
                cbFiltro.Items.Add("Peça");
                cbFiltro.Items.Add("Quantidade");
                cbFiltro.Items.Add("Motivo");
                cbFiltro.Items.Add("Cliente");
                cbFiltro.Items.Add("Usuário");

                dtgRelatorioPecas.Columns[0].Visibility = Visibility.Hidden;
                dtgRelatorioPecas.Columns[1].Visibility = Visibility.Hidden;
                dtgRelatorioPecas.Columns[2].Visibility = Visibility.Hidden;
                dtgRelatorioPecas.Columns[3].Visibility = Visibility.Hidden;
                dtgRelatorioPecas.Columns[4].Visibility = Visibility.Hidden;
                dtgRelatorioPecas.Columns[5].Visibility = Visibility.Hidden;

                dtgRelatorioPecas.Columns[6].Visibility = Visibility.Visible;
                dtgRelatorioPecas.Columns[7].Visibility = Visibility.Visible;
                dtgRelatorioPecas.Columns[8].Visibility = Visibility.Visible;
                dtgRelatorioPecas.Columns[9].Visibility = Visibility.Visible;
                dtgRelatorioPecas.Columns[10].Visibility = Visibility.Visible;
                dtgRelatorioPecas.Columns[11].Visibility = Visibility.Visible;
                dtgRelatorioPecas.Columns[12].Visibility = Visibility.Visible;
                dtgRelatorioPecas.Columns[13].Visibility = Visibility.Visible;



                SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


                try
                {

                    Con.Open();
                    SqlDataAdapter _Adapter = new SqlDataAdapter("select SaidaPecasCli.*, convert(CHAR,SaidaPecasCli.dtSaida,101) as DataSaida, SaidaPecasCli.reposicao,Pecas.descricao,motivo,SaidaPecasCli.observacao, qtdeSaida, Cliente.Nome, usuario.nome as Usuario from SaidaPecasCli inner join Cliente on SaidaPecasCli.codigo_cliente = Cliente.codigo_cliente inner join EstoquePecas on SaidaPecasCli.codigo_estoquePecas = EstoquePecas.codigo_estoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas inner join usuario on SaidaPecasCli.codigo_usuario = usuario.codigo_usuario order by DataSaida", Con);

                    DataSet _ds = new DataSet();
                    _Adapter.Fill(_ds, "relatorioDataBinding");



                    dtgRelatorioPecas.DataContext = _ds;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Não foi possivel conectar com o Banco" + ex, "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                    Con.Close();
                }


            }

        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void txtPesquisa_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cbFiltro.Text == "Tipo de Busca:" && txtPesquisa.Text != "")
            {
                txtPesquisa.Text = string.Empty;
                MessageBox.Show("Selecione um tipo de Busca.");



            }

            if (cbTipo.SelectedIndex == 1)
            {
                if (txtPesquisa.Text == "")
                {
                    SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


                    try
                    {
                        Con.Open();
                        SqlDataAdapter _Adapter = new SqlDataAdapter("select estoquePecas.*,convert(CHAR,dtEntrada,101) as DataEntrada,Pecas.descricao as Pecas, Fornecedor.Nome as Fornecedor  from EstoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas  inner join Fornecedor on EstoquePecas.codigo_fornecedor=Fornecedor.codigo_fornecedor order by DataEntrada", Con);

                        DataSet _ds = new DataSet();
                        _Adapter.Fill(_ds, "relatorioDataBinding");


                        dtgRelatorioPecas.DataContext = _ds;

                        // Fecha a conexão
                        Con.Close();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                        Con.Close();
                    }


                }
                else
                {

                    SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


                    try
                    {


                        Con.Open();

                        SqlDataAdapter _Adapter;
                        if (cbFiltro.Text == "Data")
                        {
                            _Adapter = new SqlDataAdapter("select estoquePecas.*,convert(CHAR,dtEntrada,101) as DataEntrada,Pecas.descricao as Pecas, Fornecedor.Nome as Fornecedor  from EstoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas  inner join Fornecedor on EstoquePecas.codigo_fornecedor=Fornecedor.codigo_fornecedor where convert(CHAR,dtEntrada,101) LIKE'%" + txtPesquisa.Text + "%' order by DataEntrada", Con);

                        }
                        else if (cbFiltro.Text == "Peça")
                        {
                            _Adapter = new SqlDataAdapter("select estoquePecas.*,convert(CHAR,dtEntrada,101) as DataEntrada,Pecas.descricao as Pecas, Fornecedor.Nome as Fornecedor  from EstoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas  inner join Fornecedor on EstoquePecas.codigo_fornecedor=Fornecedor.codigo_fornecedor where Pecas.descricao LIKE'%" + txtPesquisa.Text + "%' order by DataEntrada", Con);
                        }
                        else if (cbFiltro.Text == "Quantidade")
                        {
                            _Adapter = new SqlDataAdapter("select estoquePecas.*,convert(CHAR,dtEntrada,101) as DataEntrada,Pecas.descricao as Pecas, Fornecedor.Nome as Fornecedor  from EstoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas  inner join Fornecedor on EstoquePecas.codigo_fornecedor=Fornecedor.codigo_fornecedor where EstoquePecas.quantidade LIKE'%" + txtPesquisa.Text + "%' order by DataEntrada", Con);
                        }
                        else if (cbFiltro.Text == "Valor Unitário")
                        {
                            _Adapter = new SqlDataAdapter("select estoquePecas.*,convert(CHAR,dtEntrada,101) as DataEntrada,Pecas.descricao as Pecas, Fornecedor.Nome as Fornecedor  from EstoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas  inner join Fornecedor on EstoquePecas.codigo_fornecedor=Fornecedor.codigo_fornecedor where EstoquePecas.valorUni LIKE'%" + txtPesquisa.Text + "%' order by DataEntrada", Con);
                        }
                        else if (cbFiltro.Text == "Fornecedor")
                        {
                            _Adapter = new SqlDataAdapter("select estoquePecas.*,convert(CHAR,dtEntrada,101) as DataEntrada,Pecas.descricao as Pecas, Fornecedor.Nome as Fornecedor  from EstoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas  inner join Fornecedor on EstoquePecas.codigo_fornecedor=Fornecedor.codigo_fornecedor where Fornecedor.Nome LIKE'%" + txtPesquisa.Text + "%' order by DataEntrada", Con);
                        }
                        else
                        {
                            _Adapter = new SqlDataAdapter("select estoquePecas.*,convert(CHAR,dtEntrada,101) as DataEntrada,Pecas.descricao as Pecas, Fornecedor.Nome as Fornecedor  from EstoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas  inner join Fornecedor on EstoquePecas.codigo_fornecedor=Fornecedor.codigo_fornecedor where EstoquePecas.localizacao  LIKE'%" + txtPesquisa.Text + "%' order by DataEntrada", Con);

                        }
                        DataSet _ds = new DataSet();
                        _Adapter.Fill(_ds, "relatorioDataBinding");


                        dtgRelatorioPecas.DataContext = _ds;

                        // Fecha a conexão
                        Con.Close();


                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Não foi possivel conectar com o Banco" + ex, "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                        Con.Close();
                    }
                }
            }
            else if (cbTipo.SelectedIndex == 2)
            {

                if (txtPesquisa.Text == "")
                {
                    SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


                    try
                    {
                        Con.Open();
                        SqlDataAdapter _Adapter = new SqlDataAdapter("select SaidaPecasCli.*, convert(CHAR,SaidaPecasCli.dtSaida,101) as DataSaida, SaidaPecasCli.reposicao,Pecas.descricao,motivo,SaidaPecasCli.observacao, qtdeSaida, Cliente.Nome, usuario.nome as Usuario from SaidaPecasCli inner join Cliente on SaidaPecasCli.codigo_cliente = Cliente.codigo_cliente inner join EstoquePecas on SaidaPecasCli.codigo_estoquePecas = EstoquePecas.codigo_estoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas inner join usuario on SaidaPecasCli.codigo_usuario = usuario.codigo_usuario order by DataSaida", Con);

                        DataSet _ds = new DataSet();
                        _Adapter.Fill(_ds, "relatorioDataBinding");


                        dtgRelatorioPecas.DataContext = _ds;

                        // Fecha a conexão
                        Con.Close();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                        Con.Close();
                    }


                }
                else
                {

                    SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


                    try
                    {


                        Con.Open();

                        SqlDataAdapter _Adapter;
                        if (cbFiltro.Text == "Data")
                        {
                            _Adapter = new SqlDataAdapter("select SaidaPecasCli.*, convert(CHAR,SaidaPecasCli.dtSaida,101) as DataSaida, SaidaPecasCli.reposicao,Pecas.descricao,motivo,SaidaPecasCli.observacao, qtdeSaida, Cliente.Nome, usuario.nome as Usuario from SaidaPecasCli inner join Cliente on SaidaPecasCli.codigo_cliente = Cliente.codigo_cliente inner join EstoquePecas on SaidaPecasCli.codigo_estoquePecas = EstoquePecas.codigo_estoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas inner join usuario on SaidaPecasCli.codigo_usuario = usuario.codigo_usuario where convert(CHAR,SaidaPecasCli.dtSaida,101) LIKE'%" + txtPesquisa.Text + "%' order by DataSaida", Con);

                        }
                        else if (cbFiltro.Text == "Peça")
                        {
                            _Adapter = new SqlDataAdapter("select SaidaPecasCli.*, convert(CHAR,SaidaPecasCli.dtSaida,101) as DataSaida, SaidaPecasCli.reposicao,Pecas.descricao,motivo,SaidaPecasCli.observacao, qtdeSaida, Cliente.Nome, usuario.nome as Usuario from SaidaPecasCli inner join Cliente on SaidaPecasCli.codigo_cliente = Cliente.codigo_cliente inner join EstoquePecas on SaidaPecasCli.codigo_estoquePecas = EstoquePecas.codigo_estoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas inner join usuario on SaidaPecasCli.codigo_usuario = usuario.codigo_usuario where Pecas.descricao LIKE'%" + txtPesquisa.Text + "%' order by DataSaida", Con);
                        }
                        else if (cbFiltro.Text == "Quantidade")
                        {
                            _Adapter = new SqlDataAdapter("select SaidaPecasCli.*, convert(CHAR,SaidaPecasCli.dtSaida,101) as DataSaida, SaidaPecasCli.reposicao,Pecas.descricao,motivo,SaidaPecasCli.observacao, qtdeSaida, Cliente.Nome, usuario.nome as Usuario from SaidaPecasCli inner join Cliente on SaidaPecasCli.codigo_cliente = Cliente.codigo_cliente inner join EstoquePecas on SaidaPecasCli.codigo_estoquePecas = EstoquePecas.codigo_estoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas inner join usuario on SaidaPecasCli.codigo_usuario = usuario.codigo_usuario where SaidaPecasCli.qtdeSaida  LIKE'%" + txtPesquisa.Text + "%' order by DataSaida", Con);
                        }
                        else if (cbFiltro.Text == "Cliente")
                        {
                            _Adapter = new SqlDataAdapter("select SaidaPecasCli.*, convert(CHAR,SaidaPecasCli.dtSaida,101) as DataSaida, SaidaPecasCli.reposicao,Pecas.descricao,motivo,SaidaPecasCli.observacao, qtdeSaida, Cliente.Nome, usuario.nome as Usuario from SaidaPecasCli inner join Cliente on SaidaPecasCli.codigo_cliente = Cliente.codigo_cliente inner join EstoquePecas on SaidaPecasCli.codigo_estoquePecas = EstoquePecas.codigo_estoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas inner join usuario on SaidaPecasCli.codigo_usuario = usuario.codigo_usuario where Cliente.Nome LIKE'%" + txtPesquisa.Text + "%' order by DataSaida", Con);
                        }
                        else if (cbFiltro.Text == "Motivo")
                        {
                            _Adapter = new SqlDataAdapter("select SaidaPecasCli.*, convert(CHAR,SaidaPecasCli.dtSaida,101) as DataSaida, SaidaPecasCli.reposicao,Pecas.descricao,motivo,SaidaPecasCli.observacao, qtdeSaida, Cliente.Nome, usuario.nome as Usuario from SaidaPecasCli inner join Cliente on SaidaPecasCli.codigo_cliente = Cliente.codigo_cliente inner join EstoquePecas on SaidaPecasCli.codigo_estoquePecas = EstoquePecas.codigo_estoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas inner join usuario on SaidaPecasCli.codigo_usuario = usuario.codigo_usuario where SaidaPecasCli.motivo  LIKE'%" + txtPesquisa.Text + "%' order by DataSaida", Con);
                        }
                        else
                        {
                            _Adapter = new SqlDataAdapter("select SaidaPecasCli.*, convert(CHAR,SaidaPecasCli.dtSaida,101) as DataSaida, SaidaPecasCli.reposicao,Pecas.descricao,motivo,SaidaPecasCli.observacao, qtdeSaida, Cliente.Nome, usuario.nome as Usuario from SaidaPecasCli inner join Cliente on SaidaPecasCli.codigo_cliente = Cliente.codigo_cliente inner join EstoquePecas on SaidaPecasCli.codigo_estoquePecas = EstoquePecas.codigo_estoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas inner join usuario on SaidaPecasCli.codigo_usuario = usuario.codigo_usuario where Usuario.nome LIKE'%" + txtPesquisa.Text + "%' order by DataSaida", Con);
                        }
                        DataSet _ds = new DataSet();
                        _Adapter.Fill(_ds, "relatorioDataBinding");


                        dtgRelatorioPecas.DataContext = _ds;

                        // Fecha a conexão
                        Con.Close();


                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                        Con.Close();
                    }
                }

            }
        }
    }
}
