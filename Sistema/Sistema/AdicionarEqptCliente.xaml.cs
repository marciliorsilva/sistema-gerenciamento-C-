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
    /// Interaction logic for AdicionarEqptCliente.xaml
    /// </summary>
    public partial class AdicionarEqptCliente : Window
    {
        string modo;
        string codigo_estoque;
        string codigo_cliente;
        public AdicionarEqptCliente(string codigo_cliente)
        {
            this.codigo_cliente = codigo_cliente;
            InitializeComponent();
        }

        private void btNovoEqpt_Click(object sender, RoutedEventArgs e)
        {
            modo = "NovoEqptCliente";
            IncluirConsultarEstoque novo = new IncluirConsultarEstoque(modo,codigo_estoque,codigo_cliente);
            novo.ShowDialog();
            Close();
        }

        private void btAddEstoque_Click(object sender, RoutedEventArgs e)
        {
            modo = "AddEqptCliente";
            Estoque add = new Estoque(modo,codigo_cliente);
            add.ShowDialog();
            Close();
            
        }
    }
}
