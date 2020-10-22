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
        public OrdemServico()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            OrdemServicoEntrada entrada = new OrdemServicoEntrada();
            entrada.ShowDialog();

        }
    }
}
