using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ProjectMooladhara
{
    public class Devices
    {
        public string DeviceName { get; set; }
        public string DeviceManufacturer { get; set; }
        public string DeviceSpecifications { get; set; }
        public BitmapImage DeviceImage { get; set; }
        public string DeviceLink { get; set; }
    }
}
