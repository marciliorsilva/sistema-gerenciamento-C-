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
    /// Interaction logic for ClienteConsulta.xaml
    /// </summary>
    public partial class ClienteConsulta : Window
    {
        string modo;
        string codigo_cliente;
        string codigo_eqptCliente;
        string botao;
        public ClienteConsulta(string modo, string codigo_cliente)
        {
            this.codigo_cliente = codigo_cliente;
            this.modo = modo;
            

            InitializeComponent();
           

            
           if (modo == "Incluir")
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
                txtNomeFantasia.IsEnabled = false;
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
                btEditar.IsEnabled = true;
                btCadastrar.IsEnabled = false;
                tbiEquipamentos.IsEnabled = true;
                tbiHistorico.IsEnabled = true;
              
                try
                {
                    SqlConnection conexao = new SqlConnection();
                    SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder();
                    banco.DataSource = ".\\SQLEXPRESS";
                    banco.InitialCatalog = "SISTEMA";
                    banco.IntegratedSecurity = true;
                    conexao.ConnectionString = banco.ConnectionString;

                    conexao.Open();
                    // comando SQL

                    string _Select = "Select * from Cliente where codigo_cliente=" + codigo_cliente;

                    // inicializa o comando e a conexão
                    SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                    SqlDataReader resultado = _cmdSelect.ExecuteReader();
                    resultado.Read();
                    if (resultado.HasRows == true)
                    {

                        cbTipo.Text = resultado["Tipo"] + "";
                        txtNome.Text = resultado["Nome"] + "";
                        txtNomeFantasia.Text = resultado["Fantasia"] + "";
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
                        txtNumero.Text = resultado["Numero"] + "";
                        txtComplemento.Text = resultado["Complemento"] + "";
                        cbAtivo.Text = resultado["Ativo"] + "";
                        dpDtCadastro.Text = resultado["DtCadastro"] + "";
                       
                    }
                    conexao.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

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

            SqlDataAdapter _Adapter = new SqlDataAdapter("select EqptCliente.codigo_eqptCliente as Codigo,Equipamento.descricao as Equipamento, Estoque.nrSerie as nrSerie, Estoque.modelo as Modelo from EqptCliente inner join Estoque on  Estoque.codigo_estoque = EqptCliente.codigo_estoque inner join Equipamento on Equipamento.codigo_equipamento = Estoque.codigo_equipamento where EqptCliente.codigo_cliente ='"+codigo_cliente+"'", conexao);

            DataSet _ds = new DataSet();
            _Adapter.Fill(_ds, "eqptClienteDataBinding");


            dtgEqptCliente.DataContext = _ds;

            // Fecha a conexão
            conexao.Close();
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
                    codigo_eqptCliente = _dv.Row[0].ToString();
                    btConsultarEqpt.IsEnabled = true;
                    btExcluirEqpt.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
            
            try
            {
                SqlConnection conexao = new SqlConnection();
                SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder();
                banco.DataSource = ".\\SQLEXPRESS";
                banco.InitialCatalog = "SISTEMA";
                banco.IntegratedSecurity = true;
                conexao.ConnectionString = banco.ConnectionString;

                conexao.Open();
                string sql = "";
                string data = dpDtCadastro.DisplayDate.ToShortDateString();
                string nascimento = dpNascimento.DisplayDate.ToShortDateString();



                if (modo == "Incluir")
                {
                    // comando SQL para inserir - Insert Into
                    sql = @"insert into Cliente
                    (Tipo,Nome,Fantasia,cpfCnpj,IE,Identidade,dtNascimento,Sexo,Email,Telefone,Contato,DtCadastro,Ativo,Cep,Endereco,Numero,Complemento,Cidade,Bairro,Uf)
                    Values('" + cbTipo.Text + "','" + txtNome.Text + "','" + txtNomeFantasia.Text + "','" + txtCpfCnpj.Text + "','" + txtIE.Text + "','" + txtIdentidade.Text + "','" + nascimento.ToString() + "','" + cbSexo.Text + "','" + txtEmail.Text + "','" + txtTelefone.Text + "','" + txtContato.Text + "','" + data.ToString() + "','" + cbAtivo.Text + "','" + txtCep.Text + "','" + txtEndereco.Text + "','" + txtNumero.Text + "','" + txtComplemento.Text + "','" + txtCidade.Text + "','" + txtBairro.Text + "','" + cbUF.Text + "')";


                    MessageBox.Show("Cadastrado com Sucesso!");




                }
                else if (botao == "Editar")
                {


                    // comando SQL para inserir - Insert Into
                    sql = @"Update Cliente Set 
                                     Tipo ='" + cbTipo.Text + "',Nome ='" + txtNome.Text + "',Fantasia ='" + txtNomeFantasia.Text + "',cpfCnpj ='" + txtCpfCnpj.Text + "',IE ='" + txtIE.Text + "',Identidade ='" + txtIdentidade.Text + "',dtNascimento ='" + nascimento.ToString() + "',Sexo ='" + cbSexo.Text + "',Email ='" + txtEmail.Text + "',Telefone ='" + txtTelefone.Text + "',Contato ='" + txtContato.Text + "',DtCadastro ='" + data.ToString() + "',Ativo ='" + cbAtivo.Text + "',Cep ='" + txtCep.Text + "',Endereco ='" + txtEndereco.Text + "',Numero ='" + txtNumero.Text + "',Complemento ='" + txtComplemento.Text + "',Cidade ='" + txtCidade.Text + "',Bairro ='" + txtBairro.Text + "',Uf ='" + cbUF.Text + "'where codigo_cliente = " + codigo_cliente;

                    MessageBox.Show("Alterado com Sucesso !");

                }
                SqlCommand codigo = new SqlCommand(sql, conexao);
                codigo.ExecuteNonQuery();
                conexao.Close();
                Close();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no banco!"+ex.ToString());
            }
           
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
      
        private void cbTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (modo == "Incluir")
            {
                if (cbTipo.SelectedIndex == 1)
                {
                    txtIdentidade.IsEnabled = false;
                    dpNascimento.IsEnabled = false;
                    cbSexo.IsEnabled = false;
                    txtIE.IsEnabled = true;
                    txtNomeFantasia.IsEnabled = true;
                }
                else
                {
                    txtIdentidade.IsEnabled = true;
                    dpNascimento.IsEnabled = true;
                    cbSexo.IsEnabled = true;
                    txtIE.IsEnabled = false;
                    txtNomeFantasia.IsEnabled = false;
                }
            }
            else if(botao=="Editar")
            {
                if (cbTipo.SelectedIndex == 1)
                {
                    txtIdentidade.IsEnabled = false;
                    dpNascimento.IsEnabled = false;
                    cbSexo.IsEnabled = false;
                    txtIE.IsEnabled = true;
                    txtNomeFantasia.IsEnabled = true;
                }
                else
                {
                    txtIdentidade.IsEnabled = true;
                    dpNascimento.IsEnabled = true;
                    cbSexo.IsEnabled = true;
                    txtIE.IsEnabled = false;
                    txtNomeFantasia.IsEnabled = false;
                }
            
            }
            
        }

        private void btAdicionarEqpt_Click(object sender, RoutedEventArgs e)
        {
            AdicionarEqptCliente add = new AdicionarEqptCliente(codigo_cliente);
            add.ShowDialog();
            this.VinculaDados();
        }

        private void btExcluirEqpt_Click(object sender, RoutedEventArgs e)
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
                string _Deletar = @"Delete from EqptCliente
                                  Where codigo_eqptCliente = " + Convert.ToInt32(codigo_eqptCliente);

                // inicializa o comando e a conexão
                SqlCommand _cmdDeletar = new SqlCommand(_Deletar, conexao);
                // executa o comando
                _cmdDeletar.ExecuteNonQuery();

                MessageBox.Show("Excluido com Sucesso !");
                btConsultarEqpt.IsEnabled = false;
                btExcluirEqpt.IsEnabled = false;
                this.VinculaDados();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no Banco");
                btConsultarEqpt.IsEnabled = false;
                btExcluirEqpt.IsEnabled = false;
            }
        }

      
             
                       
    }
}
