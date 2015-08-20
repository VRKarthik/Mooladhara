using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMooladhara
{
    public static class FunctionObjectArgumentEditing
    {
        public static void EditArgument(FunctionProperties objFunction, string ArgumentName)
        {
            try
            {
                ArgumentEditor objArgumentEditor = new ArgumentEditor(objFunction, ArgumentName);
                objArgumentEditor.Show();
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
