using System.ComponentModel;

namespace ProjectMooladhara
{
    [DisplayName("Variable Properties")]
    public class VariableProperties : FunctionWithProperties
    {
        //General
        [Category("General")]
        [DisplayName("Function Name")]
        [Description("Name of the function for identification.")]
        [ReadOnly(true)]
        public string FunctionName { get; set; }

        [Category("General")]
        [DisplayName("Returns")]
        [Description("Type of object that returned from this function.")]
        [ReadOnly(true)]
        public string ReturnType { get; set; }

        [Category("General")]
        [DisplayName("Syntax")]
        [Description("Actual structure of function used in code.")]
        [ReadOnly(true)]
        public string Syntax { get; set; }

        [Category("General")]
        [DisplayName("Description")]
        [Description("Details of this function.")]
        [ReadOnly(true)]
        public string Description { get; set; }

        public string ExtensionId = string.Empty;

        public string SecondExtensionId = string.Empty;

        //Argument 1
        [Category("Argument 1")]
        [DisplayName("ARG-1 Name")]
        [Description("Name or identifier of Argument 1")]
        [ReadOnly(true)]
        public string Argument1Name { get; set; }

        [Category("Argument 1")]
        [DisplayName("ARG-1 Datatype")]
        [Description("Datatype of Argument 1")]
        [ReadOnly(true)]
        public string Argument1DataType { get; set; }

        public string Argument1Options = string.Empty;

        public string Argument1DefaultValue = string.Empty;

        [Category("Argument 1")]
        [DisplayName("ARG-1 Value")]
        [Description("Value from user input for Argument 1")]
        public string Argument1UserValue { get; set; }

        //Argument 2
        [Category("Argument 2")]
        [DisplayName("ARG-2 Name")]
        [Description("Name or identifier of Argument 2")]
        [ReadOnly(true)]
        public string Argument2Name { get; set; }

        [Category("Argument 2")]
        [DisplayName("ARG-2 Datatype")]
        [Description("Datatype of Argument 2")]
        [ReadOnly(true)]
        public string Argument2DataType { get; set; }

        public string Argument2Options = string.Empty;

        public string Argument2DefaultValue = string.Empty;

        [Category("Argument 2")]
        [DisplayName("ARG-2 Value")]
        [Description("Value from user input for Argument 2")]
        public string Argument2UserValue { get; set; }

        //Argument 3
        [Category("Argument 3")]
        [DisplayName("ARG-3 Name")]
        [Description("Name or identifier of Argument 3")]
        [ReadOnly(true)]
        public string Argument3Name { get; set; }

        [Category("Argument 3")]
        [DisplayName("ARG-3 Datatype")]
        [Description("Datatype of Argument 3")]
        [ReadOnly(true)]
        public string Argument3DataType { get; set; }

        public string Argument3Options = string.Empty;

        public string Argument3DefaultValue = string.Empty;

        [Category("Argument 3")]
        [DisplayName("ARG-3 Value")]
        [Description("Value from user input for Argument 3")]
        public string Argument3UserValue { get; set; }

        //Argument 4
        [Category("Argument 4")]
        [DisplayName("ARG-4 Name")]
        [Description("Name or identifier of Argument 4")]
        [ReadOnly(true)]
        public string Argument4Name { get; set; }

        [Category("Argument 4")]
        [DisplayName("ARG-4 Datatype")]
        [Description("Datatype of Argument 4")]
        [ReadOnly(true)]
        public string Argument4DataType { get; set; }

        public string Argument4Options = string.Empty;

        public string Argument4DefaultValue = string.Empty;

        [Category("Argument 4")]
        [DisplayName("ARG-4 Value")]
        [Description("Value from user input for Argument 4")]
        public string Argument4UserValue { get; set; }
    }
}