namespace Tester_Tuan4;

public class Diem
{
    public int x;
    public int y;

    public Diem(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}

public class HinhChuNhat
{
    private Diem trenTrai;
    private Diem duoiPhai;

    public HinhChuNhat(Diem trenTrai, Diem duoiPhai)
    {
        this.trenTrai = trenTrai;
        this.duoiPhai = duoiPhai;
    }

    public int DienTich()
    {
        int chieuRong = duoiPhai.x - trenTrai.x;
        int chieuCao = trenTrai.y - duoiPhai.y;
        return chieuRong * chieuCao;
    }

    public bool GiaoNhau(HinhChuNhat other)
    {
        if (this.duoiPhai.x <= other.trenTrai.x) return false;
        if (other.duoiPhai.x <= this.trenTrai.x) return false;
        if (this.duoiPhai.y >= other.trenTrai.y) return false;
        if (other.duoiPhai.y >= this.trenTrai.y) return false;
        return true;
    }
}
