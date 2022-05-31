using PBL_V3.DAL;
using PBL_V3.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL_V3.BLL
{
    class BLL_CT_HangHoa
    {
        private static BLL_CT_HangHoa _Instance;
        public static BLL_CT_HangHoa Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_CT_HangHoa();
                }
                return _Instance;
            }
            private set
            {

            }
        }

        public List<CBBItem> GetCBB()
        {
            List<CBBItem> list = new List<CBBItem>();
            foreach (LOAI_HANG_HOA item in DAL_CT_HangHoa.Instance.GetList())
            {
                list.Add(new CBBItem
                {
                    Value = item.Ma_Loai_Hang_Hoa,
                    Text = item.Ten_Loai_Hang_Hoa
                });
            }
            return list;
        }

        public List<LOAI_HANG_HOA> GetLHH_BLL()
        {
            return DAL_CT_HangHoa.Instance.GetList();
        }
    }
}
