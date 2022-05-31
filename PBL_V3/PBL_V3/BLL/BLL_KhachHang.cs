using PBL_V3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL_V3.BLL
{
    class BLL_KhachHang
    {
        private static BLL_KhachHang _Instance;
        public static BLL_KhachHang Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_KhachHang();
                }
                return _Instance;
            }
            private set
            {

            }
        }

        public KHACH_HANG GetKHByID(int idKH)
        {
            return DAL_KhachHang.Instance.GetKHByID(idKH);
        }

        public KHACH_HANG GetKHByInfo(String inForKH)
        {
            return DAL_KhachHang.Instance.GetKHByInfo(inForKH);
        }

        public void updateDTL(KHACH_HANG kh, int dtl)
        {
            DAL_KhachHang.Instance.UpdateDTL(kh, dtl);
            DAL_KhachHang.Instance.Sync();
        }

        public void AddCustomer_BLL(String info, int dtl)
        {
            int i;
            if (dtl < 200) i = 0;
            else i = 1;
            KHACH_HANG kh = new KHACH_HANG
            {
                Ten_Khach_Hang = "",
                Ma_Loai_Khach_Hang = i,
                Dia_Chi = "",
                SDT = info,
                Diem_Tich_Luy = dtl
            };
            DAL_KhachHang.Instance.Add(kh);
            DAL_KhachHang.Instance.Sync();
        }

        public List<KHACH_HANG> GetList()
        {
            return DAL_KhachHang.Instance.GetList();
        }

        public void UpdateKH(KHACH_HANG kh)
        {
            DAL_KhachHang.Instance.UpdateKH(kh);
            DAL_KhachHang.Instance.Sync();
        }

        public void Delete(KHACH_HANG kh)
        {
            BLL_HoaDon.Instance.UpdateIDKH(kh.Ma_Khach_Hang);
            DAL_KhachHang.Instance.Delete(kh);
            DAL_KhachHang.Instance.Sync();
        }
        public int? getIDbyInfo(String info)
        {
            return DAL_KhachHang.Instance.getIDbyInfo(info);
        }

        public bool checkSDT(String sdt)
        {
            return DAL_KhachHang.Instance.checkSDT(sdt);
        }
    }
}
