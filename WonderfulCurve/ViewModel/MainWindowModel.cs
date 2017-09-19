using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using WonderfulCurve.WonderfulLine;

namespace WonderfulCurve.ViewModel
{
    public class MainWindowModel : ViewModelBase
    {
        private Line _line;
        private PlotModel _plotModel;

        public MainWindowModel()
        {
            ChangeValueCommand = new RelayCommand(() =>
            {
                Update(Line.A);
                PlotModel.InvalidatePlot(true);
            });
            ApproximateX = new RelayCommand(() =>
            {
                PlotModel.InvalidatePlot(true);
            });
            ApproximateY = new RelayCommand(() =>
            {
                PlotModel.InvalidatePlot(true);
            });
            PlotModel = new PlotModel();
            SetUp();
        }

        public PlotModel PlotModel
        {
            set
            {
                _plotModel = value;
                RaisePropertyChanged();
            }
            get { return _plotModel; }
        }

        public Line Line
        {
            set
            {
                _line = value;
                RaisePropertyChanged();
            }
            get { return _line; }
        }

        public RelayCommand ChangeValueCommand { get; set; }
        public RelayCommand ApproximateX { get; set; }
        public RelayCommand ApproximateY { get; set; }

        private void SetUp()
        {
            PlotModel.Title = "Wonderful Line";
            PlotModel.LegendTitle = "x^(2/3) + y^(2/3) = a^(2/3)";
            PlotModel.LegendOrientation = LegendOrientation.Horizontal;
            PlotModel.LegendPlacement = LegendPlacement.Outside;
            PlotModel.LegendBackground = OxyColor.FromAColor(200, OxyColors.White);
            PlotModel.LegendBorder = OxyColors.Black;
            var XAxis = new LinearAxis
            {
                Title = "X",
                Position = AxisPosition.Bottom,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.LongDash,
                ExtraGridlines = new double[] {0},
                Minimum = -20,
                Maximum = 20
            };
            PlotModel.Axes.Add(XAxis);
            var YAxis = new LinearAxis
            {
                Title = "Y",
                Position = AxisPosition.Left,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.LongDash,
                ExtraGridlines = new double[] {0},
                Minimum = -20,
                Maximum = 20
            };
            PlotModel.Axes.Add(YAxis);
            Line = new Line();
            var fs = new FunctionSeries(Line.Function, XAxis.Minimum, XAxis.Maximum, 0.01)
            {
                StrokeThickness = 2,
                MarkerSize = 3,
                MarkerStroke = OxyColors.Red,
                CanTrackerInterpolatePoints = false,
                Smooth = false
            };
            PlotModel.Series.Add(fs);
        }

        public void Update(double param)
        {
            Line.A = param;
            Line.Refresh();
            PlotModel.Series.Clear();
            PlotModel.Series.Add(new FunctionSeries(Line.Function, PlotModel.Axes[0].Minimum, PlotModel.Axes[0].Maximum,
                0.01)
            {
                StrokeThickness = 2,
                MarkerSize = 3,
                MarkerStroke = OxyColors.Red,
                CanTrackerInterpolatePoints = false,
                Smooth = false
            });
        }
    }
}