using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace ProjectMooladhara
{
    [Serializable]
    [DisplayName("Function Properties")]
    public class FunctionWithFourArg : FunctionProperties, INotifyPropertyChanged
    {
        public FunctionWithFourArg()
        {
        }

        #region General

        //General
        private string ModificationStatusIndicator = null;

        [Browsable(false)]
        public string StatusIndicator
        {
            get { return ModificationStatusIndicator; }
            set { ModificationStatusIndicator = value; OnPropertyChanged("StatusIndicator"); }
        }

        private string _FunctionName;

        [Category("General")]
        [DisplayName("Function Name")]
        [Description("Name of the function for identification.")]
        [ReadOnly(true)]
        [Browsable(true)]
        public string FunctionName
        {
            get { return _FunctionName; }
            set { _FunctionName = value; }
        }

        private string _FunctionNameWithArgCount;

        [Browsable(false)]
        public string FunctionNameWithArgCount
        {
            get { return _FunctionNameWithArgCount; }
            set { _FunctionNameWithArgCount = value; }
        }

        private string _ReturnType;

        [Category("General")]
        [DisplayName("Returns")]
        [Description("Type of object that returned from this function.")]
        [ReadOnly(true)]
        [Browsable(true)]
        public string ReturnType
        {
            get { return _ReturnType; }
            set { _ReturnType = value; }
        }

        private string _Syntax;

        [Category("General")]
        [DisplayName("Syntax")]
        [Description("Actual structure of function used in code.")]
        [ReadOnly(true)]
        [Browsable(true)]
        public string Syntax
        {
            get { return _Syntax; }
            set { _Syntax = value; }
        }

        private string _Description;

        [Category("General")]
        [DisplayName("Description")]
        [Description("Details of this function.")]
        [ReadOnly(true)]
        [Browsable(true)]
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private string _ExtensionId;

        [Browsable(false)]
        public string ExtensionId
        {
            get { return _ExtensionId; }
            set { _ExtensionId = value; }
        }

        private string _SecondExtensionId;

        [Browsable(false)]
        public string SecondExtensionId
        {
            get { return _SecondExtensionId; }
            set { _SecondExtensionId = value; }
        }

        #endregion General

        #region Argument1

        //Argument 1
        private string _Argument1Name;

        [Category("Argument 1")]
        [DisplayName("ARG-1 Name")]
        [Description("Name or identifier of Argument 1")]
        [ReadOnly(true)]
        [Browsable(true)]
        public string Argument1Name
        {
            get { return _Argument1Name; }
            set { _Argument1Name = value; }
        }

        private string _Argument1DataType;

        [Category("Argument 1")]
        [DisplayName("ARG-1 Datatype")]
        [Description("Datatype of Argument 1")]
        [ReadOnly(true)]
        [Browsable(true)]
        public string Argument1DataType
        {
            get { return _Argument1DataType; }
            set { _Argument1DataType = value; }
        }

        private string _Argument1Options;

        [Browsable(false)]
        public string Argument1Options
        {
            get { return _Argument1Options; }
            set { _Argument1Options = value; }
        }

        private string _Argument1DefaultValue;

        [Browsable(false)]
        public string Argument1DefaultValue
        {
            get { return _Argument1DefaultValue; }
            set { _Argument1DefaultValue = value; }
        }

        private string _Argument1UserValue;

        [Category("Argument 1")]
        [DisplayName("ARG-1 Value")]
        [Description("Value from user input for Argument 1")]
        [ReadOnly(false)]
        [Browsable(true)]
        [Editor(typeof(ArgumentValueEditor), typeof(ArgumentValueEditor))]
        public string Argument1UserValue
        {
            get { return _Argument1UserValue; }
            set { _Argument1UserValue = value; }
        }

        private string _Argument1ValueSource;

        [Browsable(false)]
        public string Argument1ValueSource
        {
            get { return _Argument1ValueSource; }
            set { _Argument1ValueSource = value; }
        }

        private string _Argument1Status = "LightGray";

        [Browsable(false)]
        public string Argument1Status
        {
            get { return _Argument1Status; }
            set
            { _Argument1Status = value; OnPropertyChanged("Argument1Status"); }
        }

        #endregion Argument1

        #region Argument2

        //Argument 2
        private string _Argument2Name;

        [Category("Argument 2")]
        [DisplayName("ARG-2 Name")]
        [Description("Name or identifier of Argument 2")]
        [ReadOnly(true)]
        [Browsable(true)]
        public string Argument2Name
        {
            get { return _Argument2Name; }
            set { _Argument2Name = value; }
        }

        private string _Argument2DataType;

        [Category("Argument 2")]
        [DisplayName("ARG-2 Datatype")]
        [Description("Datatype of Argument 2")]
        [ReadOnly(true)]
        [Browsable(true)]
        public string Argument2DataType
        {
            get { return _Argument2DataType; }
            set { _Argument2DataType = value; }
        }

        private string _Argument2Options;

        [Browsable(false)]
        public string Argument2Options
        {
            get { return _Argument2Options; }
            set { _Argument2Options = value; }
        }

        private string _Argument2DefaultValue;

        [Browsable(false)]
        public string Argument2DefaultValue
        {
            get { return _Argument2DefaultValue; }
            set { _Argument2DefaultValue = value; }
        }

        private string _Argument2UserValue;

        [Category("Argument 2")]
        [DisplayName("ARG-2 Value")]
        [Description("Value from user input for Argument 2")]
        [ReadOnly(false)]
        [Browsable(true)]
        [Editor(typeof(ArgumentValueEditor), typeof(ArgumentValueEditor))]
        public string Argument2UserValue
        {
            get { return _Argument2UserValue; }
            set { _Argument2UserValue = value; }
        }

        private string _Argument2ValueSource;

        [Browsable(false)]
        public string Argument2ValueSource
        {
            get { return _Argument2ValueSource; }
            set { _Argument2ValueSource = value; }
        }

        private string _Argument2Status = "LightGray";

        [Browsable(false)]
        public string Argument2Status
        {
            get { return _Argument2Status; }
            set
            { _Argument2Status = value; OnPropertyChanged("Argument2Status"); }
        }

        #endregion Argument2

        #region Argument3

        //Argument 3
        private string _Argument3Name;

        [Category("Argument 3")]
        [DisplayName("ARG-3 Name")]
        [Description("Name or identifier of Argument 3")]
        [ReadOnly(true)]
        [Browsable(true)]
        public string Argument3Name
        {
            get { return _Argument3Name; }
            set { _Argument3Name = value; }
        }

        private string _Argument3DataType;

        [Category("Argument 3")]
        [DisplayName("ARG-3 Datatype")]
        [Description("Datatype of Argument 3")]
        [ReadOnly(true)]
        [Browsable(true)]
        public string Argument3DataType
        {
            get { return _Argument3DataType; }
            set { _Argument3DataType = value; }
        }

        private string _Argument3Options;

        [Browsable(false)]
        public string Argument3Options
        {
            get { return _Argument3Options; }
            set { _Argument3Options = value; }
        }

        private string _Argument3DefaultValue;

        [Browsable(false)]
        public string Argument3DefaultValue
        {
            get { return _Argument3DefaultValue; }
            set { _Argument3DefaultValue = value; }
        }

        private string _Argument3UserValue;

        [Category("Argument 3")]
        [DisplayName("ARG-3 Value")]
        [Description("Value from user input for Argument 3")]
        [ReadOnly(false)]
        [Browsable(true)]
        [Editor(typeof(ArgumentValueEditor), typeof(ArgumentValueEditor))]
        public string Argument3UserValue
        {
            get { return _Argument3UserValue; }
            set { _Argument3UserValue = value; }
        }

        private string _Argument3ValueSource;

        [Browsable(false)]
        public string Argument3ValueSource
        {
            get { return _Argument3ValueSource; }
            set { _Argument3ValueSource = value; }
        }

        private string _Argument3Status = "LightGray";

        [Browsable(false)]
        public string Argument3Status
        {
            get { return _Argument3Status; }
            set
            { _Argument3Status = value; OnPropertyChanged("Argument3Status"); }
        }

        #endregion Argument3

        #region Argument4

        //Argument 4
        private string _Argument4Name;

        [Category("Argument 4")]
        [DisplayName("ARG-4 Name")]
        [Description("Name or identifier of Argument 4")]
        [ReadOnly(true)]
        [Browsable(true)]
        public string Argument4Name
        {
            get { return _Argument4Name; }
            set { _Argument4Name = value; }
        }

        private string _Argument4DataType;

        [Category("Argument 4")]
        [DisplayName("ARG-4 Datatype")]
        [Description("Datatype of Argument 4")]
        [ReadOnly(true)]
        [Browsable(true)]
        public string Argument4DataType
        {
            get { return _Argument4DataType; }
            set { _Argument4DataType = value; }
        }

        private string _Argument4Options;

        [Browsable(false)]
        public string Argument4Options
        {
            get { return _Argument4Options; }
            set { _Argument4Options = value; }
        }

        private string _Argument4DefaultValue;

        [Browsable(false)]
        public string Argument4DefaultValue
        {
            get { return _Argument4DefaultValue; }
            set { _Argument4DefaultValue = value; }
        }

        private string _Argument4UserValue;

        [Category("Argument 4")]
        [DisplayName("ARG-4 Value")]
        [Description("Value from user input for Argument 4")]
        [ReadOnly(false)]
        [Browsable(true)]
        [Editor(typeof(ArgumentValueEditor), typeof(ArgumentValueEditor))]
        public string Argument4UserValue
        {
            get { return _Argument4UserValue; }
            set { _Argument4UserValue = value; }
        }

        private string _Argument4ValueSource;

        [Browsable(false)]
        public string Argument4ValueSource
        {
            get { return _Argument4ValueSource; }
            set { _Argument4ValueSource = value; }
        }

        private string _Argument4Status = "LightGray";

        [Browsable(false)]
        public string Argument4Status
        {
            get { return _Argument4Status; }
            set
            { _Argument4Status = value; OnPropertyChanged("Argument4Status"); }
        }

        #endregion Argument4

        #region INotifyPropertyChanged Members

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}