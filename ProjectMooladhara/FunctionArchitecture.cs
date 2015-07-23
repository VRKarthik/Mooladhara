using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMooladhara
{
    public class FunctionGroupItem
    {
        public string FunctionGroupName { get; set; }

        public ObservableCollection<FunctionSubGroupItem> FunctionCategories { get; set; }

        public FunctionGroupItem()
        {
            this.FunctionCategories = new ObservableCollection<FunctionSubGroupItem>();
        }
    }

    public class FunctionSubGroupItem
    {
        public string FunctionSubGroupName { get; set; }

        public ObservableCollection<FunctionItems> Functions { get; set; }

        public FunctionSubGroupItem()
        {
            this.Functions = new ObservableCollection<FunctionItems>();
        }
    }

    public class FunctionItems
    {
        public string FunctionItemName { get; set; }

        public string Syntax { get; set; }

        public string Description { get; set; }

        public DataRow SourceRow { get; set; }
    }

    public class PeripheralMember : FunctionItems { }

    public class DeviceMember : FunctionItems { }

    public class AccessoriesMember : FunctionItems { }

    public class InterruptMember : FunctionItems { }
}
