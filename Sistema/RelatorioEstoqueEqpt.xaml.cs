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
    /// Interaction logic for RelatorioEstoqueEqpt.xaml
    /// </summary>
    public partial class RelatorioEstoqueEqpt : Window
    {
        
        public RelatorioEstoqueEqpt()
        {
            InitializeComponent();
        }
        public void VinculaDados()
        {



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
                cbFiltro.Items.Add("Fornecedor");
                cbFiltro.Items.Add("Equipamento");
                cbFiltro.Items.Add("Nº de Serie");
                cbFiltro.Items.Add("Modelo");
                cbFiltro.Items.Add("Localização");
               
                
               
               
                dtgRelatorioEqpt.Columns[0].Visibility = Visibility.Visible;
                dtgRelatorioEqpt.Columns[1].Visibility = Visibility.Visible;
                dtgRelatorioEqpt.Columns[2].Visibility = Visibility.Visible;
                dtgRelatorioEqpt.Columns[3].Visibility = Visibility.Visible;
                dtgRelatorioEqpt.Columns[4].Visibility = Visibility.Visible;
                dtgRelatorioEqpt.Columns[5].Visibility = Visibility.Visible;

                dtgRelatorioEqpt.Columns[6].Visibility = Visibility.Hidden;
                dtgRelatorioEqpt.Columns[7].Visibility = Visibility.Hidden;
                dtgRelatorioEqpt.Columns[8].Visibility = Visibility.Hidden;
                dtgRelatorioEqpt.Columns[9].Visibility = Visibility.Hidden;
                dtgRelatorioEqpt.Columns[10].Visibility = Visibility.Hidden;
                dtgRelatorioEqpt.Columns[11].Visibility = Visibility.Hidden;
                dtgRelatorioEqpt.Columns[12].Visibility = Visibility.Hidden;
                dtgRelatorioEqpt.Columns[13].Visibility = Visibility.Hidden;



                SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");
                           

                try
                {

                    Con.Open();
                    SqlDataAdapter _Adapter = new SqlDataAdapter("Select *, convert(CHAR,dtEntrada,101) as DataEntrada, Fornecedor.nome as fornecedor, Equipamento.descricao as equipamento from Estoque inner join Fornecedor on Estoque.codigo_fornecedor = Fornecedor.codigo_fornecedor inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento where Estoque.situacao='EntradaEstoque' order by DataEntrada ", Con);

                    DataSet _ds = new DataSet();
                    _Adapter.Fill(_ds, "relatorioDataBinding");

                             

                    dtgRelatorioEqpt.DataContext = _ds;
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
                cbFiltro.Items.Add("Equipamento");
                cbFiltro.Items.Add("Nº de Serie");
                cbFiltro.Items.Add("Cliente");
                cbFiltro.Items.Add("Motivo");
                cbFiltro.Items.Add("Usuário");
                
                dtgRelatorioEqpt.Columns[0].Visibility = Visibility.Hidden;
                dtgRelatorioEqpt.Columns[1].Visibility = Visibility.Hidden;
                dtgRelatorioEqpt.Columns[2].Visibility = Visibility.Hidden;
                dtgRelatorioEqpt.Columns[3].Visibility = Visibility.Hidden;
                dtgRelatorioEqpt.Columns[4].Visibility = Visibility.Hidden;
                dtgRelatorioEqpt.Columns[5].Visibility = Visibility.Hidden;

                dtgRelatorioEqpt.Columns[6].Visibility = Visibility.Visible;
                dtgRelatorioEqpt.Columns[7].Visibility = Visibility.Visible;
                dtgRelatorioEqpt.Columns[8].Visibility = Visibility.Visible;
                dtgRelatorioEqpt.Columns[9].Visibility = Visibility.Visible;
                dtgRelatorioEqpt.Columns[10].Visibility = Visibility.Visible;
                dtgRelatorioEqpt.Columns[11].Visibility = Visibility.Visible;
                dtgRelatorioEqpt.Columns[12].Visibility = Visibility.Visible;
                dtgRelatorioEqpt.Columns[13].Visibility = Visibility.Visible;



                SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");
                           

                try
                {

                    Con.Open();
                    SqlDataAdapter _Adapter = new SqlDataAdapter("select SaidaEstoqueCli.codigo_se, convert(CHAR,dtSaida,101) as DataSaida,SaidaEstoqueCli.reposicao,Equipamento.descricao,Estoque.nrSerie,SaidaEstoqueCli.motivo,SaidaEstoqueCli.observacao, Cliente.Nome, usuario.nome as Usuario from SaidaEstoqueCli inner join Cliente on SaidaEstoqueCli.codigo_cliente = Cliente.codigo_cliente inner join Estoque on SaidaEstoqueCli.codigo_estoque = Estoque.codigo_estoque inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento inner join usuario on SaidaEstoqueCli.codigo_usuario = usuario.codigo_usuario order by DataSaida ", Con);

                    DataSet _ds = new DataSet();
                    _Adapter.Fill(_ds, "relatorioDataBinding");

                             

                    dtgRelatorioEqpt.DataContext = _ds;
                }
                catch (SqlException)
                {
                    MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                    Con.Close();
                }
         
            
            }
        }

        private void dtgRelatorioEqpt_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            
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
                        SqlDataAdapter _Adapter = new SqlDataAdapter("Select *, convert(CHAR,dtEntrada,101) as DataEntrada, Fornecedor.nome as fornecedor, Equipamento.descricao as equipamento from Estoque inner join Fornecedor on Estoque.codigo_fornecedor = Fornecedor.codigo_fornecedor inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento where Estoque.situacao='EntradaEstoque' order by DataEntrada ", Con);

                        DataSet _ds = new DataSet();
                        _Adapter.Fill(_ds, "relatorioDataBinding");


                        dtgRelatorioEqpt.DataContext = _ds;

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
                            _Adapter = new SqlDataAdapter("Select *, convert(CHAR,dtEntrada,101) as DataEntrada, Fornecedor.nome as fornecedor, Equipamento.descricao as equipamento from Estoque inner join Fornecedor on Estoque.codigo_fornecedor = Fornecedor.codigo_fornecedor inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento where Estoque.situacao='EntradaEstoque' and convert(CHAR,dtEntrada,101)  LIKE'%" + txtPesquisa.Text + "%'  order by DataEntrada ", Con);

                        }
                        else if (cbFiltro.Text == "Fornecedor")
                        {
                            _Adapter = new SqlDataAdapter("Select *, convert(CHAR,dtEntrada,101) as DataEntrada, Fornecedor.nome as fornecedor, Equipamento.descricao as equipamento from Estoque inner join Fornecedor on Estoque.codigo_fornecedor = Fornecedor.codigo_fornecedor inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento where Estoque.situacao='EntradaEstoque' and Fornecedor.Nome  LIKE'%" + txtPesquisa.Text + "%'  order by DataEntrada ", Con);
                        }
                        else if (cbFiltro.Text == "Equipamento")
                        {
                            _Adapter = new SqlDataAdapter("Select *, convert(CHAR,dtEntrada,101) as DataEntrada, Fornecedor.nome as fornecedor, Equipamento.descricao as equipamento from Estoque inner join Fornecedor on Estoque.codigo_fornecedor = Fornecedor.codigo_fornecedor inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento where Estoque.situacao='EntradaEstoque' and Equipamento.descricao  LIKE'%" + txtPesquisa.Text + "%'  order by DataEntrada ", Con);
                        }
                        else if (cbFiltro.Text == "Nº de Serie")
                        {
                            _Adapter = new SqlDataAdapter("Select *, convert(CHAR,dtEntrada,101) as DataEntrada, Fornecedor.nome as fornecedor, Equipamento.descricao as equipamento from Estoque inner join Fornecedor on Estoque.codigo_fornecedor = Fornecedor.codigo_fornecedor inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento where Estoque.situacao='EntradaEstoque' and Estoque.nrSerie  LIKE'%" + txtPesquisa.Text + "%'  order by DataEntrada ", Con);
                        }
                        else if (cbFiltro.Text == "Modelo")
                        {
                            _Adapter = new SqlDataAdapter("Select *, convert(CHAR,dtEntrada,101) as DataEntrada, Fornecedor.nome as fornecedor, Equipamento.descricao as equipamento from Estoque inner join Fornecedor on Estoque.codigo_fornecedor = Fornecedor.codigo_fornecedor inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento where Estoque.situacao='EntradaEstoque' and Estoque.Modelo  LIKE'%" + txtPesquisa.Text + "%'  order by DataEntrada ", Con);
                        }
                        else
                        {
                            _Adapter = new SqlDataAdapter("Select *, convert(CHAR,dtEntrada,101) as DataEntrada, Fornecedor.nome as fornecedor, Equipamento.descricao as equipamento from Estoque inner join Fornecedor on Estoque.codigo_fornecedor = Fornecedor.codigo_fornecedor inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento where Estoque.situacao='EntradaEstoque' and Estoque.localizacao  LIKE'%" + txtPesquisa.Text + "%'  order by DataEntrada ", Con);
                        }
                        DataSet _ds = new DataSet();
                        _Adapter.Fill(_ds, "relatorioDataBinding");


                        dtgRelatorioEqpt.DataContext = _ds;

                        // Fecha a conexão
                        Con.Close();


                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Não foi possivel conectar com o Banco"+ ex, "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
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
                        SqlDataAdapter _Adapter = new SqlDataAdapter("select convert(CHAR,dtSaida,101) as DataSaida,SaidaEstoqueCli.reposicao,Equipamento.descricao,Estoque.nrSerie,SaidaEstoqueCli.motivo,SaidaEstoqueCli.observacao, Cliente.Nome, usuario.nome as Usuario from SaidaEstoqueCli inner join Cliente on SaidaEstoqueCli.codigo_cliente = Cliente.codigo_cliente inner join Estoque on SaidaEstoqueCli.codigo_estoque = Estoque.codigo_estoque inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento inner join usuario on SaidaEstoqueCli.codigo_usuario = usuario.codigo_usuario order by DataSaida  ", Con);

                        DataSet _ds = new DataSet();
                        _Adapter.Fill(_ds, "relatorioDataBinding");


                        dtgRelatorioEqpt.DataContext = _ds;

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
                            _Adapter = new SqlDataAdapter("select convert(CHAR,dtSaida,101) as DataSaida,SaidaEstoqueCli.reposicao,Equipamento.descricao,Estoque.nrSerie,SaidaEstoqueCli.motivo,SaidaEstoqueCli.observacao, Cliente.Nome, usuario.nome as Usuario from SaidaEstoqueCli inner join Cliente on SaidaEstoqueCli.codigo_cliente = Cliente.codigo_cliente inner join Estoque on SaidaEstoqueCli.codigo_estoque = Estoque.codigo_estoque inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento inner join usuario on SaidaEstoqueCli.codigo_usuario = usuario.codigo_usuario where convert(CHAR,dtSaida,101)  LIKE'%" + txtPesquisa.Text + "%' order by DataSaida ", Con);

                        }
                        else if (cbFiltro.Text == "Cliente")
                        {
                            _Adapter = new SqlDataAdapter("select convert(CHAR,dtSaida,101) as DataSaida,SaidaEstoqueCli.reposicao,Equipamento.descricao,Estoque.nrSerie,SaidaEstoqueCli.motivo,SaidaEstoqueCli.observacao, Cliente.Nome, usuario.nome as Usuario from SaidaEstoqueCli inner join Cliente on SaidaEstoqueCli.codigo_cliente = Cliente.codigo_cliente inner join Estoque on SaidaEstoqueCli.codigo_estoque = Estoque.codigo_estoque inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento inner join usuario on SaidaEstoqueCli.codigo_usuario = usuario.codigo_usuario where Cliente.Nome  LIKE'%" + txtPesquisa.Text + "%' order by DataSaida ", Con);
                        }
                        else if (cbFiltro.Text == "Equipamento")
                        {
                            _Adapter = new SqlDataAdapter("select convert(CHAR,dtSaida,101) as DataSaida,SaidaEstoqueCli.reposicao,Equipamento.descricao,Estoque.nrSerie,SaidaEstoqueCli.motivo,SaidaEstoqueCli.observacao, Cliente.Nome, usuario.nome as Usuario from SaidaEstoqueCli inner join Cliente on SaidaEstoqueCli.codigo_cliente = Cliente.codigo_cliente inner join Estoque on SaidaEstoqueCli.codigo_estoque = Estoque.codigo_estoque inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento inner join usuario on SaidaEstoqueCli.codigo_usuario = usuario.codigo_usuario where Equipamento.descricao  LIKE'%" + txtPesquisa.Text + "%' order by DataSaida ", Con);
                        }
                        else if (cbFiltro.Text == "Nº de Serie")
                        {
                            _Adapter = new SqlDataAdapter("select convert(CHAR,dtSaida,101) as DataSaida,SaidaEstoqueCli.reposicao,Equipamento.descricao,Estoque.nrSerie,SaidaEstoqueCli.motivo,SaidaEstoqueCli.observacao, Cliente.Nome, usuario.nome as Usuario from SaidaEstoqueCli inner join Cliente on SaidaEstoqueCli.codigo_cliente = Cliente.codigo_cliente inner join Estoque on SaidaEstoqueCli.codigo_estoque = Estoque.codigo_estoque inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento inner join usuario on SaidaEstoqueCli.codigo_usuario = usuario.codigo_usuario where  Estoque.nrSerie  LIKE'%" + txtPesquisa.Text + "%' order by DataSaida ", Con);
                        }
                        else if (cbFiltro.Text == "Motivo")
                        {
                            _Adapter = new SqlDataAdapter("select convert(CHAR,dtSaida,101) as DataSaida,SaidaEstoqueCli.reposicao,Equipamento.descricao,Estoque.nrSerie,SaidaEstoqueCli.motivo,SaidaEstoqueCli.observacao, Cliente.Nome, usuario.nome as Usuario from SaidaEstoqueCli inner join Cliente on SaidaEstoqueCli.codigo_cliente = Cliente.codigo_cliente inner join Estoque on SaidaEstoqueCli.codigo_estoque = Estoque.codigo_estoque inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento inner join usuario on SaidaEstoqueCli.codigo_usuario = usuario.codigo_usuario where SaidaEstoqueCli.motivo   LIKE'%" + txtPesquisa.Text + "%' order by DataSaida", Con);
                        }
                        else
                        {
                            _Adapter = new SqlDataAdapter("select convert(CHAR,dtSaida,101) as DataSaida,SaidaEstoqueCli.reposicao,Equipamento.descricao,Estoque.nrSerie,SaidaEstoqueCli.motivo,SaidaEstoqueCli.observacao, Cliente.Nome, usuario.nome as Usuario from SaidaEstoqueCli inner join Cliente on SaidaEstoqueCli.codigo_cliente = Cliente.codigo_cliente inner join Estoque on SaidaEstoqueCli.codigo_estoque = Estoque.codigo_estoque inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento inner join usuario on SaidaEstoqueCli.codigo_usuario = usuario.codigo_usuario where Usuario.nome  LIKE'%" + txtPesquisa.Text + "%' order by DataSaida", Con);
                        }
                        DataSet _ds = new DataSet();
                        _Adapter.Fill(_ds, "relatorioDataBinding");


                        dtgRelatorioEqpt.DataContext = _ds;

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
