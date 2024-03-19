﻿#pragma checksum "..\..\..\..\DoctorWindow\DoctorWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6C7D765651CF2B1DABCFF983F9B03F2FBFE2CBA2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HospitalQMS;
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


namespace HospitalQMS {
    
    
    /// <summary>
    /// DoctorWindow
    /// </summary>
    public partial class DoctorWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\DoctorWindow\DoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtUsername;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\DoctorWindow\DoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem tabLocation;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\DoctorWindow\DoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel wpDepartment;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\DoctorWindow\DoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbFloor;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\DoctorWindow\DoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel wpRoom;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\DoctorWindow\DoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem tabPatient;
        
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
            System.Uri resourceLocater = new System.Uri("/HospitalQMS;component/doctorwindow/doctorwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\DoctorWindow\DoctorWindow.xaml"
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
            this.txtUsername = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.tabLocation = ((System.Windows.Controls.TabItem)(target));
            return;
            case 3:
            this.wpDepartment = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 4:
            this.cbFloor = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.wpRoom = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 6:
            this.tabPatient = ((System.Windows.Controls.TabItem)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

