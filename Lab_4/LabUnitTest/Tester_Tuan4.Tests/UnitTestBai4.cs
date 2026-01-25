using NUnit.Framework;
using Tester_Tuan4;

namespace Tester_Tuan4.Tests;

[TestFixture]
public class UnitTestBai4
{
    [Test]
    public void TinhDienTich_DungKetQua()
    {
        var r = new HinhChuNhat(new Diem(1, 5), new Diem(6, 2));
        Assert.That(r.DienTich(), Is.EqualTo(15));
    }

    [Test]
    public void TinhDienTich_HinhVuong_DungKetQua()
    {
        var r = new HinhChuNhat(new Diem(0, 4), new Diem(4, 0));
        Assert.That(r.DienTich(), Is.EqualTo(16));
    }

    [Test]
    public void GiaoNhau_ChongLenNhau_True()
    {
        var a = new HinhChuNhat(new Diem(0, 4), new Diem(4, 0));
        var b = new HinhChuNhat(new Diem(2, 3), new Diem(6, 1));
        Assert.That(a.GiaoNhau(b), Is.True);
        Assert.That(b.GiaoNhau(a), Is.True);
    }

    [Test]
    public void GiaoNhau_TachRoiTheoTrucX_False()
    {
        var a = new HinhChuNhat(new Diem(0, 4), new Diem(4, 0));
        var b = new HinhChuNhat(new Diem(4, 3), new Diem(7, 1));
        Assert.That(a.GiaoNhau(b), Is.False);
        Assert.That(b.GiaoNhau(a), Is.False);
    }

    [Test]
    public void GiaoNhau_TachRoiTheoTrucY_False()
    {
        var a = new HinhChuNhat(new Diem(0, 4), new Diem(4, 0));
        var b = new HinhChuNhat(new Diem(1, 0), new Diem(3, -2));
        Assert.That(a.GiaoNhau(b), Is.False);
        Assert.That(b.GiaoNhau(a), Is.False);
    }

    [Test]
    public void GiaoNhau_ChiChamCanh_False()
    {
        var a = new HinhChuNhat(new Diem(0, 4), new Diem(4, 0));
        var b = new HinhChuNhat(new Diem(4, 4), new Diem(8, 0));
        Assert.That(a.GiaoNhau(b), Is.False);
        Assert.That(b.GiaoNhau(a), Is.False);
    }

    [Test]
    public void GiaoNhau_ChiChamGoc_False()
    {
        var a = new HinhChuNhat(new Diem(0, 4), new Diem(4, 0));
        var b = new HinhChuNhat(new Diem(4, 0), new Diem(6, -2));
        Assert.That(a.GiaoNhau(b), Is.False);
        Assert.That(b.GiaoNhau(a), Is.False);
    }

    [Test]
    public void GiaoNhau_NamTrongNhau_True()
    {
        var a = new HinhChuNhat(new Diem(0, 10), new Diem(10, 0));
        var b = new HinhChuNhat(new Diem(2, 8), new Diem(4, 6));
        Assert.That(a.GiaoNhau(b), Is.True);
        Assert.That(b.GiaoNhau(a), Is.True);
    }
}
