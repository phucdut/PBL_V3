using PBL_V3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL_V3.BLL
{
    class BLL_Ban
    {
        private static BLL_Ban _Instance;
        public static BLL_Ban Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_Ban();
                }
                return _Instance;
            }
            private set
            {

            }
        }

        public List<BAN> GetTable()
        {
            return DAL_Ban.Instance.GetList();
        }

        private List<BAN> GetList()
        {
            throw new NotImplementedException();
        }

        public BAN gettable(int idban)
        {
            return DAL_Ban.Instance.gettable(idban);
        }
        public string GetnameTable(int idban)
        {

            return DAL_Ban.Instance.getNameTable(idban);
        }

        

        public void update(int id, bool tinhTrang)
        {
            DAL_Ban.Instance.Update(id, tinhTrang);
            DAL_Ban.Instance.Sync();
        }

        

        public void updateID_chuyen(int idban, int idchuyen)
        {
            DAL_Ban.Instance.updateID_chuyen(idban, (int)idchuyen);
        }
    }
}
