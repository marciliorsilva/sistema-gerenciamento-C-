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
    /// Interaction logic for OrdemServicoEntrada.xaml
    /// </summary>
    public partial class OrdemServicoEntrada : Window
    {
        string codigo_cliente;
        string nome_usuario;
        string nome_filial;
        string nome_cliente;
        string modo;
        string codigo_osEntrada;

        string codigo;
       
        string tipo;
        string Nome;
        string cpfCnpj;
        string identidade;
        string ie;
        string email;
        string telefone;
        string contato;
        string endereco;
        string cep;
        string cidade;
        string bairro;
        string uf;
        string equipamento;
        string nrSerie;
        string modelo;
        string marca;
        string defeito;
        string observacao;
        string data;
      
        NovoConsultarAtendimento formaPai;
    

        public OrdemServicoEntrada(string modo, string codigo_osEntrada, string nome_usuario, string nome_cliente, string nome_filial)
        {
            this.modo = modo;
            this.codigo_osEntrada = codigo_osEntrada;
            this.nome_usuario = nome_usuario;
            this.nome_cliente = nome_cliente;
            this.nome_filial = nome_filial;
          
            InitializeComponent();
          
          
            Random random = new Random();
            int i = random.Next(0, 1000);
            txtCodigoOs.Text = "OS"+i.ToString();
            DateTime data = DateTime.Now;
            dpDataEntrada.Text = data + "";

            MessageBox.Show(nome_cliente + "" + nome_filial + " " + modo);
            
           
           
            
        }

      
        private void cbEqpt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          txtDefeito.IsEnabled = true;
            txtObs.IsEnabled = true;
            /*string eqpt = cbEqpt.SelectedItem.ToString();
          string[] colunas = eqpt.Split('|');
          nrSerie = colunas[1];*/
                  
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btImpressao_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");
            string nome = txtCliente.Text;
            string eqpt = cbEqpt.SelectedItem.ToString();
            string[] colunas = eqpt.Split('|');
            equipamento=colunas[0];
            nrSerie = colunas[1];
            modelo = colunas[2];
            marca = colunas[3];
            defeito = txtDefeito.Text;
            observacao = txtObs.Text;
            codigo = txtCodigoOs.Text;
            data = dpDataEntrada.DisplayDate.ToShortDateString();
            if (modo != "Filial")
            {
                try
                {
                    Con.Open();



                    string _Select = "Select * from Cliente where Nome='" + txtCliente.Text + "'";

                    // inicializa o comando e a conexão
                    SqlCommand _cmdSelect = new SqlCommand(_Select, Con);
                    SqlDataReader resultado = _cmdSelect.ExecuteReader();
                    resultado.Read();
                    if (resultado.HasRows == true)
                    {

                        tipo = resultado["Tipo"] + "";
                        Nome = resultado["Nome"] + "";
                        cpfCnpj = resultado["cpfCnpj"] + "";
                        identidade = resultado["Identidade"] + "";
                        ie = resultado["IE"] + "";
                        email = resultado["Email"] + "";
                        telefone = resultado["Telefone"] + "";
                        contato = resultado["Contato"] + "";
                        endereco = resultado["Endereco"] + "";
                        cep = resultado["Cep"] + "";
                        cidade = resultado["Cidade"] + "";
                        bairro = resultado["Bairro"] + "";
                        uf = resultado["Uf"] + "";

                    }
                    Con.Close();



                }
                catch (SqlException )
                {
                    MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                    Con.Close();
                }

            }

            if(modo != "Matriz")
            {
                try
                {
                    Con.Open();



                    string _Select = "Select * from Filial where Nome='" + txtCliente.Text + "'";

                    // inicializa o comando e a conexão
                    SqlCommand _cmdSelect = new SqlCommand(_Select, Con);
                    SqlDataReader resultado = _cmdSelect.ExecuteReader();
                    resultado.Read();
                    if (resultado.HasRows == true)
                    {

                        tipo = resultado["Tipo"] + "";
                        Nome = resultado["Nome"] + "";
                        cpfCnpj = resultado["cpfCnpj"] + "";
                        identidade = resultado["Identidade"] + "";
                        ie = resultado["IE"] + "";
                        email = resultado["Email"] + "";
                        telefone = resultado["Telefone"] + "";
                        contato = resultado["Contato"] + "";
                        endereco = resultado["Endereco"] + "";
                        cep = resultado["Cep"] + "";
                        cidade = resultado["Cidade"] + "";
                        bairro = resultado["Bairro"] + "";
                        uf = resultado["Uf"] + "";

                    }
                    Con.Close();



                }
                catch (SqlException )
                {
                    MessageBox.Show("Não foi possivel conectar com o Banco" , "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                    Con.Close();
                }
            
            
            
            }

            ImpressaoOrdemServicoEntrada imprimir = new ImpressaoOrdemServicoEntrada(codigo,nome_usuario,tipo,Nome,cpfCnpj,identidade,ie,email,telefone,contato,endereco,cep,cidade,bairro,uf,equipamento,nrSerie,modelo,marca,defeito,observacao,data);
            imprimir.ShowDialog();
        }

        private void btPesquisa_Click(object sender, RoutedEventArgs e)
        {
            string atend = "OScli";

            Cliente cliente = new Cliente(atend, nome_usuario,formaPai,this);

            cliente.ShowDialog();
            cbEqpt.SelectedItem = "";
            
        }

       
        
       
        
    }
}
