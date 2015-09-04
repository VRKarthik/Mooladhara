using Fluent;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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
        #region Globals

        //private Scintilla objCodeEditor;

        #endregion Globals

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

                if (sender == TestSave)
                {
                    //TreeViewItem tvi = (TreeViewItem)ProgramTree.ItemContainerGenerator.ContainerFromIndex(0);
                    //tvi.Focus();
                    //MainFunctionProperties objMain = (MainFunctionProperties)ProgramTree.SelectedItem;
                    //SerializeObject(objMain, "D:\\treeTest.txt");

                    MainFunctionProperties objMain1 = DeSerializeObject<MainFunctionProperties>("D:\\treeTest.txt");
                    MainFunctionProperties objMainRoot = new MainFunctionProperties();
                    objMainRoot.FunctionWithPropertiesCollection = objMain1.FunctionWithPropertiesCollection;
                    ProgramTree.Items.Add(objMainRoot);
                }

                if (sender == BTNAddVariable)
                {
                    UserVariableMaker objUserVariableMaker = new UserVariableMaker();
                    objUserVariableMaker.ShowDialog();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        #endregion Button

        #region TreeView

        private void TreeView_SelectionChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                if (sender == ProgramTree)
                {
                    PropertiesGrid.SelectedObject = ProgramTree.SelectedItem;
                }

                if (sender == InterruptTree)
                {
                    PropertiesGrid.SelectedObject = InterruptTree.SelectedItem;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        #endregion TreeView

        #region ContextMenu

        private void ContextMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (((System.Windows.Controls.MenuItem)sender).Header.ToString().Trim() == "Add to main program")
                {
                    if (ProgramTree.SelectedItem != null)
                    {
                        if (ProgramTree.SelectedItem.GetType().ToString().Trim() == "ProjectMooladhara.MainFunctionProperties")
                        {
                            FunctionProperties objFunction = PropertyFactory.GetFunctionWithProperties(((FunctionItems)FunctionsExplorerTree.SelectedItem).SourceRow);
                            ((MainFunctionProperties)ProgramTree.SelectedItem).FunctionWithPropertiesCollection.Add(objFunction);
                        }
                        else
                        {
                            FunctionProperties objFunction = PropertyFactory.GetFunctionWithProperties(((FunctionItems)FunctionsExplorerTree.SelectedItem).SourceRow);
                            ((FunctionProperties)ProgramTree.SelectedItem).FunctionWithPropertiesCollection.Add(objFunction);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a node in Main Program.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }

                if (((System.Windows.Controls.MenuItem)sender).Header.ToString().Trim() == "Add to interrupt")
                {
                    if (InterruptTree.SelectedItem != null)
                    {
                        if (InterruptTree.SelectedItem.GetType().ToString().Trim() == "ProjectMooladhara.InterruptFunctionProperties")
                        {
                            FunctionProperties objFunction = PropertyFactory.GetFunctionWithProperties(((FunctionItems)FunctionsExplorerTree.SelectedItem).SourceRow);
                            ((InterruptFunctionProperties)InterruptTree.SelectedItem).FunctionWithPropertiesCollection.Add(objFunction);
                        }
                        else
                        {
                            FunctionProperties objFunction = PropertyFactory.GetFunctionWithProperties(((FunctionItems)FunctionsExplorerTree.SelectedItem).SourceRow);
                            ((FunctionProperties)InterruptTree.SelectedItem).FunctionWithPropertiesCollection.Add(objFunction);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a node in Interrupt Routine.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        #endregion ContextMenu

        #endregion Events

        #region UserDefined

        /// <summary>
        /// Serializes an object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializableObject"></param>
        /// <param name="fileName"></param>
        public void SerializeObject<T>(T serializableObject, string fileName)
        {
            if (serializableObject == null) { return; }

            try
            {
                Stream stream = File.Open(fileName, FileMode.Create);
                BinaryFormatter bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, serializableObject);
                stream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Deserializes an xml file into an object list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public T DeSerializeObject<T>(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) { return default(T); }

            T objectOut = default(T);

            try
            {
                Stream stream = File.Open(fileName, FileMode.Open);
                BinaryFormatter bformatter = new BinaryFormatter();
                objectOut = (T)bformatter.Deserialize(stream);
                stream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return objectOut;
        }

        #endregion UserDefined
    }
}