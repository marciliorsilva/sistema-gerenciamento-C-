using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sistema
{
    /// <summary>
    /// Interaction logic for ImpressaoOrdemServicoEntrada.xaml
    /// </summary>
    public partial class ImpressaoOrdemServicoEntrada : Window
    {
        string codigo;
        string nome_usuario;
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

        public ImpressaoOrdemServicoEntrada(string codigo, string nome_usuario, string tipo, string Nome, string cpfCnpj, string identidade,string ie, string email, string telefone, string contato, string endereco, string cep, string cidade, string bairro, string uf, string equipamento, string nrSerie, string modelo, string marca, string defeito, string observacao, string data)
        {
            this.codigo = codigo;
            this.nome_usuario = nome_usuario;
            this.tipo = tipo;
            this.Nome = Nome;
            this.cpfCnpj = cpfCnpj;
            this.identidade = identidade;
            this.ie = ie;
            this.email = email;
            this.telefone = telefone;
            this.contato = contato;
            this.endereco = endereco;
            this.cep = cep;
            this.cidade = cidade;
            this.bairro = bairro;
            this.uf = uf;
            this.equipamento = equipamento;
            this.nrSerie = nrSerie;
            this.modelo = modelo;
            this.marca = marca;
            this.defeito = defeito;
            this.observacao = observacao;
            this.data = data;


            InitializeComponent();
            NumeroOS.Content = codigo;
            lbnomeTecnico.Content = nome_usuario;
            lbcliente.Content = Nome;
            lbdtEntrada.Content = data;
            lbcpfCnpj.Content = cpfCnpj;
            if (tipo == "JURÍDICO")
            {
                lbrgIE.Content = ie;
            }
            else
            {
                lbrgIE.Content = identidade;
            }
            lbendereco.Content = endereco;
            lbcep.Content = cep;
            lbbairro.Content = bairro;
            lbcidade.Content = cidade;
            lbtelefone.Content = telefone;
            lbemail.Content = email;
            lbequipamento.Content = equipamento;
            lbnSerie.Content = nrSerie;
            lbmodelo.Content = modelo;
            lbmarca.Content = marca;
            lbdefeito.Content = defeito;
            lbobservacao.Content = observacao;
            lbuf.Content = uf;
            
        }

        private void btImprimir_Click(object sender, RoutedEventArgs e)
        {
          PrintDialog printDlg = new PrintDialog ();
          printDlg.PrintVisual(impressao, "Impressão Grid.");

            
        }
    }
}
