﻿#pragma checksum "..\..\IncommingWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DA019324330E1C242514E83A505BE5A3DFF361C49C2CA3E8943D3488352E1095"
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
    /// IncommingWindow
    /// </summary>
    public partial class IncommingWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\IncommingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Name_Textbox;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\IncommingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Amount_Textbox;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\IncommingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Name_Label;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\IncommingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Amount_Label;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\IncommingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Commit_Button;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\IncommingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PN_Textbox;
        
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
            System.Uri resourceLocater = new System.Uri("/Warehouse Program;component/incommingwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\IncommingWindow.xaml"
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
            this.Name_Textbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 13 "..\..\IncommingWindow.xaml"
            this.Name_Textbox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Name_Textbox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Amount_Textbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\IncommingWindow.xaml"
            this.Amount_Textbox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Amount_Textbox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Name_Label = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.Amount_Label = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.Commit_Button = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\IncommingWindow.xaml"
            this.Commit_Button.Click += new System.Windows.RoutedEventHandler(this.Commit_Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.PN_Textbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\IncommingWindow.xaml"
            this.PN_Textbox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.PN_Textbox_TextChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

