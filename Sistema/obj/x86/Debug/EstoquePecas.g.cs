﻿#pragma checksum "..\..\..\EstoquePecas.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F96104FA11B3F5F7053BF14BAFDC80B6"
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
    /// EstoquePecas
    /// </summary>
    public partial class EstoquePecas : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\EstoquePecas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbFiltro;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\EstoquePecas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPesquisa;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\EstoquePecas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtgEstoquePecas;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\EstoquePecas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btCancelar;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\EstoquePecas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btConsultar;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\EstoquePecas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btIncluir;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\EstoquePecas.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Sistema;component/estoquepecas.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\EstoquePecas.xaml"
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
            this.cbFiltro = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.txtPesquisa = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\..\EstoquePecas.xaml"
            this.txtPesquisa.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtPesquisa_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.dtgEstoquePecas = ((System.Windows.Controls.DataGrid)(target));
            
            #line 15 "..\..\..\EstoquePecas.xaml"
            this.dtgEstoquePecas.Loaded += new System.Windows.RoutedEventHandler(this.dtgEstoquePecas_Loaded);
            
            #line default
            #line hidden
            
            #line 15 "..\..\..\EstoquePecas.xaml"
            this.dtgEstoquePecas.SelectedCellsChanged += new System.Windows.Controls.SelectedCellsChangedEventHandler(this.dtgEstoquePecas_SelectedCellsChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btCancelar = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\EstoquePecas.xaml"
            this.btCancelar.Click += new System.Windows.RoutedEventHandler(this.btCancelar_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btConsultar = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\EstoquePecas.xaml"
            this.btConsultar.Click += new System.Windows.RoutedEventHandler(this.btConsultar_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btIncluir = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\EstoquePecas.xaml"
            this.btIncluir.Click += new System.Windows.RoutedEventHandler(this.btIncluir_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.textBlock1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

