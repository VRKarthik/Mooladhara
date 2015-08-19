using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMooladhara
{
    public static class FunctionObjectArgumentEditing
    {
        public static void EditArgument(FunctionProperties objFunction)
        {
            try
            {
                ArgumentEditor objArgumentEditor = new ArgumentEditor(objFunction);
                objArgumentEditor.Show();
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
