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

        private void AddDevice(object sender, RoutedEventArgs e)
        {
            new AddDevice(observationDeviceModel).Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new DevicesList(observationDeviceModel).Show();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new LongRange(observationDeviceModel).Show();
        }

    }
}
