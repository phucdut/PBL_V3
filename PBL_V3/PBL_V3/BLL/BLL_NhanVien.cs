using PBL_V3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL_V3.BLL
{
    class BLL_NhanVien
    {
        private static BLL_NhanVien _Instance;
        public static BLL_NhanVien Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_NhanVien();
                }
                return _Instance;
            }
            private set
            {

            }
        }

        public List<NHAN_VIEN> getStaff()
        {
            return DAL.DAL_NhanVien.Instance.GetList();
        }

        public bool AddStaff_BLL(NHAN_VIEN nv)
        {
            return DAL.DAL_NhanVien.Instance.Add(nv);
        }
        public bool EditStaff_BLL(NHAN_VIEN after)
        {
            return DAL.DAL_NhanVien.Instance.Update(after);
        }
        public NHAN_VIEN Staff_ID_BLL(string id)
        {
            return DAL.DAL_NhanVien.Instance.Ma_Nhan_Vien_DAL(id);
        }
        public string getID_BLL(string TenNhanVien)
        {
            return DAL_NhanVien.Instance.getID_DAL(TenNhanVien);
        }

        public void ChangeInf_BLL(String user, string name, string newpass)
        {
            if (newpass != "")
            {
                BLL_TaiKhoan.Instance.BLL_DangNhap(user, newpass, 1);
            }
            else
            {
                DAL_NhanVien.Instance.ChangeInfo_DAL(user, name);
            }
        }
    }
}
