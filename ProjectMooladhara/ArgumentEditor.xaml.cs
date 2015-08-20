using Fluent;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace ProjectMooladhara
{
    /// <summary>
    /// Shell for RDS, contains all modules
    /// </summary>
    public partial class ArgumentEditor : RibbonWindow
    {
        #region Globals

        private FunctionProperties objFunctionToConfigure;
        private string ArgumentName;
        private Type FunctionType;

        #endregion

        #region Initialization

        public ArgumentEditor(FunctionProperties objFunction, string ArgumentName)
        {
            InitializeComponent();
            objFunctionToConfigure = objFunction;
            this.ArgumentName = ArgumentName;
        }

        #endregion Initialization

        #region Events

        #region Windows

        private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                FunctionType = objFunctionToConfigure.GetType();
                lblArgumentName.Content = ArgumentName;

                if (ArgumentName.Contains("ARG-1")) { lblDefaultValue.SetBinding(ContentProperty, new Binding("Argument1DefaultValue")); }
                else if (ArgumentName.Contains("ARG-2")) { lblDefaultValue.SetBinding(ContentProperty, new Binding("Argument2DefaultValue")); }
                else if (ArgumentName.Contains("ARG-3")) { lblDefaultValue.SetBinding(ContentProperty, new Binding("Argument3DefaultValue")); }
                else if (ArgumentName.Contains("ARG-4")) { lblDefaultValue.SetBinding(ContentProperty, new Binding("Argument4DefaultValue")); }

                this.DataContext = objFunctionToConfigure;

                if (ArgumentName.Contains("ARG-1"))
                {
                    string Arg1Type = string.Empty;

                    if (FunctionType == typeof(FunctionWithOneArg))
                    {
                        FunctionWithOneArg TempObject = (FunctionWithOneArg)objFunctionToConfigure;
                        Arg1Type = TempObject.Argument1DataType;

                        switch (TempObject.Argument1ValueSource)
                        {
                            case "Default":
                                rdoDefaultValue.IsChecked = true;
                                break;

                            case "User":
                                rdoUserInput.IsChecked = true;
                                txtUserInput.Text = TempObject.Argument1UserValue;
                                break;

                            case "Variable":
                                rdoAssignVariable.IsChecked = true;
                                cmbAssignVariable.Text = TempObject.Argument1UserValue;
                                break;

                            case "Function":
                                rdoAssignFunction.IsChecked = true;
                                cmdAssignFunction.Text = TempObject.Argument1UserValue;
                                break;
                        }
                    }
                    else if (FunctionType == typeof(FunctionWithTwoArg))
                    {
                        FunctionWithTwoArg TempObject = (FunctionWithTwoArg)objFunctionToConfigure;
                        Arg1Type = TempObject.Argument1DataType;

                        switch (TempObject.Argument1ValueSource)
                        {
                            case "Default":
                                rdoDefaultValue.IsChecked = true;
                                break;

                            case "User":
                                rdoUserInput.IsChecked = true;
                                txtUserInput.Text = TempObject.Argument1UserValue;
                                break;

                            case "Variable":
                                rdoAssignVariable.IsChecked = true;
                                cmbAssignVariable.Text = TempObject.Argument1UserValue;
                                break;

                            case "Function":
                                rdoAssignFunction.IsChecked = true;
                                cmdAssignFunction.Text = TempObject.Argument1UserValue;
                                break;
                        }
                    }
                    else if (FunctionType == typeof(FunctionWithThreeArg))
                    {
                        FunctionWithThreeArg TempObject = (FunctionWithThreeArg)objFunctionToConfigure;
                        Arg1Type = TempObject.Argument1DataType;

                        switch (TempObject.Argument1ValueSource)
                        {
                            case "Default":
                                rdoDefaultValue.IsChecked = true;
                                break;

                            case "User":
                                rdoUserInput.IsChecked = true;
                                txtUserInput.Text = TempObject.Argument1UserValue;
                                break;

                            case "Variable":
                                rdoAssignVariable.IsChecked = true;
                                cmbAssignVariable.Text = TempObject.Argument1UserValue;
                                break;

                            case "Function":
                                rdoAssignFunction.IsChecked = true;
                                cmdAssignFunction.Text = TempObject.Argument1UserValue;
                                break;
                        }
                    }
                    else if (FunctionType == typeof(FunctionWithFourArg))
                    {
                        FunctionWithFourArg TempObject = (FunctionWithFourArg)objFunctionToConfigure;
                        Arg1Type = TempObject.Argument1DataType;

                        switch (TempObject.Argument1ValueSource)
                        {
                            case "Default":
                                rdoDefaultValue.IsChecked = true;
                                break;

                            case "User":
                                rdoUserInput.IsChecked = true;
                                txtUserInput.Text = TempObject.Argument1UserValue;
                                break;

                            case "Variable":
                                rdoAssignVariable.IsChecked = true;
                                cmbAssignVariable.Text = TempObject.Argument1UserValue;
                                break;

                            case "Function":
                                rdoAssignFunction.IsChecked = true;
                                cmdAssignFunction.Text = TempObject.Argument1UserValue;
                                break;
                        }
                    }
                    cmdAssignFunction.ItemsSource = DataFactory.GetDataTableByQuery("select FUNC_NAME from fun" + SharedData.SelectedSeries + " where RET_TYPE='" + Arg1Type + "'", DataFactory.DatabaseSelection.DeviceDatabase).DefaultView;
                }
                else if (ArgumentName.Contains("ARG-2"))
                {
                    string Arg2Type = string.Empty;

                    if (FunctionType == typeof(FunctionWithTwoArg))
                    {
                        FunctionWithTwoArg TempObject = (FunctionWithTwoArg)objFunctionToConfigure;
                        Arg2Type = TempObject.Argument1DataType;

                        switch (TempObject.Argument2ValueSource)
                        {
                            case "Default":
                                rdoDefaultValue.IsChecked = true;
                                break;

                            case "User":
                                rdoUserInput.IsChecked = true;
                                txtUserInput.Text = TempObject.Argument2UserValue;
                                break;

                            case "Variable":
                                rdoAssignVariable.IsChecked = true;
                                cmbAssignVariable.Text = TempObject.Argument2UserValue;
                                break;

                            case "Function":
                                rdoAssignFunction.IsChecked = true;
                                cmdAssignFunction.Text = TempObject.Argument2UserValue;
                                break;
                        }
                    }
                    else if (FunctionType == typeof(FunctionWithThreeArg))
                    {
                        FunctionWithThreeArg TempObject = (FunctionWithThreeArg)objFunctionToConfigure;
                        Arg2Type = TempObject.Argument1DataType;

                        switch (TempObject.Argument2ValueSource)
                        {
                            case "Default":
                                rdoDefaultValue.IsChecked = true;
                                break;

                            case "User":
                                rdoUserInput.IsChecked = true;
                                txtUserInput.Text = TempObject.Argument2UserValue;
                                break;

                            case "Variable":
                                rdoAssignVariable.IsChecked = true;
                                cmbAssignVariable.Text = TempObject.Argument2UserValue;
                                break;

                            case "Function":
                                rdoAssignFunction.IsChecked = true;
                                cmdAssignFunction.Text = TempObject.Argument2UserValue;
                                break;
                        }
                    }
                    else if (FunctionType == typeof(FunctionWithFourArg))
                    {
                        FunctionWithFourArg TempObject = (FunctionWithFourArg)objFunctionToConfigure;
                        Arg2Type = TempObject.Argument1DataType;

                        switch (TempObject.Argument2ValueSource)
                        {
                            case "Default":
                                rdoDefaultValue.IsChecked = true;
                                break;

                            case "User":
                                rdoUserInput.IsChecked = true;
                                txtUserInput.Text = TempObject.Argument2UserValue;
                                break;

                            case "Variable":
                                rdoAssignVariable.IsChecked = true;
                                cmbAssignVariable.Text = TempObject.Argument2UserValue;
                                break;

                            case "Function":
                                rdoAssignFunction.IsChecked = true;
                                cmdAssignFunction.Text = TempObject.Argument2UserValue;
                                break;
                        }
                    }
                    cmdAssignFunction.ItemsSource = DataFactory.GetDataTableByQuery("select FUNC_NAME from fun" + SharedData.SelectedSeries + " where RET_TYPE='" + Arg2Type + "'", DataFactory.DatabaseSelection.DeviceDatabase).DefaultView;
                }
                else if (ArgumentName.Contains("ARG-3"))
                {
                    string Arg3Type = string.Empty;

                    if (FunctionType == typeof(FunctionWithThreeArg))
                    {
                        FunctionWithThreeArg TempObject = (FunctionWithThreeArg)objFunctionToConfigure;
                        Arg3Type = TempObject.Argument1DataType;

                        switch (TempObject.Argument3ValueSource)
                        {
                            case "Default":
                                rdoDefaultValue.IsChecked = true;
                                break;

                            case "User":
                                rdoUserInput.IsChecked = true;
                                txtUserInput.Text = TempObject.Argument3UserValue;
                                break;

                            case "Variable":
                                rdoAssignVariable.IsChecked = true;
                                cmbAssignVariable.Text = TempObject.Argument3UserValue;
                                break;

                            case "Function":
                                rdoAssignFunction.IsChecked = true;
                                cmdAssignFunction.Text = TempObject.Argument3UserValue;
                                break;
                        }
                    }
                    else if (FunctionType == typeof(FunctionWithFourArg))
                    {
                        FunctionWithFourArg TempObject = (FunctionWithFourArg)objFunctionToConfigure;
                        Arg3Type = TempObject.Argument1DataType;

                        switch (TempObject.Argument3ValueSource)
                        {
                            case "Default":
                                rdoDefaultValue.IsChecked = true;
                                break;

                            case "User":
                                rdoUserInput.IsChecked = true;
                                txtUserInput.Text = TempObject.Argument3UserValue;
                                break;

                            case "Variable":
                                rdoAssignVariable.IsChecked = true;
                                cmbAssignVariable.Text = TempObject.Argument3UserValue;
                                break;

                            case "Function":
                                rdoAssignFunction.IsChecked = true;
                                cmdAssignFunction.Text = TempObject.Argument3UserValue;
                                break;
                        }
                    }
                    cmdAssignFunction.ItemsSource = DataFactory.GetDataTableByQuery("select FUNC_NAME from fun" + SharedData.SelectedSeries + " where RET_TYPE='" + Arg3Type + "'", DataFactory.DatabaseSelection.DeviceDatabase).DefaultView;
                }
                else if (ArgumentName.Contains("ARG-4"))
                {
                    string Arg4Type = string.Empty;

                    if (FunctionType == typeof(FunctionWithFourArg))
                    {
                        FunctionWithFourArg TempObject = (FunctionWithFourArg)objFunctionToConfigure;
                        Arg4Type = TempObject.Argument1DataType;

                        switch (TempObject.Argument4ValueSource)
                        {
                            case "Default":
                                rdoDefaultValue.IsChecked = true;
                                break;

                            case "User":
                                rdoUserInput.IsChecked = true;
                                txtUserInput.Text = TempObject.Argument4UserValue;
                                break;

                            case "Variable":
                                rdoAssignVariable.IsChecked = true;
                                cmbAssignVariable.Text = TempObject.Argument4UserValue;
                                break;

                            case "Function":
                                rdoAssignFunction.IsChecked = true;
                                cmdAssignFunction.Text = TempObject.Argument4UserValue;
                                break;
                        }
                    }
                    cmdAssignFunction.ItemsSource = DataFactory.GetDataTableByQuery("select FUNC_NAME from fun" + SharedData.SelectedSeries + " where RET_TYPE='" + Arg4Type + "'", DataFactory.DatabaseSelection.DeviceDatabase).DefaultView;
                }
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
                    //Getting value for argument
                    string UserValueForArgument = string.Empty;
                    string UserValueSource = string.Empty;

                    if (rdoDefaultValue.IsChecked == true)
                    {
                        UserValueForArgument = lblDefaultValue.Content.ToString();
                        UserValueSource = "Default";
                    }
                    else if (rdoUserInput.IsChecked == true)
                    {
                        UserValueForArgument = txtUserInput.Text.Trim();
                        UserValueSource = "User";
                    }
                    else if (rdoAssignVariable.IsChecked == true)
                    {
                        UserValueForArgument = cmbAssignVariable.Text.Trim();
                        UserValueSource = "Variable";
                    }
                    else if (rdoAssignFunction.IsChecked == true)
                    {
                        UserValueForArgument = cmdAssignFunction.Text.Trim();
                        UserValueSource = "Function";
                    }

                    if (ArgumentName.Contains("ARG-1"))
                    {
                        if (objFunctionToConfigure.GetType() == typeof(FunctionWithOneArg))
                        {
                            FunctionWithOneArg objTempObject = (FunctionWithOneArg)objFunctionToConfigure;
                            objTempObject.Argument1UserValue = UserValueForArgument;
                            objTempObject.Argument1ValueSource = UserValueSource;
                            objTempObject.Argument1Status = Brushes.Red;
                        }
                        else if (objFunctionToConfigure.GetType() == typeof(FunctionWithTwoArg))
                        {
                            FunctionWithTwoArg objTempObject = (FunctionWithTwoArg)objFunctionToConfigure;
                            objTempObject.Argument1UserValue = UserValueForArgument;
                            objTempObject.Argument1ValueSource = UserValueSource;
                            objTempObject.Argument1Status = Brushes.Red;
                        }
                        else if (objFunctionToConfigure.GetType() == typeof(FunctionWithThreeArg))
                        {
                            FunctionWithThreeArg objTempObject = (FunctionWithThreeArg)objFunctionToConfigure;
                            objTempObject.Argument1UserValue = UserValueForArgument;
                            objTempObject.Argument1ValueSource = UserValueSource;
                            objTempObject.Argument1Status = Brushes.Red;
                        }
                        else if (objFunctionToConfigure.GetType() == typeof(FunctionWithFourArg))
                        {
                            FunctionWithFourArg objTempObject = (FunctionWithFourArg)objFunctionToConfigure;
                            objTempObject.Argument1UserValue = UserValueForArgument;
                            objTempObject.Argument1ValueSource = UserValueSource;
                            objTempObject.Argument1Status = Brushes.Red;
                        }
                    }
                    else if (ArgumentName.Contains("ARG-2"))
                    {
                        if (objFunctionToConfigure.GetType() == typeof(FunctionWithTwoArg))
                        {
                            FunctionWithTwoArg objTempObject = (FunctionWithTwoArg)objFunctionToConfigure;
                            objTempObject.Argument2UserValue = UserValueForArgument;
                            objTempObject.Argument2ValueSource = UserValueSource;
                            objTempObject.Argument2Status = Brushes.Red;
                        }
                        else if (objFunctionToConfigure.GetType() == typeof(FunctionWithThreeArg))
                        {
                            FunctionWithThreeArg objTempObject = (FunctionWithThreeArg)objFunctionToConfigure;
                            objTempObject.Argument2UserValue = UserValueForArgument;
                            objTempObject.Argument2ValueSource = UserValueSource;
                            objTempObject.Argument2Status = Brushes.Red;
                        }
                        else if (objFunctionToConfigure.GetType() == typeof(FunctionWithFourArg))
                        {
                            FunctionWithFourArg objTempObject = (FunctionWithFourArg)objFunctionToConfigure;
                            objTempObject.Argument2UserValue = UserValueForArgument;
                            objTempObject.Argument2ValueSource = UserValueSource;
                            objTempObject.Argument2Status = Brushes.Red;
                        }
                    }
                    else if (ArgumentName.Contains("ARG-3"))
                    {
                        if (objFunctionToConfigure.GetType() == typeof(FunctionWithThreeArg))
                        {
                            FunctionWithThreeArg objTempObject = (FunctionWithThreeArg)objFunctionToConfigure;
                            objTempObject.Argument3UserValue = UserValueForArgument;
                            objTempObject.Argument3ValueSource = UserValueSource;
                            objTempObject.Argument3Status = Brushes.Red;
                        }
                        else if (objFunctionToConfigure.GetType() == typeof(FunctionWithFourArg))
                        {
                            FunctionWithFourArg objTempObject = (FunctionWithFourArg)objFunctionToConfigure;
                            objTempObject.Argument3UserValue = UserValueForArgument;
                            objTempObject.Argument3ValueSource = UserValueSource;
                            objTempObject.Argument3Status = Brushes.Red;
                        }
                    }
                    else if (ArgumentName.Contains("ARG-4"))
                    {
                        if (objFunctionToConfigure.GetType() == typeof(FunctionWithFourArg))
                        {
                            FunctionWithFourArg objTempObject = (FunctionWithFourArg)objFunctionToConfigure;
                            objTempObject.Argument4UserValue = UserValueForArgument;
                            objTempObject.Argument4ValueSource = UserValueSource;
                            objTempObject.Argument4Status = Brushes.Red;
                        }
                    }
                    this.Close();
                    //MessageBox.Show(((FunctionWithTwoArg)SharedData.objMainWindow.PropertiesGrid.SelectedObject).Argument1UserValue + "\n" + ((FunctionWithTwoArg)SharedData.objMainWindow.PropertiesGrid.SelectedObject).Argument2UserValue);
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