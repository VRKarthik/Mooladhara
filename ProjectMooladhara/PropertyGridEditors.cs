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
    public class DataGridEditor : ITypeEditor
    {
        public FrameworkElement ResolveEditor(PropertyItem propertyItem)
        {
            var button = new ComboBox();
            button.MinHeight = 10;
            button.HorizontalAlignment = HorizontalAlignment.Stretch;
            button.VerticalAlignment = VerticalAlignment.Stretch;
            button.IsTextSearchEnabled = true;
            button.IsEditable = true;

            //var _binding = new Binding("Value");
            //_binding.Source = propertyItem;
            //_binding.ValidatesOnExceptions = true;
            //_binding.ValidatesOnDataErrors = true;
            //_binding.Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay;
            //BindingOperations.SetBinding(button.DropDownContent as DataGrid, DataGrid.ItemsSourceProperty, _binding);

            return button;
        }
    }
}
