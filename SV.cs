using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_QUAN_LY_SINH_VIEN
{
    class SV
    {
        public string MSSV { get; set; }
        public string HoTen { get; set; }
        public int ID_Lop { get; set; }
        public Boolean GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public static bool isCompareMSSV(SV s1, SV s2)
        {
            return String.Compare(s1.MSSV,s2.MSSV) < 0;
        }
        public static bool isCompareHoTen(SV s1, SV s2)
        {
            return String.Compare(s1.HoTen, s2.HoTen) < 0;
        }
        public static bool isCompareID_Lop(SV s1, SV s2)
        {
            return s1.ID_Lop < s2.ID_Lop;
        }
        public static bool isCompareNgaySinh(SV s1, SV s2)
        {
            return DateTime.Compare(s1.NgaySinh, s2.NgaySinh) < 0;
        }
        public static bool isCompareGioiTinh(SV s1, SV s2)
        {
            return String.Compare(s1.GioiTinh.ToString(), s2.NgaySinh.ToString()) < 0;
        }
    }
}
