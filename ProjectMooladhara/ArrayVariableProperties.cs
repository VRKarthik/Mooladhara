using System.ComponentModel;

namespace ProjectMooladhara
{
    [DisplayName("Variable Properties")]
    public class ArrayVariableProperties : FunctionWithProperties
    {
        //General
        private string _VariableName;

        [Category("General")]
        [DisplayName("Variable Name")]
        [Description("Name of the variable for identification.")]
        [ReadOnly(true)]
        public string VariableName
        {
            get { return _VariableName; }
            set { _VariableName = value; }
        }

        private string _VariableType;

        [Category("General")]
        [DisplayName("Data Type")]
        [Description("Data Type of the variable.")]
        [ReadOnly(true)]
        public string VariableType
        {
            get { return _VariableType; }
            set { _VariableType = value; }
        }

        private string _InitialValue;

        [Category("General")]
        [DisplayName("Initial Value")]
        [Description("Initial Value of the variable.")]
        [ReadOnly(true)]
        public string InitialValue
        {
            get { return _InitialValue; }
            set { _InitialValue = value; }
        }

        private string _UserValue;

        [Category("General")]
        [DisplayName("Value")]
        [Description("Value from user to the variable.")]
        [ReadOnly(true)]
        public string UserValue
        {
            get { return _UserValue; }
            set { _UserValue = value; }
        }

        private int _ArraySize;

        [Category("General")]
        [DisplayName("Array Size")]
        [Description("Size of the array variable.")]
        [ReadOnly(true)]
        public int ArraySize
        {
            get { return _ArraySize; }
            set { _ArraySize = value; }
        }

        private string _Description;

        [Category("General")]
        [DisplayName("Description")]
        [Description("Details of this variable.")]
        [ReadOnly(true)]
        public string Description 
        {
            get { return _Description; }
            set { _Description = value; }
        }
    }
}