using System;
using System.Collections.Generic;
using System.Linq;

namespace Tester_Tuan4;

public class HocVien
{
    public string maSo;
    public string hoTen;
    public string queQuan;
    public double diem1;
    public double diem2;
    public double diem3;

    public HocVien(string maSo, string hoTen, string queQuan, double diem1, double diem2, double diem3)
    {
        this.maSo = maSo;
        this.hoTen = hoTen;
        this.queQuan = queQuan;
        this.diem1 = diem1;
        this.diem2 = diem2;
        this.diem3 = diem3;
    }

    public double DiemTrungBinh()
    {
        return (diem1 + diem2 + diem3) / 3.0;
    }

    public bool DuocHocBong()
    {
        if (diem1 < 5 || diem2 < 5 || diem3 < 5) return false;
        return DiemTrungBinh() >= 8.0;
    }
}

public static class QuanLyHocVien
{
    public static List<HocVien> LocHocVienDuocHocBong(List<HocVien> danhSach)
    {
        return danhSach.Where(hv => hv.DuocHocBong()).ToList();
    }
}
