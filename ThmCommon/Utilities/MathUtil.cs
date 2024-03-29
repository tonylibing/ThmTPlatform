﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ThmCommon.Utilities {
    public static class MathUtil {
        public static Double RoundUpToNearest(Double passednumber, Double roundto) {
            // 105.5 up to nearest 1 = 106
            // 105.5 up to nearest 10 = 110
            // 105.5 up to nearest 7 = 112
            // 105.5 up to nearest 100 = 200
            // 105.5 up to nearest 0.2 = 105.6
            // 105.5 up to nearest 0.3 = 105.6

            //if no rounto then just pass original number back
            if (roundto == 0) {
                return passednumber;
            }
            else {
                return Math.Ceiling(passednumber / roundto) * roundto;
            }
        }

        public static Double RoundDownToNearest(Double passednumber, Double roundto) {
            // 105.5 down to nearest 1 = 105
            // 105.5 down to nearest 10 = 100
            // 105.5 down to nearest 7 = 105
            // 105.5 down to nearest 100 = 100
            // 105.5 down to nearest 0.2 = 105.4
            // 105.5 down to nearest 0.3 = 105.3

            //if no rounto then just pass original number back
            if (roundto == 0) {
                return passednumber;
            }
            else {
                return Math.Floor(passednumber / roundto) * roundto;
            }
        }

        public static double StandardDeviation(List<double> numberSet, double divisor, bool removeZeroes) {
            //remove all zeroes
            if (removeZeroes) {
                numberSet.RemoveAll(n => n == 0.0);
            }
            try {
                double mean = numberSet.Average();
                return Math.Sqrt(numberSet.Sum(x => Math.Pow(x - mean, 2)) / divisor);
            }
            catch (Exception e) {
                Debug.WriteLine(e);
                return 0.0;
            }
        }
    }
}
