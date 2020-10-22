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
    /// Interaction logic for CategoriaFornecedor.xaml
    /// </summary>
    public partial class CategoriaEqpt : Window
    {
        string codigo_categoria;
        string botao;
        string descricao;
        public CategoriaEqpt()
        {
            InitializeComponent();
        }
        public void VinculaDados()
        {

            SqlConnection conexao = new SqlConnection();
            SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder();
            banco.DataSource = ".\\SQLEXPRESS";
            banco.InitialCatalog = "SISTEMA";
            banco.IntegratedSecurity = true;
            conexao.ConnectionString = banco.ConnectionString;

            conexao.Open();

            SqlDataAdapter _Adapter = new SqlDataAdapter("Select * from categoriaEqpt ORDER BY Descricao ASC", conexao);

            DataSet _ds = new DataSet();
            _Adapter.Fill(_ds, "categoriaDataBinding");


            dtgCategoria.DataContext = _ds;

            // Fecha a conexão
            conexao.Close();
        }

        private void dtgCategoria_Loaded(object sender, RoutedEventArgs e)
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

        private void dtgCategoria_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView _dv = dtgCategoria.CurrentCell.Item as DataRowView;

                if (_dv != null)
                {
                   codigo_categoria = _dv.Row[0].ToString();
                   descricao = _dv.Row[1].ToString();
                   btAlterar.IsEnabled = true;
                   btExcluir.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btAlterar_Click(object sender, RoutedEventArgs e)
        {
            botao = "Alterar";
            txtDescricao.Text = descricao;

        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection conexao = new SqlConnection();
                SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder();
                banco.DataSource = ".\\SQLEXPRESS";
                banco.InitialCatalog = "SISTEMA";
                banco.IntegratedSecurity = true;
                conexao.ConnectionString = banco.ConnectionString;

                conexao.Open();

                // comando SQL para inserir - Insert Into
                string _Inserir = @"insert into categoriaEqpt
                    (Descricao)
                    Values('" + txtDescricao.Text + "')";


                // inicializa o comando e a conexão
                SqlCommand _cmd = new SqlCommand(_Inserir, conexao);
                // executa o comando
                _cmd.ExecuteNonQuery();
                MessageBox.Show("Adicinado com Sucesso!");
                conexao.Close();
                txtDescricao.Text = string.Empty;
                this.VinculaDados();
             

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                txtDescricao.Text = string.Empty;
            }

            if (botao == "Alterar")
            {
                try
                {
                    SqlConnection conexao = new SqlConnection();
                    SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder();
                    banco.DataSource = ".\\SQLEXPRESS";
                    banco.InitialCatalog = "SISTEMA";
                    banco.IntegratedSecurity = true;
                    conexao.ConnectionString = banco.ConnectionString;

                    conexao.Open();

                    // comando SQL para inserir - Insert Into
                    string _Atualizar = @"Update categoriaEqpt Set 
                                     Descricao ='" + txtDescricao.Text +"'where codigo_categoria = " + codigo_categoria;

                    // inicializa o comando e a conexão
                    SqlCommand _cmdAtualizar = new SqlCommand(_Atualizar, conexao);
                    // executa o comando
                    _cmdAtualizar.ExecuteNonQuery();

                    MessageBox.Show("Alterado com Sucesso !");
                     this.VinculaDados();
                     conexao.Close();
                     txtDescricao.Text = string.Empty;
                     btAlterar.IsEnabled = false;
                     btExcluir.IsEnabled = false;
                   


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    txtDescricao.Text = string.Empty;
                      btAlterar.IsEnabled = false;
                     btExcluir.IsEnabled = false;
                }

            }



        }

        private void btExcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                SqlConnection conexao = new SqlConnection();
                SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder();
                banco.DataSource = ".\\SQLEXPRESS";
                banco.InitialCatalog = "SISTEMA";
                banco.IntegratedSecurity = true;
                conexao.ConnectionString = banco.ConnectionString;

                conexao.Open();

                // Command String
                string _Deletar = @"Delete from categoriaEqpt
                                  Where codigo_categoria = " +codigo_categoria;

                // inicializa o comando e a conexão
                SqlCommand _cmdDeletar = new SqlCommand(_Deletar, conexao);
                // executa o comando
                _cmdDeletar.ExecuteNonQuery();

                MessageBox.Show("Excluido com Sucesso !");
                btAlterar.IsEnabled = false;
                btExcluir.IsEnabled = false;
                this.VinculaDados();
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                btAlterar.IsEnabled = false;
                btExcluir.IsEnabled = false;
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

       
             

    }
}
