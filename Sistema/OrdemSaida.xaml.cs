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
    /// Interaction logic for OrdemSaida.xaml
    /// </summary>
    public partial class OrdemSaida : Window
    {
        string nome_usuario;
        public OrdemSaida(string nome_usuario)
        {
            this.nome_usuario = nome_usuario;
            InitializeComponent();
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            ordemServicoSaida osSaida = new ordemServicoSaida(nome_usuario);
            osSaida.ShowDialog();
        }
    }
}
