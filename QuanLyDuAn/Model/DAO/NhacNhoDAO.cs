using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using Model.ViewModel;

namespace Model.DAO
{
    public class NhacNhoDAO
    {
        QLDADbContext db = null;
        public NhacNhoDAO()
        {
            db = new QLDADbContext();
        }
        public List<NhacNho> ListAll()
        {
            return db.NhacNhoes.ToList();
        }
        public NhacNho GetByID(long id)
        {
            return db.NhacNhoes.SingleOrDefault(x => x.MaNN == id);
        }
        public bool Insert(NhacNho item)
        {
            try
            {
                db.NhacNhoes.Add(item);
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
                db.NhacNhoes.Remove(dbEntry);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
<<<<<<< HEAD
        public List<NhacNhoView> GetByNV(long id)
        {
            var data = from a in db.NhacNhoes
                            join b in db.NhanViens on a.MaNV equals b.MaNV
                            join c in db.NhanViens on a.NguoiNhanID equals c.MaNV
                            where (a.MaNV == id || a.NguoiNhanID == id)
                            select new NhacNhoView()
                            {
                                MaNN = a.MaNN,
                                MaNV = a.MaNV,
                                Ten = b.Ten,
                                TieuDe = a.TieuDe,
                                NoiDung = a.NoiDung,
                                NgayTao = a.NgayTao,
                                NguoiNhanID = a.NguoiNhanID,
                                NguoiNhan = c.Ten,
                                Status = a.Status
                            };
            return data.ToList();
        }
=======
        //public List<NhacNhoView> GetByNV(string id)
        //{
            //var data_send = from a in db.NhacNhoes
            //                join b in db.NhanViens on  a.MaNV equals b.MaNV
            //                join c in db.NhanViens on a.
            //                select new 
        //}
>>>>>>> 6c76e148f3028fb66f99de017b677362bf7fa518
    }
}
