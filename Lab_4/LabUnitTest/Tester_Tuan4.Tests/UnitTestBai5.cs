using NUnit.Framework;
using System.Collections.Generic;
using Tester_Tuan4;

namespace Tester_Tuan4.Tests;

[TestFixture]
public class UnitTestBai5
{
    [Test]
    public void TinhDiemTrungBinh_DungKetQua()
    {
        var hv = new HocVien("01", "A", "HN", 9, 8, 7);
        Assert.That(hv.DiemTrungBinh(), Is.EqualTo(8.0).Within(1e-12));
    }

    [Test]
    public void DuocHocBong_DiemTrungBinhDungBang8_KhongMonNaoDuoi5_True()
    {
        var hv = new HocVien("01", "A", "HN", 8, 8, 8);
        Assert.That(hv.DuocHocBong(), Is.True);
    }

    [Test]
    public void DuocHocBong_DiemTrungBinhLonHon8_KhongMonNaoDuoi5_True()
    {
        var hv = new HocVien("01", "A", "HN", 9, 8.5, 8.5);
        Assert.That(hv.DuocHocBong(), Is.True);
    }

    [Test]
    public void DuocHocBong_CoMonDuoi5_False()
    {
        var hv = new HocVien("01", "A", "HN", 9, 9, 4.9);
        Assert.That(hv.DuocHocBong(), Is.False);
    }

    [Test]
    public void DuocHocBong_DiemTrungBinhDuoi8_False()
    {
        var hv = new HocVien("01", "A", "HN", 7.9, 8, 8);
        Assert.That(hv.DuocHocBong(), Is.False);
    }

    [Test]
    public void DuocHocBong_MonBang5_VanHopLe_NeuTB_Du8()
    {
        var hv = new HocVien("01", "A", "HN", 5, 9.5, 9.5);
        Assert.That(hv.DuocHocBong(), Is.True);
    }

    [Test]
public void LocHocVienDuocHocBong_LocDungSoLuong()
{
    var ds = new List<HocVien>
    {
        new HocVien("01", "A", "HN", 8, 8, 8),
        new HocVien("02", "B", "HCM", 9, 9, 4),
        new HocVien("03", "C", "DN", 7, 9, 9),
        new HocVien("04", "D", "HP", 10, 10, 10),
    };

    var kq = QuanLyHocVien.LocHocVienDuocHocBong(ds);
    Assert.That(kq.Count, Is.EqualTo(3));
    Assert.That(kq[0].maSo, Is.EqualTo("01"));
    Assert.That(kq[1].maSo, Is.EqualTo("03"));
    Assert.That(kq[2].maSo, Is.EqualTo("04"));
}


    [Test]
    public void LocHocVienDuocHocBong_DanhSachRong_TraVeRong()
    {
        var ds = new List<HocVien>();
        var kq = QuanLyHocVien.LocHocVienDuocHocBong(ds);
        Assert.That(kq.Count, Is.EqualTo(0));
    }

    [Test]
    public void LocHocVienDuocHocBong_KhongAiDuDieuKien_TraVeRong()
    {
        var ds = new List<HocVien>
        {
            new HocVien("01", "A", "HN", 7, 7, 7),
            new HocVien("02", "B", "HCM", 9, 9, 4),
        };

        var kq = QuanLyHocVien.LocHocVienDuocHocBong(ds);
        Assert.That(kq.Count, Is.EqualTo(0));
    }
}
