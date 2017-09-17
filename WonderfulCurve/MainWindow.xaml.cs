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
using OxyPlot;
using WonderfulCurve.ViewModels;

namespace WonderfulCurve
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ViewModels.MainWindowModel _viewModel;

        public MainWindow()
        {
            _viewModel = new MainWindowModel();
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void ParameterValue_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _viewModel.Update(ParameterValue.Value);
            _viewModel.PlotModel.InvalidatePlot(true);
        }

        private void AproximateX_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (IsInitialized)
            {
                _viewModel.PlotModel.InvalidatePlot(true);
            }
        }

        private void AproximateY_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (IsInitialized)
            {
                _viewModel.PlotModel.InvalidatePlot(true);
            }
        }
    }
}
