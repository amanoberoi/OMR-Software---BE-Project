﻿#pragma checksum "..\..\Multi-Scan.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "328928C2A7ED881527AB339482E7E8A3"
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


namespace UI_WPF {
    
    
    /// <summary>
    /// Multi_Scan
    /// </summary>
    public partial class Multi_Scan : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 5 "..\..\Multi-Scan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid_Main;
        
        #line default
        #line hidden
        
        
        #line 6 "..\..\Multi-Scan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Menu main_menu;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Multi-Scan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_browse;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Multi-Scan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_browse;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Multi-Scan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_questions;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Multi-Scan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_id;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Multi-Scan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_choices;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Multi-Scan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_scan;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\Multi-Scan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_sheet_count;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\Multi-Scan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_scanned_count;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Multi-Scan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image preview_window;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Multi-Scan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_total_sheets;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\Multi-Scan.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_close;
        
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
            System.Uri resourceLocater = new System.Uri("/UI_WPF;component/multi-scan.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Multi-Scan.xaml"
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
            
            #line 4 "..\..\Multi-Scan.xaml"
            ((UI_WPF.Multi_Scan)(target)).Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.grid_Main = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.main_menu = ((System.Windows.Controls.Menu)(target));
            return;
            case 4:
            
            #line 7 "..\..\Multi-Scan.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 8 "..\..\Multi-Scan.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click_1);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 9 "..\..\Multi-Scan.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click_2);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 10 "..\..\Multi-Scan.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click_3);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 12 "..\..\Multi-Scan.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click_4);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 13 "..\..\Multi-Scan.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click_5);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btn_browse = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\Multi-Scan.xaml"
            this.btn_browse.Click += new System.Windows.RoutedEventHandler(this.btn_browse_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.txt_browse = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.lbl_questions = ((System.Windows.Controls.Label)(target));
            return;
            case 13:
            this.lbl_id = ((System.Windows.Controls.Label)(target));
            return;
            case 14:
            this.lbl_choices = ((System.Windows.Controls.Label)(target));
            return;
            case 15:
            this.btn_scan = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\Multi-Scan.xaml"
            this.btn_scan.Click += new System.Windows.RoutedEventHandler(this.btn_scan_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.txt_sheet_count = ((System.Windows.Controls.TextBox)(target));
            return;
            case 17:
            this.lbl_scanned_count = ((System.Windows.Controls.Label)(target));
            return;
            case 18:
            this.preview_window = ((System.Windows.Controls.Image)(target));
            return;
            case 19:
            this.lbl_total_sheets = ((System.Windows.Controls.Label)(target));
            return;
            case 20:
            this.btn_close = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\Multi-Scan.xaml"
            this.btn_close.Click += new System.Windows.RoutedEventHandler(this.btn_close_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

