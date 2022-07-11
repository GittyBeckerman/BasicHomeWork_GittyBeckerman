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
    /// Interaction logic for AddDevice.xaml, this window is like ViewModel
    /// </summary>
    public partial class AddDevice : Window
    {
        
        //the single instance of model
        private ObservationDeviceModel observationDeviceModel;
        /// <summary>
        /// ctor:: Initialize component, Initialize the single instance
        /// </summary>
        /// <param name="ObservationDeviceModelMain"></param>
        public AddDevice(ObservationDeviceModel ObservationDeviceModelMain)
        {
            InitializeComponent();
            observationDeviceModel = ObservationDeviceModelMain;
            Type.ItemsSource = Enum.GetValues(typeof(ObserveType));
           
        }
        /// <summary>
        /// add device - call to the Model to  Add device
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDeviceToModel(object sender, RoutedEventArgs e)
        {
     
            try
            {
                observationDeviceModel.AddDevice(RangeInput(), fieldOfVisionInput(), (ObserveType)TypeInput());
                MessageBox.Show("you add Observation Device succesfully");
                Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                this.Close();
            }
        }

        // chack input function - helper
        public double RangeInput()
        {
            try { return double.Parse(rangeInput.Text); }
            catch (Exception) { throw new InvalidObjException("range"); }
        }
        // chack input function - helper
        public int TypeInput()
        {
            return Type.SelectedIndex != -1 ? Type.SelectedIndex  : throw new InvalidObjException("Weight");
        }
        // chack input function - helper
        public double fieldOfVisionInput()
        {
            try { return double.Parse(fieldOfViewInput.Text); }
            catch (Exception) { throw new InvalidObjException("field Of vision"); }
        }

   
    }
}
