using PBL_V3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL_V3.DAL
{
    class DAL_CT_HoaDon : IGeneral<CHI_TIET_HD_BAN_HANG>
    {
        private PBL_VS1Entities db;
        private static DAL_CT_HoaDon _Instance;
        public static DAL_CT_HoaDon Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DAL_CT_HoaDon();
                }
                return _Instance;
            }
            private set
            {

            }
        }
        public DAL_CT_HoaDon()
        {
            db = new PBL_VS1Entities();
        }

        public List<CHI_TIET_HD_BAN_HANG> GetList()
        {
            throw new NotImplementedException();
        }

        public List<CHI_TIET_HD_BAN_HANG> GetList(int key)
        {
            throw new NotImplementedException();
        }

        public void Add(CHI_TIET_HD_BAN_HANG temp)

        {
            db.CHI_TIET_HD_BAN_HANG.Add(temp);
        }

        public int GetID(int idBill, int idHH)
        {
            CHI_TIET_HD_BAN_HANG chitiet = db.CHI_TIET_HD_BAN_HANG.First(p => p.Ma_Hoa_Don == idBill && p.Ma_Hang_Hoa == idHH);
            return chitiet.Ma_CTHD;
        }

        public void Delete(CHI_TIET_HD_BAN_HANG temp)
        {
            CHI_TIET_HD_BAN_HANG chitiet = db.CHI_TIET_HD_BAN_HANG.First(p => p.Ma_CTHD == temp.Ma_CTHD);
            db.CHI_TIET_HD_BAN_HANG.Remove(chitiet);
        }

        public void Update(int idBill, String TenHH, int soLuong)
        {
            CHI_TIET_HD_BAN_HANG current = db.CHI_TIET_HD_BAN_HANG.First(p => p.Ma_Hoa_Don == idBill && p.HANG_HOA.Ten_Hang_Hoa == TenHH);

            current.So_Luong = soLuong;
        }

        public void Sync()
        {
            db.SaveChanges();
        }
    }
}
