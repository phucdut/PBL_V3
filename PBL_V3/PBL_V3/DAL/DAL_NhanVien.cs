using PBL_V3.Entity;
using PBL_V3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL_V3.DAL
{
    public class DAL_NhanVien : IGeneral<NHAN_VIEN>
    {
        private PBL_SQL_V1Entities db;
        private static DAL_NhanVien _Instance;
        public static DAL_NhanVien Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DAL_NhanVien();
                }
                return _Instance;
            }
            private set
            {

            }
        }
        public DAL_NhanVien()
        {
            db = new PBL_SQL_V1Entities();
        }

        public bool Add(NHAN_VIEN temp)
        {
            try
            {
                using (var newStaff = new PBL_SQL_V1Entities())
                {

                    newStaff.Entry(temp).State = System.Data.Entity.EntityState.Added;
                    newStaff.SaveChanges();
                    return true;
                }

            }
            catch (Exception)
            {
                return false;
            }

        }
        public void ChangeInfo_DAL(String user, string name)
        {
            NHAN_VIEN nv = db.NHAN_VIEN.First(p => p.Ma_Nhan_Vien == user);
            nv.Ten_Nhan_Vien = name;
            Sync();
        }

        public NHAN_VIEN Ma_Nhan_Vien_DAL(string id)
        {
            using (var staff = new PBL_SQL_V1Entities())
            {
                return staff.NHAN_VIEN.Where(p => (p.Ma_Nhan_Vien) == id).FirstOrDefault();
            }

        }

        public List<NHAN_VIEN> GetList()
        {
            PBL_SQL_V1Entities db = new PBL_SQL_V1Entities();

            List<NHAN_VIEN> list = db.NHAN_VIEN.ToList();
            List<NHAN_VIEN> listStaff = new List<NHAN_VIEN>();
            NHAN_VIEN temp = new NHAN_VIEN();
            foreach (var item in list)
            {
                listStaff.Add(new NHAN_VIEN
                {
                    Ma_Nhan_Vien = item.Ma_Nhan_Vien,
                    Ten_Nhan_Vien = item.Ten_Nhan_Vien,
                    Gioi_Tinh = item.Gioi_Tinh,
                    Chuc_Vu = item.Chuc_Vu,
                    Phan_Quyen = item.Phan_Quyen,
                    Dia_Chi = item.Dia_Chi,
                    SDT = item.SDT,
                    Mat_Khau = item.Mat_Khau

                });

            }

            return list;
        }

        public List<NHAN_VIEN> GetList(int key)
        {
            throw new NotImplementedException();
        }

        public void Sync()
        {
            db.SaveChanges();
        }

        public bool Update(NHAN_VIEN after)    //NHANVIEN before
        {
            try
            {
                using (PBL_SQL_V1Entities db = new PBL_SQL_V1Entities())  //var newStaff = new PBL3_QLTraSuaEntities()
                {
                    NHAN_VIEN before = db.NHAN_VIEN.First(p => p.Ma_Nhan_Vien == after.Ma_Nhan_Vien);

                    before = db.NHAN_VIEN.Where(p => p.Ma_Nhan_Vien.Equals(before.Ma_Nhan_Vien)).SingleOrDefault();
                    before.Ten_Nhan_Vien = after.Ten_Nhan_Vien;
                    before.Gioi_Tinh = after.Gioi_Tinh;
                    before.Chuc_Vu = after.Chuc_Vu;
                    before.Phan_Quyen = after.Phan_Quyen;
                    before.Dia_Chi = after.Dia_Chi;
                    before.SDT = after.SDT;
                    before.Tinh_Trang = after.Tinh_Trang;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }
        void IGeneral<NHAN_VIEN>.Add(NHAN_VIEN temp)
        {
            throw new NotImplementedException();
        }

        void IGeneral<NHAN_VIEN>.Delete(NHAN_VIEN temp)
        {
            throw new NotImplementedException();
        }

        public string getID_DAL(string MaNhanVien)
        {
            NHAN_VIEN nv = db.NHAN_VIEN.First(p => p.Ma_Nhan_Vien == MaNhanVien);
            return nv.Ma_Nhan_Vien;
        }
    }
}
