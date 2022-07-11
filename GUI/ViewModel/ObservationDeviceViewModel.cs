using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    class ObservationDeviceViewModel
    {
  
            public ObserveType ObserveType { get; set; }
            public double fieldOfView { get; set; }

        public double range { get; set; }

        ObservationDeviceViewModel(double fieldOfView, double range, ObserveType ObserveType)
        {
            this.range = range;
            this.ObserveType = ObserveType;
            this.fieldOfView = fieldOfView;
        }





    }
}
