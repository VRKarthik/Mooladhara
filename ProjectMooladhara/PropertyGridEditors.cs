using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace ProjectMooladhara
{
    public class ArgumentValueEditor : ITypeEditor
    {
        public FrameworkElement ResolveEditor(PropertyItem propertyItem)
        {
            Button objButton = new Button();
            objButton.Content = "...";
            objButton.Tag = propertyItem.DisplayName;
            objButton.HorizontalAlignment = HorizontalAlignment.Stretch;
            objButton.Click += objButton_Click;

            //var _binding = new Binding("Value");
            //_binding.Source = propertyItem;
            //_binding.ValidatesOnExceptions = true;
            //_binding.ValidatesOnDataErrors = true;
            //_binding.Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay;
            //BindingOperations.SetBinding(button.DropDownContent as DataGrid, DataGrid.ItemsSourceProperty, _binding);

            return objButton;
        }

        private void objButton_Click(object sender, RoutedEventArgs e)
        {
            FunctionObjectArgumentEditing.EditArgument((FunctionProperties)SharedData.objMainWindow.PropertiesGrid.SelectedObject, ((Button)sender).Tag.ToString().Trim());
        }
    }
}
