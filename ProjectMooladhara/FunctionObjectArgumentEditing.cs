using System;

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
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}