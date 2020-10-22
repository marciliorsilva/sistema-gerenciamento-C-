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
    /// Interaction logic for NovoConsultarAtendimento.xaml
    /// </summary>
    public partial class NovoConsultarAtendimento : Window
    {


        string modo;
        string botao; 
        string nome_usuario;
        string codigo_usuario;
        string codigo_atendimento;
        string nome_cliente;
        string nome_filial;
        NovoConsultarAtendimento formapai;
        OrdemServicoEntrada formPaiOS;
    
        public NovoConsultarAtendimento(string modo, string codigo_atendimento, string nome_usuario,string nome_cliente, string nome_filial)
        {
            this.modo = modo;
            this.codigo_atendimento = codigo_atendimento;
            this.nome_usuario = nome_usuario;
            this.nome_cliente = nome_cliente;
            this.nome_filial = nome_filial;
            InitializeComponent();
            txtCliente.Text = nome_cliente;

            

            if (modo == "Novo")
            {
                DateTime data = DateTime.Now;
                dpData.Text = data + "";
                DateTime hora = DateTime.Now;
                txtHora.Text = hora.Hour+":"+hora.Minute+ "";
                btEditar.IsEnabled = false;
                       
            }
            else
            {
                btEditar.IsEnabled = true;
                dpData.IsEnabled = false;
                txtHora.IsEnabled = false;
                txtContato.IsEnabled = false;
                txtDescricao.IsEnabled = false;
                txtCliente.IsEnabled = false;
                cbSituacao.IsEnabled = false;
                btCadastrar.IsEnabled = false;
                cbMotivo.IsEnabled = false;
                

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

                    string _Select = "select *, usuario.nome as Usuario from Atendimento inner join usuario on Atendimento.codigo_usuario = usuario.codigo_usuario where codigo_Atendimento =" + codigo_atendimento;

                    // inicializa o comando e a conexão
                    SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                    SqlDataReader resultado = _cmdSelect.ExecuteReader();
                    resultado.Read();

                    if (resultado.HasRows == true)
                    {
                        dpData.Text = resultado["dataEntrada"] + "";
                        txtHora.Text = resultado["horaEntrada"] + "";
                        cbMotivo.Text = resultado["motivo"] + "";
                        txtCliente.Text = resultado["Cliente"] + "";
                        txtContato.Text = resultado["contato"] + "";
                        txtDescricao.Text = resultado["descricao"] + "";
                        cbSituacao.Text = resultado["situacao"] + "";
                        dpResolvido.Text = resultado["dataResolvido"] + "";
                        txtHoraResolvido.Text = resultado["horaResolvido"] + "";
                        txtResolvidoPor.Text = resultado["resolvidoPor"] + "";
                        txtConclusao.Text = resultado["conclusao"] + "";
                                     
                        

                    }

                   
                 
                    conexao.Close();


                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Erro no banco!" + ex.ToString());
                }

            }
        }

        private void btPesquisaCli_Click(object sender, RoutedEventArgs e)
        {
            string atend = "pesquisaCli";
           
            Cliente cliente = new Cliente(atend, nome_usuario,this,formPaiOS);
         
            cliente.ShowDialog();
           
          
          

        }

        private void btEditar_Click(object sender, RoutedEventArgs e)
        {
            botao = "Editar";
            btEditar.IsEnabled = false;
            dpData.IsEnabled = true;
            txtHora.IsEnabled = true;
            txtContato.IsEnabled = true;
            txtDescricao.IsEnabled = true;
            txtCliente.IsEnabled = true;
            cbSituacao.IsEnabled = true;
            btCadastrar.IsEnabled = true;
            cbMotivo.IsEnabled = true;

        }

        private void cbSituacao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (modo == "Novo" || botao=="Editar")
            {

                if (cbSituacao.SelectedIndex == 2)
                {
                    DateTime data = DateTime.Now;
                    dpResolvido.Text = data + "";
                    DateTime hora = DateTime.Now;
                    txtHoraResolvido.Text = hora.Hour + ":" + hora.Minute + "";
                    dpResolvido.IsEnabled = true;
                    txtHoraResolvido.IsEnabled = true;
                    txtConclusao.IsEnabled = true;
                    txtResolvidoPor.Text = nome_usuario;
                }
                else
                {
                    dpResolvido.Text = string.Empty;
                    txtHoraResolvido.Text = string.Empty;
                    txtResolvidoPor.Text = string.Empty;
                    txtConclusao.Text = string.Empty;
                    txtConclusao.IsEnabled = false;
                    dpResolvido.IsEnabled = false;
                    txtHoraResolvido.IsEnabled = false;
                    txtResolvidoPor.IsEnabled = false;
                    txtConclusao.IsEnabled = false;

                }
            }
           
        }

        private void btCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (cbMotivo.Text == "")
            {
                MessageBox.Show("O campo MOTIVO não pode ficar em branco.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else if (txtCliente.Text == "")
            {
                MessageBox.Show("O campo Cliente não pode ficar em branco.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else if (cbSituacao.Text == "")
            {
                MessageBox.Show("O campo SITUAÇÃO não pode ficar em branco.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else
            {

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

                    string _Select = "Select * from usuario where nome='" + nome_usuario + "'";

                    // inicializa o comando e a conexão
                    SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                    SqlDataReader resultado = _cmdSelect.ExecuteReader();
                    resultado.Read();

                    codigo_usuario = resultado["codigo_usuario"] + "";


                    conexao.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }




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
                    string sql = "";

                    string dataSaida = dpData.DisplayDate.ToShortDateString();
                    string dataResolvido = dpResolvido.DisplayDate.ToShortDateString();

                    if (modo == "Novo")
                    {
                        sql = @"insert into Atendimento(cliente, codigo_usuario,dataEntrada,horaEntrada,motivo,contato,descricao,situacao,dataResolvido,horaResolvido,resolvidoPor,conclusao)
                        Values('" + txtCliente.Text + "','" + codigo_usuario + "',convert(smalldatetime,'" + dataSaida.ToString() + "',103),'" + txtHora.Text + "','" + cbMotivo.Text + "','" + txtContato.Text + "','" + txtDescricao.Text + "','" + cbSituacao.Text + "',convert(smalldatetime,'" + dataResolvido.ToString() + "',103),'" + txtHoraResolvido.Text + "','" + txtResolvidoPor.Text + "','" + txtConclusao.Text + "')";

                        MessageBox.Show("Atendimento cadastrado com sucesso!");
                    }
                    else if (botao == "Editar")
                    {
                        sql = @"Update Atendimento Set cliente= '" + txtCliente.Text + "',dataEntrada=convert(smalldatetime,'" + dataSaida.ToString() + "',103),horaEntrada='" + txtHora.Text + "',contato='" + txtContato.Text + "',descricao='" + txtDescricao.Text + "',situacao='" + cbSituacao.Text + "',dataResolvido=convert(smalldatetime,'" + dataResolvido.ToString() + "',103),horaResolvido='" + txtHoraResolvido.Text + "',resolvidoPor='" + txtResolvidoPor.Text + "',conclusao='" + txtConclusao.Text + "' where codigo_atendimento='" + codigo_atendimento + "'";
                        MessageBox.Show("Atendimento alterado com Sucesso !");

                    }


                    SqlCommand codigo = new SqlCommand(sql, conexao);
                    codigo.ExecuteNonQuery();
                    Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Erro no banco!" + ex.ToString());
                }
            }




        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

       

       
                
    }
}
