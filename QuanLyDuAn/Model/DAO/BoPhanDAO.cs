using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class BoPhanDAO
    {
        QLDADbContext db = null;

        public BoPhanDAO()
        {
            db = new QLDADbContext();
        }

        public List<BoPhan> ListAll()
        {
            return db.BoPhans.ToList();
        }
    }
}
