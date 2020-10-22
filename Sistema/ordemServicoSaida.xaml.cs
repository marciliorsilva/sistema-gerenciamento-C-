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
    /// Interaction logic for ordemServicoSaida.xaml
    /// </summary>
    public partial class ordemServicoSaida : Window
    {
        string modo;
        string codigo_spc, nome_usuario;
      
        public ordemServicoSaida(string nome_usuario)
        {
            this.nome_usuario = nome_usuario;
            InitializeComponent();
            
        }

        private void btAddPeca_Click(object sender, RoutedEventArgs e)
        {
            modo = "AddOrdemServico";
            IncluirConsultarPecasSaida incluir = new IncluirConsultarPecasSaida(modo, codigo_spc, nome_usuario, this);
            incluir.ShowDialog();
     
        }

        private void btEditarPeca_Click(object sender, RoutedEventArgs e)
        {
            

                modo = "EditarOrdemServico";
                txtLinha.Text = listProdutos.SelectedIndex.ToString();
                string produtos = listProdutos.SelectedItem.ToString();
                string[] colunas = produtos.Split('|');
                codigo_spc = colunas[0];

                IncluirConsultarPecasSaida editar = new IncluirConsultarPecasSaida(modo, codigo_spc, nome_usuario, this);
                editar.ShowDialog();
            
        }
    }
}
