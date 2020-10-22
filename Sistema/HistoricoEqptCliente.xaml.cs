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
    /// Interaction logic for HistoricoEqptCliente.xaml
    /// </summary>
    public partial class HistoricoEqptCliente : Window
    {
        string codigo_estoque;
        public HistoricoEqptCliente(string codigo_estoque)
        {
            this.codigo_estoque = codigo_estoque;
            InitializeComponent();
        }
        public void HistoricoPecas()
        {

            SqlConnection conexao = new SqlConnection();
            SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder();
            banco.DataSource = ".\\SQLEXPRESS";
            banco.InitialCatalog = "SISTEMA";
            banco.IntegratedSecurity = true;
            conexao.ConnectionString = banco.ConnectionString;

            conexao.Open();

            SqlDataAdapter _Adapter = new SqlDataAdapter("select EstoquePecas.dtSaida,Pecas.descricao, Fornecedor.Nome,PecasEqptCliente.qtdeSaida, PecasEqptCliente.observacao from PecasEqptCliente inner join EstoquePecas on PecasEqptCliente.codigo_estoquePecas = EstoquePecas.codigo_estoquePecas inner join Pecas on Pecas.codigo_pecas = EstoquePecas.codigo_pecas inner join Fornecedor on Fornecedor.codigo_fornecedor = EstoquePecas.codigo_fornecedor inner join EqptCliente on EqptCliente.codigo_eqptCliente = PecasEqptCliente.codigo_eqptCliente where EqptCliente.codigo_estoque = '"+codigo_estoque+"'group by EstoquePecas.dtSaida,Pecas.descricao, Fornecedor.Nome,PecasEqptCliente.qtdeSaida, PecasEqptCliente.observacao", conexao);

            DataSet _ds = new DataSet();
            _Adapter.Fill(_ds, "historicoPecasDataBinding");


            dtgHistoricoPecas.DataContext = _ds;

            // Fecha a conexão
            conexao.Close();
        }

        private void dtgHistoricoPecas_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.HistoricoPecas();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
