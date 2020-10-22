﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace Sistema
{
    /// <summary>
    /// Interaction logic for EntradaEqpt.xaml
    /// </summary>
    public partial class EntradaEqpt : Window
    {

        string codigo_entrada;
        string modo;
        public EntradaEqpt()
        {
            InitializeComponent();
        }
        public void VinculaDados()
        {

            SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


            try
            {
                Con.Open();

                SqlDataAdapter _Adapter = new SqlDataAdapter("select Entrada.codigo_entrada as Codigo, Entrada.notaFiscal as NotaFiscal, convert(CHAR,dtPedido,101) as dataContrato  as Data,Fornecedor.Nome as Fornecedor,Equipamento.descricao as Equipamento,entradaEqpt.quantidade as Quantidade,entradaEqpt.observacao as Observação,entradaEqpt.situacao as Situação from Entrada inner join entradaEqpt on Entrada.codigo_entrada = entradaEqpt.numeroPedido inner join Fornecedor on Entrada.codigo_fornecedor = Fornecedor.codigo_fornecedor inner join Equipamento on entradaEqpt.codigo_equipamento = Equipamento.codigo_equipamento", Con);

                DataSet _ds = new DataSet();
                _Adapter.Fill(_ds, "entradaDataBinding");


                dtgEntrada.DataContext = _ds;

                // Fecha a conexão
                Con.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                Con.Close();
            }

        }
        private void dtgEntrada_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.VinculaDados();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void dtgEntrada_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView _dv = dtgEntrada.CurrentCell.Item as DataRowView;

                if (_dv != null)
                {
                    codigo_entrada = _dv.Row[0].ToString();
                    btConsultar.IsEnabled = true;
                    btExcluir.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btIncluir_Click(object sender, RoutedEventArgs e)
        {
            modo = "Incluir";
            EntradaEqptConsulta incluir = new EntradaEqptConsulta(modo,codigo_entrada);
            incluir.ShowDialog();
            this.VinculaDados();
        }

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            modo = "Consultar";
            EntradaEqptConsulta consultar = new EntradaEqptConsulta(modo, codigo_entrada);
            consultar.ShowDialog();
            btExcluir.IsEnabled = false;
            btConsultar.IsEnabled = false;
            this.VinculaDados();

        }

        private void btExcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


                try
                {
                    Con.Open();
                    // Command String
                    string _Deletar = @"Delete from EntradaEqpt Where numeroPedido =" + Convert.ToInt32(codigo_entrada);
                    string _Deletar2 = @" Delete from Entrada Where codigo_entrada = " + Convert.ToInt32(codigo_entrada);

                    // inicializa o comando e a conexão
                    SqlCommand _cmdDeletar = new SqlCommand(_Deletar, Con);
                    SqlCommand _cmdDeletar2 = new SqlCommand(_Deletar2, Con);
                    // executa o comando
                    _cmdDeletar.ExecuteNonQuery();

                    MessageBox.Show("Excluido com Sucesso !");
                    btConsultar.IsEnabled = false;
                    btExcluir.IsEnabled = false;
                    this.VinculaDados();
                    Con.Close();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                    Con.Close();
                }

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco:" + ex.ToString());
                btConsultar.IsEnabled = false;
                btExcluir.IsEnabled = false;
            }
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

       
       
    }
}
