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
    /// Interaction logic for Cliente.xaml
    /// </summary>
    public partial class Cliente : Window
    {
        string codigo_cliente;
        string codigo_filial;
        string modo;
        string atend;
        string nome_cliente;
        string nome_usuario;
        string nome_filial;
        string modo2;
      
        NovoConsultarAtendimento formaPai;
        OrdemServicoEntrada formPaiOS;
      

        public Cliente(string atend, string nome_usuario,NovoConsultarAtendimento formaPai,OrdemServicoEntrada formPaiOS)
        {
            this.atend = atend;
            this.nome_usuario = nome_usuario;
            this.formaPai = formaPai;
            this.formPaiOS = formPaiOS;
            InitializeComponent();

            if (atend == "pesquisaCli" || atend == "OScli")
            {
                btAtend.Opacity = 1;

            }
            else
            {
                btAtend.Opacity = 0;
            }

        }


        public void VinculaDados()
        {
            SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


            try
            {
                Con.Open();
                SqlDataAdapter _Adapter = new SqlDataAdapter("Select * , convert(CHAR,DtCadastro,101) as dataContrato from Cliente", Con);

                DataSet _ds = new DataSet();
                _Adapter.Fill(_ds, "clienteDataBinding");

              
                dtgCliente.DataContext = _ds;

                
            }
            catch (SqlException)
            {
                MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                Con.Close();
            }

            

            
        }

        

        private void dtgCliente_Loaded(object sender, RoutedEventArgs e)
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

        private void dtgCliente_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            modo = "SelecionouMatriz";
            modo2 = "SelecionouMatriz";
            SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");

            try
            {
                DataRowView _dv = dtgCliente.CurrentCell.Item as DataRowView;

                if (_dv != null)
                {
                    codigo_cliente = _dv.Row[0].ToString();
                    nome_cliente = _dv.Row[2].ToString();
                    btConsultar.IsEnabled = true;
                    btExcluir.IsEnabled = true;

                    Con.Open();
                    SqlDataAdapter _Adapter = new SqlDataAdapter("Select * , convert(CHAR,DtCadastro,101) as dataContrato from Filial where codigo_cliente='" + codigo_cliente + "'", Con);

                    DataSet _ds = new DataSet();
                    _Adapter.Fill(_ds, "filialDataBinding");


                    dtgFilial.DataContext = _ds;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

      

        private void dtgFilial_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            modo = "SelecionouFilial";
            modo2 = "SelecionouFilial";
            try
            {
                DataRowView _dv = dtgFilial.CurrentCell.Item as DataRowView;

                if (_dv != null)
                {
                    codigo_filial = _dv.Row[0].ToString();
                    nome_filial = _dv.Row[2].ToString();
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
            ClienteConsulta clienteConsulta = new ClienteConsulta(modo, codigo_cliente,nome_cliente);
            clienteConsulta.ShowDialog();
            this.VinculaDados();
        }


        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            if (modo == "SelecionouMatriz")
            {
                modo = "Consultar";
                ClienteConsulta clienteConsulta = new ClienteConsulta(modo, codigo_cliente, nome_cliente);

                btConsultar.IsEnabled = false;
                btExcluir.IsEnabled = false;
                clienteConsulta.ShowDialog();
                this.VinculaDados();
            }
            else if (modo == "SelecionouFilial")
            {
              
                modo = "ConsultarFilial";
                FilialConsulta consultar = new FilialConsulta(modo, codigo_cliente, codigo_filial, nome_filial);
                btConsultar.IsEnabled = false;
                btExcluir.IsEnabled = false;
                consultar.ShowDialog();
                                            
            }

        }

        private void btExcluir_Click(object sender, RoutedEventArgs e)
        {
            
                SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");

                if (modo == "SelecionouMatriz")
                {

                    try
                    {
                        Con.Open();
                        // Command String
                        string _Deletar = @"Delete from Cliente
                                  Where codigo_cliente = " + Convert.ToInt32(codigo_cliente);
                        string DeletarCliEqpt = @"Delete from EqptCliente
                                  Where codigo_cliente = " + Convert.ToInt32(codigo_cliente);

                        // inicializa o comando e a conexão
                        SqlCommand _cmdDeletar = new SqlCommand(_Deletar, Con);
                        SqlCommand _cmdDeletarEqpt = new SqlCommand(DeletarCliEqpt, Con);
                        // executa o comando
                        _cmdDeletar.ExecuteNonQuery();

                        MessageBox.Show("Excluido com Sucesso !");
                        btConsultar.IsEnabled = false;
                        btExcluir.IsEnabled = false;
                        this.VinculaDados();
                        Con.Close();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Não é possivel excluir, pois existem 1 ou mais cadastros utilizando esse Cliente.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                        btConsultar.IsEnabled = false;
                        btExcluir.IsEnabled = false;
                        Con.Close();
                    }
                }
                else if (modo == "SelecionouFilial")
                {
                    try
                    {
                        Con.Open();
                        // Command String
                        string _Deletar = @"Delete from Filial
                                  Where codigo_filial = " + Convert.ToInt32(codigo_filial);
                        string DeletarCliEqpt = @"Delete from EqptFilial
                                  Where codigo_filial = " + Convert.ToInt32(codigo_filial);

                        // inicializa o comando e a conexão
                        SqlCommand _cmdDeletar = new SqlCommand(_Deletar, Con);
                        SqlCommand _cmdDeletarEqpt = new SqlCommand(DeletarCliEqpt, Con);
                        // executa o comando
                        _cmdDeletar.ExecuteNonQuery();

                        MessageBox.Show("Excluido com Sucesso !");
                        btConsultar.IsEnabled = false;
                        btExcluir.IsEnabled = false;
                        this.VinculaDados();
                        Con.Close();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Erro no Banco.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                        btConsultar.IsEnabled = false;
                        btExcluir.IsEnabled = false;
                        Con.Close();
                    }
                }
           
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void txtPesquisa_SelectionChanged(object sender, RoutedEventArgs e)
        {
            
            if (cbFiltro.Text == "Tipo de Busca:" && txtPesquisa.Text!="")
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
                    SqlDataAdapter _Adapter = new SqlDataAdapter("Select * , convert(CHAR,DtCadastro,101) as dataContrato from Cliente ", Con);

                    DataSet _ds = new DataSet();
                    _Adapter.Fill(_ds, "clienteDataBinding");


                    dtgCliente.DataContext = _ds;

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
                    if (cbFiltro.Text == "CNPJ/CPF")
                    {
                        _Adapter = new SqlDataAdapter("Select * , convert(CHAR,DtCadastro,101) as dataContrato from Cliente where cpfCnpj  LIKE'%" + txtPesquisa.Text + "%'", Con);

                    }
                    else
                    {
                        _Adapter = new SqlDataAdapter("Select * , convert(CHAR,DtCadastro,101) as dataContrato from Cliente  where " + cbFiltro.Text + " LIKE'%" + txtPesquisa.Text + "%'", Con);
                    }
                    DataSet _ds = new DataSet();
                    _Adapter.Fill(_ds, "clienteDataBinding");


                    dtgCliente.DataContext = _ds;

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

        private void btAtend_Click(object sender, RoutedEventArgs e)
        {
            string modo = "Novo";
            string codigo_atendimento = "";
            string codigo_osEntrada = "";
          
            SqlConnection conexao = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");

            if (atend == "pesquisaCli")
            {
                NovoConsultarAtendimento atendimento = new NovoConsultarAtendimento(modo, codigo_atendimento, nome_usuario, nome_cliente, nome_filial);


                if (modo2 == "SelecionouFilial")
                {


                    formaPai.txtCliente.Text = nome_filial.ToString();

                }
                else
                {

                    formaPai.txtCliente.Text = nome_cliente.ToString();

                }

                Close();

            }

            else if (atend == "OScli")
            {


                if (modo2 == "SelecionouFilial")
                {


                    modo = "Filial";
                    OrdemServicoEntrada os = new OrdemServicoEntrada(modo, codigo_osEntrada, nome_usuario, nome_cliente, nome_filial);

                    formPaiOS.txtCliente.Text = nome_filial.ToString();
                    formPaiOS.cbEqpt.Text = string.Empty;
                    formPaiOS.cbEqpt.SelectedItem = string.Empty;
                    formPaiOS.cbEqpt.Items.Clear();
                    formPaiOS.cbEqpt.IsEnabled = true;
                    

                    try
                    {
                        conexao.Open();
                        // comando SQL

                        string _Select = "select EqptFilial.codigo_eqptFilial as Codigo,Equipamento.descricao as Equipamento, Estoque.nrSerie as nrSerie, Estoque.modelo as Modelo, Fornecedor.Nome as Marca,Filial.codigo_filial from EqptFilial inner join Estoque on  Estoque.codigo_estoque = EqptFilial.codigo_estoque  inner join Fornecedor on Fornecedor.codigo_fornecedor = Estoque.codigo_fornecedor inner join Equipamento on Equipamento.codigo_equipamento = Estoque.codigo_equipamento inner join Filial on EqptFilial.codigo_filial = Filial.codigo_filial where Filial.Nome='" + nome_filial.ToString() + "'";

                        // inicializa o comando e a conexão
                        SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                        SqlDataReader resultado = _cmdSelect.ExecuteReader();
                   
                        while (resultado.Read())
                        {

                            formPaiOS.cbEqpt.Items.Add(resultado["Equipamento"] + "" + " | " + resultado["nrSerie"] + "" + " | " + resultado["Modelo"] + "" + " | " + resultado["Marca"] + "");
                         
                        }
                       
                        conexao.Close();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                        conexao.Close();
                    }
                   
                    
                }
                else
                {

                    modo = "Matriz";
                    OrdemServicoEntrada os = new OrdemServicoEntrada(modo, codigo_osEntrada, nome_usuario, nome_cliente, nome_filial);

                    formPaiOS.txtCliente.Text = nome_cliente.ToString();
                    formPaiOS.cbEqpt.Text = string.Empty;
                    formPaiOS.cbEqpt.SelectedItem = string.Empty;
                    formPaiOS.cbEqpt.Items.Clear();
                    formPaiOS.cbEqpt.IsEnabled = true;
                   
                    try
                    {
                        conexao.Open();
                        // comando SQL

                        string _Select = "select EqptCliente.codigo_eqptCliente as Codigo,Equipamento.descricao as Equipamento, Estoque.nrSerie as nrSerie, Estoque.modelo as Modelo, Fornecedor.Nome as Marca, Cliente.codigo_cliente from EqptCliente inner join Estoque on  Estoque.codigo_estoque = EqptCliente.codigo_estoque  inner join Fornecedor on Fornecedor.codigo_fornecedor = Estoque.codigo_fornecedor inner join Equipamento on Equipamento.codigo_equipamento = Estoque.codigo_equipamento inner join Cliente on EqptCliente.codigo_cliente = Cliente.codigo_cliente where Cliente.Nome='" + nome_cliente.ToString() + "'";

                        // inicializa o comando e a conexão
                        SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                        SqlDataReader resultado = _cmdSelect.ExecuteReader();
                                           
                        while (resultado.Read())
                        {
                            formPaiOS.cbEqpt.Items.Add(resultado["Equipamento"] + "" + " | " + resultado["nrSerie"] + "" + " | " + resultado["Modelo"] + "" + " | " + resultado["Marca"] + "");
                                                 
                        }
                       
                        conexao.Close();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                        conexao.Close();
                    }

                   
                    
                }

                Close();
            
            
            
            
            }
           
           
        }

       

       

    }
}
