using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class KhachHangDAO
    {
        QLDADbContext db = null;
        
        public KhachHangDAO()
        {
            db = new QLDADbContext();
        }

        public KhachHang GetByID(long id)
        {
            return db.KhachHangs.SingleOrDefault(x => x.MaKH == id);
        }
        public List<KhachHang> ListAll()
        {
            return db.KhachHangs.ToList();
        }
        public bool Insert(KhachHang item)
        {
            try
            {
                db.KhachHangs.Add(item);
                db.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }
        public bool Update(KhachHang item)
        {
            var dbEntry = GetByID(item.MaKH);
            try
            {
                dbEntry.NgaySua = item.NgaySua;
                dbEntry.SoDT = item.SoDT;
                dbEntry.SoTK = item.SoTK;
                dbEntry.Ten = item.Ten;
                dbEntry.DiaChi = item.DiaChi;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(long item)
        {
            var dbEntry = GetByID(item);
            try
            {
                db.KhachHangs.Remove(dbEntry);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
