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
    /// Interaction logic for CategoriaFornecedor.xaml
    /// </summary>
    public partial class CategoriaEqpt : Window
    {
        string codigo_categoria;
        string botao;
        string descricao;
        public CategoriaEqpt()
        {
            InitializeComponent();
        }
        public void VinculaDados()
        {

            SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


            try
            {
                Con.Open();
                SqlDataAdapter _Adapter = new SqlDataAdapter("Select * from categoriaEqpt ORDER BY Descricao ASC", Con);

                DataSet _ds = new DataSet();
                _Adapter.Fill(_ds, "categoriaDataBinding");


                dtgCategoria.DataContext = _ds;
            }
            catch (SqlException)
            {
                MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                Con.Close();
            }
                                  

        }

        private void dtgCategoria_Loaded(object sender, RoutedEventArgs e)
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

        private void dtgCategoria_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView _dv = dtgCategoria.CurrentCell.Item as DataRowView;

                if (_dv != null)
                {
                   codigo_categoria = _dv.Row[0].ToString();
                   descricao = _dv.Row[1].ToString();
                   btAlterar.IsEnabled = true;
                   btExcluir.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btAlterar_Click(object sender, RoutedEventArgs e)
        {
            botao = "Alterar";
            txtDescricao.Text = descricao;

        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtDescricao.Text == "")
            {
                MessageBox.Show("O campo CATEGORIA não pode ficar em branco.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else
            {

                SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");



                try
                {
                    Con.Open();
                    string _Inserir = @"insert into categoriaEqpt
                    (Descricao)
                    Values('" + txtDescricao.Text + "')";


                    // inicializa o comando e a conexão
                    SqlCommand _cmd = new SqlCommand(_Inserir, Con);
                    // executa o comando
                    _cmd.ExecuteNonQuery();
                    MessageBox.Show("Adicinado com Sucesso!");
                    Con.Close();
                    txtDescricao.Text = string.Empty;
                    this.VinculaDados();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                    Con.Close();
                }


                // comando SQL para inserir - Insert Into



                if (botao == "Alterar")
                {


                    try
                    {
                        Con.Open();
                        // comando SQL para inserir - Insert Into
                        string _Atualizar = @"Update categoriaEqpt Set 
                                     Descricao ='" + txtDescricao.Text + "'where codigo_categoria = " + codigo_categoria;

                        // inicializa o comando e a conexão
                        SqlCommand _cmdAtualizar = new SqlCommand(_Atualizar, Con);
                        // executa o comando
                        _cmdAtualizar.ExecuteNonQuery();

                        MessageBox.Show("Alterado com Sucesso !");
                        this.VinculaDados();
                        Con.Close();
                        txtDescricao.Text = string.Empty;
                        btAlterar.IsEnabled = false;
                        btExcluir.IsEnabled = false;
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                        Con.Close();
                        txtDescricao.Text = string.Empty;
                        btAlterar.IsEnabled = false;
                        btExcluir.IsEnabled = false;
                    }
                }
            }
                             
                        

        }

        private void btExcluir_Click(object sender, RoutedEventArgs e)
        {
           

                SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


                try
                {
                    Con.Open();
                    // Command String
                    string _Deletar = @"Delete from categoriaEqpt
                                  Where codigo_categoria = " + codigo_categoria;

                    // inicializa o comando e a conexão
                    SqlCommand _cmdDeletar = new SqlCommand(_Deletar, Con);
                    // executa o comando
                    _cmdDeletar.ExecuteNonQuery();

                    MessageBox.Show("Excluido com Sucesso !");
                    btAlterar.IsEnabled = false;
                    btExcluir.IsEnabled = false;
                    this.VinculaDados();
                    Con.Close();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                    Con.Close();
                    btAlterar.IsEnabled = false;
                    btExcluir.IsEnabled = false;
                }

              
            
          
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

      
             

    }
}
