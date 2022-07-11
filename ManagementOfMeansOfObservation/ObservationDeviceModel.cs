using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    /// <summary>
    /// this class responsible for the entire logical side of the system
    /// </summary>
    public class ObservationDeviceModel
    {
        //list of all the devices
        List<ObservationDevice> observationDevices;

        //ctor: ctor Initializing the list 
        public ObservationDeviceModel()
        {
            observationDevices = new List<ObservationDevice>();
        }

        /// <summary>
        ///  add device to the list 
        /// </summary>
        /// <param name="range"></param>
        /// <param name="fieldOfView"></param>
        /// <param name="Type"></param>

        public void AddDevice(double range, double fieldOfView, ObserveType Type)
        {
            ObservationDevice observationDevice = new ObservationDevice();
            observationDevice.range = range;
            observationDevice.FieldOfView = fieldOfView;
            observationDevice.ObserveType = Type;
            observationDevices.Add(observationDevice);
        }

        /// <summary>
        /// delete device from the list 
        /// </summary>
        /// <param name="range"></param>
        /// <param name="fieldOfView"></param>
        /// <param name="Type"></param>
        public void DeleteDevice(double range, double fieldOfView, ObserveType Type)
        {
            int observationDeviceIndex = observationDevices.FindIndex(d => d.ObserveType == Type && d.range == range && d.FieldOfView == fieldOfView);
            observationDevices.RemoveAt(observationDeviceIndex);
        }

        // helper function 
        public List<ObservationDevice> GetDevicesList()
        {
            return observationDevices;
        }
    }
}
