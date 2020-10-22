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
    /// Interaction logic for EstoquePecasSaida.xaml
    /// </summary>
    public partial class EstoquePecasSaida : Window
    {
        string codigo_spc;
        string modo;
        string nome_usuario;
        ordemServicoSaida formPai;

        public EstoquePecasSaida(string nome_usuario)
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


            SqlDataAdapter _Adapter = new SqlDataAdapter("select SaidaPecasCli.codigo_spc, convert(CHAR,SaidaPecasCli.dtSaida,101) as DataSaida, SaidaPecasCli.reposicao,Pecas.descricao,motivo,SaidaPecasCli.observacao, qtdeSaida, Cliente.Nome, usuario.nome as Usuario from SaidaPecasCli inner join Cliente on SaidaPecasCli.codigo_cliente = Cliente.codigo_cliente inner join EstoquePecas on SaidaPecasCli.codigo_estoquePecas = EstoquePecas.codigo_estoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas inner join usuario on SaidaPecasCli.codigo_usuario = usuario.codigo_usuario where reposicao != 'Sim' order by DataSaida ", conexao);


            DataSet _ds = new DataSet();
            _Adapter.Fill(_ds, "saidaPecasDataBinding");
                        
            dtgSaidaPecas.DataContext = _ds;
            
            
                           // Fecha a conexão
                conexao.Close();
        }

        private void dtgSaidaPecas_Loaded(object sender, RoutedEventArgs e)
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

        private void dtgSaidaPecas_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView _dv = dtgSaidaPecas.CurrentCell.Item as DataRowView;

                if (_dv != null)
                {

                    codigo_spc = _dv.Row[0].ToString();
                    
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
            IncluirConsultarPecasSaida incluir = new IncluirConsultarPecasSaida(modo, codigo_spc, nome_usuario, formPai);
            incluir.ShowDialog();
            this.VinculaDados();
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            modo = "Consultar";
            IncluirConsultarPecasSaida consultar = new IncluirConsultarPecasSaida(modo, codigo_spc, nome_usuario, formPai);
            consultar.ShowDialog();
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
                    SqlDataAdapter _Adapter = new SqlDataAdapter("select SaidaPecasCli.codigo_spc, convert(CHAR,SaidaPecasCli.dtSaida,101) as DataSaida, SaidaPecasCli.reposicao,Pecas.descricao,motivo,SaidaPecasCli.observacao, qtdeSaida, Cliente.Nome, usuario.nome as Usuario from SaidaPecasCli inner join Cliente on SaidaPecasCli.codigo_cliente = Cliente.codigo_cliente inner join EstoquePecas on SaidaPecasCli.codigo_estoquePecas = EstoquePecas.codigo_estoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas inner join usuario on SaidaPecasCli.codigo_usuario = usuario.codigo_usuario where reposicao != 'Sim' order by DataSaida ", Con);

                    DataSet _ds = new DataSet();
                    _Adapter.Fill(_ds, "saidaPecasDataBinding");


                    dtgSaidaPecas.DataContext = _ds;

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
                        _Adapter = new SqlDataAdapter("select SaidaPecasCli.codigo_spc, convert(CHAR,SaidaPecasCli.dtSaida,101) as DataSaida,SaidaPecasCli.reposicao,Pecas.descricao,motivo,SaidaPecasCli.observacao, qtdeSaida, Cliente.Nome, usuario.nome as Usuario from SaidaPecasCli inner join Cliente on SaidaPecasCli.codigo_cliente = Cliente.codigo_cliente inner join EstoquePecas on SaidaPecasCli.codigo_estoquePecas = EstoquePecas.codigo_estoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas inner join usuario on SaidaPecasCli.codigo_usuario = usuario.codigo_usuario where reposicao != 'Sim' and  convert(CHAR,SaidaPecasCli.dtSaida,101) LIKE'%" + txtPesquisa.Text + "%' order by DataSaida", Con);

                    }
                    else if (cbFiltro.Text == "Peças")
                    {
                        _Adapter = new SqlDataAdapter("select SaidaPecasCli.codigo_spc, convert(CHAR,SaidaPecasCli.dtSaida,101) as DataSaida, SaidaPecasCli.reposicao,Pecas.descricao,motivo,SaidaPecasCli.observacao, qtdeSaida, Cliente.Nome, usuario.nome as Usuario from SaidaPecasCli inner join Cliente on SaidaPecasCli.codigo_cliente = Cliente.codigo_cliente inner join EstoquePecas on SaidaPecasCli.codigo_estoquePecas = EstoquePecas.codigo_estoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas inner join usuario on SaidaPecasCli.codigo_usuario = usuario.codigo_usuario where reposicao != 'Sim' and Pecas.descricao LIKE'%" + txtPesquisa.Text + "%' order by DataSaida", Con);
                    }
                    else if (cbFiltro.Text == "Motivo")
                    {
                        _Adapter = new SqlDataAdapter("select SaidaPecasCli.codigo_spc, convert(CHAR,SaidaPecasCli.dtSaida,101) as DataSaida,SaidaPecasCli.reposicao,Pecas.descricao,motivo,SaidaPecasCli.observacao, qtdeSaida, Cliente.Nome, usuario.nome as Usuario from SaidaPecasCli inner join Cliente on SaidaPecasCli.codigo_cliente = Cliente.codigo_cliente inner join EstoquePecas on SaidaPecasCli.codigo_estoquePecas = EstoquePecas.codigo_estoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas inner join usuario on SaidaPecasCli.codigo_usuario = usuario.codigo_usuario where reposicao != 'Sim' and motivo LIKE'%" + txtPesquisa.Text + "%' order by DataSaida", Con);
                    }
                    else if (cbFiltro.Text == "Cliente")
                    {
                        _Adapter = new SqlDataAdapter("select SaidaPecasCli.codigo_spc, convert(CHAR,SaidaPecasCli.dtSaida,101) as DataSaida,SaidaPecasCli.reposicao,Pecas.descricao,motivo,SaidaPecasCli.observacao, qtdeSaida, Cliente.Nome, usuario.nome as Usuario from SaidaPecasCli inner join Cliente on SaidaPecasCli.codigo_cliente = Cliente.codigo_cliente inner join EstoquePecas on SaidaPecasCli.codigo_estoquePecas = EstoquePecas.codigo_estoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas inner join usuario on SaidaPecasCli.codigo_usuario = usuario.codigo_usuario where reposicao != 'Sim' and Cliente.Nome LIKE'%" + txtPesquisa.Text + "%' order by DataSaida", Con);
                    }
                    else
                    {
                        _Adapter = new SqlDataAdapter("select SaidaPecasCli.codigo_spc, convert(CHAR,SaidaPecasCli.dtSaida,101) as DataSaida,SaidaPecasCli.reposicao,Pecas.descricao,motivo,SaidaPecasCli.observacao, qtdeSaida, Cliente.Nome, usuario.nome as Usuario from SaidaPecasCli inner join Cliente on SaidaPecasCli.codigo_cliente = Cliente.codigo_cliente inner join EstoquePecas on SaidaPecasCli.codigo_estoquePecas = EstoquePecas.codigo_estoquePecas inner join Pecas on EstoquePecas.codigo_pecas = Pecas.codigo_pecas inner join usuario on SaidaPecasCli.codigo_usuario = usuario.codigo_usuario where reposicao != 'Sim' and Usuario.nome LIKE'%" + txtPesquisa.Text + "%' order by DataSaida", Con);
                    }

                    DataSet _ds = new DataSet();
                    _Adapter.Fill(_ds, "saidaPecasDataBinding");


                    dtgSaidaPecas.DataContext = _ds;

                    // Fecha a conexão
                    Con.Close();


                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Não foi possivel conectar com o Banco"+ ex, "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                    Con.Close();
                }
            }
        }

      
    }
}
