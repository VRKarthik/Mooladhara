using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectMooladhara
{
    public static class ProjectCreation
    {
        /// <summary>
        /// Validation for new project to be created
        /// </summary>
        public static void ValidateAndCreateNewProject()
        {
            try
            {
                //Checking for project is empty or not
                if (SharedData.objMainWindow.TXTProjectName.Text.Length == 0 || SharedData.objMainWindow.TXTProjectName.Text.Trim() == "provide a project name here")
                {
                    throw new Exception("Please provide a valid project name.");
                }
                else
                {
                    SharedData.CurrentProjectName = SharedData.objMainWindow.TXTProjectName.Text.Trim();
                }

                //Replacing space with underscore in project name
                SharedData.CurrentProjectName = SharedData.CurrentProjectName.Replace(' ', '_');

                //Checking for special characters in project name
                Regex objRegexPattern = new Regex("[!@#$%^&*)(-+|\\?/.,;:'=`~]");
                if (objRegexPattern.IsMatch(SharedData.CurrentProjectName))
                {
                    throw new Exception("Project name should not contain special characters.");
                }

                //Checking for empty Project Location
                if (SharedData.objMainWindow.TXTProjectLocation.Text.Length == 0)
                {
                    throw new Exception("Please provide a valid location to save your project.");
                }

                //Checking for device selection
                if (SharedData.objMainWindow.LBXSeries.SelectedIndex == -1)
                {
                    throw new Exception("Please select a device to create a project.");
                }
                else
                {
                    DeviceSeries objSelectedDevice = (DeviceSeries)SharedData.objMainWindow.LBXSeries.SelectedItem;
                    SharedData.SelectedDeviceSeries = objSelectedDevice.SeriesNumber;
                }

                //Checking for project name existence
                foreach (DirectoryInfo objDirectory in new DirectoryInfo(SharedData.ProjectDirectory).GetDirectories())
                {
                    if (objDirectory.Name == SharedData.CurrentProjectName)
                    {
                        throw new Exception("Project name already exists. Project can't be created.");
                    }
                }

                CreateNewProject();
            }
            catch (Exception Ex)
            {
                throw new Exception("Can't create project.\n" + Ex.Message);
            }
        }

        /// <summary>
        /// Creating project folders for new project
        /// </summary>
        private static void CreateNewProject()
        {
            try
            {
                //Project folder creation
                SharedData.CurrentProjectSolutionPath = Directory.CreateDirectory(SharedData.ProjectDirectory + "\\" + SharedData.CurrentProjectName).FullName;
                SharedData.CurrentProjectWorkingPath = Directory.CreateDirectory(SharedData.CurrentProjectSolutionPath + "\\" + SharedData.CurrentProjectName).FullName;
                SharedData.CurrentProjectSourcePath = Directory.CreateDirectory(SharedData.CurrentProjectWorkingPath + "\\Source").FullName;
                SharedData.CurrentProjectObjectPath = Directory.CreateDirectory(SharedData.CurrentProjectWorkingPath + "\\Object").FullName;
                SharedData.CurrentProjectBinPath = Directory.CreateDirectory(SharedData.CurrentProjectWorkingPath + "\\Bin").FullName;

                //RDS solution file creation
                using (StreamWriter objFileWriter = File.CreateText(SharedData.CurrentProjectSolutionPath + "\\" + SharedData.CurrentProjectName + ".rds"))
                {
                    objFileWriter.WriteLine("[Rapid Development Studio V3.0]");
                    objFileWriter.WriteLine("[Powered by Foresquare Technologies]");
                    objFileWriter.WriteLine("[website        : http://www.foresquare.in]");
                    objFileWriter.WriteLine("[support        : http://www.rds.foresquare.in]");
                    objFileWriter.WriteLine("[Project Name   : {0}]", SharedData.CurrentProjectName);
                    objFileWriter.WriteLine("[Project Type   : {0}]", SharedData.SelectedDevice);
                    objFileWriter.WriteLine("[SelectedDevice : {0}]", SharedData.SelectedDeviceSeries);
                    objFileWriter.WriteLine("[Directory      : {0}]", SharedData.CurrentProjectSolutionPath);
                    objFileWriter.WriteLine("[Created On     : {0}]", DateTime.Now.ToString());
                    objFileWriter.WriteLine("[Modified On    : {0}]", DateTime.Now.ToString());
                }

                //Copying necessary files from RDS to current project working folder
                File.Copy(SharedData.RDSConfigurationDirectory + "\\" + SharedData.SelectedDevice + "\\H" + SharedData.SelectedDeviceSeries + ".db", SharedData.CurrentProjectObjectPath + "\\H" + SharedData.SelectedDeviceSeries + ".db");
                File.Copy(SharedData.RDSConfigurationDirectory + "\\" + SharedData.SelectedDevice + "\\D" + SharedData.SelectedDeviceSeries + ".db", SharedData.CurrentProjectObjectPath + "\\D" + SharedData.SelectedDeviceSeries + ".db");

                //Closing backstage
                SharedData.objMainWindow.BackStage.IsOpen = false;
            }
            catch (Exception Ex)
            {
                throw new Exception("Can't create project.\n" + Ex.Message);
            }
        }
    }
}
