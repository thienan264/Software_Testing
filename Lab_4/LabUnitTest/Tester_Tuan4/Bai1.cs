using System;

namespace Tester_Tuan4;

public static class Bai1
{
    public static double Power(double x, int n)
    {
        if (n == 0) return 1.0;

        if (x == 0.0 && n < 0)
            throw new DivideByZeroException();

        if (n > 0)
            return Power(x, n - 1) * x;

        return Power(x, n + 1) / x;
    }
}
