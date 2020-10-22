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
    /// Interaction logic for NovoConsultarAtendimento.xaml
    /// </summary>
    public partial class NovoConsultarAtendimento : Window
    {
       
       
        string modo;
        public NovoConsultarAtendimento(string modo)
        {
            this.modo = modo;
            InitializeComponent();

            
            if (modo == "Novo")
            {
                DateTime data = DateTime.Now;
                dpData.Text = data + "";
                DateTime hora = DateTime.Now;
                txtHora.Text = hora.Hour+":"+hora.Minute+ "";
                       
            }
        }
                
    }
}
