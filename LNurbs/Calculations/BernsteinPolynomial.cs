using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNurbs.Calculations
{
    public static class BernsteinPolynomial
    {
        public static double Calculate(int i, int n, double u)
        {
            return (Calculator.Factorial(n) / (Calculator.Factorial(i) * Calculator.Factorial(n - i))) * Math.Pow(u, i) *
                    Math.Pow(1 - u, n - i);
        }
    }
}
