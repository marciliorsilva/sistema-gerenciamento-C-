﻿#pragma checksum "..\..\..\CategoriaFornecedor.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BD1222DF80050D3427DDC040D2BD91C5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
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
    /// CategoriaFornecedor
    /// </summary>
    public partial class CategoriaFornecedor : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\CategoriaFornecedor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDescricao;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\..\CategoriaFornecedor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtgCategoria;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\CategoriaFornecedor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btExcluir;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\CategoriaFornecedor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btAlterar;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\CategoriaFornecedor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btAdd;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\CategoriaFornecedor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button4;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\CategoriaFornecedor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label2;
        
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
            System.Uri resourceLocater = new System.Uri("/Sistema;component/categoriafornecedor.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\CategoriaFornecedor.xaml"
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
            this.txtDescricao = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.dtgCategoria = ((System.Windows.Controls.DataGrid)(target));
            
            #line 7 "..\..\..\CategoriaFornecedor.xaml"
            this.dtgCategoria.Loaded += new System.Windows.RoutedEventHandler(this.dtgCategoria_Loaded);
            
            #line default
            #line hidden
            
            #line 7 "..\..\..\CategoriaFornecedor.xaml"
            this.dtgCategoria.SelectedCellsChanged += new System.Windows.Controls.SelectedCellsChangedEventHandler(this.dtgCategoria_SelectedCellsChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btExcluir = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\CategoriaFornecedor.xaml"
            this.btExcluir.Click += new System.Windows.RoutedEventHandler(this.btExcluir_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btAlterar = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\CategoriaFornecedor.xaml"
            this.btAlterar.Click += new System.Windows.RoutedEventHandler(this.btAlterar_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btAdd = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\CategoriaFornecedor.xaml"
            this.btAdd.Click += new System.Windows.RoutedEventHandler(this.btAdd_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.button4 = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.label2 = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

