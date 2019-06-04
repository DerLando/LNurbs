using System;
using LNurbs.Calculations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Geometry;

namespace RhinoPluginTests
{
    /// <summary>
    /// Example test methods that invoke RhinoCommon
    /// </summary>
    [TestClass]
    public class CalculationTests
    {
        /// <summary>
        /// Tests edge cases and normal cases of factorial function
        /// <see cref="Calculator.Factorial"/>
        /// </summary>
        [TestMethod]
        [DataRow(0, 1)]
        [DataRow(1, 1)]
        [DataRow(5, 120)]
        [DataRow(7, 5040)]
        public void CalculatorFactorial_ShouldWork(int n, int expected)
        {
            // Arrange

            // Act
            var actual = Calculator.Factorial(n);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(0, 1, 0.5, 0.5)]
        [DataRow(1, 1, 0.5, 0.5)]
        public void BernsteinPolynomialCalculation_ShouldWork(int i, int n, double u, double expected)
        {
            // Arrange

            // Act
            var actual = BernsteinPolynomial.Calculate(i, n, u);

            // Assert
            Assert.AreEqual(expected, actual, 0.0001);
        }

    }
}