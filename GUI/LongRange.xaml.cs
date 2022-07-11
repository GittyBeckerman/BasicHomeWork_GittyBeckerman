using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Model;

namespace GUI
{
    /// <summary>
    /// Interaction logic for LongRange.xaml
    /// </summary>
    /// 
    public partial class LongRange : Window
    {
        // the instance of model
        ObservationDeviceModel ObservationDeviceModel;
        // ctor:   Initialize component'   Initialize the instance of model
        public LongRange(ObservationDeviceModel ObservationDeviceModelMain)
        {

            InitializeComponent();
            ObservationDeviceModel = ObservationDeviceModelMain;


        }
        /// <summary>
        ///  the function display to the screen the devices who are they FieldOfView is at least As in their requirement and the range is max!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void DisplaySuitabledevices(object sender, RoutedEventArgs e)
        {
            try
            {
                bool observationDevice = ObservationDeviceModel.GetDevicesList().FindAll(d => d.FieldOfView >= fieldOfVisionInput()).OrderBy(d => d.range).ToList().Any();
                DeviceInfo.Text = observationDevice == false ? "No device found" : ObservationDeviceModel.GetDevicesList().FindAll(d => d.FieldOfView >= fieldOfVisionInput()).OrderBy(d => d.range).ToList().First().ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                this.Close();
            }


        }





        // cheack input function - helper function
        public double fieldOfVisionInput()
        {
            try { return double.Parse(fieldOfViewInput.Text); }
            catch (Exception) { throw new InvalidObjException("field Of View Input"); }
        }

    
    }



}
