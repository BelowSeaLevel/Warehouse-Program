﻿#pragma checksum "..\..\UpdateWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F67BC389664E2C78C6E8693B7B5A7C24B24A1B03CD7B1558CCE4BAED6FC6D1C1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
using Warehouse_Program;


namespace Warehouse_Program {
    
    
    /// <summary>
    /// UpdateWindow
    /// </summary>
    public partial class UpdateWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\UpdateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox LBItems;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\UpdateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Oke_Button;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\UpdateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BT_GetStock;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\UpdateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_Naam;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\UpdateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_Aantal;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\UpdateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_PartNummer;
        
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
            System.Uri resourceLocater = new System.Uri("/Warehouse Program;component/updatewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UpdateWindow.xaml"
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
            this.LBItems = ((System.Windows.Controls.ListBox)(target));
            
            #line 13 "..\..\UpdateWindow.xaml"
            this.LBItems.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.LBItems_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Oke_Button = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\UpdateWindow.xaml"
            this.Oke_Button.Click += new System.Windows.RoutedEventHandler(this.Oke_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BT_GetStock = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\UpdateWindow.xaml"
            this.BT_GetStock.Click += new System.Windows.RoutedEventHandler(this.BT_GetStock_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TB_Naam = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\UpdateWindow.xaml"
            this.TB_Naam.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TB_Naam_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TB_Aantal = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\UpdateWindow.xaml"
            this.TB_Aantal.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TB_Aantal_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TB_PartNummer = ((System.Windows.Controls.TextBox)(target));
            
            #line 21 "..\..\UpdateWindow.xaml"
            this.TB_PartNummer.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TB_PartNummer_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 22 "..\..\UpdateWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Delete_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

