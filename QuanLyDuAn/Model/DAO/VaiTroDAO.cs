using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class VaiTroDAO
    {
        QLDADbContext db = null;

        public VaiTroDAO()
        {
            db = new QLDADbContext();
        }

        public List<VaiTro> ListAll()
        {
            return db.VaiTroes.ToList();
        }
    }
}
