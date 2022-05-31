using PBL_V3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL_V3.DAL
{
    class DAL_HoaDon : IGeneral<HOA_DON_BAN_HANG>
    {
        private PBL_SQL_V1Entities db;
        private static DAL_HoaDon _Instance;
        public static DAL_HoaDon Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DAL_HoaDon();
                }
                return _Instance;
            }
            private set
            {



            }
        }
        public DAL_HoaDon()
        {
            db = new PBL_SQL_V1Entities();
        }



        public List<HOA_DON_BAN_HANG> GetList()
        {
            throw new NotImplementedException();
        }



        public List<HOA_DON_BAN_HANG> GetListByDate(DateTime checkIn)
        {
            List<HOA_DON_BAN_HANG> list = (from hoadon in db.HOA_DON_BAN_HANG
                                           where hoadon.Date_HDBH >= checkIn 
                                  select hoadon).ToList();

            return list;

        }



        public List<HOA_DON_BAN_HANG> GetList(int key)
        {
            List<HOA_DON_BAN_HANG> list = (from hoadon in db.HOA_DON_BAN_HANG
                                           where hoadon.Ma_Ban == key && hoadon.Date_HDBH == null
                                  select hoadon).ToList();

            return list;
        }



        public HOA_DON_BAN_HANG Get_HOA_DON_BAN_HANG(int id)
        {
            HOA_DON_BAN_HANG hoadon = db.HOA_DON_BAN_HANG.First(p => p.Ma_Hoa_Don == id);



            return hoadon;
        }



        public void Add(HOA_DON_BAN_HANG temp)
        {
            db.HOA_DON_BAN_HANG.Add(temp);
        }



        public void Delete(HOA_DON_BAN_HANG temp)
        {
            db.HOA_DON_BAN_HANG.Remove(temp);
        }



        public void Update(HOA_DON_BAN_HANG before, HOA_DON_BAN_HANG after)
        {
            throw new NotImplementedException();
        }



        public void Sync()
        {
            db.SaveChanges();
        }



        public void Thanhtoan(int idbill, int tongtien, int? IDKH, int discount)
        {
            HOA_DON_BAN_HANG tempt = db.HOA_DON_BAN_HANG.FirstOrDefault(p => p.Ma_Hoa_Don == idbill);
            tempt.Date_HDBH = DateTime.Now;
            tempt.Tong_Tien = tongtien;
            tempt.Ma_Khach_Hang = IDKH;
            tempt.Giam_Gia = discount;
            DAL_Ban.Instance.Update((int)tempt.Ma_Ban, true);
            List<BAN> listban = DAL_Ban.Instance.GetList();
            foreach (BAN item in listban)
            {
                if (item.Ma_Ban_Chuyen_Den == tempt.Ma_Ban)
                {
                    DAL_Ban.Instance.Update((int)item.Ma_Ban, true);
                    DAL_Ban.Instance.updateID_chuyen(item.Ma_Ban, null);
                }
            }
            DAL_Ban.Instance.Sync();



        }



        public int GetIDByKH(KHACH_HANG kh)
        {
            HOA_DON_BAN_HANG hd = db.HOA_DON_BAN_HANG.FirstOrDefault(p => p.Ma_Khach_Hang == kh.Ma_Khach_Hang);



            return hd.Ma_Hoa_Don;
        }



        public void UpdateKH(int idBill, KHACH_HANG kh)
        {
            HOA_DON_BAN_HANG hd = db.HOA_DON_BAN_HANG.FirstOrDefault(p => p.Ma_Hoa_Don == idBill);



            hd.Ma_Khach_Hang = kh.Ma_Khach_Hang;
        }



        public void UpdateIDKH(int idKH)
        {
            var list = from p in db.HOA_DON_BAN_HANG where p.Ma_Khach_Hang == idKH select p;
            foreach (HOA_DON_BAN_HANG item in list)
            {
                item.Ma_Khach_Hang = null;
            }
        }



        public double getTotalBillInMonth_DAL(DateTime dMonth)
        {
            var list = from p in db.HOA_DON_BAN_HANG
                       where p.Date_HDBH >= dMonth
                       select p.Tong_Tien;
            var sum = list.ToList().Sum();

            return Convert.ToDouble(sum);
        }
    }
}
