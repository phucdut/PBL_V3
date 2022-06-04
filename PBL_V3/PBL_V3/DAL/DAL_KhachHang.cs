using PBL_V3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL_V3.DAL
{
    class DAL_KhachHang : IGeneral<KHACH_HANG>
    {
        private PBL_VS1Entities db;
        private static DAL_KhachHang _Instance;
        public static DAL_KhachHang Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DAL_KhachHang();
                }
                return _Instance;
            }
            private set
            {

            }
        }
        public DAL_KhachHang()
        {
            db = new PBL_VS1Entities();
        }

        public List<KHACH_HANG> GetList()
        {
            List<KHACH_HANG> list = (db.KHACH_HANG).ToList();
            return list;
        }

        public List<KHACH_HANG> GetList(int key)
        {
            throw new NotImplementedException();
        }

        public KHACH_HANG GetKHByID(int id)
        {
            KHACH_HANG kh = db.KHACH_HANG.FirstOrDefault(p => p.Ma_Khach_Hang == id);

            return kh;
        }

        public KHACH_HANG GetKHByInfo(String inForKH)
        {
            KHACH_HANG kh = db.KHACH_HANG.FirstOrDefault(p => p.SDT == inForKH || p.Ten_Khach_Hang == inForKH);

            return kh;
        }

        public void Add(KHACH_HANG temp)
        {
            db.KHACH_HANG.Add(temp);
        }

        public void Delete(KHACH_HANG temp)
        {
            db.KHACH_HANG.Remove(temp);
        }


        public void UpdateDTL(KHACH_HANG khachhang, int dtl)
        {
            KHACH_HANG kh = db.KHACH_HANG.First(p => p.Ma_Khach_Hang == khachhang.Ma_Khach_Hang);
            kh.Diem_Tich_Luy += dtl;
            if (kh.Diem_Tich_Luy < 100)
            {
                kh.Ma_Loai_Khach_Hang = 1;
            }else if (kh.Diem_Tich_Luy > 100 && kh.Diem_Tich_Luy <300)
            {
                kh.Ma_Loai_Khach_Hang = 2;
            } else if(kh.Diem_Tich_Luy > 300)
            {
                kh.Ma_Loai_Khach_Hang = 3;
            }    

        }

        public void UpdateKH(KHACH_HANG kh)
        {
            KHACH_HANG cus = db.KHACH_HANG.First(p => p.Ma_Khach_Hang == kh.Ma_Khach_Hang);
            cus.Ten_Khach_Hang = kh.Ten_Khach_Hang;
            cus.Dia_Chi = kh.Dia_Chi;
            cus.SDT = kh.SDT;
        }

        public void Sync()
        {
            db.SaveChanges();
        }
        public int? getIDbyInfo(String info)
        {
            KHACH_HANG cus = db.KHACH_HANG.FirstOrDefault(p => p.SDT == info);
            if (cus != null)
                return cus.Ma_Khach_Hang;
            else return null;
        }

        public bool checkSDT(String sdt)
        {
            KHACH_HANG cus = db.KHACH_HANG.FirstOrDefault(p => p.SDT == sdt);

            return false ? cus.SDT == null : true;
        }
    }
}
