using NUnit.Framework;
using System;
using Tester_Tuan4;

namespace Tester_Tuan4.Tests;

[TestFixture]
public class UnitTestBai1
{
    [TestCase(2.5, 0, 1.0)]
    [TestCase(-3.0, 0, 1.0)]
    [TestCase(0.0, 0, 1.0)]
    public void N_Bang_0_LuonTraVe_1(double x, int n, double expected)
    {
        Assert.That(Bai1.Power(x, n), Is.EqualTo(expected));
    }

    [Test]
    public void N_Duong_TinhDungKetQua()
    {
        Assert.That(Bai1.Power(2.0, 3), Is.EqualTo(8.0));
        Assert.That(Bai1.Power(5.0, 1), Is.EqualTo(5.0));
        Assert.That(Bai1.Power(-2.0, 3), Is.EqualTo(-8.0));
        Assert.That(Bai1.Power(-2.0, 2), Is.EqualTo(4.0));
    }

    [Test]
    public void N_Am_TinhDungKetQua()
    {
        Assert.That(Bai1.Power(2.0, -3), Is.EqualTo(0.125).Within(1e-12));
        Assert.That(Bai1.Power(-2.0, -3), Is.EqualTo(-0.125).Within(1e-12));
        Assert.That(Bai1.Power(10.0, -1), Is.EqualTo(0.1).Within(1e-12));
    }

    [Test]
    public void X_Bang_0_N_Duong_TraVe_0()
    {
        Assert.That(Bai1.Power(0.0, 5), Is.EqualTo(0.0));
    }

    [Test]
    public void X_Bang_0_N_Am_ThiNemNgoaiLe()
    {
        Assert.Throws<DivideByZeroException>(() => Bai1.Power(0.0, -1));
    }

    [Test]
    public void KiemTra_DinhNghia_DeQuy_N_Duong()
    {
        double x = 1.7;
        int n = 4;

        Assert.That(
            Bai1.Power(x, n),
            Is.EqualTo(Bai1.Power(x, n - 1) * x).Within(1e-12)
        );
    }

    [Test]
    public void KiemTra_DinhNghia_DeQuy_N_Am()
    {
        double x = 1.7;
        int n = -4;

        Assert.That(
            Bai1.Power(x, n),
            Is.EqualTo(Bai1.Power(x, n + 1) / x).Within(1e-12)
        );
    }
}
