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
    /// Interaction logic for EstoquePecas.xaml
    /// </summary>
    public partial class EstoquePecas : Window
    {
        string modo;
        string nome_peca;
        string codigo_estoquePecas;
        public EstoquePecas()
        {
            
            InitializeComponent();
        }
        public void VinculaDados()
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


            SqlDataAdapter _Adapter = new SqlDataAdapter("select estoquePecas.*, convert(CHAR,dtEntrada,101) as DataEntrada,Pecas.descricao as Pecas, Fornecedor.Nome as Fornecedor  from EstoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas  inner join Fornecedor on EstoquePecas.codigo_fornecedor=Fornecedor.codigo_fornecedor where quantidade > 0", conexao);


            DataSet _ds = new DataSet();
            _Adapter.Fill(_ds, "estoquePecasDataBinding");



            dtgEstoquePecas.DataContext = _ds;


            // Fecha a conexão
            conexao.Close();
        }

        

        private void dtgEstoquePecas_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.VinculaDados();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dtgEstoquePecas_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView _dv = dtgEstoquePecas.CurrentCell.Item as DataRowView;

                if (_dv != null)
                {

                    codigo_estoquePecas = _dv.Row[0].ToString();

                    btConsultar.IsEnabled = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            modo = "Incluir";
            IncluirConsultarEstoquePeca incluir = new IncluirConsultarEstoquePeca(modo, codigo_estoquePecas);
            incluir.ShowDialog();
            this.VinculaDados();
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            modo = "Consultar";
            IncluirConsultarEstoquePeca consultar = new IncluirConsultarEstoquePeca(modo, codigo_estoquePecas);
             consultar.ShowDialog();
            this.VinculaDados();
            
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
            else if (txtPesquisa.Text == "")
            {
                SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


                try
                {
                    Con.Open();
                    SqlDataAdapter _Adapter = new SqlDataAdapter("select estoquePecas.*, convert(CHAR,dtEntrada,101) as DataEntrada,Pecas.descricao as Pecas, Fornecedor.Nome as Fornecedor  from EstoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas  inner join Fornecedor on EstoquePecas.codigo_fornecedor=Fornecedor.codigo_fornecedor where quantidade > 0", Con);

                    DataSet _ds = new DataSet();
                    _Adapter.Fill(_ds, "estoquePecasDataBinding");


                    dtgEstoquePecas.DataContext = _ds;

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
                        _Adapter = new SqlDataAdapter("select estoquePecas.*, convert(CHAR,dtEntrada,101) as DataEntrada,Pecas.descricao as Pecas, Fornecedor.Nome as Fornecedor  from EstoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas  inner join Fornecedor on EstoquePecas.codigo_fornecedor=Fornecedor.codigo_fornecedor where quantidade > 0 and estoquePecas.dtEntrada LIKE'%" + txtPesquisa.Text + "%'", Con);

                    }
                    else if (cbFiltro.Text == "Peças")
                    {
                        _Adapter = new SqlDataAdapter("select estoquePecas.*, convert(CHAR,dtEntrada,101) as DataEntrada,Pecas.descricao as Pecas, Fornecedor.Nome as Fornecedor  from EstoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas  inner join Fornecedor on EstoquePecas.codigo_fornecedor=Fornecedor.codigo_fornecedor where quantidade > 0 and Pecas.descricao LIKE'%" + txtPesquisa.Text + "%'", Con);
                    }
                    else if (cbFiltro.Text == "Fornecedor")
                    {
                        _Adapter = new SqlDataAdapter("select estoquePecas.*, convert(CHAR,dtEntrada,101) as DataEntrada,Pecas.descricao as Pecas, Fornecedor.Nome as Fornecedor  from EstoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas  inner join Fornecedor on EstoquePecas.codigo_fornecedor=Fornecedor.codigo_fornecedor where quantidade > 0 and Fornecedor.Nome LIKE'%" + txtPesquisa.Text + "%'", Con);
                    }
                    else 
                    {
                        _Adapter = new SqlDataAdapter("select estoquePecas.*, convert(CHAR,dtEntrada,101) as DataEntrada,Pecas.descricao as Pecas, Fornecedor.Nome as Fornecedor  from EstoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas  inner join Fornecedor on EstoquePecas.codigo_fornecedor=Fornecedor.codigo_fornecedor where quantidade > 0 and localizacao LIKE'%" + txtPesquisa.Text + "%'", Con);
                    }

                    DataSet _ds = new DataSet();
                    _Adapter.Fill(_ds, "estoquePecasDataBinding");


                    dtgEstoquePecas.DataContext = _ds;

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
