using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMooladhara
{
    public class FunctionWithProperties
    {
        public ObservableCollection<FunctionWithProperties> FunctionWithPropertiesCollection { get; set; }

        public FunctionWithProperties()
        {
            this.FunctionWithPropertiesCollection = new ObservableCollection<FunctionWithProperties>();
        }
    }
}
