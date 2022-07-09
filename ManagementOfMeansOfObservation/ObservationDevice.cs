using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementOfMeansOfObservation
{
    public class ObservationDevice
    {
        public ObserveType ObserveType { get; set; }
        private double fieldOfView;
        public double FieldOfView
        {
            get { return fieldOfView; }
            set
            {
                if (value > 360 || value < 0)
                    throw new Exception();
                else fieldOfView = value;
            }
        }
        private double _range;


        //Range

        public double range
        {
            get
            {
                return _range;
            }
            set
            {
                _range = value;
            }
        }
        public override string ToString()
        {
            return "Device:: Type: " + ObserveType + ", Range: "+ range +", Field of vision: " + fieldOfView + "."; 
        }
    }
    
}


