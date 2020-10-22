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
    /// Interaction logic for FilialConsulta.xaml
    /// </summary>
    public partial class FilialConsulta : Window
    {
        string modo;
        string codigo_filial;
        string codigo_cliente;
        string codigo_eqptFilial;
        string nome_filial;
        string botao;
        public FilialConsulta(string modo, string codigo_cliente, string codigo_filial, string nome_filial)
        {
            this.modo = modo;
            this.codigo_filial = codigo_filial;
            this.nome_filial = nome_filial;
            this.codigo_cliente = codigo_cliente;
            InitializeComponent();

            if (modo == "AddFilial")
            {
                DateTime data1 = DateTime.Now;
                cbAtivo.SelectedIndex = 0;
                dpDtCadastro.Text = data1 + "";
                btEditar.IsEnabled = false;




            }
            else
            {

                cbTipo.IsEnabled = false;
                txtNome.IsEnabled = false;
                txtCpfCnpj.IsEnabled = false;
                txtIE.IsEnabled = false;
                txtIdentidade.IsEnabled = false;
                dpNascimento.IsEnabled = false;
                cbSexo.IsEnabled = false;
                txtEmail.IsEnabled = false;
                txtTelefone.IsEnabled = false;
                txtContato.IsEnabled = false;
                cbAtivo.IsEnabled = false;
                dpDtCadastro.IsEnabled = false;
                txtCep.IsEnabled = false;
                txtEndereco.IsEnabled = false;
                txtNumero.IsEnabled = false;
                txtComplemento.IsEnabled = false;
                txtCidade.IsEnabled = false;
                txtBairro.IsEnabled = false;
                cbUF.IsEnabled = false;
                cbContrato.IsEnabled = false;
                btEditar.IsEnabled = true;
                btCadastrar.IsEnabled = false;
                tbiEquipamentos.IsEnabled = true;
                tbiHistorico.IsEnabled = true;
                dpFimContrato.IsEnabled = false;

                SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


                try
                {
                    Con.Open();
                    string _Select = "Select * from Filial where codigo_filial=" + codigo_filial;



                    // inicializa o comando e a conexão
                    SqlCommand _cmdSelect = new SqlCommand(_Select, Con);
                    SqlDataReader resultado = _cmdSelect.ExecuteReader();
                    resultado.Read();
                    if (resultado.HasRows == true)
                    {

                        cbTipo.SelectedItem = resultado["Tipo"] + "";
                        txtNome.Text = resultado["Nome"] + "";
                        txtCpfCnpj.Text = resultado["cpfCnpj"] + "";
                        txtIdentidade.Text = resultado["Identidade"] + "";
                        dpNascimento.Text = resultado["dtNascimento"] + "";
                        cbSexo.Text = resultado["Sexo"] + "";
                        txtIE.Text = resultado["IE"] + "";
                        txtEmail.Text = resultado["Email"] + "";
                        txtTelefone.Text = resultado["Telefone"] + "";
                        txtContato.Text = resultado["Contato"] + "";
                        txtEndereco.Text = resultado["Endereco"] + "";
                        txtCep.Text = resultado["Cep"] + "";
                        txtCidade.Text = resultado["Cidade"] + "";
                        txtBairro.Text = resultado["Bairro"] + "";
                        cbUF.Text = resultado["Uf"] + "";
                        cbContrato.Text = resultado["contrato"] + "";
                        txtNumero.Text = resultado["Numero"] + "";
                        txtComplemento.Text = resultado["Complemento"] + "";
                        cbAtivo.Text = resultado["Ativo"] + "";
                        dpDtCadastro.Text = resultado["DtCadastro"] + "";
                        if (cbContrato.Text == "Sim")
                        {
                            dpFimContrato.Text = resultado["dataContrato"] + "";

                        }
                        else
                        {
                            dpFimContrato.Text = string.Empty;

                        }
                    }
                    Con.Close();

                }
                catch (SqlException)
                {
                    MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                    Con.Close();
                }


            }
        }

        public void VinculaDados()
        {

            SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


            try
            {

                Con.Open();
                SqlDataAdapter _Adapter = new SqlDataAdapter("select EqptFilial.codigo_eqptFilial as Codigo,Equipamento.descricao as Equipamento, Estoque.nrSerie as nrSerie, Estoque.modelo as Modelo from EqptFilial inner join Estoque on  Estoque.codigo_estoque = EqptFilial.codigo_estoque inner join Equipamento on Equipamento.codigo_equipamento = Estoque.codigo_equipamento where EqptFilial.codigo_filial ='" + codigo_filial + "'", Con);

                DataSet _ds = new DataSet();
                _Adapter.Fill(_ds, "eqptClienteDataBinding");


                dtgEqptCliente.DataContext = _ds;

                // Fecha a conexão
                Con.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                Con.Close();
            }
        }


        private void dtgEqptCliente_Loaded(object sender, RoutedEventArgs e)
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

        private void dtgEqptCliente_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

            try
            {
                DataRowView _dv = dtgEqptCliente.CurrentCell.Item as DataRowView;


                if (_dv != null)
                {

                    codigo_eqptFilial = _dv.Row[0].ToString();
                    btConsultarEqpt.IsEnabled = true;
                    btExcluirEqpt.IsEnabled = true;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void AtendimentoLoad()
        {

            SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


            try
            {
                Con.Open();
                SqlDataAdapter _Adapter = new SqlDataAdapter("select Atendimento.*, convert(CHAR,dataEntrada,101) as DataEntrada2, Usuario.nome as Usuario from Atendimento inner join Usuario on Atendimento.codigo_usuario = Usuario.codigo_usuario where Atendimento.cliente = '" + nome_filial + "'", Con);

                DataSet _ds = new DataSet();
                _Adapter.Fill(_ds, "atendimentoDataBinding");


                dtgAtendimento.DataContext = _ds;

                // Fecha a conexão
                Con.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                Con.Close();
            }

            
        }

        private void btEditar_Click(object sender, RoutedEventArgs e)
        {
            botao = "Editar";
            cbTipo.IsEnabled = true;
            txtNome.IsEnabled = true;
            txtCpfCnpj.IsEnabled = true;
            txtEmail.IsEnabled = true;
            txtTelefone.IsEnabled = true;
            txtContato.IsEnabled = true;
            cbAtivo.IsEnabled = true;
            dpDtCadastro.IsEnabled = true;
            txtCep.IsEnabled = true;
            txtEndereco.IsEnabled = true;
            txtNumero.IsEnabled = true;
            txtComplemento.IsEnabled = true;
            txtCidade.IsEnabled = true;
            txtBairro.IsEnabled = true;
            cbUF.IsEnabled = true;
            btEditar.IsEnabled = false;
            btCadastrar.IsEnabled = true;


        }

        private void btCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("O campo NOME não pode ficar em branco.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else
            {
                SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


                try
                {
                    Con.Open();

                    string sql = "";
                    string data = dpDtCadastro.DisplayDate.ToShortDateString();
                    string nascimento = dpNascimento.DisplayDate.ToShortDateString();
                    string dataContrato = dpFimContrato.DisplayDate.ToShortDateString();



                    if (modo == "AddFilial")
                    {
                        // comando SQL para inserir - Insert Into
                        sql = @"insert into Filial
                    (Tipo,Nome,cpfCnpj,IE,Identidade,dtNascimento,Sexo,Email,Telefone,Contato,DtCadastro,Ativo,Contrato,DataContrato,Cep,Endereco,Numero,Complemento,Cidade,Bairro,Uf,codigo_cliente)
                    Values('" + cbTipo.Text + "','" + txtNome.Text + "','" + txtCpfCnpj.Text + "','" + txtIE.Text + "','" + txtIdentidade.Text + "',convert(smalldatetime,'" + nascimento.ToString() + "',103),'" + cbSexo.Text + "','" + txtEmail.Text + "','" + txtTelefone.Text + "','" + txtContato.Text + "',convert(smalldatetime,'" + data.ToString() + "',103),'" + cbAtivo.Text + "','" + cbContrato.Text + "',convert(smalldatetime,'" + dataContrato.ToString() + "',103),'" + txtCep.Text + "','" + txtEndereco.Text + "','" + txtNumero.Text + "','" + txtComplemento.Text + "','" + txtCidade.Text + "','" + txtBairro.Text + "','" + cbUF.Text + "','" +codigo_cliente+ "')";


                        MessageBox.Show("Cadastrado com Sucesso!");

                    }

                    else if (botao == "Editar")
                    {


                        // comando SQL para inserir - Insert Into
                        sql = @"Update Filial Set 
                                     Tipo ='" + cbTipo.Text + "',Nome ='" + txtNome.Text + "',cpfCnpj ='" + txtCpfCnpj.Text + "',IE ='" + txtIE.Text + "',Identidade ='" + txtIdentidade.Text + "',dtNascimento=convert(smalldatetime,'" + nascimento.ToString() + "',103),Sexo ='" + cbSexo.Text + "',Email ='" + txtEmail.Text + "',Telefone ='" + txtTelefone.Text + "',Contato ='" + txtContato.Text + "',DtCadastro=convert(smalldatetime,'" + data.ToString() + "',103),Ativo ='" + cbAtivo.Text + "',Contrato ='" + cbContrato.Text + "',DataContrato=convert(smalldatetime,'" + dataContrato.ToString() + "',103),Cep ='" + txtCep.Text + "',Endereco ='" + txtEndereco.Text + "',Numero ='" + txtNumero.Text + "',Complemento ='" + txtComplemento.Text + "',Cidade ='" + txtCidade.Text + "',Bairro ='" + txtBairro.Text + "',Uf ='" + cbUF.Text + "'where codigo_filial = " + codigo_filial;

                        MessageBox.Show("Alterado com Sucesso !");


                    }

                    SqlCommand codigo = new SqlCommand(sql, Con);
                    codigo.ExecuteNonQuery();
                    this.VinculaDados();
                    Con.Close();
                    Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Não foi possivel conectar com o Banco"+ex, "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                    Con.Close();
                }
            }



        }
        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cbTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (modo != "Incluir")
            {
                txtIdentidade.IsEnabled = false;
                dpNascimento.IsEnabled = false;
                cbSexo.IsEnabled = false;
                txtIE.IsEnabled = false;
            }
            else
            {

                if (cbTipo.SelectedIndex == 1)
                {
                    txtIdentidade.IsEnabled = false;
                    dpNascimento.IsEnabled = false;
                    cbSexo.IsEnabled = false;
                    txtIE.IsEnabled = true;
                    txtIdentidade.Text = string.Empty;
                    dpNascimento.Text = string.Empty;
                    cbSexo.Text = string.Empty;

                }
                else
                {
                    txtIdentidade.IsEnabled = true;
                    dpNascimento.IsEnabled = true;
                    cbSexo.IsEnabled = true;
                    txtIE.IsEnabled = false;
                    txtIE.Text = string.Empty;

                }

            }

            if (botao == "Editar")
            {
                if (cbTipo.SelectedIndex == 1)
                {
                    txtIdentidade.IsEnabled = false;
                    dpNascimento.IsEnabled = false;
                    cbSexo.IsEnabled = false;
                    txtIE.IsEnabled = true;


                }
                else
                {
                    txtIdentidade.IsEnabled = true;
                    dpNascimento.IsEnabled = true;
                    cbSexo.IsEnabled = true;
                    txtIE.IsEnabled = true;


                }

            }

        }

        private void btAdicionarEqpt_Click(object sender, RoutedEventArgs e)
        {

            modo = "AddFilial";
            ClienteEqpt add = new ClienteEqpt(modo, codigo_cliente, codigo_filial);
            add.ShowDialog();
            this.VinculaDados();


        }

        private void btExcluirEqpt_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


            try
            {
                Con.Open();
                // Command String
                string _Deletar = @"Delete from EqptFilial
                                  Where codigo_eqptFilial = " + Convert.ToInt32(codigo_eqptFilial);

                // inicializa o comando e a conexão
                SqlCommand _cmdDeletar = new SqlCommand(_Deletar, Con);
                // executa o comando
                _cmdDeletar.ExecuteNonQuery();

                MessageBox.Show("Excluido com Sucesso !");
                btConsultarEqpt.IsEnabled = false;
                btExcluirEqpt.IsEnabled = false;
                this.VinculaDados();
                Con.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                btConsultarEqpt.IsEnabled = false;
                btExcluirEqpt.IsEnabled = false;
                Con.Close();
            }


        }
        private void cbContrato_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (modo == "AddFilial" || botao == "Editar")
            {
                if (cbContrato.SelectedIndex == 0)
                {
                    dpFimContrato.IsEnabled = true;

                }
                else
                {
                    dpFimContrato.IsEnabled = false;
                    dpFimContrato.Text = string.Empty;
                }
            }
            else if (modo == "ConsultarFilial")
            {

                if (cbContrato.SelectedIndex == 0)
                {
                    dpFimContrato.IsEnabled = false;

                }
                else
                {
                    dpFimContrato.IsEnabled = false;
                    dpFimContrato.Text = string.Empty;
                }

            }
        }

        private void dtgAtendimento_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.AtendimentoLoad();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btConsultarEqpt_Click(object sender, RoutedEventArgs e)
        {

            modo = "ConsultarFilial";
            ClienteEqpt consultar = new ClienteEqpt(modo, codigo_cliente, codigo_filial);
            consultar.ShowDialog();
            this.VinculaDados();

        }

    }
}
