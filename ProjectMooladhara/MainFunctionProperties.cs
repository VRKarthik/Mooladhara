using System;
using System.ComponentModel;

namespace ProjectMooladhara
{
    [Serializable]
    [DisplayName("Main Function Properties")]
    public class MainFunctionProperties : FunctionWithProperties
    {
        //General
        [Category("General")]
        [DisplayName("Function Name")]
        [Description("Name of the function for identification.")]
        [ReadOnly(true)]
        public string FunctionName { get { return "Main"; } }

        [Category("General")]
        [DisplayName("Returns")]
        [Description("Type of object that returned from this function.")]
        [ReadOnly(true)]
        public string ReturnType { get { return "void"; } }

        [Category("General")]
        [DisplayName("Syntax")]
        [Description("Actual structure of function used in code.")]
        [ReadOnly(true)]
        public string Syntax { get { return "main()"; } }

        [Category("General")]
        [DisplayName("Description")]
        [Description("Details of this function.")]
        [ReadOnly(true)]
        public string Description { get { return "Starting point of the program"; } }
    }
}