using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using LNurbs.Calculations;
using  Rhino;
using Rhino.Geometry;

namespace LNurbs.Geometry
{
    public class Bezier
    {
        #region public properties

        public int Degree { get; set; }
        public Interval Interval { get; set; }
        public Point3d[] ControlPoints { get; set; }

        #endregion

        #region static

        private static Interval _default = new Interval(0, 1);

        #endregion

        #region Constructors

        public Bezier()
        {
            Degree = 1;
            Interval = _default;
            ControlPoints = new[]{Point3d.Origin, new Point3d(1, 1, 1)};
        }

        public Bezier(int degree, Point3d[] controlPoints)
        {
            if (controlPoints.Length != degree - 1) return;

            Degree = degree;
            Interval = _default;
            ControlPoints = controlPoints;
        }

        public Bezier(int degree, Interval interval, Point3d[] controlPoints)
        {
            if (controlPoints.Length != degree - 1) return;

            Degree = degree;
            Interval = interval;
            ControlPoints = controlPoints;
        }

        #endregion

        #region public Methods

        public Point3d PointAt(double u)
        {
            if (!Interval.IncludesParameter(u)) return Point3d.Unset;

            int cpCount = Degree + 1;

            var uFactors = CalculateUFactors(u);
            Point3d[] cpCopy = new Point3d[cpCount];

            for (int i = 0; i < Degree + 1; i++)
            {
                cpCopy[i] = ControlPoints[i] * uFactors[i];
            }
            return cpCopy.Point3dSum();
        }

        #endregion

        #region private Methods

        private double[] CalculateUFactors(double u)
        {
            double[] uFactors = new double[Degree + 1];

            for (int i = 0; i < uFactors.Length; i++)
            {
                uFactors[i] = BernsteinPolynomial.Calculate(i, Degree, u);
            }

            return uFactors;
        }

        #endregion
    }
}
