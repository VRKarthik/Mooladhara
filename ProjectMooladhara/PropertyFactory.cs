using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectMooladhara
{
    public static class PropertyFactory
    {
        public static FunctionProperties GetFunctionWithProperties(DataRow objRow)
        {
            try
            {
                FunctionProperties objFunctionProperties = new FunctionProperties();
                DataTable objTable = DataFactory.GetDataTable("FUN16F884", DataFactory.DatabaseSelection.DeviceDatabase);

                string stringSyntax = objRow["SYNTAX"].ToString().Trim();
                string stringArgsOnly = stringSyntax.Substring(stringSyntax.IndexOf('('));
                int intArgsCount = Regex.Matches(stringArgsOnly, "arg").Count;

                if (intArgsCount == 0)
                {
                    FunctionWithNoArg objFunction = new FunctionWithNoArg();

                    objFunction.Description = objRow["DESC"].ToString();
                    objFunction.Syntax = objRow["SYNTAX"].ToString();
                    objFunction.FunctionName = objRow["FUNC_NAME"].ToString();
                    objFunction.ReturnType = objRow["RET_TYPE"].ToString();
                    objFunction.FunctionNameWithArgCount = "[" + intArgsCount + " arg(s)]";

                    objFunctionProperties = objFunction;
                }
                else if (intArgsCount == 1)
                {
                    FunctionWithOneArg objFunction = new FunctionWithOneArg();

                    objFunction.Description = objRow["DESC"].ToString();
                    objFunction.Syntax = objRow["SYNTAX"].ToString();
                    objFunction.FunctionName = objRow["FUNC_NAME"].ToString();
                    objFunction.ReturnType = objRow["RET_TYPE"].ToString();
                    objFunction.FunctionNameWithArgCount ="[" + intArgsCount + " arg(s)]";

                    objFunction.Argument1DataType = objRow["ARG1_DATATYPE"].ToString();
                    objFunction.Argument1DefaultValue = objRow["ARG1_DEFAULT"].ToString();
                    objFunction.Argument1Name = objRow["ARG1_NAME"].ToString();
                    objFunction.Argument1Options = objRow["ARG1_OPTIONS"].ToString();

                    objFunctionProperties = objFunction;
                }
                else if (intArgsCount == 2)
                {
                    FunctionWithTwoArg objFunction = new FunctionWithTwoArg();

                    objFunction.Description = objRow["DESC"].ToString();
                    objFunction.Syntax = objRow["SYNTAX"].ToString();
                    objFunction.FunctionName = objRow["FUNC_NAME"].ToString();
                    objFunction.ReturnType = objRow["RET_TYPE"].ToString();
                    objFunction.FunctionNameWithArgCount = "[" + intArgsCount + " arg(s)]";

                    objFunction.Argument1DataType = objRow["ARG1_DATATYPE"].ToString();
                    objFunction.Argument1DefaultValue = objRow["ARG1_DEFAULT"].ToString();
                    objFunction.Argument1Name = objRow["ARG1_NAME"].ToString();
                    objFunction.Argument1Options = objRow["ARG1_OPTIONS"].ToString();

                    objFunction.Argument2DataType = objRow["ARG2_DATATYPE"].ToString();
                    objFunction.Argument2DefaultValue = objRow["ARG2_DEFAULT"].ToString();
                    objFunction.Argument2Name = objRow["ARG2_NAME"].ToString();
                    objFunction.Argument2Options = objRow["ARG2_OPTIONS"].ToString();

                    objFunctionProperties = objFunction;
                }
                else if (intArgsCount == 3)
                {
                    FunctionWithThreeArg objFunction = new FunctionWithThreeArg();

                    objFunction.Description = objRow["DESC"].ToString();
                    objFunction.Syntax = objRow["SYNTAX"].ToString();
                    objFunction.FunctionName = objRow["FUNC_NAME"].ToString();
                    objFunction.ReturnType = objRow["RET_TYPE"].ToString();
                    objFunction.FunctionNameWithArgCount = "[" + intArgsCount + " arg(s)]";

                    objFunction.Argument1DataType = objRow["ARG1_DATATYPE"].ToString();
                    objFunction.Argument1DefaultValue = objRow["ARG1_DEFAULT"].ToString();
                    objFunction.Argument1Name = objRow["ARG1_NAME"].ToString();
                    objFunction.Argument1Options = objRow["ARG1_OPTIONS"].ToString();

                    objFunction.Argument2DataType = objRow["ARG2_DATATYPE"].ToString();
                    objFunction.Argument2DefaultValue = objRow["ARG2_DEFAULT"].ToString();
                    objFunction.Argument2Name = objRow["ARG2_NAME"].ToString();
                    objFunction.Argument2Options = objRow["ARG2_OPTIONS"].ToString();

                    objFunction.Argument3DataType = objRow["ARG3_DATATYPE"].ToString();
                    objFunction.Argument3DefaultValue = objRow["ARG3_DEFAULT"].ToString();
                    objFunction.Argument3Name = objRow["ARG3_NAME"].ToString();
                    objFunction.Argument3Options = objRow["ARG3_OPTIONS"].ToString();

                    objFunctionProperties = objFunction;
                }
                else if (intArgsCount == 4)
                {
                    FunctionWithFourArg objFunction = new FunctionWithFourArg();

                    objFunction.Description = objRow["DESC"].ToString();
                    objFunction.Syntax = objRow["SYNTAX"].ToString();
                    objFunction.FunctionName = objRow["FUNC_NAME"].ToString();
                    objFunction.ReturnType = objRow["RET_TYPE"].ToString();
                    objFunction.FunctionNameWithArgCount = "[" + intArgsCount + " arg(s)]";

                    objFunction.Argument1DataType = objRow["ARG1_DATATYPE"].ToString();
                    objFunction.Argument1DefaultValue = objRow["ARG1_DEFAULT"].ToString();
                    objFunction.Argument1Name = objRow["ARG1_NAME"].ToString();
                    objFunction.Argument1Options = objRow["ARG1_OPTIONS"].ToString();

                    objFunction.Argument2DataType = objRow["ARG2_DATATYPE"].ToString();
                    objFunction.Argument2DefaultValue = objRow["ARG2_DEFAULT"].ToString();
                    objFunction.Argument2Name = objRow["ARG2_NAME"].ToString();
                    objFunction.Argument2Options = objRow["ARG2_OPTIONS"].ToString();

                    objFunction.Argument3DataType = objRow["ARG3_DATATYPE"].ToString();
                    objFunction.Argument3DefaultValue = objRow["ARG3_DEFAULT"].ToString();
                    objFunction.Argument3Name = objRow["ARG3_NAME"].ToString();
                    objFunction.Argument3Options = objRow["ARG3_OPTIONS"].ToString();

                    objFunction.Argument4DataType = objRow["ARG4_DATATYPE"].ToString();
                    objFunction.Argument4DefaultValue = objRow["ARG4_DEFAULT"].ToString();
                    objFunction.Argument4Name = objRow["ARG4_NAME"].ToString();
                    objFunction.Argument4Options = objRow["ARG4_OPTIONS"].ToString();

                    objFunctionProperties = objFunction;
                }

                //ModifyPropertiesBrowsable(intArgsCount, objFunction);

                return objFunctionProperties;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        private static void ModifyPropertiesBrowsable(int intCount, FunctionProperties objFunction)
        {
            try
            {
                if (intCount == 0)
                {
                    foreach (var objProperty in objFunction.GetType().GetProperties())
                    {
                        if (objProperty.Name.Contains("Argument1"))
                        {
                            SetBrowsableToFalse(objProperty, objFunction);
                        }

                        if (objProperty.Name.Contains("Argument2"))
                        {
                            SetBrowsableToFalse(objProperty, objFunction);
                        }

                        if (objProperty.Name.Contains("Argument3"))
                        {
                            SetBrowsableToFalse(objProperty, objFunction);
                        }

                        if (objProperty.Name.Contains("Argument4"))
                        {
                            SetBrowsableToFalse(objProperty, objFunction);
                        }
                    }
                }
                else if (intCount == 1)
                {
                    foreach (var objProperty in objFunction.GetType().GetProperties())
                    {
                        //if (objProperty.Name.Contains("Argument1"))
                        //{
                        //    SetBrowsableToTrue(objProperty);
                        //}

                        if (objProperty.Name.Contains("Argument2"))
                        {
                            SetBrowsableToFalse(objProperty, objFunction);
                        }

                        if (objProperty.Name.Contains("Argument3"))
                        {
                            SetBrowsableToFalse(objProperty, objFunction);
                        }

                        if (objProperty.Name.Contains("Argument4"))
                        {
                            SetBrowsableToFalse(objProperty, objFunction);
                        }
                    }
                }
                else if (intCount == 2)
                {
                    foreach (var objProperty in objFunction.GetType().GetProperties())
                    {
                        //if (objProperty.Name.Contains("Argument1"))
                        //{
                        //    SetBrowsableToTrue(objProperty);
                        //}

                        //if (objProperty.Name.Contains("Argument2"))
                        //{
                        //    SetBrowsableToTrue(objProperty);
                        //}

                        if (objProperty.Name.Contains("Argument3"))
                        {
                            SetBrowsableToFalse(objProperty, objFunction);
                        }

                        if (objProperty.Name.Contains("Argument4"))
                        {
                            SetBrowsableToFalse(objProperty, objFunction);
                        }
                    }
                }
                else if (intCount == 3)
                {
                    foreach (var objProperty in objFunction.GetType().GetProperties())
                    {
                        //if (objProperty.Name.Contains("Argument1"))
                        //{
                        //    SetBrowsableToTrue(objProperty);
                        //}

                        //if (objProperty.Name.Contains("Argument2"))
                        //{
                        //    SetBrowsableToTrue(objProperty);
                        //}

                        //if (objProperty.Name.Contains("Argument3"))
                        //{
                        //    SetBrowsableToTrue(objProperty);
                        //}

                        if (objProperty.Name.Contains("Argument4"))
                        {
                            SetBrowsableToFalse(objProperty, objFunction);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        private static void SetBrowsableToFalse(PropertyInfo objProperty, FunctionProperties objFunction)
        {
            try
            {
                Debug.WriteLine(objProperty.Name);
                PropertyDescriptor objPropertyDescriptor = TypeDescriptor.GetProperties(objFunction)[objProperty.Name];
                BrowsableAttribute objBrowsableAttribute = (BrowsableAttribute)objPropertyDescriptor.Attributes[typeof(BrowsableAttribute)];
                FieldInfo IsBrowsable = objBrowsableAttribute.GetType().GetField("browsable", BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.NonPublic);
                IsBrowsable.SetValue(objBrowsableAttribute, false);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }
    }
}