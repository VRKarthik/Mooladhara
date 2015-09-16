using System;
using System.ComponentModel;

namespace ProjectMooladhara
{
    [Serializable]
    [DisplayName("Function Properties")]
    public class FunctionWithNoArg : FunctionProperties
    {
        public FunctionWithNoArg()
        {
        }

        #region General

        //General
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

        private string _ModifiedSyntax;

        [Category("General")]
        [DisplayName("Modified Syntax")]
        [Description("Actual syntax of function used in code with user values.")]
        [ReadOnly(true)]
        [Browsable(true)]
        public string ModifiedSyntax
        {
            get { return _ModifiedSyntax; }
            set { _ModifiedSyntax = value; }
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
    }
}