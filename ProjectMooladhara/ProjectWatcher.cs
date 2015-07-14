using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMooladhara
{
    public class ProjectWatcher
    {
        public FileSystemWatcher objProjectFolderWatcher = new FileSystemWatcher();

        public ProjectWatcher()
        {
            //Setting FileSystemWatcher to monitor project folder
            objProjectFolderWatcher.Changed += objProjectFolderWatcher_Changed;
            objProjectFolderWatcher.Deleted += objProjectFolderWatcher_Deleted;
            objProjectFolderWatcher.Renamed += objProjectFolderWatcher_Renamed;
            objProjectFolderWatcher.Created += objProjectFolderWatcher_Created;
            objProjectFolderWatcher.Filter = "*.*";
            objProjectFolderWatcher.Path = SharedData.CurrentProjectSolutionPath;
            objProjectFolderWatcher.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.CreationTime | NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.LastAccess | NotifyFilters.LastWrite;
            objProjectFolderWatcher.IncludeSubdirectories = true;
            objProjectFolderWatcher.EnableRaisingEvents = true;

            SharedData.objFileSystemWatcher = objProjectFolderWatcher;
        }

        private void objProjectFolderWatcher_Created(object sender, FileSystemEventArgs e)
        {
            try
            {
                SharedData.objMainWindow.Dispatcher.Invoke((Action)(() => { Loaders.LoadProjectExplorer(); }));
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        private void objProjectFolderWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            try
            {
                SharedData.objMainWindow.Dispatcher.Invoke((Action)(() => { Loaders.LoadProjectExplorer(); }));
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        private void objProjectFolderWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            try
            {
                SharedData.objMainWindow.Dispatcher.Invoke((Action)(() => { Loaders.LoadProjectExplorer(); }));
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        private void objProjectFolderWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            try
            {
                SharedData.objMainWindow.Dispatcher.Invoke((Action)(() => { Loaders.LoadProjectExplorer(); }));
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }
    }
}
