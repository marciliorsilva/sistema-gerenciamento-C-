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
    /// Interaction logic for ListaSolicitacao.xaml
    /// </summary>
    public partial class ListaSolicitacao : Window
    {
        string codigo_entrada;
        string Fornecedor;
        string Equipamento;
        string Quantidade;
        
        public ListaSolicitacao()
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

            SqlDataAdapter _Adapter = new SqlDataAdapter("select Entrada.codigo_entrada as Codigo, Entrada.notaFiscal as NotaFiscal, Entrada.dtPedido as Data,Fornecedor.Nome as Fornecedor,Equipamento.descricao as Equipamento,entradaEqpt.quantidade as Quantidade,entradaEqpt.observacao as Observação,entradaEqpt.situacao as Situação from Entrada inner join entradaEqpt on Entrada.codigo_entrada = entradaEqpt.numeroPedido inner join Fornecedor on Entrada.codigo_fornecedor = Fornecedor.codigo_fornecedor inner join Equipamento on entradaEqpt.codigo_equipamento = Equipamento.codigo_equipamento where situacao='Aguardando Chegada'", conexao);

            DataSet _ds = new DataSet();
            _Adapter.Fill(_ds, "entradaDataBinding");


            dtgEntrada.DataContext = _ds;

            // Fecha a conexão
            conexao.Close();
        }
        private void dtgEntrada_Loaded(object sender, RoutedEventArgs e)
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
        private void dtgEntrada_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView _dv = dtgEntrada.CurrentCell.Item as DataRowView;

                if (_dv != null)
                {

                    codigo_entrada = _dv.Row[0].ToString();
                    Fornecedor = _dv.Row[3].ToString();
                    Equipamento = _dv.Row[4].ToString();
                    Quantidade = _dv.Row[5].ToString();

                    btCadastrarEqpt.IsEnabled = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btCadastrarEqpt_Click(object sender, RoutedEventArgs e)
        {

            IncluirListaSolicitacaoEstoque estoque = new IncluirListaSolicitacaoEstoque(Fornecedor, Equipamento, Quantidade, codigo_entrada);
            estoque.ShowDialog();
            this.VinculaDados();
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
