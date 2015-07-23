using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMooladhara
{
    public static class PropertyFactory
    {
        public static FunctionProperties GetFunctionWithProperties(DataRow objRow)
        {
            try
            {
                FunctionProperties objFunction = new FunctionProperties();
                DataTable objTable = DataFactory.GetDataTable("FUN16F884", DataFactory.DatabaseSelection.DeviceDatabase);

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

                objFunction.Description = objRow["DESC"].ToString();
                objFunction.Syntax = objRow["SYNTAX"].ToString();
                objFunction.FunctionName = objRow["FUNC_NAME"].ToString();
                objFunction.ReturnType = objRow["RET_TYPE"].ToString();
                return objFunction;
            }
            catch(Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }
    }
}
