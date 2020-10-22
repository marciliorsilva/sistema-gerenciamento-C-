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
    /// Interaction logic for Equipamento.xaml
    /// </summary>
    public partial class EquipamentoConsulta : Window
    {
        string modo;
        string codigo_equipamento;
        string codigo_categoria;
        string botao;

        public EquipamentoConsulta(string modo, string codigo_equipamento)
        {
            this.modo = modo;
            this.codigo_equipamento = codigo_equipamento;
            InitializeComponent();
            

                cbAtivo.SelectedIndex = 0;
                btEditar.IsEnabled = false;
               
                    SqlConnection conexao = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


                    try
                    {
                        conexao.Open();
                         // comando SQL

                    string _Select = "Select * from categoriaEqpt";

                    // inicializa o comando e a conexão
                    SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                    SqlDataReader resultado = _cmdSelect.ExecuteReader();
                    while (resultado.Read())
                    {

                        cbCategoria.Items.Add(resultado["descricao"] + "");

                    }
                    conexao.Close();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                        conexao.Close();
                    }
                   
               

           
           if (modo == "Consultar")
            {
                txtNome.IsEnabled = false;
                cbCategoria.IsEnabled = false;
                txtPrCusto.IsEnabled = false;
                txtPrVenda.IsEnabled = false;
                txtComissao.IsEnabled = false;
                cbAtivo.IsEnabled = false;
                btEditar.IsEnabled = true;
                btCadastrar.IsEnabled = false;
               
                    try
                    {
                        conexao.Open();
                         // comando SQL

                    string _Select = "Select * from Equipamento where codigo_equipamento=" + codigo_equipamento;

                    // inicializa o comando e a conexão
                    SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                    SqlDataReader resultado = _cmdSelect.ExecuteReader();
                    resultado.Read();
                   
                    if (resultado.HasRows == true)
                    {

                        txtNome.Text = resultado["descricao"] + "";
                        
                        txtPrCusto.Text = resultado["precoCusto"] + "";
                        txtPrVenda.Text = resultado["precoVenda"] + "";
                        txtComissao.Text = resultado["comissao"] + "";
                        cbAtivo.Text = resultado["ativo"] + "";
                        codigo_categoria = resultado["codigo_categoria"] + "";

                    }
                    conexao.Close();

                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                        conexao.Close();
                    }
                   
               
              
                    try
                    {
                    conexao.Open();
                    String consultarCurso = "SELECT * FROM CategoriaEqpt  where codigo_categoria = " + codigo_categoria;
                    SqlCommand codigo = new SqlCommand(consultarCurso, conexao);
                    SqlDataReader resultado = codigo.ExecuteReader();
                    resultado.Read();

                    cbCategoria.SelectedValue = resultado["descricao"] + "";
                         
                    conexao.Close();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                        conexao.Close();
                    }
               
                
           

            }

        }

        private void btEditar_Click(object sender, RoutedEventArgs e)
        {
            botao = "Editar";
            txtNome.IsEnabled = true;
            cbCategoria.IsEnabled = true;
            txtPrCusto.IsEnabled = true;
            txtPrVenda.IsEnabled = true;
            txtComissao.IsEnabled = true;
            cbAtivo.IsEnabled = true;
            btCadastrar.IsEnabled = true;
                    
          
        }

        private void btCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("O campo DESCRIÇÃO não pode ficar em branco.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else if (cbCategoria.Text == "")
            {
                MessageBox.Show("O campo CATEGORIA não pode ficar em branco.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else
            {


                SqlConnection conexao = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


                try
                {
                    conexao.Open();
                    // comando SQL
                    String descricaoCategoria = cbCategoria.SelectedValue.ToString();
                    string _Select = "Select * from categoriaEqpt where descricao='" + descricaoCategoria + "'";

                    // inicializa o comando e a conexão
                    SqlCommand _cmdSelect = new SqlCommand(_Select, conexao);
                    SqlDataReader resultado = _cmdSelect.ExecuteReader();
                    resultado.Read();

                    codigo_categoria = resultado["codigo_categoria"] + "";


                    conexao.Close();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                    conexao.Close();
                }




                try
                {
                    conexao.Open();
                    string sql = "";
                    // comando SQL para inserir - Insert Into
                    if (modo == "Incluir")
                    {
                        sql = @"insert into Equipamento
                    (descricao,codigo_categoria,precoCusto,precoVenda,comissao,ativo)
                    Values('" + txtNome.Text + "','" + codigo_categoria + "','" + txtPrCusto.Text + "','" + txtPrVenda.Text + "','" + txtComissao.Text + "','" + cbAtivo.Text + "')";


                        // inicializa o comando e a conexão

                        MessageBox.Show("Cadastrado com Sucesso!");
                        Close();
                    }
                    else if (botao == "Editar")
                    {

                        // comando SQL para inserir - Insert Into
                        sql = @"Update Equipamento Set 
                                     descricao ='" + txtNome.Text + "',codigo_categoria ='" + codigo_categoria + "',precoCusto ='" + txtPrCusto.Text + "',precoVenda ='" + txtPrVenda.Text + "',comissao ='" + txtComissao.Text + "',ativo ='" + cbAtivo.Text + "'where codigo_equipamento = " + codigo_equipamento;

                        MessageBox.Show("Alterado com Sucesso !");


                    }

                    SqlCommand codigo = new SqlCommand(sql, conexao);
                    codigo.ExecuteNonQuery();
                    conexao.Close();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                    conexao.Close();
                }
            }
                         
            
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

       
       

    }
}
