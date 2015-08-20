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
    [DisplayName("Function Properties")]
    public class FunctionWithOneArg : FunctionProperties
    {
        public FunctionWithOneArg()
        {
        }

        #region General

        //General
        private SolidColorBrush ModificationStatusIndicator;

        [Browsable(false)]
        public SolidColorBrush StatusIndicator
        {
            get { return ModificationStatusIndicator; }
            set { ModificationStatusIndicator = value; }
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

        #endregion Argument1
    }
}