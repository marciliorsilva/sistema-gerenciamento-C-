﻿#pragma checksum "..\..\..\RelatorioPecas.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4318913371B7CE7D9C82854A50E9FD8B"
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
    /// RelatorioPecas
    /// </summary>
    public partial class RelatorioPecas : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\RelatorioPecas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbTipo;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\RelatorioPecas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbFiltro;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\RelatorioPecas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPesquisa;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\RelatorioPecas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtgRelatorioPecas;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\RelatorioPecas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btCancelar;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\RelatorioPecas.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Sistema;component/relatoriopecas.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\RelatorioPecas.xaml"
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
            this.cbTipo = ((System.Windows.Controls.ComboBox)(target));
            
            #line 6 "..\..\..\RelatorioPecas.xaml"
            this.cbTipo.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbTipo_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cbFiltro = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.txtPesquisa = ((System.Windows.Controls.TextBox)(target));
            
            #line 16 "..\..\..\RelatorioPecas.xaml"
            this.txtPesquisa.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtPesquisa_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.dtgRelatorioPecas = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.btCancelar = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\RelatorioPecas.xaml"
            this.btCancelar.Click += new System.Windows.RoutedEventHandler(this.btCancelar_Click);
            
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
