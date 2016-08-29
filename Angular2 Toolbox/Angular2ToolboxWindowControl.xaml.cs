//------------------------------------------------------------------------------
// <copyright file="Angular2ToolboxWindowControl.xaml.cs" company="Thomas Brian">
//     Copyright (c) Thomas Brian.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Angular2_Toolbox
{
    using Microsoft.VisualStudio.Shell;
    using EnvDTE;
    using EnvDTE80;
    using System;
    using System.Windows;
    using System.Windows.Controls;

    public partial class Angular2ToolboxWindowControl : UserControl
    {
        static string angular2DocumentationUri = @"https://angular.io/docs/ts/latest/api";
        static string projectGithubUri = @"https://github.com/tdbrian/NG2VS-Toolbox";
        string appDirectory;

        public Angular2ToolboxWindowControl()
        {
            InitializeComponent();
            setNavigationPanelInitalState();
            hidePanels();
            welcomePanel.Visibility = Visibility.Visible;
        }

        private void setNavigationPanelInitalState()
        {
            navigationPanel.IsEnabled = false;
            navigationPanel.Opacity = .3;
        }

        private void goHome(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            hidePanels();
            welcomePanel.Visibility = Visibility.Visible;
        }

        private void showNewNg2App(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            newAppDetailsPanel.Visibility = Visibility.Collapsed;
            newNg2SelectedFolderInfo.Visibility = Visibility.Collapsed;

            var dte = GetActiveIDE();
            if (!solutionIsOpen(dte))
            {
                MessageBox.Show("Please create a .Net project first for us to add NG2 to. Check out the getting started guide if you need more info.", "Project Required");
                return;
            }

            hidePanels();
            selectNewFolderNg2Btn.Visibility = Visibility.Visible;
            addNg2Panel.Visibility = Visibility.Visible;
        }

        private void openDocumentation(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(angular2DocumentationUri);
            }
            catch (Exception)
            {
                MessageBox.Show("Sorry, unable to open angular.io documenation.", "Unable to open Angular.io");
            }
        }

        private void openProjectGithub(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(projectGithubUri);
            }
            catch (Exception)
            {
                MessageBox.Show("Sorry, unable to open project GitHub page.", "Unable to open GitHub");
            }
        }

        private void hidePanels()
        {
            welcomePanel.Visibility = Visibility.Collapsed;
            addNg2Panel.Visibility = Visibility.Collapsed;
        }

        private void selectNewProjectFolder(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var dte = GetActiveIDE();

            if (!solutionIsOpen(dte))
            {
                MessageBox.Show("Please create a .Net project first for us to add NG2 to. Check out the getting started guide if you need more info.", "Project Required");
                return;
            }

            var folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            folderDialog.Description = "Select the directory to add the new NG2 app directory";

            var fullName = dte.Application.Solution.FullName;
            folderDialog.SelectedPath = System.IO.Path.GetDirectoryName(fullName);

            System.Windows.Forms.DialogResult result = folderDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                selectNewFolderNg2Btn.Visibility = Visibility.Collapsed;
                newNg2SelectedFolderInfo.Visibility = Visibility.Visible;
                appDirectory = folderDialog.SelectedPath;
                newNg2SelectedFolderInfo.Text = "Selected Location: " + appDirectory;
                newAppDetailsPanel.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Sorry, unable to get the selected directory", "Unable to get directory");
            }
        }

        private bool solutionIsOpen(DTE2 dte)
        {
            return dte.Application.Solution.IsOpen;
        }

        private static DTE2 GetActiveIDE()
        {
            DTE2 dte = (DTE2)Package.GetGlobalService(typeof(DTE));
            return dte;
        }

        private void addNewNg2(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (string.IsNullOrEmpty(newAppNameInput.Text))
            {
                MessageBox.Show("A valid name for the NG2 app is required.", "Name Required");
                return;
            }

            MessageBox.Show("Created new project: " + newAppNameInput.Text + " at " + appDirectory, "NG2 App Added");
            hidePanels();
            welcomePanel.Visibility = Visibility.Visible;
        }
    }
}