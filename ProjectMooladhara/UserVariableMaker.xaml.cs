using Fluent;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ProjectMooladhara
{
    /// <summary>
    /// Shell for RDS, contains all modules
    /// </summary>
    public partial class UserVariableMaker : RibbonWindow
    {
        #region Globals

        #endregion Globals

        #region Initialization

        public UserVariableMaker()
        {
            InitializeComponent();
        }

        #endregion Initialization

        #region Events

        #region Windows

        private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                CMBVariableType.ItemsSource = DataFactory.GetDataTable("DATATYPE", DataFactory.DatabaseSelection.DeviceDatabase).DefaultView;
                CMBVariableType.DisplayMemberPath = "DATA_TYPE";
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        #endregion Windows

        #region ListBox

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        #endregion ListBox

        #region Button

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender == btnSave)
                {
                    if (CHKVariableIsArray.IsChecked == true)
                    {
                        VariableLoadFunctions.AddVariable(TXTVariableName.Text.Trim(), CMBVariableType.Text.Trim(), TXTInitialValue.Text.Trim(), (int)NUDArraySize.Value, TXTDescription.Text.Trim(), true);
                    }
                    else if (CHKVariableIsArray.IsChecked == false)
                    {
                        VariableLoadFunctions.AddVariable(TXTVariableName.Text.Trim(), CMBVariableType.Text.Trim(), TXTInitialValue.Text.Trim(), 0, TXTDescription.Text.Trim(), false);
                    }
                    this.Close();
                }

                if (sender == btnClose)
                {
                    this.Close();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        #endregion Button

        #region TreeView

        private void TreeView_SelectionChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        #endregion TreeView

        #region ContextMenu

        private void ContextMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        #endregion ContextMenu

        #endregion Events
    }
}