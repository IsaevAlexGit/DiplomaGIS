using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyCalcLib.Tests
{
    [TestClass]
    public class OptimumTests
    {
        [TestMethod]
        public void TestEqualWeights()
        {
            // Arrange
            // Веса важности
            double weightPharmacy = 0.33;
            double weightResidents = 0.33;
            double weightRetired = 0.34;

            List<BufferZone> arrayForNormalization = new List<BufferZone>
            {
                new BufferZone(1, 1, 1, 900, 1, 1743, 633),
                new BufferZone(2, 2, 2, 900, 2, 9633, 3492),
                new BufferZone(3, 3, 3, 900, 24, 14676, 5319),
                new BufferZone(4, 4, 4, 900, 8, 10800, 3915),
                new BufferZone(5, 5, 5, 900, 27, 12857, 4664),
                new BufferZone(6, 6, 6, 900, 8, 11171, 4255),
                new BufferZone(7, 7, 7, 900, 18, 15441, 5597),
                new BufferZone(8, 8, 8, 900, 9, 12560, 4554),
                new BufferZone(9, 9, 9, 900, 11, 9584, 3474),
                new BufferZone(10, 10, 10, 900, 0, 0, 0)
            };

            List<BufferZone> arrayWithStartZones = new List<BufferZone>
            {
                new BufferZone(1, 1, 1, 900, 1, 1743, 633),
                new BufferZone(2, 2, 2, 900, 2, 9633, 3492),
                new BufferZone(3, 3, 3, 900, 24, 14676, 5319),
                new BufferZone(4, 4, 4, 900, 8, 10800, 3915),
                new BufferZone(5, 5, 5, 900, 27, 12857, 4664),
                new BufferZone(6, 6, 6, 900, 8, 11171, 4255),
                new BufferZone(7, 7, 7, 900, 18, 15441, 5597),
                new BufferZone(8, 8, 8, 900, 9, 12560, 4554),
                new BufferZone(9, 9, 9, 900, 11, 9584, 3474),
                new BufferZone(10, 10, 10, 900, 0, 0, 0)
            };

            // ID лучшей точки, которую мы должны получить
            int expected = 7;
            Optimum point = new Optimum();
            // Act
            // Ищем ID лучшей точки
            int actual = point.getOptimum(arrayForNormalization, arrayWithStartZones, weightPharmacy, weightResidents, weightRetired);
            // Assert
            // Проверка, совпадает ли ожидаемый результат с полученным
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPharmacyPriority()
        {
            // Arrange
            double weightPharmacy = 1;
            double weightResidents = 0;
            double weightRetired = 0;

            List<BufferZone> arrayForNormalization = new List<BufferZone>
            {
                new BufferZone(1, 1, 1, 900, 1, 1743, 633),
                new BufferZone(2, 2, 2, 900, 2, 9633, 3492),
                new BufferZone(3, 3, 3, 900, 24, 14676, 5319),
                new BufferZone(4, 4, 4, 900, 8, 10800, 3915),
                new BufferZone(5, 5, 5, 900, 27, 12857, 4664),
                new BufferZone(6, 6, 6, 900, 8, 11171, 4255),
                new BufferZone(7, 7, 7, 900, 18, 15441, 5597),
                new BufferZone(8, 8, 8, 900, 9, 12560, 4554),
                new BufferZone(9, 9, 9, 900, 11, 9584, 3474),
                new BufferZone(10, 10, 10, 900, 0, 0, 0)
            };

            List<BufferZone> arrayWithStartZones = new List<BufferZone>
            {
                new BufferZone(1, 1, 1, 900, 1, 1743, 633),
                new BufferZone(2, 2, 2, 900, 2, 9633, 3492),
                new BufferZone(3, 3, 3, 900, 24, 14676, 5319),
                new BufferZone(4, 4, 4, 900, 8, 10800, 3915),
                new BufferZone(5, 5, 5, 900, 27, 12857, 4664),
                new BufferZone(6, 6, 6, 900, 8, 11171, 4255),
                new BufferZone(7, 7, 7, 900, 18, 15441, 5597),
                new BufferZone(8, 8, 8, 900, 9, 12560, 4554),
                new BufferZone(9, 9, 9, 900, 11, 9584, 3474),
                new BufferZone(10, 10, 10, 900, 0, 0, 0)
            };

            int expected = 10;
            Optimum point = new Optimum();
            // Act
            int actual = point.getOptimum(arrayForNormalization, arrayWithStartZones, weightPharmacy, weightResidents, weightRetired);
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestResidentsPriority()
        {
            // Arrange
            double weightPharmacy = 0;
            double weightResidents = 1;
            double weightRetired = 0;

            List<BufferZone> arrayForNormalization = new List<BufferZone>
            {
                new BufferZone(1, 1, 1, 900, 1, 1743, 633),
                new BufferZone(2, 2, 2, 900, 2, 9633, 3492),
                new BufferZone(3, 3, 3, 900, 24, 14676, 5319),
                new BufferZone(4, 4, 4, 900, 8, 10800, 3915),
                new BufferZone(5, 5, 5, 900, 27, 12857, 4664),
                new BufferZone(6, 6, 6, 900, 8, 11171, 4255),
                new BufferZone(7, 7, 7, 900, 18, 15441, 5597),
                new BufferZone(8, 8, 8, 900, 9, 12560, 4554),
                new BufferZone(9, 9, 9, 900, 11, 9584, 3474),
                new BufferZone(10, 10, 10, 900, 0, 0, 0)
            };

            List<BufferZone> arrayWithStartZones = new List<BufferZone>
            {
                new BufferZone(1, 1, 1, 900, 1, 1743, 633),
                new BufferZone(2, 2, 2, 900, 2, 9633, 3492),
                new BufferZone(3, 3, 3, 900, 24, 14676, 5319),
                new BufferZone(4, 4, 4, 900, 8, 10800, 3915),
                new BufferZone(5, 5, 5, 900, 27, 12857, 4664),
                new BufferZone(6, 6, 6, 900, 8, 11171, 4255),
                new BufferZone(7, 7, 7, 900, 18, 15441, 5597),
                new BufferZone(8, 8, 8, 900, 9, 12560, 4554),
                new BufferZone(9, 9, 9, 900, 11, 9584, 3474),
                new BufferZone(10, 10, 10, 900, 0, 0, 0)
            };

            int expected = 7;
            Optimum point = new Optimum();
            // Act
            int actual = point.getOptimum(arrayForNormalization, arrayWithStartZones, weightPharmacy, weightResidents, weightRetired);
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestZeroBufferZones()
        {
            // Arrange
            double weightPharmacy = 0;
            double weightResidents = 1;
            double weightRetired = 0;

            List<BufferZone> arrayForNormalization = new List<BufferZone>
            {
                new BufferZone(1, 1, 1, 500, 0, 0, 0),
                new BufferZone(2, 2, 2, 500, 0, 0, 0),
                new BufferZone(3, 3, 3, 500, 0, 0, 0),
                new BufferZone(4, 4, 4, 500, 0, 0, 0),
                new BufferZone(5, 5, 5, 500, 0, 0, 0)
            };

            List<BufferZone> arrayWithStartZones = new List<BufferZone>
            {
                new BufferZone(1, 1, 1, 500, 0, 0, 0),
                new BufferZone(2, 2, 2, 500, 0, 0, 0),
                new BufferZone(3, 3, 3, 500, 0, 0, 0),
                new BufferZone(4, 4, 4, 500, 0, 0, 0),
                new BufferZone(5, 5, 5, 500, 0, 0, 0)
            };

            int expected = 5;
            Optimum point = new Optimum();
            // Act
            int actual = point.getOptimum(arrayForNormalization, arrayWithStartZones, weightPharmacy, weightResidents, weightRetired);
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBufferZonesInSinglePoint()
        {
            // Arrange
            double weightPharmacy = 0.5;
            double weightResidents = 0.4;
            double weightRetired = 0.1;

            List<BufferZone> arrayForNormalization = new List<BufferZone>
            {
                new BufferZone(1, 1, 1, 500, 16, 4397, 1592),
                new BufferZone(2, 1, 1, 500, 16, 4397, 1592),
                new BufferZone(3, 1, 1, 500, 16, 4397, 1592),
                new BufferZone(4, 1, 1, 500, 16, 4397, 1592),
                new BufferZone(5, 1, 1, 500, 16, 4397, 1592)
            };

            List<BufferZone> arrayWithStartZones = new List<BufferZone>
            {
                new BufferZone(1, 1, 1, 500, 16, 4397, 1592),
                new BufferZone(2, 1, 1, 500, 16, 4397, 1592),
                new BufferZone(3, 1, 1, 500, 16, 4397, 1592),
                new BufferZone(4, 1, 1, 500, 16, 4397, 1592),
                new BufferZone(5, 1, 1, 500, 16, 4397, 1592)
            };

            int expected = 5;
            Optimum point = new Optimum();
            // Act
            int actual = point.getOptimum(arrayForNormalization, arrayWithStartZones, weightPharmacy, weightResidents, weightRetired);
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestWithNormalZoneAndEmpty()
        {
            // Arrange
            double weightPharmacy = 1;
            double weightResidents = 0;
            double weightRetired = 0;

            List<BufferZone> arrayForNormalization = new List<BufferZone>
            {
                new BufferZone(1, 1, 1, 500, 0, 2384, 865),
                new BufferZone(2, 2, 2, 500, 0, 0, 0)
            };

            List<BufferZone> arrayWithStartZones = new List<BufferZone>
            {
                new BufferZone(1, 1, 1, 500, 0, 2384, 865),
                new BufferZone(2, 2, 2, 500, 0, 0, 0)
            };

            int expected = 2;
            Optimum point = new Optimum();
            // Act
            int actual = point.getOptimum(arrayForNormalization, arrayWithStartZones, weightPharmacy, weightResidents, weightRetired);
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestWithEmptyZoneAndNormal()
        {
            // Arrange
            double weightPharmacy = 1;
            double weightResidents = 0;
            double weightRetired = 0;

            List<BufferZone> arrayForNormalization = new List<BufferZone>
            {
                new BufferZone(1, 1, 1, 500, 0, 0, 0),
                new BufferZone(2, 2, 2, 500, 0, 2384, 865)
            };

            List<BufferZone> arrayWithStartZones = new List<BufferZone>
            {
                new BufferZone(1, 1, 1, 500, 0, 0, 0),
                new BufferZone(2, 2, 2, 500, 0, 2384, 865)
            };

            int expected = 2;
            Optimum point = new Optimum();
            // Act
            int actual = point.getOptimum(arrayForNormalization, arrayWithStartZones, weightPharmacy, weightResidents, weightRetired);
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAllConvolutionAgree()
        {
            // Arrange
            double weightPharmacy = 0;
            double weightResidents = 1;
            double weightRetired = 0;

            List<BufferZone> arrayForNormalization = new List<BufferZone>
            {
                new BufferZone(1, 1, 1, 500, 2, 733, 267),
                new BufferZone(2, 1, 1, 500, 0, 2384, 865),
                new BufferZone(3, 1, 1, 500, 0, 3666, 1329),
                new BufferZone(4, 1, 1, 500, 1, 3653, 1326)
            };

            List<BufferZone> arrayWithStartZones = new List<BufferZone>
            {
                new BufferZone(1, 1, 1, 500, 2, 733, 267),
                new BufferZone(2, 1, 1, 500, 0, 2384, 865),
                new BufferZone(3, 1, 1, 500, 0, 3666, 1329),
                new BufferZone(4, 1, 1, 500, 1, 3653, 1326)
            };

            int expected = 3;
            Optimum point = new Optimum();
            // Act
            int actual = point.getOptimum(arrayForNormalization, arrayWithStartZones, weightPharmacy, weightResidents, weightRetired);
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLinearAndMultiplicativeAgree()
        {
            // Arrange
            double weightPharmacy = 1;
            double weightResidents = 0;
            double weightRetired = 0;

            List<BufferZone> arrayForNormalization = new List<BufferZone>
            {
                new BufferZone(1, 1, 1, 500, 1, 1703, 618),
                new BufferZone(2, 2, 2, 500, 2, 2305, 836),
                new BufferZone(3, 3, 3, 500, 2, 4662, 1689),
                new BufferZone(4, 4, 4, 500, 0, 0, 0),
                new BufferZone(5, 5, 5, 500, 6, 6172, 2237),
                new BufferZone(6, 6, 6, 500, 0, 0, 0)
            };

            List<BufferZone> arrayWithStartZones = new List<BufferZone>
            {
                new BufferZone(1, 1, 1, 500, 1, 1703, 618),
                new BufferZone(2, 2, 2, 500, 2, 2305, 836),
                new BufferZone(3, 3, 3, 500, 2, 4662, 1689),
                new BufferZone(4, 4, 4, 500, 0, 0, 0),
                new BufferZone(5, 5, 5, 500, 6, 6172, 2237),
                new BufferZone(6, 6, 6, 500, 0, 0, 0)
            };

            int expected = 6;
            Optimum point = new Optimum();
            // Act
            int actual = point.getOptimum(arrayForNormalization, arrayWithStartZones, weightPharmacy, weightResidents, weightRetired);
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLinearAndMaxiMinAgree()
        {
            // Arrange
            double weightPharmacy = 0.34;
            double weightResidents = 0.33;
            double weightRetired = 0.33;

            List<BufferZone> arrayForNormalization = new List<BufferZone>
            {
                new BufferZone(1, 1, 1, 500, 2, 647, 235),
                new BufferZone(2, 2, 2, 500, 1, 4422, 1603),
                new BufferZone(3, 3, 3, 500, 2, 2432, 883)
            };

            List<BufferZone> arrayWithStartZones = new List<BufferZone>
            {
                new BufferZone(1, 1, 1, 500, 2, 647, 235),
                new BufferZone(2, 2, 2, 500, 1, 4422, 1603),
                new BufferZone(3, 3, 3, 500, 2, 2432, 883)
            };

            int expected = 2;
            Optimum point = new Optimum();
            // Act
            int actual = point.getOptimum(arrayForNormalization, arrayWithStartZones, weightPharmacy, weightResidents, weightRetired);
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAllConvolutionDisagree()
        {
            // Arrange
            double weightPharmacy = 0.34;
            double weightResidents = 0.33;
            double weightRetired = 0.33;

            List<BufferZone> arrayForNormalization = new List<BufferZone>
            {
                new BufferZone(1, 1, 1, 500, 1, 3107, 1125),
                new BufferZone(2, 2, 2, 500, 0, 0, 0),
                new BufferZone(3, 3, 3, 500, 3, 1533, 554),
                new BufferZone(4, 4, 4, 500, 2, 2432, 883),
                new BufferZone(5, 5, 5, 500, 7, 3386, 1229),
                new BufferZone(6, 6, 6, 500, 3, 4079, 1480),
                new BufferZone(7, 7, 7, 500, 3, 3409, 1234)
            };

            List<BufferZone> arrayWithStartZones = new List<BufferZone>
            {
                new BufferZone(1, 1, 1, 500, 1, 3107, 1125),
                new BufferZone(2, 2, 2, 500, 0, 0, 0),
                new BufferZone(3, 3, 3, 500, 3, 1533, 554),
                new BufferZone(4, 4, 4, 500, 2, 2432, 883),
                new BufferZone(5, 5, 5, 500, 7, 3386, 1229),
                new BufferZone(6, 6, 6, 500, 3, 4079, 1480),
                new BufferZone(7, 7, 7, 500, 3, 3409, 1234)
            };

            int expected = 1;
            Optimum point = new Optimum();
            // Act
            int actual = point.getOptimum(arrayForNormalization, arrayWithStartZones, weightPharmacy, weightResidents, weightRetired);
            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}