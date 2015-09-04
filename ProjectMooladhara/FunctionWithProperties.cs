using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ProjectMooladhara
{
    [Serializable]
    public class FunctionWithProperties
    {
        [Browsable(false)]
        public ObservableCollection<FunctionWithProperties> FunctionWithPropertiesCollection { get; set; }

        public FunctionWithProperties()
        {
            this.FunctionWithPropertiesCollection = new ObservableCollection<FunctionWithProperties>();
        }
    }
}