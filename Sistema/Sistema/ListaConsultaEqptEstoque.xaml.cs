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
    /// Interaction logic for ListaConsultaEqptEstoque.xaml
    /// </summary>
    public partial class ListaConsultaEqptEstoque : Window
    {
        string nome_equipamento;
        string codigo_estoque;
        string codigo_cliente;
        string modo;
        public ListaConsultaEqptEstoque(string nome_equipamento, string modo,string codigo_cliente)
        {
            this.nome_equipamento = nome_equipamento;
            this.modo = modo;
            this.codigo_cliente = codigo_cliente;
            InitializeComponent();

            if (modo == "AddEqptCliente")
            {
                btAddEqptCli.Opacity = 1;
                btEditar.IsEnabled = false;
            }
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


            SqlDataAdapter _Adapter = new SqlDataAdapter("select Estoque.*,Equipamento.descricao from Estoque inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento where descricao='" + nome_equipamento + "'", conexao);
            

            DataSet _ds = new DataSet();
            _Adapter.Fill(_ds, "listaEqptDataBinding");



            dtgListaEqpt.DataContext = _ds;


            // Fecha a conexão
            conexao.Close();
        }

        private void dtgListaEqpt_Loaded(object sender, RoutedEventArgs e)
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

        private void dtgListaEqpt_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView _dv = dtgListaEqpt.CurrentCell.Item as DataRowView;

                if (_dv != null)
                {
                    codigo_estoque = _dv.Row[0].ToString();
                    if (modo == "AddEqptCliente")
                    {
                        btEditar.IsEnabled = false;
                    }
                    else
                    {
                        btEditar.IsEnabled = true;
                    }
                }
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

        private void btEditar_Click(object sender, RoutedEventArgs e)
        {
            modo="Editar";
            IncluirConsultarEstoque editar = new IncluirConsultarEstoque(modo, codigo_estoque, codigo_cliente);
            editar.ShowDialog();
        }

        private void btAddEqptCli_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conexao = new SqlConnection();
            SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder();
            banco.DataSource = ".\\SQLEXPRESS";
            banco.InitialCatalog = "SISTEMA";
            banco.IntegratedSecurity = true;
            conexao.ConnectionString = banco.ConnectionString;

            conexao.Open();
            string sql;
             sql = "insert into EqptCliente(codigo_estoque, codigo_cliente) values('"+codigo_estoque+"','"+codigo_cliente+"')";

             string sql2 = @"Update Estoque Set situacao ='SaidaEstoque' where codigo_estoque = " + codigo_estoque;

            MessageBox.Show("Adicionado com Sucesso!");
            SqlCommand codigo = new SqlCommand(sql, conexao);
            codigo.ExecuteNonQuery();
            SqlCommand codigo2 = new SqlCommand(sql2, conexao);
            codigo2.ExecuteNonQuery();
            conexao.Close();
            Close();
        }
    }
}
