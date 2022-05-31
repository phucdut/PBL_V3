using PBL_V3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL_V3.DAL
{
    class DAL_HangHoa : IGeneral<HANG_HOA>
    { 
        private PBL_SQL_V1Entities db;
        private static DAL_HangHoa _Instance;
        public static DAL_HangHoa Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DAL_HangHoa();
                }
                return _Instance;
            }
            private set
            {

            }
        }
        public DAL_HangHoa()
        {
            db = new PBL_SQL_V1Entities();
        }

        public void Add(HANG_HOA temp)
        {
            db.HANG_HOA.Add(temp);
        }

        public void Delete(HANG_HOA temp)
        {
            HANG_HOA current = db.HANG_HOA.First(p => p.Ma_Hang_Hoa == temp.Ma_Hang_Hoa);
            current.Tinh_Trang = 0;
        }

        public List<HANG_HOA> GetList()
        {
            return db.HANG_HOA.Where(p => p.Tinh_Trang == 1).ToList();
        }

        public List<HANG_HOA> GetList(int key)
        {
            var l2 = db.HANG_HOA.Where(p => p.Ma_Loai_Hang_Hoa == key && p.Tinh_Trang == 1);

            return l2.ToList();
        }

        public void Update(HANG_HOA hanghoaThayDoi, String name)
        {
            HANG_HOA current = db.HANG_HOA.First(p => p.Ten_Hang_Hoa == name);
            if (current.Tinh_Trang == 1)
            {
                current.Ten_Hang_Hoa = hanghoaThayDoi.Ten_Hang_Hoa;
                current.Ma_Loai_Hang_Hoa = hanghoaThayDoi.Ma_Loai_Hang_Hoa;
                current.Gia_Hang_Hoa = hanghoaThayDoi.Gia_Hang_Hoa;
            }
            else
            {
                current.Tinh_Trang = 1;
                current.Ten_Hang_Hoa = hanghoaThayDoi.Ten_Hang_Hoa;
                current.Ma_Loai_Hang_Hoa = hanghoaThayDoi.Ma_Loai_Hang_Hoa;
                current.Gia_Hang_Hoa = hanghoaThayDoi.Gia_Hang_Hoa;
            }
        }

        public int GetIDByName(String name)
        {
            HANG_HOA hh = db.HANG_HOA.First(p => p.Ten_Hang_Hoa == name);

            return hh.Ma_Hang_Hoa;
        }
        
        
        public HANG_HOA GetHHByName(String name)
        {
            HANG_HOA hh = db.HANG_HOA.FirstOrDefault(p => p.Ten_Hang_Hoa == name);

            return hh;
        }
        
        public void Sync()
        {
            db.SaveChanges();
        }
    }
}
