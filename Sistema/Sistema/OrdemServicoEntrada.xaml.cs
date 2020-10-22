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
    /// Interaction logic for OrdemServicoEntrada.xaml
    /// </summary>
    public partial class OrdemServicoEntrada : Window
    {
        string codigo_cliente;
        public void CarregarClientes()
        {

            SqlConnection conexao = new SqlConnection();
            SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder();
            banco.DataSource = ".\\SQLEXPRESS";
            banco.InitialCatalog = "SISTEMA";
            banco.IntegratedSecurity = true;
            conexao.ConnectionString = banco.ConnectionString;

            conexao.Open();

            SqlDataAdapter _Adapter = new SqlDataAdapter("Select * from Cliente", conexao);

            DataTable ds = new DataTable();
            _Adapter.Fill(ds);

            for (int i = 0; i < ds.Rows.Count; i++)
            {
                
                cbCliente.Items.Add(ds.Rows[i]["Nome"]);

            }

            // Fecha a conexão
            conexao.Close();
        }
        private void cbCliente_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.CarregarClientes();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public OrdemServicoEntrada()
        {
            InitializeComponent();

            Random random = new Random();
            int i = random.Next(0, 1000);
            txtCodigoOs.Text = "OS"+i.ToString();
            DateTime data = DateTime.Now;
            dpDataEntrada.Text = data + "";
            
            
           
            
        }

        private void cbCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

            cbEqpt.IsEnabled = true;
            cbEqpt.Items.Clear();
            SqlConnection conexao = new SqlConnection();
            SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder();
            banco.DataSource = ".\\SQLEXPRESS";
            banco.InitialCatalog = "SISTEMA";
            banco.IntegratedSecurity = true;
            conexao.ConnectionString = banco.ConnectionString;

            conexao.Open();


            SqlDataAdapter _Adapter = new SqlDataAdapter("select Cliente.codigo_cliente, EqptCliente.codigo_eqptCliente as Codigo,Equipamento.descricao as Equipamento, Estoque.nrSerie as nrSerie, Estoque.modelo as Modelo from EqptCliente inner join Estoque on  Estoque.codigo_estoque = EqptCliente.codigo_estoque inner join Equipamento on Equipamento.codigo_equipamento = Estoque.codigo_equipamento inner join Cliente on Cliente.codigo_cliente = EqptCliente.codigo_cliente where Cliente.Nome ='" + cbCliente.SelectedValue.ToString() + "'", conexao);

            DataTable ds = new DataTable();
            _Adapter.Fill(ds);

            for (int i = 0; i < ds.Rows.Count; i++)
            {
                
                cbEqpt.Items.Add(ds.Rows[i]["Equipamento"]);
            }




            // Fecha a conexão
            conexao.Close();

            

        }

        private void cbEqpt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            txtDefeito.IsEnabled = true;
            txtObs.IsEnabled = true;
            SqlConnection conexao = new SqlConnection();
            SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder();
            banco.DataSource = ".\\SQLEXPRESS";
            banco.InitialCatalog = "SISTEMA";
            banco.IntegratedSecurity = true;
            conexao.ConnectionString = banco.ConnectionString;

            conexao.Open();


            SqlDataAdapter _Adapter = new SqlDataAdapter("select EqptCliente.codigo_eqptCliente as Codigo,Equipamento.descricao as Equipamento, Estoque.nrSerie as nrSerie, Estoque.modelo as Modelo, Fornecedor.Nome as Fornecedor from EqptCliente inner join Estoque on  Estoque.codigo_estoque = EqptCliente.codigo_estoque  inner join Fornecedor on Fornecedor.codigo_fornecedor = Estoque.codigo_fornecedor inner join Equipamento on Equipamento.codigo_equipamento = Estoque.codigo_equipamento where descricao = '" + cbEqpt.SelectedValue.ToString() + "'", conexao);

            DataTable ds = new DataTable();
            _Adapter.Fill(ds);

            for (int i = 0; i < ds.Rows.Count; i++)
            {

               txtNumeroSerie.Text = ds.Rows[i]["nrSerie"]+"";
               txtModelo.Text = ds.Rows[i]["Modelo"]+"";
               txtMarca.Text = ds.Rows[i]["Fornecedor"] + "";
                
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

       
        
    }
}
