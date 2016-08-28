//------------------------------------------------------------------------------
// <copyright file="Angular2ToolboxWindowControl.xaml.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Angular2_Toolbox
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for Angular2ToolboxWindowControl.
    /// </summary>
    public partial class Angular2ToolboxWindowControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Angular2ToolboxWindowControl"/> class.
        /// </summary>
        public Angular2ToolboxWindowControl()
        {
            this.InitializeComponent();
        }

        private void insertNg2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentUICulture, "Invoked '{0}'", this.ToString()), "Angular2ToolboxWindow");
        }
    }
}