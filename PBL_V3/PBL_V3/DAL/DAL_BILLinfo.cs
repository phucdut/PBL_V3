using PBL_V3.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL_V3.DAL
{
    class DAL_BILLinfo
    {
        private PBL_VS1Entities db;
        private static DAL_BILLinfo _Instance;
        public static DAL_BILLinfo Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DAL_BILLinfo();
                }
                return _Instance;
            }
            private set
            {

            }
        }
        public DAL_BILLinfo()
        {
            db = new PBL_VS1Entities();
        }

        public List<BILLinfo> GetBillInfo(BAN table)
        {
            var list = from hanghoa in db.HANG_HOA
                       from hoadon in db.HOA_DON_BAN_HANG
                       from hoadonChitiet in db.CHI_TIET_HD_BAN_HANG
                       where hanghoa.Ma_Hang_Hoa == hoadonChitiet.Ma_Hang_Hoa
                       where hoadon.Ma_Hoa_Don == hoadonChitiet.Ma_Hoa_Don
                       where hoadon.Ma_Ban == table.Ma_Ban
                       where hoadon.Gio_di == null
                       let tongTien = hoadonChitiet.So_Luong * (double)hanghoa.Gia_Hang_Hoa
                       select new { hanghoa.Ten_Hang_Hoa, hoadonChitiet.So_Luong, hanghoa.Gia_Hang_Hoa, tongTien };

            List<BILLinfo> listBillIn = new List<BILLinfo>();

            foreach (var item in list)
            {
                BILLinfo temp = new BILLinfo
                {
                    MatHang = item.Ten_Hang_Hoa,
                    SoLuong = (int)item.So_Luong,
                    DonGia = (double)item.Gia_Hang_Hoa,
                    TongTien = (double)item.tongTien
                };
                listBillIn.Add(temp);
            }

            return listBillIn;

        }


    }
}
