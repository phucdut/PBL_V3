using PBL_V3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL_V3.BLL
{
    class BLL_HoaDon
    {

        private static BLL_HoaDon _Instance;
        public static BLL_HoaDon Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_HoaDon();
                }
                return _Instance;
            }
            private set
            {

            }
        }

        public bool checkHoaDon(int idTable)
        {
            int hang = DAL_HoaDon.Instance.GetList(idTable).Count;
            if (DAL_HoaDon.Instance.GetList(idTable).Count <= 0) return false;
            return true;
        }

        public void InsertHOADON(int idBAN, int? idKH, string idNV)
        {
            HOA_DON_BAN_HANG hoadon = new HOA_DON_BAN_HANG
            {
                Ma_Ban = idBAN,
                Ma_Khach_Hang = idKH,
                Ma_Nhan_Vien = idNV,
                Date_HDBH = DateTime.Now,
                //Date_HDBH = null,
                Tong_Tien = 0,
                Giam_Gia = 0,
                //  Diem_TL = 0
            };

            DAL_HoaDon.Instance.Add(hoadon);
            DAL_HoaDon.Instance.Sync();
        }

        public int GetIdByTable(int idTable)
        {
            int id = DAL_HoaDon.Instance.GetList(idTable).First().Ma_Hoa_Don;
            return id;
        }

        public HOA_DON_BAN_HANG getHOADONbyID(int ID_HOADON)
        {
            return DAL_HoaDon.Instance.Get_HOA_DON(ID_HOADON);
        }

        public void delete(int idBill)
        {
            HOA_DON_BAN_HANG hoadon = DAL_HoaDon.Instance.Get_HOA_DON(idBill);

            DAL_HoaDon.Instance.Delete(hoadon);
            DAL_HoaDon.Instance.Sync();
        }

        public void Thanhtoan(int idbill, int tongtien, int? IDKH, int discount)
        {
            if (IDKH == null)
            {
                DAL_HoaDon.Instance.Thanhtoan(idbill, tongtien, null, discount);
            }
            else
            {
                DAL_HoaDon.Instance.Thanhtoan(idbill, tongtien, (int)IDKH, discount);
            }

            DAL_HoaDon.Instance.Sync();
        }

        public List<HOA_DON_BAN_HANG> GetListHOADONByDate(DateTime checkIn)
        {
            return DAL_HoaDon.Instance.GetListByDate(checkIn);
        }

        public int getIDByKH(KHACH_HANG kh)
        {
            return DAL_HoaDon.Instance.GetIDByKH(kh);
        }

        public void UpdateKH(int idBill, KHACH_HANG kh)
        {
            DAL_HoaDon.Instance.UpdateKH(idBill, kh);
            DAL_HoaDon.Instance.Sync();
        }

        public void UpdateIDKH(int idKH)
        {
            DAL_HoaDon.Instance.UpdateIDKH(idKH);
            DAL_HoaDon.Instance.Sync();
        }

        public double getTotalBillInMonth(DateTime firstMonth)
        {
            return DAL_HoaDon.Instance.getTotalBillInMonth_DAL(firstMonth);
        }
    }
}
