using PBL_V3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PBL_V3.BLL
{
    class BLL_TaiKhoan
    {
        private static BLL_TaiKhoan _Instance;
        public static BLL_TaiKhoan Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_TaiKhoan();
                }
                return _Instance;
            }
            private set
            {

            }
        }
        public bool BLL_DangNhap(string username, string password, int type)
        {
            byte[] tempt = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hashData = new MD5CryptoServiceProvider().ComputeHash(tempt);
            string hashpass = "";
            foreach (byte item in hashData)
            {
                hashpass += item;
            }

            if (type == 0)
            {
                return DAL.DAL_TaiKhoan.Instance.DAL_DangNhap(username, hashpass);
            }
            else
            {
                return DAL.DAL_TaiKhoan.Instance.ResetPassword_DAL(username, hashpass);
            }
        }

        public bool ChangeAccount(string id, NHAN_VIEN after)
        {
            return DAL_TaiKhoan.Instance.ChangeAccount(id, after);
        }

        public NHAN_VIEN GetNVByID(string id)
        {
            return DAL_TaiKhoan.Instance.GetNVByID(id);
        }
    }
}
