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
    /// Interaction logic for ListaConsultaPecasEstoque.xaml
    /// </summary>
    public partial class ListaConsultaPecasEstoque : Window
    {
        string modo;
        string nome_peca;
        public ListaConsultaPecasEstoque(string modo, string nome_peca)
        {
            this.modo = modo;
            this.nome_peca = nome_peca;
            InitializeComponent();
        }
    }
}
