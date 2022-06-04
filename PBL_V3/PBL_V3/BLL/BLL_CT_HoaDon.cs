using PBL_V3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL_V3.Interface;

namespace PBL_V3.BLL
{
    class BLL_CT_HoaDon
    {
        private static BLL_CT_HoaDon _Instance;
        public static BLL_CT_HoaDon Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_CT_HoaDon();
                }
                return _Instance;
            }
            private set
            {

            }
        }

        public void update(int idBill, String tenHH, int soLuong)
        {
            DAL_CT_HoaDon.Instance.Update(idBill, tenHH, soLuong);
            DAL_CT_HoaDon.Instance.Sync();
        }
 

        public void insert(int idBill, String tenHH, int soLuong)
        {
            int idHH = DAL_HangHoa.Instance.GetIDByName(tenHH);
            CHI_TIET_HD_BAN_HANG chitietHD = new CHI_TIET_HD_BAN_HANG
            {
                
                Ma_Hoa_Don = idBill,
                Ma_Hang_Hoa = idHH,
                So_Luong = soLuong
            };

            DAL_CT_HoaDon.Instance.Add(chitietHD);
            DAL_CT_HoaDon.Instance.Sync();
        }

        public void delete(int idBill, String tenHH, int soLuong)
        {
            int idHH = DAL_HangHoa.Instance.GetIDByName(tenHH);
            int idCTHD = DAL_CT_HoaDon.Instance.GetID(idBill, idHH);
            CHI_TIET_HD_BAN_HANG chitiet = new CHI_TIET_HD_BAN_HANG
            {
                Ma_CTHD = idCTHD,
                Ma_Hoa_Don = idBill,
                Ma_Hang_Hoa = idHH,
                So_Luong = soLuong,
            };
            DAL_CT_HoaDon.Instance.Delete(chitiet);
            DAL_CT_HoaDon.Instance.Sync();
        }
    }
}
