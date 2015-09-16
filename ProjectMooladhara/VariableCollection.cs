using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMooladhara
{
    public class VariableCollection
    {
        public ObservableCollection<VariableProperties> SingleVariablesCollection {get; set;}

        public ObservableCollection<ArrayVariableProperties> ArrayVariablesCollection { get; set; }

        public VariableCollection()
        {
            SingleVariablesCollection = new ObservableCollection<VariableProperties>();
            ArrayVariablesCollection = new ObservableCollection<ArrayVariableProperties>();
        }
    }
}
