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
using Microsoft.Practices.ServiceLocation;
using OxyPlot;
using WonderfulCurve.ViewModel;

namespace WonderfulCurve
{
    /// <summary>
    /// Made by Eremin Maxim 308
    /// Plot visualization by function x^(3/2) + y^(3/2) = a^(3/2)
    /// Used: Oxyplot, MVVM, WPF, C#
    /// </summary>
    public partial class MainWindow : Window
    {

        private static MainWindowModel Vm => ViewModelLocator.MainWindowModel;

        public MainWindow()
        {
            DataContext = Vm;
            InitializeComponent();
        }
        

        private void ParameterValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Vm.ChangeValueCommand?.Execute(null);
        }

        private void YValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Vm.ApproximateY?.Execute(null);
        }

        private void XValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Vm.ApproximateY?.Execute(null);
        }
    }
}
