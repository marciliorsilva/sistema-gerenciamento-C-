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
            if (modo == "AddEqptCliente")
            {
                btListaSolicitacao.IsEnabled = false;
                btIncluir.IsEnabled = false;
    
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
            

            SqlDataAdapter _Adapter = new SqlDataAdapter("select Equipamento.descricao as Equipamento, COUNT(Estoque.situacao) as Quantidade, Equipamento.precoVenda as PreçoDeVenda,Estoque.localizacao as Localização, Fornecedor.Nome as Fornecedor  from Estoque inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento  inner join Fornecedor on Estoque.codigo_fornecedor=Fornecedor.codigo_fornecedor where Estoque.situacao='Estoque' group by Equipamento.descricao, Equipamento.precoVenda, Estoque.localizacao, Fornecedor.Nome", conexao);
           
           
            DataSet _ds = new DataSet();
            _Adapter.Fill(_ds, "estoqueDataBinding");
            
                     
            
            dtgEstoque.DataContext = _ds;

            
            // Fecha a conexão
            conexao.Close();
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
            IncluirConsultarEstoque incluir = new IncluirConsultarEstoque(modo,codigo_estoque,codigo_cliente);
            incluir.ShowDialog();
            this.VinculaDados();
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            
            ListaConsultaEqptEstoque consultar = new ListaConsultaEqptEstoque(nome_equipamento, modo, codigo_cliente);
            consultar.ShowDialog();
            this.VinculaDados();
            if (modo == "AddEqptCliente")
            {
                Close();
            }
        }

       

    }
}
