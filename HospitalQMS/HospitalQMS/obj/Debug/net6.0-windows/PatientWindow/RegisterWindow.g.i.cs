﻿#pragma checksum "..\..\..\..\PatientWindow\RegisterWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C39EA6C364D9E093AE4419622249D1B615FF23A2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HospitalQMS.Component;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace HospitalQMS.PatientWindow {
    
    
    /// <summary>
    /// RegisterWindow
    /// </summary>
    public partial class RegisterWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\PatientWindow\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grFirst;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\PatientWindow\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGetTicket;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\PatientWindow\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grSecond;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\PatientWindow\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReturnFirst;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\PatientWindow\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGetBHYT;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\PatientWindow\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGetService;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\PatientWindow\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grThird;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\PatientWindow\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grFourth;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\PatientWindow\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReturnSecond;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HospitalQMS;component/patientwindow/registerwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\PatientWindow\RegisterWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.grFirst = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.btnGetTicket = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\..\PatientWindow\RegisterWindow.xaml"
            this.btnGetTicket.Click += new System.Windows.RoutedEventHandler(this.btnGetTicket_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.grSecond = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.btnReturnFirst = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\..\PatientWindow\RegisterWindow.xaml"
            this.btnReturnFirst.Click += new System.Windows.RoutedEventHandler(this.btnReturnFirst_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnGetBHYT = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\..\PatientWindow\RegisterWindow.xaml"
            this.btnGetBHYT.Click += new System.Windows.RoutedEventHandler(this.btnGetBHYT_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnGetService = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\..\PatientWindow\RegisterWindow.xaml"
            this.btnGetService.Click += new System.Windows.RoutedEventHandler(this.btnGetService_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.grThird = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.grFourth = ((System.Windows.Controls.Grid)(target));
            return;
            case 9:
            this.btnReturnSecond = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\..\PatientWindow\RegisterWindow.xaml"
            this.btnReturnSecond.Click += new System.Windows.RoutedEventHandler(this.btnReturnSecond_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

