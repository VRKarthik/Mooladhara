using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProjectMooladhara
{
    public static class Loaders
    {
        public static FunctionProperties objFunction;
        public static void LoadProject()
        {
            try
            {
                LoadConfigurations();
                LoadProjectExplorer();
                LoadFunctions();

                ProjectWatcher objWatcher = new ProjectWatcher();

                LoadMainFunction();
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

                foreach (DataRow objTempRow in objConfigurationTable.Select("TYPE='BOOL'"))
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
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        public static void LoadProjectExplorer()
        {
            try
            {
                #region OldCode
                //if (SharedData.objMainWindow.ProjectExplorerTree.HasItems == true)
                //{
                //    SharedData.objMainWindow.ProjectExplorerTree.Items.Clear();
                //}
                //else if (SharedData.objMainWindow.ProjectExplorerTree.HasItems == false)
                //{
                //    List<SolutionItem> Solutions = new List<SolutionItem>();
                //    SolutionItem objRootSolution = new SolutionItem();

                //    objRootSolution.SolutionName = SharedData.CurrentProjectName;
                //    objRootSolution.SolutionPath = SharedData.CurrentProjectSolutionPath;

                //    FolderMember SourceFolder = new FolderMember() { FolderName = "Source", FolderPath = SharedData.CurrentProjectSourcePath };
                //    FolderMember ObjectFolder = new FolderMember() { FolderName = "Object", FolderPath = SharedData.CurrentProjectObjectPath };
                //    FolderMember BinFolder = new FolderMember() { FolderName = "Bin", FolderPath = SharedData.CurrentProjectBinPath };

                //    foreach (FileInfo objFile in new DirectoryInfo(SharedData.CurrentProjectSourcePath).GetFiles())
                //    {
                //        SourceFolder.Files.Add(new FileMember() { FileName = objFile.Name, FilePath = objFile.FullName });
                //    }

                //    foreach (FileInfo objFile in new DirectoryInfo(SharedData.CurrentProjectObjectPath).GetFiles())
                //    {
                //        ObjectFolder.Files.Add(new FileMember() { FileName = objFile.Name, FilePath = objFile.FullName });
                //    }

                //    foreach (FileInfo objFile in new DirectoryInfo(SharedData.CurrentProjectBinPath).GetFiles())
                //    {
                //        BinFolder.Files.Add(new FileMember() { FileName = objFile.Name, FilePath = objFile.FullName });
                //    }

                //    objRootSolution.Folders.Add(SourceFolder);
                //    objRootSolution.Folders.Add(ObjectFolder);
                //    objRootSolution.Folders.Add(BinFolder);

                //    Solutions.Add(objRootSolution);

                //    SharedData.objMainWindow.ProjectExplorerTree.ItemsSource = Solutions;
                // }
                #endregion

                SharedData.objMainWindow.ProjectExplorerTree.ItemsSource = PrepareProjectFolders();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        private static List<SolutionItem> PrepareProjectFolders()
        {
            try
            {
                List<SolutionItem> Solutions = new List<SolutionItem>();
                SolutionItem objRootSolution = new SolutionItem();

                foreach (FileInfo objFile in new DirectoryInfo(SharedData.CurrentProjectSolutionPath).GetFiles())
                {
                    objRootSolution.SolutionName = objFile.Name;
                    objRootSolution.SolutionPath = objFile.FullName;
                }

                foreach (DirectoryInfo objDirectory in new DirectoryInfo(SharedData.CurrentProjectWorkingPath).GetDirectories())
                {
                    FolderMember objFolderMember = new FolderMember();
                    objFolderMember.FolderName = objDirectory.Name;
                    objFolderMember.FolderPath = objDirectory.FullName;

                    foreach (FileInfo objFile in objDirectory.GetFiles())
                    {
                        FileMember objFileMember = new FileMember();
                        objFileMember.FileName = objFile.Name;
                        objFileMember.FilePath = objFile.FullName;
                        objFolderMember.Files.Add(objFileMember);
                    }

                    objRootSolution.Folders.Add(objFolderMember);
                }

                Solutions.Add(objRootSolution);
                return Solutions;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        public static void LoadFunctions()
        {
            try
            {
                List<FunctionGroupItem> objFunctionGroups = new List<FunctionGroupItem>();

                DataTable objFunctionUnitTable = DataFactory.GetDataTable("fu" + SharedData.SelectedSeries, DataFactory.DatabaseSelection.DeviceDatabase);

                FunctionGroupItem objPeripheralGroup = new FunctionGroupItem();
                objPeripheralGroup.FunctionGroupName = "Peripherals";
                foreach (DataRow objTempRow in objFunctionUnitTable.Select("FUN_ID='PER'"))
                {
                    FunctionSubGroupItem objPeripheralSubGroup = new FunctionSubGroupItem();
                    DataTable objFunctionsTable = DataFactory.GetDataTable("fun" + SharedData.SelectedSeries, DataFactory.DatabaseSelection.DeviceDatabase);

                    foreach (DataRow objRow in objFunctionsTable.Select("DEV_ID='" + objTempRow["DEV_ID"].ToString().Trim() + "'"))
                    {
                        PeripheralMember objPeripheral = new PeripheralMember();
                        objPeripheral.FunctionItemName = objRow["FUNC_NAME"].ToString();
                        objPeripheral.Syntax = objRow["SYNTAX"].ToString();
                        objPeripheral.Description = AssignDescription(objRow["DESC"].ToString());
                        objPeripheral.SourceRow = objRow;
                        objPeripheralSubGroup.Functions.Add(objPeripheral);
                    }
                    objPeripheralSubGroup.FunctionSubGroupName = objTempRow["NAME"].ToString().ToUpperInvariant();
                    objPeripheralGroup.FunctionCategories.Add(objPeripheralSubGroup);
                }

                FunctionGroupItem objDeviceGroup = new FunctionGroupItem();
                objDeviceGroup.FunctionGroupName = "Devices";
                foreach (DataRow objTempRow in objFunctionUnitTable.Select("FUN_ID='DEV'"))
                {
                    FunctionSubGroupItem objDeviceSubGroup = new FunctionSubGroupItem();
                    DataTable objFunctionsTable = DataFactory.GetDataTable("fun" + SharedData.SelectedSeries, DataFactory.DatabaseSelection.DeviceDatabase);

                    foreach (DataRow objRow in objFunctionsTable.Select("DEV_ID='" + objTempRow["DEV_ID"].ToString().Trim() + "'"))
                    {
                        DeviceMember objDevice = new DeviceMember();
                        objDevice.FunctionItemName = objRow["FUNC_NAME"].ToString();
                        objDevice.Syntax = objRow["SYNTAX"].ToString();
                        objDevice.Description = AssignDescription(objRow["DESC"].ToString());
                        objDevice.SourceRow = objRow;
                        objDeviceSubGroup.Functions.Add(objDevice);
                    }
                    objDeviceSubGroup.FunctionSubGroupName = objTempRow["NAME"].ToString().ToUpperInvariant();
                    objDeviceGroup.FunctionCategories.Add(objDeviceSubGroup);
                }

                FunctionGroupItem objAccessoriesGroup = new FunctionGroupItem();
                objAccessoriesGroup.FunctionGroupName = "Accessories";
                foreach (DataRow objTempRow in objFunctionUnitTable.Select("FUN_ID='ACC'"))
                {
                    FunctionSubGroupItem objAccessoriesSubGroup = new FunctionSubGroupItem();
                    DataTable objFunctionsTable = DataFactory.GetDataTable("fun" + SharedData.SelectedSeries, DataFactory.DatabaseSelection.DeviceDatabase);

                    foreach (DataRow objRow in objFunctionsTable.Select("DEV_ID='" + objTempRow["DEV_ID"].ToString().Trim() + "'"))
                    {
                        AccessoriesMember objAccessory = new AccessoriesMember();
                        objAccessory.FunctionItemName = objRow["FUNC_NAME"].ToString();
                        objAccessory.Syntax = objRow["SYNTAX"].ToString();
                        objAccessory.Description = AssignDescription(objRow["DESC"].ToString());
                        objAccessory.SourceRow = objRow;
                        objAccessoriesSubGroup.Functions.Add(objAccessory);
                    }
                    objAccessoriesSubGroup.FunctionSubGroupName = objTempRow["NAME"].ToString().ToUpperInvariant();
                    objAccessoriesGroup.FunctionCategories.Add(objAccessoriesSubGroup);
                }

                FunctionGroupItem objInterruptGroup = new FunctionGroupItem();
                objInterruptGroup.FunctionGroupName = "Interrupts";
                foreach (DataRow objTempRow in objFunctionUnitTable.Select("FUN_ID='INT'"))
                {
                    FunctionSubGroupItem objInterruptSubGroup = new FunctionSubGroupItem();
                    DataTable objFunctionsTable = DataFactory.GetDataTable("fun" + SharedData.SelectedSeries, DataFactory.DatabaseSelection.DeviceDatabase);

                    foreach (DataRow objRow in objFunctionsTable.Select("DEV_ID='" + objTempRow["DEV_ID"].ToString().Trim() + "'"))
                    {
                        InterruptMember objInterrupt = new InterruptMember();
                        objInterrupt.FunctionItemName = objRow["FUNC_NAME"].ToString();
                        objInterrupt.Syntax = objRow["SYNTAX"].ToString();
                        objInterrupt.Description = AssignDescription(objRow["DESC"].ToString());
                        objInterrupt.SourceRow = objRow;
                        objInterruptSubGroup.Functions.Add(objInterrupt);
                    }
                    objInterruptSubGroup.FunctionSubGroupName = objTempRow["NAME"].ToString().ToUpperInvariant();
                    objInterruptGroup.FunctionCategories.Add(objInterruptSubGroup);
                }

                objFunctionGroups.Add(objPeripheralGroup);
                objFunctionGroups.Add(objDeviceGroup);
                objFunctionGroups.Add(objAccessoriesGroup);
                objFunctionGroups.Add(objInterruptGroup);

                SharedData.objMainWindow.FunctionsExplorerTree.ItemsSource = objFunctionGroups;
            }
            catch (Exception Ex)
            {
                throw new Exception("Can't load functions.\n" + Ex.Message);
            }
        }

        public static void LoadMainFunction()
        {
            try
            {
                SharedData.objMainWindow.ProgramTree.Items.Add(new MainFunctionProperties());
            }
            catch (Exception Ex)
            {
                throw new Exception("Can't load functions.\n" + Ex.Message);
            }
        }

        public static void LoadInterruptFunction()
        {
            try
            {
                SharedData.objMainWindow.ProgramTree.Items.Add(new InterruptFunctionProperties());
            }
            catch (Exception Ex)
            {
                throw new Exception("Can't load functions.\n" + Ex.Message);
            }
        }

        private static string AssignDescription(string DescriptionWithSymbol)
        {
            try
            {
                StringBuilder objStringToReturn = new StringBuilder();
                foreach (string stringDesc in DescriptionWithSymbol.Split('$'))
                {
                    objStringToReturn.AppendLine(stringDesc);
                }
                return objStringToReturn.ToString();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }
    }
}
