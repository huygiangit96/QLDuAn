using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class BangCongDAO
    {
        QLDADbContext db = null;

        public BangCongDAO()
        {
            db = new QLDADbContext();
        }
        public List<BangCong> ListAll()
        {
            return db.BangCongs.ToList();
        }
        public bool Insert(BangCong item)
        {
            try
            {
                db.BangCongs.Add(item);
                db.SaveChanges();
                return true;
            }
            catch { }
            return false;
        }
        public bool Update(BangCong item)
        {
            var dbEntry = db.BangCongs.Find(item.MaCC);
            if(dbEntry == null)
            {
                return false;
            }
            dbEntry.MaCV = item.MaCV;
            dbEntry.MaNV = item.MaNV;
            dbEntry.NgayBatDau = item.NgayBatDau;
            dbEntry.NgayKetThuc = item.NgayKetThuc;
            dbEntry.NgaySua = item.NgaySua;
            dbEntry.SoGioLam = item.SoGioLam;
            dbEntry.TenChucNang = item.TenChucNang;
            db.SaveChanges();
            return true;
        }
        
        public bool Delete(long id)
        {
            var dbEntry = GetByID(id);
            try
            {
                db.BangCongs.Remove(dbEntry);
                db.SaveChanges();
                return true;
            }
            catch { }
            return false;
        }
        public BangCong GetByID(long id)
        {
            return db.BangCongs.SingleOrDefault(x => x.MaCC == id);
        }
    }
}
