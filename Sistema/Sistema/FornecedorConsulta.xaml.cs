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
    /// Interaction logic for Fornecedor.xaml
    /// </summary>
    public partial class FornecedorConsulta : Window
    {
        string modo;
        string codigo_fornecedor;
        string botao;
       
        public FornecedorConsulta(string modo, string codigo_fornecedor)
        {
            this.modo = modo;
            this.codigo_fornecedor = codigo_fornecedor;
           
            InitializeComponent();
            
            if (modo == "Incluir")
            {            
                DateTime data = DateTime.Now;
                cbAtivo.SelectedIndex=0;
                dpDtCadastro.Text = data+"";
                btEditar.IsEnabled = false;
            }
            else 
            {
                txtNome.IsEnabled = false;
                txtNomeFantasia.IsEnabled = false;
                txtCnpj.IsEnabled = false;
                txtIE.IsEnabled = false;
                txtEmail.IsEnabled = false;
                txtSite.IsEnabled = false;
                txtTelefone.IsEnabled = false;
                cbAtivo.IsEnabled = false;
                dpDtCadastro.IsEnabled = false;
                txtCep.IsEnabled = false;
                txtEndereco.IsEnabled = false;
                txtNumero.IsEnabled = false;
                txtComplemento.IsEnabled = false;
                txtCidade.IsEnabled = false;
                txtBairro.IsEnabled = false;
                cbUF.IsEnabled = false;
                txtContato.IsEnabled = false;
                btEditar.IsEnabled = true;
                btCadastrar.IsEnabled = false;
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

                    string _Select = "Select * from Fornecedor where codigo_fornecedor=" + codigo_fornecedor;

                    // inicializa o comando e a conexão
                    SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                    SqlDataReader resultado = _cmdSelect.ExecuteReader();
                    resultado.Read();
                    if (resultado.HasRows == true)
                    {

                        txtNome.Text = resultado["Nome"] + "";
                        txtNomeFantasia.Text = resultado["Fantasia"] + "";
                        txtCnpj.Text = resultado["Cnpj"] + "";
                        txtIE.Text = resultado["IE"] + "";
                        txtTelefone.Text = resultado["Telefone"] + "";
                        txtEmail.Text = resultado["Email"] + "";
                        txtEndereco.Text = resultado["Endereco"] + "";
                        txtCep.Text = resultado["Cep"] + "";
                        txtCidade.Text = resultado["Cidade"] + "";
                        txtBairro.Text = resultado["Bairro"] + "";
                        cbUF.Text = resultado["Uf"] + "";
                        txtNumero.Text = resultado["Numero"] + "";
                        txtComplemento.Text = resultado["Complemento"] + "";
                        cbAtivo.Text = resultado["Ativo"] + "";
                        dpDtCadastro.Text = resultado["DtCadastro"]+"";
                        txtContato.Text = resultado["Contato"]+"";


                    }
                    conexao.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }

        private void btEditar_Click(object sender, RoutedEventArgs e)
        {
            botao = "Editar";
            txtNome.IsEnabled = true;
            txtNomeFantasia.IsEnabled = true;
            txtCnpj.IsEnabled = true;
            txtIE.IsEnabled = true;
            txtEmail.IsEnabled = true;
            txtSite.IsEnabled = true;
            txtTelefone.IsEnabled = true;
            cbAtivo.IsEnabled = true;
            dpDtCadastro.IsEnabled = true;
            txtContato.IsEnabled = true;
            btCadastrar.IsEnabled = true;
            txtCep.IsEnabled = true;
            txtEndereco.IsEnabled = true;
            txtNumero.IsEnabled = true;
            txtComplemento.IsEnabled = true;
            txtCidade.IsEnabled = true;
            txtBairro.IsEnabled = true;
            cbUF.IsEnabled = true;

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
                   if(modo=="Incluir")
                   {
                    // comando SQL para inserir - Insert Into
                    sql = @"insert into Fornecedor
                    (Nome,Fantasia,Cnpj,IE,Email,Telefone,Contato,DtCadastro,Ativo,Cep,Endereco,Numero,Complemento,Cidade,Bairro,Uf)
                    Values('" + txtNome.Text + "','" + txtNomeFantasia.Text + "','" + txtCnpj.Text + "','" + txtIE.Text + "','" + txtEmail.Text + "','" + txtTelefone.Text + "','" + txtContato.Text + "','" + data.ToString() + "','" + cbAtivo.Text + "','" + txtCep.Text + "','" + txtEndereco.Text + "','" + txtNumero.Text + "','" + txtComplemento.Text + "','" + txtCidade.Text + "','" + txtBairro.Text + "','" + cbUF.Text + "')";


                    MessageBox.Show("Cadastrado com Sucesso!");
                   



            }
            else if(botao=="Editar")
            {
               
                   
                    // comando SQL para inserir - Insert Into
                    string _Atualizar = @"Update Fornecedor Set 
                                     nome ='" + txtNome.Text + "',Fantasia ='" + txtNomeFantasia + "',Cnpj ='" + txtCnpj.Text + "',IE ='" + txtIE.Text + "',Email ='" + txtEmail.Text + "',Telefone ='" + txtTelefone.Text + "',Contato ='" + txtContato.Text + "',DtCadastro ='" + data.ToString() + "',Ativo ='" + cbAtivo.Text + "',Cep ='" + txtCep.Text + "',Endereco ='" + txtEndereco.Text + "',Numero ='" + txtNumero.Text + "',Complemento ='" + txtComplemento.Text + "',Cidade ='" + txtCidade.Text + "',Bairro ='" + txtBairro.Text + "',Uf ='" + cbUF.Text + "'where codigo_fornecedor = " + codigo_fornecedor;

                     MessageBox.Show("Alterado com Sucesso !");   
                    
            }
                SqlCommand codigo = new SqlCommand(sql, conexao);
                codigo.ExecuteNonQuery();
                conexao.Close();
                Close();
               
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no banco!");
            }
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        
    }
}
