using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

    public class FunctionItems { }

    public class PeripheralMember : FunctionItems
    {
        public string PeripheralName { get; set; }
    }

    public class DeviceMember : FunctionItems
    {
        public string DeviceName { get; set; }
    }

    public class AccessoriesMember : FunctionItems
    {
        public string AccessoriesName { get; set; }
    }

    public class InterruptMember : FunctionItems
    {
        public string InterruptName { get; set; }
    }
}
