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

            Title = "MH acesso - GE1.0 - Estoque de Equipamento | Lista do Equipameto - "+ nome_equipamento;
            
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


            SqlDataAdapter _Adapter = new SqlDataAdapter("select Estoque.*,Equipamento.descricao from Estoque inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento where descricao='" + nome_equipamento + "'AND Estoque.situacao2='EntradaEstoque'", conexao);
            

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
                
                    btEditar.IsEnabled = true;
                    
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
            IncluirConsultarEstoque editar = new IncluirConsultarEstoque(modo, codigo_estoque);
            editar.ShowDialog();
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
                    SqlDataAdapter _Adapter = new SqlDataAdapter("select Estoque.*,Equipamento.descricao from Estoque inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento where descricao='" + nome_equipamento + "' AND Estoque.situacao2='EntradaEstoque'", Con);

                    DataSet _ds = new DataSet();
                    _Adapter.Fill(_ds, "listaEqptDataBinding");


                    dtgListaEqpt.DataContext = _ds;

                    // Fecha a conexão
                    Con.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Não foi possivel conectar com o Banco "+ex, "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    if (cbFiltro.Text == "Nº de Serie")
                    {
                        _Adapter = new SqlDataAdapter("select Estoque.*,Equipamento.descricao from Estoque inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento where descricao='" + nome_equipamento + "' AND Estoque.situacao2='EntradaEstoque' AND Estoque.nrSerie LIKE'%" + txtPesquisa.Text + "%' ", Con);
                   
                    }
                    else if (cbFiltro.Text == "Modelo")
                    {
                        _Adapter = new SqlDataAdapter("select Estoque.*,Equipamento.descricao from Estoque inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento where descricao='" + nome_equipamento + "' AND Estoque.situacao2='EntradaEstoque' AND Estoque.modelo LIKE'%" + txtPesquisa.Text + "%'", Con);
                    }
                    else 
                    {
                        _Adapter = new SqlDataAdapter("select Estoque.*,Equipamento.descricao from Estoque inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento where descricao='" + nome_equipamento + "' AND Estoque.situacao2='EntradaEstoque' AND Estoque.localizacao LIKE'%" + txtPesquisa.Text + "%'", Con);

                    }
                   

                                                       
                    
                     DataSet _ds = new DataSet();
                    _Adapter.Fill(_ds, "listaEqptDataBinding");


                    dtgListaEqpt.DataContext = _ds;

                    // Fecha a conexão
                    Con.Close();


                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Não foi possivel conectar com o Banco"+ex, "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                    Con.Close();
                }
            }
        }
    }
}
