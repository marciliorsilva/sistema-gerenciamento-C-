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

            SqlConnection conexao = new SqlConnection();
            SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder();
            banco.DataSource = ".\\SQLEXPRESS";
            banco.InitialCatalog = "SISTEMA";
            banco.IntegratedSecurity = true;
            conexao.ConnectionString = banco.ConnectionString;

            conexao.Open();


            SqlDataAdapter _Adapter = new SqlDataAdapter("select Pecas.descricao as Pecas, COUNT(EstoquePecas.situacao) as Quantidade, EstoquePecas.localizacao as Localização, Fornecedor.Nome as Fornecedor  from EstoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas  inner join Fornecedor on EstoquePecas.codigo_fornecedor=Fornecedor.codigo_fornecedor where EstoquePecas.situacao='Estoque' group by Pecas.descricao, EstoquePecas.localizacao, Fornecedor.Nome", conexao);


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

                    nome_peca = _dv.Row[0].ToString();

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
            ListaConsultaPecasEstoque consultar = new ListaConsultaPecasEstoque(nome_peca, modo);
            consultar.ShowDialog();
            this.VinculaDados();
            
        }
    }
}
