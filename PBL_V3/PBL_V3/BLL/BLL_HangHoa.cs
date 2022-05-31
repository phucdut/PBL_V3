using PBL_V3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL_V3.BLL
{
    class BLL_HangHoa
    {
        private static BLL_HangHoa _Instance;
        public static BLL_HangHoa Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_HangHoa();
                }
                return _Instance;
            }
            private set
            {

            }
        }

        
        public void Add(HANG_HOA hh)
        {
            DAL_HangHoa.Instance.Add(hh);
            DAL_HangHoa.Instance.Sync();
        }

        public List<HANG_HOA> GetList()
        {
            return DAL_HangHoa.Instance.GetList();
        }

        public List<HANG_HOA> GetList(int id)
        {
            if (id == -1)
            {
                return DAL_HangHoa.Instance.GetList();
            }
            return DAL_HangHoa.Instance.GetList(id);
        }

        public HANG_HOA GetHHByName(String name)
        {
            return DAL_HangHoa.Instance.GetHHByName(name);
        }

        public void update(HANG_HOA hh, String name)
        {
            DAL_HangHoa.Instance.Update(hh, name);
            DAL_HangHoa.Instance.Sync();
        }

        public void delete(HANG_HOA hh)
        {
            DAL_HangHoa.Instance.Delete(hh);
            DAL_HangHoa.Instance.Sync();
        }
        
        
    }
}
