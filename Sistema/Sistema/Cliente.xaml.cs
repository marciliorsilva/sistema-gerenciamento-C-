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
    /// Interaction logic for Cliente.xaml
    /// </summary>
    public partial class Cliente : Window
    {
        string codigo_cliente;
        string modo;
        public Cliente()
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

            SqlDataAdapter _Adapter = new SqlDataAdapter("Select * from Cliente", conexao);

            DataSet _ds = new DataSet();
            _Adapter.Fill(_ds, "clienteDataBinding");


            dtgCliente.DataContext = _ds;

            // Fecha a conexão
            conexao.Close();
        }

        private void dtgCliente_Loaded(object sender, RoutedEventArgs e)
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

        private void dtgCliente_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView _dv = dtgCliente.CurrentCell.Item as DataRowView;

                if (_dv != null)
                {
                    codigo_cliente = _dv.Row[0].ToString();
                    btConsultar.IsEnabled = true;
                    btExcluir.IsEnabled = true;
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
            ClienteConsulta clienteConsulta = new ClienteConsulta(modo, codigo_cliente);
            clienteConsulta.ShowDialog();
            this.VinculaDados();
        }


        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            modo = "Consultar";
            ClienteConsulta clienteConsulta = new ClienteConsulta(modo, codigo_cliente);
            clienteConsulta.ShowDialog();
            btExcluir.IsEnabled = false;
            btConsultar.IsEnabled = false;
            this.VinculaDados();
            
        }

        private void btExcluir_Click(object sender, RoutedEventArgs e)
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

                // Command String
                string _Deletar = @"Delete from Cliente
                                  Where codigo_cliente = " + Convert.ToInt32(codigo_cliente);
                string DeletarCliEqpt = @"Delete from EqptCliente
                                  Where codigo_cliente = " + Convert.ToInt32(codigo_cliente);

                // inicializa o comando e a conexão
                SqlCommand _cmdDeletar = new SqlCommand(_Deletar, conexao);
                SqlCommand _cmdDeletarEqpt = new SqlCommand(DeletarCliEqpt, conexao);
                // executa o comando
                _cmdDeletar.ExecuteNonQuery();

                MessageBox.Show("Excluido com Sucesso !");
                btConsultar.IsEnabled = false;
                btExcluir.IsEnabled = false;
                this.VinculaDados();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não é possivel excluir, pois existem 1 ou mais cadastros utilizando esse Cliente !");
                btConsultar.IsEnabled = false;
                btExcluir.IsEnabled = false;
            }
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void txtPesquisa_SelectionChanged(object sender, RoutedEventArgs e)
        {
            
            if (cbFiltro.Text == "Tipo de Busca:" && txtPesquisa.Text!="")
            {
                txtPesquisa.Text = string.Empty;
                MessageBox.Show("Selecione um tipo de Busca.");
               
                

            }
            else if (txtPesquisa.Text == "")
            {
                SqlConnection conexao = new SqlConnection();
                SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder();
                banco.DataSource = ".\\SQLEXPRESS";
                banco.InitialCatalog = "SISTEMA";
                banco.IntegratedSecurity = true;
                conexao.ConnectionString = banco.ConnectionString;

                conexao.Open();

                SqlDataAdapter _Adapter = new SqlDataAdapter("Select * from Cliente", conexao);

                DataSet _ds = new DataSet();
                _Adapter.Fill(_ds, "clienteDataBinding");


                dtgCliente.DataContext = _ds;

                // Fecha a conexão
                conexao.Close();
            }
            else
            {

                SqlConnection conexao = new SqlConnection();
                SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder();
                banco.DataSource = ".\\SQLEXPRESS";
                banco.InitialCatalog = "SISTEMA";
                banco.IntegratedSecurity = true;
                conexao.ConnectionString = banco.ConnectionString;

                conexao.Open();
                SqlDataAdapter _Adapter;
                if (cbFiltro.Text == "CNPJ/CPF")
                {
                    _Adapter = new SqlDataAdapter("Select * from Cliente where cpfCnpj  LIKE'%" + txtPesquisa.Text + "%'", conexao);

                }
                else
                {
                    _Adapter = new SqlDataAdapter("Select * from Cliente where " + cbFiltro.Text + " LIKE'%" + txtPesquisa.Text + "%'", conexao);
                }
                DataSet _ds = new DataSet();
                _Adapter.Fill(_ds, "clienteDataBinding");


                dtgCliente.DataContext = _ds;

                // Fecha a conexão
                conexao.Close();


            }
        }

    }
}
