using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;

namespace LNurbs.Calculations
{
    public static class Calculator
    {
        public static int Factorial(int n)
        {
            return (n == 1 || n == 0) ? 1 : Factorial(n - 1) * n;
        }

        public static Point3d Point3dSum(this Point3d[] ptArray)
        {
            var result = Vector3d.Zero;
            for (int i = 0; i < ptArray.Length; i++)
            {
                result += (Vector3d)ptArray[i];
            }

            return new Point3d(result);
        }
    }
}
