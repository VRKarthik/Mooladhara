using System;
using System.Data;
using System.Data.SQLite;

namespace ProjectMooladhara
{
    public static class DataFactory
    {
        private static string stringConnectionStringToMainDB = "Data Source=" + SharedData.RDSConfigurationDirectory + "\\Moola.db;Version=3;New=False;Compress=True;";

        public enum DatabaseSelection
        {
            MainDatabase,
            DeviceDatabase,
            HeadersDatabase
        };

        /// <summary>
        /// Get Dataset from DB for specified Tablename
        /// </summary>
        /// <param name="TableName">Table name to be selected</param>
        /// <returns>Dataset contains table data</returns>
        public static DataSet GetDataSet(string TableName, DatabaseSelection objDatabaseSelection)
        {
            try
            {
                SQLiteConnection objDatabaseConnection = new SQLiteConnection();

                if (objDatabaseSelection == DatabaseSelection.MainDatabase)
                {
                    objDatabaseConnection.ConnectionString = stringConnectionStringToMainDB;
                }
                else if (objDatabaseSelection == DatabaseSelection.DeviceDatabase)
                {
                    objDatabaseConnection.ConnectionString = "Data Source=" + SharedData.RDSConfigurationDirectory + "\\" + SharedData.SelectedDevice + "\\D" + SharedData.SelectedDeviceSeries + ".db;Version=3;New=False;Compress=True;";
                }
                else if (objDatabaseSelection == DatabaseSelection.HeadersDatabase)
                {
                    objDatabaseConnection.ConnectionString = "Data Source=" + SharedData.RDSConfigurationDirectory + "\\" + SharedData.SelectedDevice + "\\H" + SharedData.SelectedDeviceSeries + ".db;Version=3;New=False;Compress=True;";
                }
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
        /// Get Datatable from DB for specified query
        /// </summary>
        /// <param name="TableName">Query to be executed</param>
        /// <returns>Datatable contains table data</returns>
        public static DataTable GetDataTableByQuery(string Query, DatabaseSelection objDatabaseSelection)
        {
            try
            {
                SQLiteConnection objDatabaseConnection = new SQLiteConnection();

                if (objDatabaseSelection == DatabaseSelection.MainDatabase)
                {
                    objDatabaseConnection.ConnectionString = stringConnectionStringToMainDB;
                }
                else if (objDatabaseSelection == DatabaseSelection.DeviceDatabase)
                {
                    objDatabaseConnection.ConnectionString = "Data Source=" + SharedData.RDSConfigurationDirectory + "\\" + SharedData.SelectedDevice + "\\D" + SharedData.SelectedDeviceSeries + ".db;Version=3;New=False;Compress=True;";
                }
                else if (objDatabaseSelection == DatabaseSelection.HeadersDatabase)
                {
                    objDatabaseConnection.ConnectionString = "Data Source=" + SharedData.RDSConfigurationDirectory + "\\" + SharedData.SelectedDevice + "\\H" + SharedData.SelectedDeviceSeries + ".db;Version=3;New=False;Compress=True;";
                }
                objDatabaseConnection.Open();
                SQLiteCommand objSelectCommand = objDatabaseConnection.CreateCommand();
                SQLiteDataAdapter objSQLiteAdapter = new SQLiteDataAdapter(Query, objDatabaseConnection);
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

        /// <summary>
        /// Get Datatable from DB for specified Tablename
        /// </summary>
        /// <param name="TableName">Table name to be selected</param>
        /// <returns>Datatable contains table data</returns>
        public static DataTable GetDataTable(string TableName, DatabaseSelection objDatabaseSelection)
        {
            try
            {
                SQLiteConnection objDatabaseConnection = new SQLiteConnection();

                if (objDatabaseSelection == DatabaseSelection.MainDatabase)
                {
                    objDatabaseConnection.ConnectionString = stringConnectionStringToMainDB;
                }
                else if (objDatabaseSelection == DatabaseSelection.DeviceDatabase)
                {
                    objDatabaseConnection.ConnectionString = "Data Source=" + SharedData.RDSConfigurationDirectory + "\\" + SharedData.SelectedDevice + "\\D" + SharedData.SelectedDeviceSeries + ".db;Version=3;New=False;Compress=True;";
                }
                else if (objDatabaseSelection == DatabaseSelection.HeadersDatabase)
                {
                    objDatabaseConnection.ConnectionString = "Data Source=" + SharedData.RDSConfigurationDirectory + "\\" + SharedData.SelectedDevice + "\\H" + SharedData.SelectedDeviceSeries + ".db;Version=3;New=False;Compress=True;";
                }
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