using System.Collections.ObjectModel;

namespace ProjectMooladhara
{
    public class SolutionItem
    {
        public string SolutionName { get; set; }

        public string SolutionPath { get; set; }

        public ObservableCollection<FolderMember> Folders { get; set; }

        public SolutionItem()
        {
            this.Folders = new ObservableCollection<FolderMember>();
        }
    }

    public class FolderMember
    {
        public string FolderName { get; set; }

        public string FolderPath { get; set; }

        public ObservableCollection<FileMember> Files { get; set; }

        public FolderMember()
        {
            this.Files = new ObservableCollection<FileMember>();
        }
    }

    public class FileMember
    {
        public string FileName { get; set; }

        public string FilePath { get; set; }
    }
}