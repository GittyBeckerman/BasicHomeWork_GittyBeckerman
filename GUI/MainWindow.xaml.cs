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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Model;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // the single instance of Model
        private ObservationDeviceModel observationDeviceModel = new ObservationDeviceModel();
        public MainWindow()
        {
            InitializeComponent();


        }

        /// <summary>
        /// send to new window = add device
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDevice(object sender, RoutedEventArgs e)
        {
            new AddDevice(observationDeviceModel).Show();
        }

        /// <summary>
        /// send to new window of list of the devices
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowAllDevices(object sender, RoutedEventArgs e)
        {
            new DevicesList(observationDeviceModel).Show();

        }

        /// <summary>
        /// send to new window that show the farest device
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowTheFarestDevice(object sender, RoutedEventArgs e)
        {
            new LongRange(observationDeviceModel).Show();
        }

    }
}
