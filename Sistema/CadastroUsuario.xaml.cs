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
    /// Interaction logic for CadastroUsuario.xaml
    /// </summary>
    public partial class CadastroUsuario : Window
    {
        string codigo_usuario;
        string botao;

        public CadastroUsuario()
        {
            InitializeComponent();
        }
        public void VinculaDados()
        {

            SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


            try
            {
                Con.Open();
                SqlDataAdapter _Adapter = new SqlDataAdapter("Select * from Usuario", Con);

                DataSet _ds = new DataSet();
                _Adapter.Fill(_ds, "usuarioDataBinding");


                dtgUsuario.DataContext = _ds;
            }
            catch (SqlException)
            {
                MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                Con.Close();
            }


        }

        private void dtgUsuario_Loaded(object sender, RoutedEventArgs e)
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

        private void dtgUsuario_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView _dv = dtgUsuario.CurrentCell.Item as DataRowView;

                if (_dv != null)
                {
                    codigo_usuario = _dv.Row[0].ToString();

                    
                    btEditar.IsEnabled = true;
                    btExcluir.IsEnabled = true;
                   

                  
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
           
            btEditar.IsEnabled = false;
            btExcluir.IsEnabled = false;
          
            SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


            try
            {
                Con.Open();

                string _Select = "Select * from Usuario where codigo_usuario=" + codigo_usuario;

                // inicializa o comando e a conexão
                SqlCommand _cmdSelect = new SqlCommand(_Select, Con);
                SqlDataReader resultado = _cmdSelect.ExecuteReader();
                resultado.Read();
                if (resultado.HasRows == true)
                {
                    txtNome.Text = resultado["nome"] + "";
                    txtUsuario.Text = resultado["usuario"] + "";
                    txtSenha.Text = resultado["senha"] + "";
                    cbTipoAcesso.Text = resultado["tipo"] + "";
                    txtFuncao.Text = resultado["cargo"] + "";


                }
                Con.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                Con.Close();
            }
        }

        private void btCadastrar_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");
           
            if (txtNome.Text == "")
            {
                MessageBox.Show("O campo NOME não pode ficar em branco.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else if (txtFuncao.Text == "")
            {
                MessageBox.Show("O campo FUNÇÃO não pode ficar em branco.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else if (cbTipoAcesso.Text == "")
            {
                MessageBox.Show("O campo TIPO DE ACESSO não pode ficar em branco.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else if (txtUsuario.Text == "")
            {
                MessageBox.Show("O campo USUÁRIO não pode ficar em branco.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else if (txtSenha.Text == "")
            {
                MessageBox.Show("O campo SENHA não pode ficar em branco.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else
            {
                if (botao == "Editar")
                {


                    try
                    {
                        Con.Open();
                        // comando SQL para inserir - Insert Into
                        string _Atualizar = @"Update Usuario Set 
                                     nome ='" + txtNome.Text + "', usuario ='" + txtUsuario.Text + "',senha ='" + txtSenha.Text + "',tipo ='" + cbTipoAcesso.Text + "',cargo ='" + txtFuncao.Text + "'where codigo_usuario = " + codigo_usuario;

                        // inicializa o comando e a conexão
                        SqlCommand _cmdAtualizar = new SqlCommand(_Atualizar, Con);
                        // executa o comando
                        _cmdAtualizar.ExecuteNonQuery();

                        MessageBox.Show("Alterado com Sucesso !");

                        Con.Close();
                        txtNome.Text = string.Empty;
                        txtUsuario.Text = string.Empty;
                        txtSenha.Text = string.Empty;
                        cbTipoAcesso.Text = string.Empty;
                        txtFuncao.Text = string.Empty;
                        btEditar.IsEnabled = false;
                        this.VinculaDados();

                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                        Con.Close();
                        txtNome.Text = string.Empty;
                        txtUsuario.Text = string.Empty;
                        txtSenha.Text = string.Empty;
                        cbTipoAcesso.Text = string.Empty;
                        txtFuncao.Text = string.Empty;
                        btEditar.IsEnabled = false;
                    }
                }
                else
                {
                    try
                    {
                        Con.Open();
                        string _Inserir = @"insert into Usuario
                    (nome, usuario, senha, tipo, cargo)
                    Values('" + txtNome.Text + "','" + txtUsuario.Text + "','" + txtSenha.Text + "','" + cbTipoAcesso.Text + "','" + txtFuncao.Text + "')";


                        // inicializa o comando e a conexão
                        SqlCommand _cmd = new SqlCommand(_Inserir, Con);
                        // executa o comando
                        _cmd.ExecuteNonQuery();
                        MessageBox.Show("Adicinado com Sucesso!");
                        Con.Close();
                        txtNome.Text = string.Empty;
                        txtUsuario.Text = string.Empty;
                        txtSenha.Text = string.Empty;
                        cbTipoAcesso.Text = string.Empty;
                        txtFuncao.Text = string.Empty;
                        this.VinculaDados();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Não foi possivel conectar com o Banco" + ex, "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                        Con.Close();
                    }

                }
                // comando SQL para inserir - Insert Into

                       
            }
            
        }

        private void btExcluir_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


            try
            {
                Con.Open();
                // Command String
                string _Deletar = @"Delete from Usuario
                                  Where codigo_usuario = " + codigo_usuario;

                // inicializa o comando e a conexão
                SqlCommand _cmdDeletar = new SqlCommand(_Deletar, Con);
                // executa o comando
                _cmdDeletar.ExecuteNonQuery();

                MessageBox.Show("Excluido com Sucesso !");
                btEditar.IsEnabled = false;
                btExcluir.IsEnabled = false;
                txtNome.Text = string.Empty;
                txtUsuario.Text = string.Empty;
                txtSenha.Text = string.Empty;
                cbTipoAcesso.Text = string.Empty;
                txtFuncao.Text = string.Empty;
               
                this.VinculaDados();
              
                Con.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                Con.Close();
                btEditar.IsEnabled = false;
                btExcluir.IsEnabled = false;
            }
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
