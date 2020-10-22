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
    /// Interaction logic for Estoque.xaml
    /// </summary>
    public partial class Estoque : Window
    {
        string modo;
        string codigo_estoque;
        string nome_equipamento;
        string codigo_cliente;
        public Estoque(string modo, string codigo_cliente)
        {
            this.modo = modo;
            this.codigo_cliente = codigo_cliente;
            InitializeComponent();
           
        }
        public void VinculaDados()
        {

            SqlConnection conexao = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


            try
            {
                conexao.Open();
                SqlDataAdapter _Adapter = new SqlDataAdapter("select Equipamento.descricao as Equipamento, COUNT(Estoque.codigo_equipamento) as Quantidade, Fornecedor.Nome as Fornecedor  from Estoque inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento  inner join Fornecedor on Estoque.codigo_fornecedor=Fornecedor.codigo_fornecedor where Estoque.situacao2='EntradaEstoque' group by Equipamento.descricao, Fornecedor.Nome", conexao);


                DataSet _ds = new DataSet();
                _Adapter.Fill(_ds, "estoqueDataBinding");



                dtgEstoque.DataContext = _ds;


                // Fecha a conexão
                conexao.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                conexao.Close();
            }
            

           
        }

        private void dtgEstoque_Loaded(object sender, RoutedEventArgs e)
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

        private void dtgEstoque_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView _dv = dtgEstoque.CurrentCell.Item as DataRowView;

                if (_dv != null)
                {
                    
                    nome_equipamento = _dv.Row[0].ToString();
                                  
                     btConsultar.IsEnabled = true;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btListaSolicitacao_Click(object sender, RoutedEventArgs e)
        {
            ListaSolicitacao lista = new ListaSolicitacao();
            lista.ShowDialog();
            this.VinculaDados();
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            modo = "Incluir";
            IncluirConsultarEstoque incluir = new IncluirConsultarEstoque(modo,codigo_estoque);
            incluir.ShowDialog();
            this.VinculaDados();
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            modo = "Consultar";
            ListaConsultaEqptEstoque consultar = new ListaConsultaEqptEstoque(nome_equipamento, modo, codigo_cliente);
            consultar.ShowDialog();
            this.VinculaDados();
           
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
                    SqlDataAdapter _Adapter = new SqlDataAdapter("select Equipamento.descricao as Equipamento, COUNT(Estoque.codigo_equipamento) as Quantidade, Fornecedor.Nome as Fornecedor  from Estoque inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento  inner join Fornecedor on Estoque.codigo_fornecedor=Fornecedor.codigo_fornecedor where Estoque.situacao2='EntradaEstoque' group by Equipamento.descricao, Fornecedor.Nome", Con);

                    DataSet _ds = new DataSet();
                    _Adapter.Fill(_ds, "estoqueDataBinding");


                    dtgEstoque.DataContext = _ds;

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

                    SqlDataAdapter _Adapter ;
                    if (cbFiltro.Text == "Equipamento")
                    {
                        _Adapter = new SqlDataAdapter("select Equipamento.descricao as Equipamento, COUNT(Estoque.codigo_equipamento) as Quantidade, Fornecedor.Nome as Fornecedor  from Estoque inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento  inner join Fornecedor on Estoque.codigo_fornecedor=Fornecedor.codigo_fornecedor where Estoque.situacao2='EntradaEstoque' and Equipamento.descricao LIKE'%" + txtPesquisa.Text + "%' group by Equipamento.descricao, Fornecedor.Nome ", Con);

                    }
                    else 
                    {
                        _Adapter = new SqlDataAdapter("select Equipamento.descricao as Equipamento, COUNT(Estoque.codigo_equipamento) as Quantidade, Fornecedor.Nome as Fornecedor  from Estoque inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento  inner join Fornecedor on Estoque.codigo_fornecedor=Fornecedor.codigo_fornecedor where Estoque.situacao2='EntradaEstoque' and Fornecedor.Nome LIKE'%" + txtPesquisa.Text + "%' group by Equipamento.descricao, Fornecedor.Nome ", Con);
                    }
                   
                    DataSet _ds = new DataSet();
                    _Adapter.Fill(_ds, "estoqueDataBinding");


                    dtgEstoque.DataContext = _ds;

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
