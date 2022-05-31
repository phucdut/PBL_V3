using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL_V3.DAL
{
    public class DAL_TaiKhoan
    {
        private PBL_SQL_V1Entities db;
        private static DAL_TaiKhoan _Instance;
        public static DAL_TaiKhoan Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DAL_TaiKhoan();
                }
                return _Instance;
            }
            private set
            {

            }
        }
        public DAL_TaiKhoan()
        {
            db = new PBL_SQL_V1Entities();
        }

        public bool DAL_DangNhap(string username, string password)
        {
            NHAN_VIEN s = db.NHAN_VIEN.FirstOrDefault(p => p.Ma_Nhan_Vien == username);
            if (s == null || s.Tinh_Trang == -1) return false;
            return s.Mat_Khau == password;
        }

        public bool ResetPassword_DAL(string username, string newpassword)
        {

            db = new PBL_SQL_V1Entities();
            var s = db.NHAN_VIEN.Where(p => p.Ma_Nhan_Vien == username).FirstOrDefault();
            s.Mat_Khau = newpassword;
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Console.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
                return false;
            }
        }
        public bool ChangeAccount(string username, NHAN_VIEN after)    //NHAN_VIEN before
        {
            db = new PBL_SQL_V1Entities();
            var s = db.NHAN_VIEN.Where(p => p.Ma_Nhan_Vien == username).FirstOrDefault();
            s.Ma_Nhan_Vien = after.Ma_Nhan_Vien;
            s.Mat_Khau = after.Mat_Khau;
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public NHAN_VIEN GetNVByID(string id)
        {
            NHAN_VIEN nv = db.NHAN_VIEN.FirstOrDefault(p => p.Ma_Nhan_Vien == id);

            return nv;
        }
    }
}
