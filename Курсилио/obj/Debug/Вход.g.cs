﻿#pragma checksum "..\..\Вход.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A5B92B91824CDBD2601B5C1F22E8391705E981BB1F803E73B27983A4F9C4A47C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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
using Курсилио;


namespace Курсилио {
    
    
    /// <summary>
    /// Вход
    /// </summary>
    public partial class Вход : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 106 "..\..\Вход.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button vhod;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\Вход.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nic;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\Вход.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pas;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\Вход.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AdminLog;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\Вход.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button reg;
        
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
            System.Uri resourceLocater = new System.Uri("/Курсилио;component/%d0%92%d1%85%d0%be%d0%b4.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Вход.xaml"
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
            
            #line 104 "..\..\Вход.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.vhod = ((System.Windows.Controls.Button)(target));
            
            #line 110 "..\..\Вход.xaml"
            this.vhod.Click += new System.Windows.RoutedEventHandler(this.vhod_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.nic = ((System.Windows.Controls.TextBox)(target));
            
            #line 125 "..\..\Вход.xaml"
            this.nic.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.nic_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.pas = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 132 "..\..\Вход.xaml"
            this.pas.PasswordChanged += new System.Windows.RoutedEventHandler(this.pas_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AdminLog = ((System.Windows.Controls.Button)(target));
            
            #line 141 "..\..\Вход.xaml"
            this.AdminLog.Click += new System.Windows.RoutedEventHandler(this.AdminLog_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.reg = ((System.Windows.Controls.Button)(target));
            
            #line 149 "..\..\Вход.xaml"
            this.reg.Click += new System.Windows.RoutedEventHandler(this.reg_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 159 "..\..\Вход.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

