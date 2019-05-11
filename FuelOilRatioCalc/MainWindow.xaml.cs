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

namespace FuelOilRatioCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void VolumeKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !IsNumberKey(e.Key)&& !IsDelOrBackspaceOrTabKey(e.Key);
        }
        private bool IsNumberKey(Key inKey)
        {
            if (inKey < Key.D0 || inKey > Key.D9)
            {
                if (inKey < Key.NumPad0 || inKey > Key.NumPad9)
                {
                    return false;
                }
            }
            return true;
        }
        private bool IsDelOrBackspaceOrTabKey(Key key)
        {
            return key == Key.Delete || key == Key.Back || key == Key.Tab || key == Key.OemPeriod || key == Key.Decimal;
        }

        private void RadioBtnMouseUp(object sender, RoutedEventArgs e)
        {
            if ((bool)ImperialRadio.IsChecked)
            {
                FuelVolLbl.Content = "Gallons";
                CalculateVolume();
            }
            else if ((bool)MetricRadio.IsChecked)
            {
                FuelVolLbl.Content = "Liter";
                CalculateVolume();

            }
            else
            {
                List<FuelOil> fuelOil = new List<FuelOil>();
                fuelOil.Add(new FuelOil { Ratio = "err", Volume = "err" });
                FuelOilList.ItemsSource = fuelOil;
            }
        }

        private void VolumeKeyUp(object sender, KeyEventArgs e)
        {
            CalculateVolume();
            if (FuelVolumeBox.Text == "")
            {
                FuelOilList.ItemsSource = null;
            }
        }

        private void CalculateVolume()
        {
            try
            {
                decimal d = decimal.Parse(FuelVolumeBox.Text);
                if ((bool)ImperialRadio.IsChecked)
                {
                    FuelOilList.ItemsSource = Calculate.CalculatRatio(false, d);
                }
                else
                {
                    FuelOilList.ItemsSource = Calculate.CalculatRatio(true, d);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
