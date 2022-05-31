using PBL_V3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL_V3.DAL
{
    class DAL_Ban : IGeneral<BAN>
    {
        private PBL_SQL_V1Entities db;
        private static DAL_Ban _Instance;
        public static DAL_Ban Instance
        {
            get
            {

                if (_Instance == null)
                {
                    _Instance = new DAL_Ban();
                }
                return _Instance;
            }
            private set
            {

            }
        }
        DAL_Ban()
        {
            db = new PBL_SQL_V1Entities();
        }

        ~DAL_Ban()
        {
            db.Dispose();
        }

        public void Add(BAN temp)
        {
            throw new NotImplementedException();
        }

        public void Delete(BAN temp)
        {
            throw new NotImplementedException();
        }

        public List<BAN> GetList()
        {
            List<BAN> list = (db.BANs).ToList();
            return list;
        }
        public BAN gettable(int idban)
        {
            db = new PBL_SQL_V1Entities();
            return db.BANs.FirstOrDefault(p => p.Ma_Ban == idban);
        }
        public string getNameTable(int IDBAN)
        {
            db = new PBL_SQL_V1Entities();
            BAN ban = db.BANs.FirstOrDefault(p => p.Ma_Ban == IDBAN);
            if (ban == null) return "";
            else return ban.Ten_Ban;
        }
        public List<BAN> GetList(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, bool tinhTrang)
        {
            BAN ban = db.BANs.First(p => p.Ma_Ban == id);
            ban.Tinh_Trang = tinhTrang;

            List<BAN> list = db.BANs.ToList();
        }
        public void updateID_chuyen(int idban, int? idchuyen)
        {
            BAN ban = db.BANs.First(p => p.Ma_Ban == idban);
            ban.Ma_Ban_Chuyen_Den = idchuyen;
            Sync();
        }

        public void Sync()
        {
            db.SaveChanges();
        }
    }
}
