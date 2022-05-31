using PBL_V3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL_V3.BLL
{
    class BLL_BILLinfo
    {
        private static BLL_BILLinfo _Instance;
        public static BLL_BILLinfo Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_BILLinfo();
                }
                return _Instance;
            }
            private set
            {

            }
        }

        public List<Entity.BILLinfo> GetList(BAN table)
        {
            return DAL_BILLinfo.Instance.GetBillInfo(table);
        }
    }
}
