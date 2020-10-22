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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");
                               
          
            try
            {
                Con.Open();

                try
                {
                    string usuario = txtUsuario.Text;
                    string senha = pbSenha.Password;
                    string tipo_usuario = "";
                    string codigo_usuario = "";
                    string nome_usario = "";
                    string cargo = "";
                    if (txtUsuario.Text == "")
                    {
                        MessageBox.Show("Degite o Usuário.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        SqlCommand command = new SqlCommand("select * from Usuario where usuario='" + usuario + "' and senha='" + senha + "'", Con);
                        SqlDataReader reader = null;
                        reader = command.ExecuteReader();

                        if (reader.Read() == true)
                        {
                            tipo_usuario = reader["tipo"] + "";
                            codigo_usuario = reader["codigo_usuario"] + "";
                            nome_usario = reader["nome"] + "";
                            cargo = reader["cargo"] + "";
                            Adm login = new Adm(tipo_usuario, codigo_usuario, nome_usario, cargo);
                            Close();
                            login.ShowDialog();

                        }
                        else
                        {
                            MessageBox.Show("O nome do Usuário ou à Senha estão Incorretos.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                            Con.Close();
                        }
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Erro no Banco!");
                    Con.Close();
                }

            }
            catch(SqlException)
            {
                MessageBox.Show("Não foi possivel conectar com o Banco!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                Con.Close();
            }

          }
    }
}
