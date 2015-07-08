using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ProjectMooladhara
{
    public static class UILoadFunctions
    {
        /// <summary>
        /// Prepares RDS supported device list to bind with ListBox - LBXListDevices from table Supported_Devices
        /// </summary>
        /// <returns>Observable Collection of RDS Supported Devices</returns>
        public static ObservableCollection<Devices> PrepareDeviceList()
        {
            try
            {
                ObservableCollection<Devices> RDSDeviceList = new ObservableCollection<Devices>();

                foreach (DataRow objCurrentRow in DataFactory.GetDataTable("Supported_Devices").Rows)
                {
                    Devices objDevice = new Devices();
                    objDevice.DeviceName = objCurrentRow["dev_name"].ToString().Trim();
                    objDevice.DeviceManufacturer = objCurrentRow["dev_manuf"].ToString().Trim();
                    objDevice.DeviceSpecifications = objCurrentRow["dev_desc"].ToString().Trim();

                    byte[] byteImage = (byte[])objCurrentRow["dev_image"];
                    Stream stream = new MemoryStream(byteImage);
                    BitmapImage objImage = new BitmapImage();
                    objImage = new BitmapImage();
                    objImage.BeginInit();
                    objImage.StreamSource = stream;
                    objImage.EndInit();

                    objDevice.DeviceImage = objImage;
                    objDevice.DeviceLink = objCurrentRow["dev_link"].ToString().Trim();

                    RDSDeviceList.Add(objDevice);
                }

                return RDSDeviceList;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        public static ObservableCollection<DeviceSeries> PrepareDeviceSeriesList(string DeviceName)
        {
            try
            {
                ObservableCollection<DeviceSeries> RDSDeviceSeriesList = new ObservableCollection<DeviceSeries>();

                foreach (DataRow objCurrentRow in DataFactory.GetDataTable(DeviceName).Rows)
                {
                    DeviceSeries objDevice = new DeviceSeries();
                    objDevice.SeriesNumber = objCurrentRow["ID"].ToString().Trim();
                    objDevice.Description1 = objCurrentRow["DESC1"].ToString().Trim().Split('$')[0];
                    objDevice.Description2 = objCurrentRow["DESC2"].ToString().Trim().Split('$')[0];
                    objDevice.Description3 = objCurrentRow["DESC3"].ToString().Trim().Split('$')[0];
                    objDevice.Description4 = objCurrentRow["DESC4"].ToString().Trim().Split('$')[0];
                    objDevice.Description5 = objCurrentRow["DESC5"].ToString().Trim().Split('$')[0];

                    objDevice.FullDescription1 = objCurrentRow["DESC1"].ToString().Trim();
                    objDevice.FullDescription2 = objCurrentRow["DESC2"].ToString().Trim();
                    objDevice.FullDescription3 = objCurrentRow["DESC3"].ToString().Trim();
                    objDevice.FullDescription4 = objCurrentRow["DESC4"].ToString().Trim();
                    objDevice.FullDescription5 = objCurrentRow["DESC5"].ToString().Trim();

                    RDSDeviceSeriesList.Add(objDevice);
                }

                return RDSDeviceSeriesList;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        /// <summary>
        /// Load and Sets device details like device name, manufacturer, etc., from table PICDevices
        /// </summary>
        public static void SetDeviceDetails()
        {
            try
            {
                Devices objSelectedDevice = (Devices)SharedData.objMainWindow.LBXDeviceList.SelectedItem;
                SharedData.objMainWindow.LBLDeviceName.Content = objSelectedDevice.DeviceName;
                SharedData.objMainWindow.RTBDescription.Document.Blocks.Clear();
                SharedData.objMainWindow.RTBDescription.Document.Blocks.Add(new Paragraph(new Run(objSelectedDevice.DeviceSpecifications)));
                SharedData.objMainWindow.LBLManufacturer.Text = "";
                SharedData.objMainWindow.LBLManufacturer.Inlines.Add(new Run(objSelectedDevice.DeviceManufacturer + "   "));
                SharedData.objMainWindow.LBLManufacturer.Inlines.Add(new Run(objSelectedDevice.DeviceLink) { FontStyle = FontStyles.Italic, TextDecorations = TextDecorations.Underline, Foreground = Brushes.Blue });
                SharedData.objMainWindow.IMGDeviceImage.Source = objSelectedDevice.DeviceImage;

                if (objSelectedDevice.DeviceName.Contains("PIC"))
                {
                    SharedData.SelectedDevice = "PIC";
                    SharedData.objMainWindow.LBXSeries.ItemsSource = PrepareDeviceSeriesList("PICDevices");
                }
                else if (objSelectedDevice.DeviceName.Contains("ARM"))
                {
                    SharedData.SelectedDevice = "ARM";
                    SharedData.objMainWindow.LBXSeries.ItemsSource = PrepareDeviceSeriesList("ARMDevices");
                }
                else if (objSelectedDevice.DeviceName.Contains("AVR"))
                {
                    SharedData.SelectedDevice = "AVR";
                    SharedData.objMainWindow.LBXSeries.ItemsSource = PrepareDeviceSeriesList("AVRDevices");
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }
    }
}
