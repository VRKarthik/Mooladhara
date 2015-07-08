using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMooladhara
{
    public class DeviceSeries
    {
        private string _SeriesNumber = null;

        public string SeriesNumber
        {
            get
            {
                return SharedData.SelectedDevice + _SeriesNumber;
            }
            set
            {
                _SeriesNumber = value;
            }
        }

        public string Description1 { get; set; }

        public string Description2 { get; set; }

        public string Description3 { get; set; }

        public string Description4 { get; set; }

        public string Description5 { get; set; }

        public string FullDescription1 { get; set; }

        public string FullDescription2 { get; set; }

        public string FullDescription3 { get; set; }

        public string FullDescription4 { get; set; }

        public string FullDescription5 { get; set; }
    }
}
