using Fluent;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace ProjectMooladhara
{
    /// <summary>
    /// Shell for RDS, contains all modules
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        #region Global


        #endregion

        #region Initialization

        public MainWindow()
        {
            InitializeComponent();

            App.splashScreen.AddMessage("Loading 1...");
            Thread.Sleep(100);
            App.splashScreen.AddMessage("Loading 2...");
            Thread.Sleep(100);
            App.splashScreen.AddMessage("Loading 3...");
            Thread.Sleep(100);
            App.splashScreen.AddMessage("Loading 4...");
            Thread.Sleep(100);
            App.splashScreen.AddMessage("Loading 5...");
            Thread.Sleep(100);
            App.splashScreen.AddMessage("Loading 6...");
            Thread.Sleep(100);
            App.splashScreen.AddMessage("Loading 7...");
            Thread.Sleep(100);
            App.splashScreen.AddMessage("Loading 8...");
            Thread.Sleep(100);
            App.splashScreen.AddMessage("Loading 9...");
            Thread.Sleep(100);
            App.splashScreen.AddMessage("Loading 10...");
            Thread.Sleep(100);
            App.splashScreen.LoadComplete();
        }

        #endregion Initialization

        #region Events

        #region Windows

        private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                //Loading supported device list
                LBXDeviceList.ItemsSource = UILoadFunctions.PrepareDeviceList();
                SharedData.objMainWindow = this;

                TXTProjectLocation.Text = SharedData.ProjectDirectory;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        #endregion Windows

        #region ListBox

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender == LBXDeviceList)
                {
                    //Loading device details to show in details panel
                    BTNCreateProject.IsEnabled = true;
                    UILoadFunctions.SetDeviceDetails();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        #endregion ListBox

        #region Button

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender == BTNSelectLocation)
                {
                    System.Windows.Forms.FolderBrowserDialog objFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
                    objFolderBrowserDialog.ShowDialog();
                    TXTProjectLocation.Text = objFolderBrowserDialog.SelectedPath;
                }

                if (sender == BTNCreateProject)
                {
                    ProgressDialogResult result = ProgressDialog.Execute(this, "Creating project \"" + TXTProjectName.Text.Trim() + "\"", () =>
                    {
                        Thread.Sleep(300);
                    });
                    ProjectCreation.ValidateAndCreateNewProject();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        #endregion

        #region TreeView

        private void TreeView_SelectionChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                PropertiesGrid.SelectedObject = ProgramTree.SelectedItem;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        #endregion TreeView


        #endregion Events
    }
}