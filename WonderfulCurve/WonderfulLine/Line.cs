using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WonderfulCurve.WonderfulLine
{
    class Line
    {
        private double _a;
        private Func<double, double> _function;

        public double A
        {
            set
            {
                _a = value;
            }
            get
            {
                return _a;
            }
        }

        public Func<double, double> Function
        {
            set
            {
                _function = value;
            }
            get
            {
                return _function;
            }
        }

        public Line() : this(0)
        {
            
        }

        public Line(double param)
        {
            A = param;
            Function = FunctionF;
        }

        public void Refresh()
        {
            Function = FunctionF;
        }

        private double FunctionF(double t)
        {
            return Math.Pow((A * Math.Pow(A, 1.0 / 2.0) - Math.Pow(t, 3.0 / 2.0)), 2.0 / 3.0);
        }
    }
}
