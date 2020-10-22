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
    /// Interaction logic for Adm.xaml
    /// </summary>
    public partial class Adm : Window
    {
        string codigo_cliente;
        string modo;
        public Adm()
        {
            InitializeComponent();

        }

        private void FornecedorCadastro_MenuClick(object sender, RoutedEventArgs e)
        {
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.ShowDialog();
        }

        private void EquipamentoCadastro_MenuClick(object sender, RoutedEventArgs e)
        {
            Equipamento equipamento = new Equipamento();
            equipamento.ShowDialog();
        }

        private void CategoriaCadastro_MenuClick(object sender, RoutedEventArgs e)
        {
            CategoriaEqpt categoriaEqpt = new CategoriaEqpt();
            categoriaEqpt.ShowDialog();
        }

        private void EntradaEqpt_MenuClick(object sender, RoutedEventArgs e)
        {
            EntradaEqpt entrada = new EntradaEqpt();
            entrada.ShowDialog();
        }

        private void ReceberEqpt_MenuClick(object sender, RoutedEventArgs e)
        {
            Estoque receberEqpt = new Estoque(modo,codigo_cliente);
            receberEqpt.ShowDialog();
        }

        private void CadastrarCliente_MenuClick(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.ShowDialog();
        }

        private void Atendimento_MenuClick(object sender, RoutedEventArgs e)
        {
            Atendimento atendimento = new Atendimento();
            atendimento.ShowDialog();

        }

        private void EntradaOs_MenuClick(object sender, RoutedEventArgs e)
        {
            OrdemServico entrada = new OrdemServico();
            entrada.ShowDialog();
        }

        private void Pecas_MenuClick(object sender, RoutedEventArgs e)
        {
            Pecas pecas = new Pecas();
            pecas.ShowDialog();
        }

        private void ReceberPecas_MenuClick(object sender, RoutedEventArgs e)
        {
            EstoquePecas estoquePecas = new EstoquePecas();
            estoquePecas.ShowDialog();
        }

        
    }
}
