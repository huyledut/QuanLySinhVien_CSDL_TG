using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_QUAN_LY_SINH_VIEN
{
    class CSDL
    {
        public DataTable DTSV { get; set; }
        public DataTable DTLSH { get; set; }
        private static CSDL _Instance;
        public static CSDL Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new CSDL();
                return _Instance;
            }
            private set { }
        }
        private CSDL()
        {
            DTSV = new DataTable();
            DTSV.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("MSSV",typeof(string)),
                new DataColumn("HoTen",typeof(string)),
                new DataColumn("GioiTinh",typeof(Boolean)),
                new DataColumn("ID_Lop", typeof(int)),
                new DataColumn("NgaySinh",typeof(DateTime))
            });
            DataRow dr1 = DTSV.NewRow();
            dr1["MSSV"] = "001";
            dr1["HoTen"] = "NVA";
            dr1["GioiTinh"] = true;
            dr1["ID_Lop"] = 1;
            dr1["NgaySinh"] = DateTime.Now;

            DataRow dr2 = DTSV.NewRow();
            dr2["MSSV"] = "002";
            dr2["HoTen"] = "NVB";
            dr2["GioiTinh"] = true;
            dr2["ID_Lop"] = 1;
            dr2["NgaySinh"] = DateTime.Now;

            DataRow dr3 = DTSV.NewRow();
            dr3["MSSV"] = "003";
            dr3["HoTen"] = "NVC";
            dr3["GioiTinh"] = true;
            dr3["ID_Lop"] = 2;
            dr3["NgaySinh"] = DateTime.Now;

            DataRow dr4 = DTSV.NewRow();
            dr4["MSSV"] = "004";
            dr4["HoTen"] = "NVD";
            dr4["GioiTinh"] = true;
            dr4["ID_Lop"] = 2;
            dr4["NgaySinh"] = DateTime.Now;

            DataRow dr5 = DTSV.NewRow();
            dr5["MSSV"] = "005";
            dr5["HoTen"] = "NVE";
            dr5["GioiTinh"] = false;
            dr5["ID_Lop"] = 3;
            dr5["NgaySinh"] = DateTime.Now;

            DTSV.Rows.Add(dr1);
            DTSV.Rows.Add(dr2);
            DTSV.Rows.Add(dr3);
            DTSV.Rows.Add(dr4);
            DTSV.Rows.Add(dr5);

            DTLSH = new DataTable();
            DTLSH.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("ID_Lop",typeof(int)),
                new DataColumn("TenLop",typeof(string))                
            });
            DataRow d1 = DTLSH.NewRow();
            d1["ID_Lop"] = 1;
            d1["TenLop"] = "19T1";
            DTLSH.Rows.Add(d1);

            DataRow d2 = DTLSH.NewRow();
            d2["ID_Lop"] = 2;
            d2["TenLop"] = "19T2";
            DTLSH.Rows.Add(d2);

            DataRow d3 = DTLSH.NewRow();
            d3["ID_Lop"] = 3;
            d3["TenLop"] = "19T3";
            DTLSH.Rows.Add(d3);
        }
        
        public void setDTSV(List<SV> s)
        {
            DTSV.Rows.Clear();
            foreach(SV i in s)
            {
                DataRow dr = DTSV.NewRow();
                dr["MSSV"] = i.MSSV;
                dr["HoTen"] = i.HoTen;
                dr["GioiTinh"] = i.GioiTinh;
                dr["ID_Lop"] = i.ID_Lop;
                dr["NgaySinh"] = i.NgaySinh;
                DTSV.Rows.Add(dr);
            }
        }
    }
}
