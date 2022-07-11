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
using System.Collections.ObjectModel;

namespace GUI
{
    /// <summary>
    /// Interaction logic for DevicesList.xaml
    /// </summary>
    public partial class DevicesList : Window
    {
        ObservationDeviceModel observationDeviceModel;


        //viewModel instance - update the **view** auto when there is a change;
        private ObservableCollection<ObservationDevice> MyCollection = new ObservableCollection<ObservationDevice>();
        public DevicesList(ObservationDeviceModel blMain)
        {
            InitializeComponent();
            this.observationDeviceModel = blMain;
    
            foreach (ObservationDevice device in observationDeviceModel.GetDevicesList())
            {
                MyCollection.Add(device);
            }
            if(MyCollection.Count == 0) MessageBox.Show("There are currently no devices of observation");
            DataContext = MyCollection;
            TypeSelector.ItemsSource = Enum.GetValues(typeof(ObserveType));
           
          
        }
        

        // the viewModel call to the Model and delete the device.
        private void DeleteDeviceFromList(object sender, MouseButtonEventArgs e)
        {
            try
            {
                
                ObservationDevice observationDevice = (sender as ListView).SelectedValue as ObservationDevice;
                observationDeviceModel.DeleteDevice(observationDevice.range, observationDevice.FieldOfView, observationDevice.ObserveType);
                MyCollection.Remove(observationDevice);
                DevicesListView.ItemsSource = MyCollection;
       
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                Close();
            }
        }

        private void TypeSelectorSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox status = sender as ComboBox;

            DevicesListView.ItemsSource = observationDeviceModel.GetDevicesList().FindAll(device => device.ObserveType == (ObserveType)status.SelectedItem);
        }

        private void SortByRange(object sender, RoutedEventArgs e)
        {
            
         MyCollection  = ConvertListToObservableCollection(MyCollection.OrderBy(d => d.range).ToList());

        }




        // helper function
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






