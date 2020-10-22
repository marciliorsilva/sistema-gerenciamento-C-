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
    /// Interaction logic for EstoqueSaida.xaml
    /// </summary>
    public partial class EstoqueSaida : Window
    {
        string codigo_se;
        string modo;
        string nome_usuario;

        public EstoqueSaida(string nome_usuario)
        {
            this.nome_usuario = nome_usuario;
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


            SqlDataAdapter _Adapter = new SqlDataAdapter("select SaidaEstoqueCli.codigo_se, convert(CHAR,dtSaida,101) as DataSaida,SaidaEstoqueCli.reposicao,Equipamento.descricao,Estoque.nrSerie,motivo,SaidaEstoqueCli.observacao, Cliente.Nome, usuario.nome as Usuario from SaidaEstoqueCli inner join Cliente on SaidaEstoqueCli.codigo_cliente = Cliente.codigo_cliente inner join Estoque on SaidaEstoqueCli.codigo_estoque = Estoque.codigo_estoque inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento inner join usuario on SaidaEstoqueCli.codigo_usuario = usuario.codigo_usuario where reposicao != 'Sim' order by DataSaida", conexao);


            DataSet _ds = new DataSet();
            _Adapter.Fill(_ds, "saidaEstoqueDataBinding");

            dtgSaidaEstoque.DataContext = _ds;


            // Fecha a conexão
            conexao.Close();
        }

        private void dtgSaidaEstoque_Loaded(object sender, RoutedEventArgs e)
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

        private void dtgSaidaEstoque_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView _dv = dtgSaidaEstoque.CurrentCell.Item as DataRowView;

                if (_dv != null)
                {

                    codigo_se = _dv.Row[0].ToString();

                    btConsultar.IsEnabled = true;

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
            IncluirConsultarEstoqueSaida incluir = new IncluirConsultarEstoqueSaida(modo, codigo_se, nome_usuario);
            incluir.ShowDialog();
            this.VinculaDados();
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            modo = "Consultar";
            IncluirConsultarEstoqueSaida incluir = new IncluirConsultarEstoqueSaida(modo, codigo_se, nome_usuario);
            incluir.ShowDialog();
            this.VinculaDados();
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
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
                    SqlDataAdapter _Adapter = new SqlDataAdapter("select SaidaEstoqueCli.codigo_se, convert(CHAR,dtSaida,101) as DataSaida,SaidaEstoqueCli.reposicao,Equipamento.descricao,Estoque.nrSerie,motivo,SaidaEstoqueCli.observacao, Cliente.Nome, usuario.nome as Usuario from SaidaEstoqueCli inner join Cliente on SaidaEstoqueCli.codigo_cliente = Cliente.codigo_cliente inner join Estoque on SaidaEstoqueCli.codigo_estoque = Estoque.codigo_estoque inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento inner join usuario on SaidaEstoqueCli.codigo_usuario = usuario.codigo_usuario where reposicao != 'Sim' order by DataSaida", Con);

                    DataSet _ds = new DataSet();
                    _Adapter.Fill(_ds, "saidaEstoqueDataBinding");


                    dtgSaidaEstoque.DataContext = _ds;

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

                    SqlDataAdapter _Adapter;
                    if (cbFiltro.Text == "Data")
                    {
                        _Adapter = new SqlDataAdapter("select SaidaEstoqueCli.codigo_se, convert(CHAR,SaidaEstoqueCli.dtSaida,101) as DataSaida,SaidaEstoqueCli.reposicao,Equipamento.descricao,Estoque.nrSerie,motivo,SaidaEstoqueCli.observacao, Cliente.Nome, usuario.nome as Usuario from SaidaEstoqueCli inner join Cliente on SaidaEstoqueCli.codigo_cliente = Cliente.codigo_cliente inner join Estoque on SaidaEstoqueCli.codigo_estoque = Estoque.codigo_estoque inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento inner join usuario on SaidaEstoqueCli.codigo_usuario = usuario.codigo_usuario where reposicao != 'Sim' and convert(CHAR,SaidaEstoqueCli.dtSaida,101) LIKE'%" + txtPesquisa.Text + "%' order by DataSaida", Con);

                    }
                    else if (cbFiltro.Text == "Equipamento")
                    {
                        _Adapter = new SqlDataAdapter("select SaidaEstoqueCli.codigo_se, convert(CHAR,dtSaida,101) as DataSaida,SaidaEstoqueCli.reposicao,Equipamento.descricao,Estoque.nrSerie,motivo,SaidaEstoqueCli.observacao, Cliente.Nome, usuario.nome as Usuario from SaidaEstoqueCli inner join Cliente on SaidaEstoqueCli.codigo_cliente = Cliente.codigo_cliente inner join Estoque on SaidaEstoqueCli.codigo_estoque = Estoque.codigo_estoque inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento inner join usuario on SaidaEstoqueCli.codigo_usuario = usuario.codigo_usuario where reposicao != 'Sim' and Equipamento.descricao LIKE'%" + txtPesquisa.Text + "%' order by DataSaida", Con);
                    }
                    else if (cbFiltro.Text == "Nº de Série")
                    {
                        _Adapter = new SqlDataAdapter("select SaidaEstoqueCli.codigo_se, convert(CHAR,dtSaida,101) as DataSaida,SaidaEstoqueCli.reposicao,Equipamento.descricao,Estoque.nrSerie,motivo,SaidaEstoqueCli.observacao, Cliente.Nome, usuario.nome as Usuario from SaidaEstoqueCli inner join Cliente on SaidaEstoqueCli.codigo_cliente = Cliente.codigo_cliente inner join Estoque on SaidaEstoqueCli.codigo_estoque = Estoque.codigo_estoque inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento inner join usuario on SaidaEstoqueCli.codigo_usuario = usuario.codigo_usuario where reposicao != 'Sim' and Estoque.nrSerie LIKE'%" + txtPesquisa.Text + "%' order by DataSaida", Con);
                    }
                    else if (cbFiltro.Text == "Motivo")
                    {
                        _Adapter = new SqlDataAdapter("select SaidaEstoqueCli.codigo_se, convert(CHAR,dtSaida,101) as DataSaida,SaidaEstoqueCli.reposicao,Equipamento.descricao,Estoque.nrSerie,motivo,SaidaEstoqueCli.observacao, Cliente.Nome, usuario.nome as Usuario from SaidaEstoqueCli inner join Cliente on SaidaEstoqueCli.codigo_cliente = Cliente.codigo_cliente inner join Estoque on SaidaEstoqueCli.codigo_estoque = Estoque.codigo_estoque inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento inner join usuario on SaidaEstoqueCli.codigo_usuario = usuario.codigo_usuario where reposicao != 'Sim' and motivo LIKE'%" + txtPesquisa.Text + "%' order by DataSaida", Con);
                    }
                    else if (cbFiltro.Text == "Cliente")
                    {
                        _Adapter = new SqlDataAdapter("select SaidaEstoqueCli.codigo_se, convert(CHAR,dtSaida,101) as DataSaida,SaidaEstoqueCli.reposicao,Equipamento.descricao,Estoque.nrSerie,motivo,SaidaEstoqueCli.observacao, Cliente.Nome, usuario.nome as Usuario from SaidaEstoqueCli inner join Cliente on SaidaEstoqueCli.codigo_cliente = Cliente.codigo_cliente inner join Estoque on SaidaEstoqueCli.codigo_estoque = Estoque.codigo_estoque inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento inner join usuario on SaidaEstoqueCli.codigo_usuario = usuario.codigo_usuario where reposicao != 'Sim' and Cliente.Nome LIKE'%" + txtPesquisa.Text + "%' order by DataSaida", Con);
                    }
                    else
                    {
                        _Adapter = new SqlDataAdapter("select SaidaEstoqueCli.codigo_se, convert(CHAR,dtSaida,101) as DataSaida,SaidaEstoqueCli.reposicao,Equipamento.descricao,Estoque.nrSerie,motivo,SaidaEstoqueCli.observacao, Cliente.Nome, usuario.nome as Usuario from SaidaEstoqueCli inner join Cliente on SaidaEstoqueCli.codigo_cliente = Cliente.codigo_cliente inner join Estoque on SaidaEstoqueCli.codigo_estoque = Estoque.codigo_estoque inner join Equipamento on Estoque.codigo_equipamento = Equipamento.codigo_equipamento inner join usuario on SaidaEstoqueCli.codigo_usuario = usuario.codigo_usuario where reposicao != 'Sim' and Usuario.nome LIKE'%" + txtPesquisa.Text + "%' order by DataSaida", Con);
                    }

                    DataSet _ds = new DataSet();
                    _Adapter.Fill(_ds, "saidaEstoqueDataBinding");


                    dtgSaidaEstoque.DataContext = _ds;

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
