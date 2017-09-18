using System.Windows;
using GalaSoft.MvvmLight.Threading;
using Microsoft.Practices.ServiceLocation;
using WonderfulCurve.ViewModel;

namespace WonderfulCurve
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        App()
        {
            DispatcherHelper.Initialize();
            ViewModelLocator.SetAndReg();
            ServiceLocator.Current.GetInstance<MainWindowModel>();
        }
    }
    
}
