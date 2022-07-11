using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ObservationDeviceModel
    {
        List<ObservationDevice> observationDevices;
        public ObservationDeviceModel()
        {
            observationDevices = new List<ObservationDevice>();
        }

        public void AddDevice(double range, double fieldOfView, ObserveType Type)
        {
            ObservationDevice observationDevice = new ObservationDevice();
            observationDevice.range = range;
            observationDevice.FieldOfView = fieldOfView;
            observationDevice.ObserveType = Type;
            observationDevices.Add(observationDevice);
        }
        public void DeleteDevice(double range, double fieldOfView, ObserveType Type)
        {
            int observationDeviceIndex = observationDevices.FindIndex(d => d.ObserveType == Type && d.range == range && d.FieldOfView == fieldOfView);
            observationDevices.RemoveAt(observationDeviceIndex);
        }
        public List<ObservationDevice> GetDevicesList()
        {
            return observationDevices;
        }
    }
}
