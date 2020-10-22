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
    /// Interaction logic for Atendimento.xaml
    /// </summary>
    public partial class Atendimento : Window
    {
        string modo;
        public Atendimento()
        {
            InitializeComponent();
        }

        private void btNovo_Click(object sender, RoutedEventArgs e)
        {
            modo = "Novo";
            NovoConsultarAtendimento novo = new NovoConsultarAtendimento(modo);
            novo.ShowDialog();
        }
    }
}
