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
    /// Interaction logic for Atendimento.xaml
    /// </summary>
    public partial class Atendimento : Window
    {
        string modo;
        string codigo_atendimento;
        string nome_usuario;
        string nome_cliente = "";
        string tipo_acesso;
        string nome_filial;
        public Atendimento(string nome_usuario)
        {
            this.nome_usuario = nome_usuario;
           
            InitializeComponent();

            SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


            try
            {
                Con.Open();
                // comando SQL

                string _Select = "Select * from Usuario where nome='"+nome_usuario+"'";

                // inicializa o comando e a conexão
                SqlCommand _cmdSelect = new SqlCommand(_Select, Con);
                SqlDataReader resultado = _cmdSelect.ExecuteReader();
                resultado.Read();

                tipo_acesso = resultado["tipo"] + "";
                Con.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                Con.Close();
            }
        }
        public void VinculaDados()
        {

            SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


            try
            {
                SqlDataAdapter _Adapter;
                Con.Open();
                if (tipo_acesso == "Administrador")
                {
                    _Adapter = new SqlDataAdapter("select Atendimento.*, convert(CHAR,dataEntrada,101) as DataEntrada2, Usuario.nome as Usuario from Atendimento inner join Usuario on Atendimento.codigo_usuario = Usuario.codigo_usuario", Con);

                }
                else
                {
                    _Adapter = new SqlDataAdapter("select Atendimento.*, convert(CHAR,dataEntrada,101) as DataEntrada2, Usuario.nome as Usuario from Atendimento inner join Usuario on Atendimento.codigo_usuario = Usuario.codigo_usuario where Atendimento.situacao !='Resolvido'", Con);
                }
                DataSet _ds = new DataSet();
                _Adapter.Fill(_ds, "atendimentoDataBinding");


                dtgAtendimento.DataContext = _ds;
            }
            catch (SqlException)
            {
                MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                Con.Close();
            }



          
        }

        private void dtgAtendimento_Loaded(object sender, RoutedEventArgs e)
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

        private void dtgAtendimento_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRowView _dv = dtgAtendimento.CurrentCell.Item as DataRowView;

                if (_dv != null)
                {
                    codigo_atendimento = _dv.Row[0].ToString();
                    btConsultar.IsEnabled = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btNovo_Click(object sender, RoutedEventArgs e)
        {
            modo = "Novo";
          
            NovoConsultarAtendimento novo = new NovoConsultarAtendimento(modo,codigo_atendimento,nome_usuario,nome_cliente, nome_filial);
            novo.ShowDialog();
            this.VinculaDados();
        }

       

        private void btConsultar_Click(object sender, RoutedEventArgs e)
        {
            modo = "Consultar";

            NovoConsultarAtendimento consultar = new NovoConsultarAtendimento(modo, codigo_atendimento,nome_usuario,nome_cliente,nome_filial);
            consultar.ShowDialog();
            this.VinculaDados();

        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void txtPesquisa_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cbFiltro.Text == "Tipo de Busca:" && txtPesquisa.Text != "")
            {
                txtPesquisa.Text = string.Empty;
                MessageBox.Show("Selecione um tipo de Busca.");



            }
            else if (txtPesquisa.Text == "")
            {
                SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


                try
                {
                    Con.Open();
                    SqlDataAdapter _Adapter = new SqlDataAdapter("select Atendimento.*, convert(CHAR,dataEntrada,101) as DataEntrada2, Usuario.nome as Usuario from Atendimento inner join Usuario on Atendimento.codigo_usuario = Usuario.codigo_usuario where Atendimento.situacao !='Resolvido' order by DataEntrada2", Con);

                    DataSet _ds = new DataSet();
                    _Adapter.Fill(_ds, "atendimentoDataBinding");


                    dtgAtendimento.DataContext = _ds;

                    // Fecha a conexão
                    Con.Close();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                    Con.Close();
                }


            }
            else
            {

                SqlConnection Con = new SqlConnection("Data Source=MHACESSO-PC\\SQLEXPRESS;Initial Catalog=SISTEMA;User ID=sa;Password=_43690");


                try
                {
                    Con.Open();

                    SqlDataAdapter _Adapter;
                    if (cbFiltro.Text == "Data")
                    {
                        _Adapter = new SqlDataAdapter("select Atendimento.*, convert(CHAR,dataEntrada,101) as DataEntrada2, Usuario.nome as Usuario from Atendimento inner join Usuario on Atendimento.codigo_usuario = Usuario.codigo_usuario where convert(CHAR,dataEntrada,101)  LIKE'%" + txtPesquisa.Text + "%' and Atendimento.situacao !='Resolvido' order by DataEntrada2", Con);

                    }
                    else if (cbFiltro.Text == "Cliente")
                    {
                        _Adapter = new SqlDataAdapter("select Atendimento.*, convert(CHAR,dataEntrada,101) as DataEntrada2, Usuario.nome as Usuario from Atendimento inner join Usuario on Atendimento.codigo_usuario = Usuario.codigo_usuario  where Cliente.Nome LIKE'%" + txtPesquisa.Text + "%' and Atendimento.situacao !='Resolvido' order by DataEntrada2", Con);
                    }
                    else if (cbFiltro.Text == "Usuario")
                    {
                        _Adapter = new SqlDataAdapter("select Atendimento.*, convert(CHAR,dataEntrada,101) as DataEntrada2, Usuario.nome as Usuario from Atendimento inner join Usuario on Atendimento.codigo_usuario = Usuario.codigo_usuario  where Usuario.nome LIKE'%" + txtPesquisa.Text + "%' and Atendimento.situacao !='Resolvido' order by DataEntrada2", Con);
                    }
                    else 
                    {
                        _Adapter = new SqlDataAdapter("select Atendimento.*, convert(CHAR,dataEntrada,101) as DataEntrada2, Usuario.nome as Usuario from Atendimento inner join Usuario on Atendimento.codigo_usuario = Usuario.codigo_usuario  where Atendimento.motivo LIKE'%" + txtPesquisa.Text + "%' and Atendimento.situacao !='Resolvido' order by DataEntrada2", Con);
                    }
                    DataSet _ds = new DataSet();
                    _Adapter.Fill(_ds, "atendimentoDataBinding");


                    dtgAtendimento.DataContext = _ds;

                    // Fecha a conexão
                    Con.Close();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Não foi possivel conectar com o Banco", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                    Con.Close();
                }




            }
        }
    }
}
