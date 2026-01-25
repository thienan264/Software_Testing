using NUnit.Framework;
using System;
using System.Collections.Generic;
using Tester_Tuan4;

namespace Tester_Tuan4.Tests;

[TestFixture]
public class UnitTestBai2
{
    [Test]
    public void KhoiTao_NAm_ThiNemNgoaiLe()
    {
        var ex = Assert.Throws<ArgumentException>(() =>
        {
            _ = new Polynomial(-1, new List<int> { 1 });
        });
        Assert.That(ex!.Message, Is.EqualTo("Invalid Data"));
    }

    [Test]
    public void KhoiTao_ThieuHeSo_ThiNemNgoaiLe()
    {
        var ex = Assert.Throws<ArgumentException>(() =>
        {
            _ = new Polynomial(2, new List<int> { 1, 2 });
        });
        Assert.That(ex!.Message, Is.EqualTo("Invalid Data"));
    }

    [Test]
    public void KhoiTao_ThuaHeSo_ThiNemNgoaiLe()
    {
        var ex = Assert.Throws<ArgumentException>(() =>
        {
            _ = new Polynomial(2, new List<int> { 1, 2, 3, 4 });
        });
        Assert.That(ex!.Message, Is.EqualTo("Invalid Data"));
    }

    [Test]
    public void TinhGiaTri_DaThucBac0_TraVeHangSo()
    {
        var p = new Polynomial(0, new List<int> { 7 });
        Assert.That(p.Cal(0), Is.EqualTo(7));
        Assert.That(p.Cal(10), Is.EqualTo(7));
        Assert.That(p.Cal(-3), Is.EqualTo(7));
    }

    [Test]
    public void TinhGiaTri_DaThucBac1_DungKetQua()
    {
        var p = new Polynomial(1, new List<int> { 2, 3 });
        Assert.That(p.Cal(0), Is.EqualTo(2));
        Assert.That(p.Cal(1), Is.EqualTo(5));
        Assert.That(p.Cal(2), Is.EqualTo(8));
        Assert.That(p.Cal(-1), Is.EqualTo(-1));
    }

    [Test]
    public void TinhGiaTri_DaThucBac2_DungKetQua()
    {
        var p = new Polynomial(2, new List<int> { 1, 0, 2 });
        Assert.That(p.Cal(0), Is.EqualTo(1));
        Assert.That(p.Cal(1), Is.EqualTo(3));
        Assert.That(p.Cal(2), Is.EqualTo(9));
        Assert.That(p.Cal(-2), Is.EqualTo(9));
    }

    [Test]
    public void TinhGiaTri_HeSoAm_DungKetQua()
    {
        var p = new Polynomial(3, new List<int> { -1, 2, -3, 1 });
        Assert.That(p.Cal(1), Is.EqualTo(-1));
        Assert.That(p.Cal(2), Is.EqualTo(-1));
    }

    [Test]
    public void TinhGiaTri_TatCaHeSoBang0_TraVe0()
    {
        var p = new Polynomial(4, new List<int> { 0, 0, 0, 0, 0 });
        Assert.That(p.Cal(0), Is.EqualTo(0));
        Assert.That(p.Cal(10), Is.EqualTo(0));
        Assert.That(p.Cal(-5), Is.EqualTo(0));
    }

    [Test]
    public void TinhGiaTri_XKhongNguyen_BiCatPhanThapPhan()
    {
        var p = new Polynomial(2, new List<int> { 1, 1, 1 });
        Assert.That(p.Cal(1.2), Is.EqualTo(3));
        Assert.That(p.Cal(1.5), Is.EqualTo(4));
    }
}
