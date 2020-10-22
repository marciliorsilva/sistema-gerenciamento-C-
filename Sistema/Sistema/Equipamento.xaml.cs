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
    /// Interaction logic for Equipamento.xaml
    /// </summary>
    public partial class Equipamento : Window
    {
        string codigo_equipamento;
        string modo;
        public Equipamento()
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

            SqlDataAdapter _Adapter = new SqlDataAdapter("select Equipamento.*, categoriaEqpt.descricao as Categoria from Equipamento inner join  categoriaEqpt on Equipamento.codigo_categoria = categoriaEqpt.codigo_categoria", conexao);

            DataSet _ds = new DataSet();
            _Adapter.Fill(_ds, "equipamentoDataBinding");


            dtgEquipamento.DataContext = _ds;

            // Fecha a conexão
            conexao.Close();
        }

        private void dtgEquipamento_Loaded(object sender, RoutedEventArgs e)
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

        private void dtgEquipamento_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView _dv = dtgEquipamento.CurrentCell.Item as DataRowView;

                if (_dv != null)
                {
                    codigo_equipamento = _dv.Row[0].ToString();
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
            EquipamentoConsulta incluir = new EquipamentoConsulta(modo, codigo_equipamento);
            incluir.ShowDialog();
            this.VinculaDados();

        }
        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            modo = "Consultar";
            EquipamentoConsulta consultar = new EquipamentoConsulta(modo, codigo_equipamento);
            btConsultar.IsEnabled = false;
            btExcluir.IsEnabled = false;
            consultar.ShowDialog();


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
                string _Deletar = @"Delete from Equipamento
                                  Where codigo_equipamento = " + Convert.ToInt32(codigo_equipamento);

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
                MessageBox.Show("Erro no banco:"+ex.ToString());
                btConsultar.IsEnabled = false;
                btExcluir.IsEnabled = false;
            }
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }

    }
}
