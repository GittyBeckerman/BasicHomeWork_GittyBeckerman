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
using System.Collections.ObjectModel;

namespace GUI
{
    /// <summary>
    /// Interaction logic for DevicesList.xaml
    /// </summary>
    public partial class DevicesList : Window
    {
        BL bl;

        private ObservableCollection<ObservationDevice> MyCollection = new ObservableCollection<ObservationDevice>();
        public DevicesList(BL blMain)
        {
            InitializeComponent();
            bl = blMain;
            foreach (ObservationDevice device in bl.GetDevicesList())
            {
                MyCollection.Add(device);
            }
            DataContext = MyCollection;
            TypeSelector.ItemsSource = Enum.GetValues(typeof(ObserveType));

        }

        private void DevicesListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ObservationDevice observationDevice = (sender as ListView).SelectedValue as ObservationDevice;
                bl.DeleteDevice(observationDevice.range, observationDevice.FieldOfView, observationDevice.ObserveType);
                MyCollection.Remove(observationDevice);
                DevicesListView.ItemsSource = MyCollection;

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                this.Close();
            }
        }

        private void TypeSelectorSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox status = sender as ComboBox;

            DevicesListView.ItemsSource = bl.GetDevicesList().FindAll(device => device.ObserveType == (ObserveType)status.SelectedItem);
        }

        private void SortByRange(object sender, RoutedEventArgs e)
        {
            
         MyCollection  = ConvertListToObservableCollection(MyCollection.OrderBy(d => d.range).ToList());

        }

        public static ObservableCollection<ObservationDevice> ConvertListToObservableCollection(List<ObservationDevice> SourceList)
        {


            ObservableCollection<ObservationDevice> targetList = new ObservableCollection<ObservationDevice>();

            foreach (ObservationDevice device in SourceList)
            {
                targetList.Add(device);
            }
            return targetList;
        }

    }
}






