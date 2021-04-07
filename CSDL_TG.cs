using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_QUAN_LY_SINH_VIEN
{
    class CSDL_TG
    {
        private static CSDL_TG _Instance;
        public static CSDL_TG Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new CSDL_TG();
                return _Instance;
            }
            private set { }
        }
        
        public SV GetSV(DataRow i)
        {
            SV s = new SV();
            s.HoTen = i["HoTen"].ToString();
            s.MSSV  = i["MSSV"].ToString();
            s.GioiTinh = Convert.ToBoolean(i["GioiTinh"]);
            s.NgaySinh = Convert.ToDateTime(i["NgaySinh"]);
            s.ID_Lop = Convert.ToInt32(i["ID_Lop"]);
            return s;
        }

        public List<SV> GetListSV(int ID_Lop)
        {
            List<SV> listSV = new List<SV>();
            //id =0 thi tra ve toan bo danh sach
            if (ID_Lop == 0)
            {
                foreach (DataRow i in CSDL.Instance.DTSV.Rows)
                    listSV.Add(GetSV(i));
            }
            else
            {
                foreach (DataRow i in CSDL.Instance.DTSV.Rows)
                    if (Convert.ToInt32(i["ID_Lop"]) == ID_Lop)
                        listSV.Add(GetSV(i));
            }
            return listSV;
        } 
        
        public LSH getLSH(DataRow i)
        {
            LSH lop = new LSH();
            lop.ID_Lop = Convert.ToInt32(i["ID_Lop"]);
            lop.TenLop = Convert.ToString(i["TenLop"]);
            return lop;
        }

        public List<LSH> getListLSH()
        {
            List<LSH> DSLop = new List<LSH>();
            foreach(DataRow i in CSDL.Instance.DTLSH.Rows)
            {
                DSLop.Add(getLSH(i));
            }
            return DSLop;
        }

        public List<SV> searchSV(string NameSV)
        {
            List<SV> DS = new List<SV>();
            foreach(DataRow i in CSDL.Instance.DTSV.Rows)
            {
                if (i["HoTen"].ToString() == NameSV || i["HoTen"].ToString().Contains(NameSV)==true)
                    DS.Add(GetSV(i));
            }
            return DS;
        }

        public Boolean addSV(SV s)
        {
            Boolean add = true;
            List<SV> DS = new List<SV>();
            //đầu tiên là phải kiểm tra mssv có bị trùng không
            foreach (SV i in GetListSV(0))
                if(i.MSSV == s.MSSV) return add = false;
            foreach (SV i in GetListSV(0))
                DS.Add(i);
            DS.Add(s);
            CSDL.Instance.setDTSV(DS);
            return add;
        }

        public void editSV(SV s)
        {          
            List<SV> DS = new List<SV>();
            DS = GetListSV(0);           
            int index = 0;
            foreach (SV i in DS)
            {
                if (s.MSSV != i.MSSV)
                    index++;
                else break;
            }
            DS[index] = s;
            CSDL.Instance.setDTSV(DS);            
        }

        public SV getSV_ByMSSV(string mssv)
        {
            SV s = new SV();
            foreach (SV i in CSDL_TG.Instance.GetListSV(0))
                if (mssv == i.MSSV) s = i;
            return s;
        }
    }
}
