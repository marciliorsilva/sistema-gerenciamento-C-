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
    /// Interaction logic for Apontamento.xaml
    /// </summary>
    public partial class Apontamento : Window
    {
        string nome_usario;
        public Apontamento(string nome_usario)
        {
            this.nome_usario = nome_usario;
            InitializeComponent();
        }

        private void btCadastrar_Click(object sender, RoutedEventArgs e)
        {
            IncluirConsultarApontamento cadastrar = new IncluirConsultarApontamento(nome_usario);
            cadastrar.ShowDialog();
        }
    }
}
