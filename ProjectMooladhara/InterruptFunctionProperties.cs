using System.ComponentModel;

namespace ProjectMooladhara
{
    [DisplayName("Interrupt Function Properties")]
    public class InterruptFunctionProperties : FunctionWithProperties
    {
        //General
        [Category("General")]
        [DisplayName("Function Name")]
        [Description("Name of the function for identification.")]
        [ReadOnly(true)]
        public string FunctionName { get { return "Interrupt Routine"; } }

        [Category("General")]
        [DisplayName("Returns")]
        [Description("Type of object that returned from this function.")]
        [ReadOnly(true)]
        public string ReturnType { get { return "void"; } }

        [Category("General")]
        [DisplayName("Syntax")]
        [Description("Actual structure of function used in code.")]
        [ReadOnly(true)]
        public string Syntax { get { return "interrupt()"; } }

        [Category("General")]
        [DisplayName("Description")]
        [Description("Details of this function.")]
        [ReadOnly(true)]
        public string Description { get { return "Starting point of the interrupt"; } }
    }
}