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
    /// Interaction logic for Fornecedor.xaml
    /// </summary>
    public partial class Fornecedor : Window
    {
        string codigo_fornecedor;
        string modo;
        public Fornecedor()
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

            SqlDataAdapter _Adapter = new SqlDataAdapter("Select * from Fornecedor", conexao);

            DataSet _ds = new DataSet();
            _Adapter.Fill(_ds, "fornecedorDataBinding");


            dtgFornecedor.DataContext = _ds;

            // Fecha a conexão
            conexao.Close();
        }
        private void dtgFornecedor_Loaded(object sender, RoutedEventArgs e)
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

        private void dtgFornecedor_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView _dv = dtgFornecedor.CurrentCell.Item as DataRowView;

                if (_dv != null)
                {
                    codigo_fornecedor = _dv.Row[0].ToString();
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
            FornecedorConsulta fornecedorConsultar = new FornecedorConsulta(modo, codigo_fornecedor);
            fornecedorConsultar.ShowDialog();

            this.VinculaDados();

        }
        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            modo = "Consultar";
            FornecedorConsulta fornecedorConsultar = new FornecedorConsulta(modo, codigo_fornecedor);
            btExcluir.IsEnabled = false;
            btConsultar.IsEnabled = false;
            fornecedorConsultar.ShowDialog();


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
                string _Deletar = @"Delete from Fornecedor
                                  Where codigo_fornecedor = " + Convert.ToInt32(codigo_fornecedor);

                // inicializa o comando e a conexão
                SqlCommand _cmdDeletar = new SqlCommand(_Deletar, conexao);
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
                MessageBox.Show("Não é possivel excluir, pois existem 1 ou mais cadastros utilizando esse Fornecedor");
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
          if(cbFiltro.Text == "Tipo de Busca:")
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

              SqlDataAdapter _Adapter = new SqlDataAdapter("Select * from Fornecedor", conexao);

              DataSet _ds = new DataSet();
              _Adapter.Fill(_ds, "fornecedorDataBinding");


              dtgFornecedor.DataContext = _ds;

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

                SqlDataAdapter _Adapter = new SqlDataAdapter("Select * from Fornecedor where "+cbFiltro.Text+" LIKE'%"+ txtPesquisa.Text +"%'", conexao);

                DataSet _ds = new DataSet();
                _Adapter.Fill(_ds, "fornecedorDataBinding");


                dtgFornecedor.DataContext = _ds;

                // Fecha a conexão
                conexao.Close();


            }
            
        }

       
    }
}
