using NUnit.Framework;
using System;
using Tester_Tuan4;

namespace Tester_Tuan4.Tests;

[TestFixture]
public class UnitTestBai3
{
    [Test]
    public void KhoiTao_SoAm_ThiNemNgoaiLe()
    {
        var ex = Assert.Throws<ArgumentException>(() => _ = new Radix(-1));
        Assert.That(ex!.Message, Is.EqualTo("Incorrect Value"));
    }

    [TestCase(1)]
    [TestCase(0)]
    public void ChuyenDoi_CoSoNhoHon2_ThiNemNgoaiLe(int radix)
    {
        var r = new Radix(10);
        var ex = Assert.Throws<ArgumentException>(() => r.ConvertDecimalToAnother(radix));
        Assert.That(ex!.Message, Is.EqualTo("Invalid Radix"));
    }

    [TestCase(17)]
    [TestCase(100)]
    public void ChuyenDoi_CoSoLonHon16_ThiNemNgoaiLe(int radix)
    {
        var r = new Radix(10);
        var ex = Assert.Throws<ArgumentException>(() => r.ConvertDecimalToAnother(radix));
        Assert.That(ex!.Message, Is.EqualTo("Invalid Radix"));
    }

    [Test]
    public void ChuyenDoi_MacDinh_LaNhiPhan()
    {
        var r = new Radix(10);
        Assert.That(r.ConvertDecimalToAnother(), Is.EqualTo("1010"));
    }

    [Test]
    public void ChuyenDoi_CoSo2_DungKetQua()
    {
        Assert.That(new Radix(1).ConvertDecimalToAnother(2), Is.EqualTo("1"));
        Assert.That(new Radix(2).ConvertDecimalToAnother(2), Is.EqualTo("10"));
        Assert.That(new Radix(10).ConvertDecimalToAnother(2), Is.EqualTo("1010"));
        Assert.That(new Radix(16).ConvertDecimalToAnother(2), Is.EqualTo("10000"));
    }

    [Test]
    public void ChuyenDoi_CoSo8_DungKetQua()
    {
        Assert.That(new Radix(8).ConvertDecimalToAnother(8), Is.EqualTo("10"));
        Assert.That(new Radix(9).ConvertDecimalToAnother(8), Is.EqualTo("11"));
        Assert.That(new Radix(64).ConvertDecimalToAnother(8), Is.EqualTo("100"));
    }

    [Test]
    public void ChuyenDoi_CoSo10_GiuNguyenGiaTri()
    {
        Assert.That(new Radix(0).ConvertDecimalToAnother(10), Is.EqualTo(""));
        Assert.That(new Radix(7).ConvertDecimalToAnother(10), Is.EqualTo("7"));
        Assert.That(new Radix(12345).ConvertDecimalToAnother(10), Is.EqualTo("12345"));
    }

    [Test]
    public void ChuyenDoi_CoSo16_CoChuCai()
    {
        Assert.That(new Radix(10).ConvertDecimalToAnother(16), Is.EqualTo("A"));
        Assert.That(new Radix(11).ConvertDecimalToAnother(16), Is.EqualTo("B"));
        Assert.That(new Radix(12).ConvertDecimalToAnother(16), Is.EqualTo("C"));
        Assert.That(new Radix(13).ConvertDecimalToAnother(16), Is.EqualTo("D"));
        Assert.That(new Radix(14).ConvertDecimalToAnother(16), Is.EqualTo("E"));
        Assert.That(new Radix(15).ConvertDecimalToAnother(16), Is.EqualTo("F"));
        Assert.That(new Radix(16).ConvertDecimalToAnother(16), Is.EqualTo("10"));
        Assert.That(new Radix(31).ConvertDecimalToAnother(16), Is.EqualTo("1F"));
        Assert.That(new Radix(255).ConvertDecimalToAnother(16), Is.EqualTo("FF"));
    }

    [Test]
    public void ChuyenDoi_CoSo3_DungKetQua()
    {
        Assert.That(new Radix(5).ConvertDecimalToAnother(3), Is.EqualTo("12"));
        Assert.That(new Radix(10).ConvertDecimalToAnother(3), Is.EqualTo("101"));
    }

    [Test]
    public void ChuyenDoi_SoBang0_TraVeChuoiRong()
    {
        Assert.That(new Radix(0).ConvertDecimalToAnother(2), Is.EqualTo(""));
        Assert.That(new Radix(0).ConvertDecimalToAnother(16), Is.EqualTo(""));
    }
}
