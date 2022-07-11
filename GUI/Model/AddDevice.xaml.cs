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
    /// Interaction logic for AddDevice.xaml
    /// </summary>
    public partial class AddDevice : Window
    {
        private ObservationDeviceModel bl;
        public AddDevice(ObservationDeviceModel blMain)
        {
            InitializeComponent();
            bl = blMain;
            Type.ItemsSource = Enum.GetValues(typeof(ObserveType));
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
     
            try
            {
                bl.AddDevice(RangeInput(), fieldOfVisionInput(), (ObserveType)TypeInput());
                MessageBox.Show("you add Observation Device succesfully");
                Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                this.Close();
            }
        }
        public double RangeInput()
        {
            try { return double.Parse(rangeInput.Text); }
            catch (Exception) { throw new InvalidObjException("range"); }
        }

        public int TypeInput()
        {
            return Type.SelectedIndex != -1 ? Type.SelectedIndex  : throw new InvalidObjException("Weight");
        }

        public double fieldOfVisionInput()
        {
            try { return double.Parse(fieldOfViewInput.Text); }
            catch (Exception) { throw new InvalidObjException("field Of vision"); }
        }

        private void Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
