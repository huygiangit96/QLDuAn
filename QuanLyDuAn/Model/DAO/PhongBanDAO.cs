using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class PhongBanDAO
    {
        QLDADbContext db = null;

        public PhongBanDAO()
        {
            db = new QLDADbContext();
        }

        public List<PhongBan> ListAll()
        {
            return db.PhongBans.ToList();
        }
    }
}
