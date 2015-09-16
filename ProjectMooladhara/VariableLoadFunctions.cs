using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMooladhara
{
    public static class VariableLoadFunctions
    {
        public static void AddVariable(string VariableName, string VariableType, string InitialValue, int ArraySize, string Description, bool IsArray)
        {
            if (IsArray == true)
            {
                ArrayVariableProperties objArrayVariable = new ArrayVariableProperties();
                objArrayVariable.VariableName = VariableName;
                objArrayVariable.VariableType = VariableType;
                objArrayVariable.InitialValue = InitialValue;
                objArrayVariable.ArraySize = ArraySize;
                objArrayVariable.Description = Description;

                if (SharedData.ArrayVariablesCollection.Contains(objArrayVariable, new ArrayVariableComparer()))
                {
                    throw new Exception("Variable with provided variable name already exists.\nPlease change the variable name. ");
                }
                else
                {
                    SharedData.ArrayVariablesCollection.Add(objArrayVariable);
                }
            }
            else if (IsArray == false)
            {
                VariableProperties objSingleVariable = new VariableProperties();
                objSingleVariable.VariableName = VariableName;
                objSingleVariable.VariableType = VariableType;
                objSingleVariable.InitialValue = InitialValue;
                objSingleVariable.Description = Description;

                if (SharedData.SingleVariablesCollection.Contains(objSingleVariable, new SingleVariableComparer()))
                {
                    throw new Exception("Variable with provided variable name already exists.\nPlease change the variable name. ");
                }
                else
                {
                    SharedData.SingleVariablesCollection.Add(objSingleVariable);
                }
            }
        }
    }
}
