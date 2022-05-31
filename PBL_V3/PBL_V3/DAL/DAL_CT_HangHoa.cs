using PBL_V3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL_V3.DAL
{
    internal class DAL_CT_HangHoa : IGeneral<LOAI_HANG_HOA>
    {
        private PBL_SQL_V1Entities db;
        private static DAL_CT_HangHoa _Instance;
        public static DAL_CT_HangHoa Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DAL_CT_HangHoa();
                }
                return _Instance;
            }
            private set
            {

            }
        }
        public DAL_CT_HangHoa()
        {
            db = new PBL_SQL_V1Entities();
        }
        public void Add(LOAI_HANG_HOA temp)
        {
            throw new NotImplementedException();
        }

        public void Delete(LOAI_HANG_HOA temp)
        {
            throw new NotImplementedException();
        }

        public List<LOAI_HANG_HOA> GetList()
        {
            return db.LOAI_HANG_HOA.ToList();
        }

        public List<LOAI_HANG_HOA> GetList(int key)
        {
            throw new NotImplementedException();
        }


        public void Update(LOAI_HANG_HOA before, LOAI_HANG_HOA after)
        {
            throw new NotImplementedException();
        }

        public void Sync()
        {
            throw new NotImplementedException();
        }
    
    }
}
