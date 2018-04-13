using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class ViTriDAO
    {
        QLDADbContext db = new QLDADbContext();
        public ViTriDAO()
        {
            db = new QLDADbContext();
        }
        public List<ViTri> ListAll()
        {
            return db.ViTris.ToList();
        }
    }
}
