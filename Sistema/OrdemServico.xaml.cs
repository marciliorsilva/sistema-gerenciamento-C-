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
    /// Interaction logic for OrdemServico.xaml
    /// </summary>
    public partial class OrdemServico : Window
    {
        string nome_filial;
        string nome_cliente;
        string modo;
        string codigo_osEntrada;
        string nome_usuario;

        public OrdemServico(string nome_usuario)
        {
            this.nome_usuario = nome_usuario;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
         
            OrdemServicoEntrada entrada = new OrdemServicoEntrada(modo, codigo_osEntrada, nome_usuario, nome_cliente, nome_filial);
            entrada.ShowDialog();

        }
    }
}
