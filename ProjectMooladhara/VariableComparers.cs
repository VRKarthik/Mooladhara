using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMooladhara
{
    public class SingleVariableComparer : IEqualityComparer<VariableProperties>
    {
        public bool Equals(VariableProperties CurrentVariable, VariableProperties SecondCurrentVariable)
        {
            bool IsExists = false;
            foreach (VariableProperties ExistingVariable in SharedData.SingleVariablesCollection)
            {
                if (ExistingVariable.VariableName.ToLower() == SecondCurrentVariable.VariableName.ToLower())
                {
                    IsExists = true;
                }
            }
            return IsExists;
        }

        public int GetHashCode(VariableProperties obj)
        {
            return obj.VariableName.GetHashCode();
        }
    }

    public class ArrayVariableComparer : IEqualityComparer<ArrayVariableProperties>
    {
        public bool Equals(ArrayVariableProperties CurrentVariable, ArrayVariableProperties SecondCurrentVariable)
        {
            bool IsExists = false;
            foreach (ArrayVariableProperties ExistingVariable in SharedData.ArrayVariablesCollection)
            {
                if (ExistingVariable.VariableName.ToLower() == SecondCurrentVariable.VariableName.ToLower())
                {
                    IsExists = true;
                }
            }
            return IsExists;
        }

        public int GetHashCode(ArrayVariableProperties obj)
        {
            return obj.VariableName.GetHashCode();
        }
    }
}
