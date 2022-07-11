using System;
using GUI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// this class is Observation Device
    /// </summary>
    public class ObservationDevice
    {
        public ObserveType ObserveType { get; set; }
        private double fieldOfView;
        private double _range;



        //fieldOfView property
        public double FieldOfView
        {
            get { return fieldOfView; }
            set
            {
                if (value > 360 || value < 0)
                    throw new InvalidObjException("field of vision,  must be in  degrees!");
                else fieldOfView = value;
            }
        }



        //Range property

        public double range
        {
            get
            {
                return _range;
            }
            set
            {
                if ( value < 0)
                    throw new InvalidObjException("range,  can't be negetive!");
                else _range = value;
            }
        }


        //ovveride ToString
        public override string ToString()
        {
            return "Device:: Type: " + ObserveType + ", Range: "+ range +", Field of vision: " + fieldOfView + "."; 
        }
    }
    
}


