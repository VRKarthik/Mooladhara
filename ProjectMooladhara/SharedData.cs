using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMooladhara
{
    public static class SharedData
    {
        private static string MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private static string DefaultDirectoryPath = MyDocuments + "\\Rapid Development Studio\\Projects";
        private static string RDSConfigurationPath = "C:\\RDS";
        private static string RDSSettingsPath = "C:\\RDS\\Settings";
        private static string RDSHeadersPath = "C:\\RDS\\Headers";
        private static string RDSHelpPath = "C:\\RDS\\Help";

        private static string _CurrentProjectName = null;
        private static string _CurrentProjectSolutionPath = null;
        private static string _CurrentProjectWorkingPath = null;
        private static string _CurrentProjectObjectPath = null;
        private static string _CurrentProjectSourcePath = null;
        private static string _CurrentProjectBinPath = null;

        private static MainWindow _objMainWindow = null;

        private static string _SelectedDevice = null;
        private static string _SelectedDeviceSeries = null;

        public static MainWindow objMainWindow
        {
            get { return _objMainWindow; }
            set { _objMainWindow = value; }
        }

        public static string ProjectDirectory
        {
            get
            {
                return DefaultDirectoryPath;
            }
        }

        public static string RDSConfigurationDirectory
        {
            get
            {
                return RDSConfigurationPath;
            }
        }

        public static string RDSHelpDirectory
        {
            get
            {
                return RDSHelpPath;
            }
        }

        public static string RDSSettingsDirectory
        {
            get
            {
                return RDSSettingsPath;
            }
        }

        public static string RDSHeadersDirectory
        {
            get
            {
                return RDSHeadersPath;
            }
        }

        public static string SelectedDevice
        {
            get
            {
                return _SelectedDevice;
            }
            set
            {
                _SelectedDevice = value;
            }
        }

        public static string CurrentProjectName
        {
            get
            {
                return _CurrentProjectName;
            }
            set
            {
                _CurrentProjectName = value;
            }
        }

        public static string CurrentProjectSolutionPath
        {
            get
            {
                return _CurrentProjectSolutionPath;
            }
            set
            {
                _CurrentProjectSolutionPath = value;
            }
        }

        public static string CurrentProjectWorkingPath
        {
            get
            {
                return _CurrentProjectWorkingPath;
            }
            set
            {
                _CurrentProjectWorkingPath = value;
            }
        }

        public static string CurrentProjectObjectPath
        {
            get
            {
                return _CurrentProjectObjectPath;
            }
            set
            {
                _CurrentProjectObjectPath = value;
            }
        }

        public static string CurrentProjectSourcePath
        {
            get
            {
                return _CurrentProjectSourcePath;
            }
            set
            {
                _CurrentProjectSourcePath = value;
            }
        }

        public static string CurrentProjectBinPath
        {
            get
            {
                return _CurrentProjectBinPath;
            }
            set
            {
                _CurrentProjectBinPath = value;
            }
        }

        public static string SelectedDeviceSeries
        {
            get
            {
                return _SelectedDeviceSeries;
            }
            set
            {
                _SelectedDeviceSeries = value;
            }
        }
    }
}
