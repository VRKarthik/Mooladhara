using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMooladhara
{
    public static class DataFactory
    {
        private static string stringConnectionString = "Data Source=" + SharedData.RDSConfigurationDirectory + "\\Moola.db;Version=3;New=False;Compress=True;";

        /// <summary>
        /// Get Dataset from DB for specified Tablename
        /// </summary>
        /// <param name="TableName">Table name to be selected</param>
        /// <returns>Dataset contains table data</returns>
        public static DataSet GetDataSet(string TableName)
        {
            try
            {
                SQLiteConnection objDatabaseConnection = new SQLiteConnection(stringConnectionString);
                objDatabaseConnection.Open();
                SQLiteCommand objSelectCommand = objDatabaseConnection.CreateCommand();
                SQLiteDataAdapter objSQLiteAdapter = new SQLiteDataAdapter("select * from " + TableName, objDatabaseConnection);
                DataSet objTempDataSet = new DataSet();
                objSQLiteAdapter.Fill(objTempDataSet);
                objDatabaseConnection.Close();
                return objTempDataSet;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        /// <summary>
        /// Get Datatable from DB for specified Tablename
        /// </summary>
        /// <param name="TableName">Table name to be selected</param>
        /// <returns>Datatable contains table data</returns>
        public static DataTable GetDataTable(string TableName)
        {
            try
            {
                SQLiteConnection objDatabaseConnection = new SQLiteConnection(stringConnectionString);
                objDatabaseConnection.Open();
                SQLiteCommand objSelectCommand = objDatabaseConnection.CreateCommand();
                SQLiteDataAdapter objSQLiteAdapter = new SQLiteDataAdapter("select * from " + TableName, objDatabaseConnection);
                DataSet objTempDataSet = new DataSet();
                objSQLiteAdapter.Fill(objTempDataSet);
                objDatabaseConnection.Close();
                return objTempDataSet.Tables[0];
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }
    }
}
