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
using ManagementOfMeansOfObservation;

namespace GUI
{
    /// <summary>
    /// Interaction logic for LongRange.xaml
    /// </summary>
    public partial class LongRange : Window
    {
        BL bl;
        public LongRange(BL blMain)
        {

            InitializeComponent();
            bl = blMain;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool observationDevice = bl.GetDevicesList().FindAll(d => d.FieldOfView >= fieldOfVisionInput()).OrderBy(d => d.range).ToList().Any();
                DeviceInfo.Text = observationDevice == false ? "No device found" : bl.GetDevicesList().FindAll(d => d.FieldOfView >= fieldOfVisionInput()).OrderBy(d => d.range).ToList().First().ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                this.Close();
            }


        }

        public double fieldOfVisionInput()
        {
            try { return double.Parse(fieldOfViewInput.Text); }
            catch (Exception) { throw new InvalidObjException("field Of View Input"); }
        }

    
    }



}
