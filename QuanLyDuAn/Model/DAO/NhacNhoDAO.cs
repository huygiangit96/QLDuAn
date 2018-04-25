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
        public List<NhacNhoView> GetByNV(long id)
        {
            var data = (from a in db.NhacNhoes
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
                            }).ToList();
            foreach(var item in data)
            {
                item.ReplyID = GetIDEmpByName(item.Ten);
            }
            return data;
        }
        // lấy ra mã nahan viên theo tên
        public long GetIDEmpByName(string s)
        {
            return db.NhanViens.Where(x => x.Ten.ToString() == s).SingleOrDefault().MaNV;
        }
        public void ChangeStatus(long id)
        {
            var dbEntry = db.NhacNhoes.SingleOrDefault(x => x.MaNN == id);
            dbEntry.Status = 0;
            db.SaveChanges();
        }
    }
}
