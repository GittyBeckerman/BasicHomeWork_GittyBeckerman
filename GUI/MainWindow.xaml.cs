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
using ManagementOfMeansOfObservation;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BL bl = new BL();
        public MainWindow()
        {
            InitializeComponent();
         
         
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new AddDevice(bl).Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new DevicesList(bl).Show();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new LongRange(bl).Show();
        }

    }
}
