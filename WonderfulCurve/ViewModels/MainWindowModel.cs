using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Series;
using WonderfulCurve.WonderfulLine;
using LinearAxis = OxyPlot.Wpf.LinearAxis;

namespace WonderfulCurve.ViewModels
{
    class MainWindowModel : INotifyPropertyChanged
    {
        private PlotModel _plotModel;
        private Line _line;

        public PlotModel PlotModel
        {
            set
            {
                _plotModel = value;
            }
            get
            {
                return _plotModel;
            }
        }

        public Line Line
        {
            set
            {
                _line = value;
            }
            get
            {
                return _line;
            }
        }

        public MainWindowModel()
        {
            PlotModel = new PlotModel();
            SetUp();
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SetUp()
        {
            PlotModel.Title = "Wonderful Line";
            PlotModel.LegendTitle = "x^(3/2) + y^(3/2) = a^(3/2)";
            PlotModel.LegendOrientation = LegendOrientation.Horizontal;
            PlotModel.LegendPlacement = LegendPlacement.Outside;
            PlotModel.LegendBackground = OxyColor.FromAColor(200, OxyColors.White);
            PlotModel.LegendBorder = OxyColors.Black;
            OxyPlot.Axes.LinearAxis XAxis = new OxyPlot.Axes.LinearAxis()
            {
                Title = "X",
                Position = AxisPosition.Bottom,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.LongDash,
                ExtraGridlines = new Double[] { 0 },
                Minimum = -20,
                Maximum = 20
            };
            PlotModel.Axes.Add(XAxis);
            OxyPlot.Axes.LinearAxis YAxis = new OxyPlot.Axes.LinearAxis()
            {
                Title = "Y",
                Position = AxisPosition.Left,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.LongDash,
                ExtraGridlines = new Double[] { 0 },
                Minimum = -20,
                Maximum = 20,
            };
            PlotModel.Axes.Add(YAxis);
            Line = new Line();
            FunctionSeries fs = new FunctionSeries(Line.Function, XAxis.Minimum, XAxis.Maximum, 0.01)
            {
                StrokeThickness = 2,
                MarkerSize = 3,
                MarkerStroke = OxyColors.Red,
                CanTrackerInterpolatePoints = false,
                Smooth = false,
            };
            PlotModel.Series.Add(fs);
        }

        public void Update(double param)
        {
            Line.A = param;
            Line.Refresh();
            PlotModel.Series.Clear();
            PlotModel.Series.Add(new FunctionSeries(Line.Function, PlotModel.Axes[0].Minimum, PlotModel.Axes[0].Maximum, 0.01)
            {
                StrokeThickness = 2,
                MarkerSize = 3,
                MarkerStroke = OxyColors.Red,
                CanTrackerInterpolatePoints = false,
                Smooth = false,
            });
        }
    }
}
