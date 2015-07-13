using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProjectMooladhara
{
    public static class Loaders
    {
        public static void LoadProject()
        {
            try
            {
                LoadConfigurations();
                LoadProjectExplorer();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        public static void LoadConfigurations()
        {
            try
            {
                DataTable objConfigurationTable = DataFactory.GetDataTable("config" + SharedData.SelectedSeries, DataFactory.DatabaseSelection.DeviceDatabase);
                
                foreach(DataRow objTempRow in objConfigurationTable.Select("TYPE='BOOL'"))
                {
                    BooleanConfigurationControl objBoolControl = new BooleanConfigurationControl();
                    objBoolControl.ConfigurationName.Content = objTempRow["CONFIG_NAME"].ToString().Trim();
                    objBoolControl.ConfigurationDescription.Content = objTempRow["DESC"].ToString().Trim();

                    SharedData.objMainWindow.ConfigurationPanel.Children.Add(objBoolControl);
                }

                foreach (DataRow objTempRow in objConfigurationTable.Select("TYPE='LIST'"))
                {
                    ListConfigurationControl objListControl = new ListConfigurationControl();
                    objListControl.ConfigurationName.Content = objTempRow["CONFIG_NAME"].ToString().Trim();
                    objListControl.ConfigurationDescription.Content = objTempRow["DESC"].ToString().Trim();
                    objListControl.ConfigurationList.ItemsSource = objTempRow["VALUE"].ToString().Trim().Split(',');

                    SharedData.objMainWindow.FrequenciesPanel.Children.Add(objListControl);
                }
            }
            catch(Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        public static void LoadProjectExplorer()
        {
            try
            {
                TreeViewItem objSolutionFolder = new TreeViewItem();
                objSolutionFolder.Tag = SharedData.CurrentProjectSolutionPath;
                objSolutionFolder.Header = "Project - " + SharedData.CurrentProjectName;

                TreeViewItem objProjectFolder = new TreeViewItem();
                objProjectFolder.Tag = SharedData.CurrentProjectSolutionPath;
                objProjectFolder.Header = SharedData.CurrentProjectName;

                objSolutionFolder.Items.Add(objProjectFolder);
                SharedData.objMainWindow.ProjectExplorerTree.Items.Add(objSolutionFolder);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }
    }
}
