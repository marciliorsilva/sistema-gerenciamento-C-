﻿#pragma checksum "..\..\..\ListaConsultaEqptEstoque.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "494BDC523EA07678A345259F6341AC35"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Sistema {
    
    
    /// <summary>
    /// ListaConsultaEqptEstoque
    /// </summary>
    public partial class ListaConsultaEqptEstoque : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\ListaConsultaEqptEstoque.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtgListaEqpt;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\ListaConsultaEqptEstoque.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btCancelar;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\ListaConsultaEqptEstoque.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btEditar;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\ListaConsultaEqptEstoque.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbFiltro;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\ListaConsultaEqptEstoque.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPesquisa;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\ListaConsultaEqptEstoque.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlock1;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Sistema;component/listaconsultaeqptestoque.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ListaConsultaEqptEstoque.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.dtgListaEqpt = ((System.Windows.Controls.DataGrid)(target));
            
            #line 6 "..\..\..\ListaConsultaEqptEstoque.xaml"
            this.dtgListaEqpt.Loaded += new System.Windows.RoutedEventHandler(this.dtgListaEqpt_Loaded);
            
            #line default
            #line hidden
            
            #line 6 "..\..\..\ListaConsultaEqptEstoque.xaml"
            this.dtgListaEqpt.SelectedCellsChanged += new System.Windows.Controls.SelectedCellsChangedEventHandler(this.dtgListaEqpt_SelectedCellsChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btCancelar = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\ListaConsultaEqptEstoque.xaml"
            this.btCancelar.Click += new System.Windows.RoutedEventHandler(this.btCancelar_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btEditar = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\ListaConsultaEqptEstoque.xaml"
            this.btEditar.Click += new System.Windows.RoutedEventHandler(this.btEditar_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cbFiltro = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.txtPesquisa = ((System.Windows.Controls.TextBox)(target));
            
            #line 33 "..\..\..\ListaConsultaEqptEstoque.xaml"
            this.txtPesquisa.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtPesquisa_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.textBlock1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
