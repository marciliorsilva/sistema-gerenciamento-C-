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
    /// Interaction logic for IncluirConsultarApontamento.xaml
    /// </summary>
    public partial class IncluirConsultarApontamento : Window
    {
        string nome;
        string data;
        string nome_usario;
        public IncluirConsultarApontamento(string nome_usario)
        {
            this.nome_usario = nome_usario;
            InitializeComponent();
            
            try
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
                // comando SQL

                string _Select = "Select * from Cliente ";

                // inicializa o comando e a conexão
                SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                SqlDataReader resultado = _cmdSelect.ExecuteReader();
                while (resultado.Read())
                {

                    cbCliente.Items.Add(resultado["Nome"] + "");


                }

                conexao.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no banco!" + ex.ToString());
            }
        }

        public class ClienteApontamento
        {
            public string Nome { get; set; }
            public string dtTratamento { get; set; }
           
        }
        private void cbCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            

        }

        private void dtgApontFilial_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView _dv = dtgApontFilial.CurrentCell.Item as DataRowView;

                if (_dv != null)
                {
                    nome = _dv.Row[0].ToString();
                    
                }
                else
                {
                   

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (data == "")
            {
                MessageBox.Show("O campo 'Tratado até' não pode ficar em branco.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else if(dtPeriodoFinal.Text=="")
            {
             MessageBox.Show("O campo Período Final não pode ficar em branco.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);


            }
            else if (dtPeriodoInicial.Text == "")
            {
                MessageBox.Show("O campo Período Inicial não pode ficar em branco.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);


            }
            else
            {

                SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");
              

                string periodoInical = dtPeriodoInicial.DisplayDate.ToShortDateString();
                string periodoFinal = dtPeriodoFinal.DisplayDate.ToShortDateString();

                try
                {
                    Con.Open();
                    string _Inserir = @"insert into Apontamento
                    (cliente,dtTratamento,periodoInicial,periodoFinal,usuario)
                    Values('" + nome + "','"+"'convert(smalldatetime,'" + data.ToString() + "',103)'"+"',convert(smalldatetime,'" + periodoFinal.ToString() + "',103)'"+"',convert(smalldatetime,'" + periodoFinal.ToString() + "',103),'" + nome_usario + "'";
                    

                    // inicializa o comando e a conexão
                    SqlCommand _cmd = new SqlCommand(_Inserir, Con);
                    // executa o comando
                    _cmd.ExecuteNonQuery();
                    MessageBox.Show("Adicinado com Sucesso!");


                }
                catch (SqlException)
                {
                    MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                    Con.Close();
                }
            }
        }

        private void dtgApontFilial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
    }
}
