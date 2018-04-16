using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using Model.ViewModel;

namespace Model.DAO
{
    public class ChiTietLichLamViecDAO
    {
        QLDADbContext db = null;

        public ChiTietLichLamViecDAO()
        {
            db = new QLDADbContext();
        }
        public List<ChiTietLichLamViec> ListAll()
        {
            return db.ChiTietLichLamViecs.ToList();
        }
        public bool Insert(ChiTietLichLamViec item)
        {
            try
            {
                db.ChiTietLichLamViecs.Add(item);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public List<ChiTietLLV_NV_ViewModel> GetNVByCV(long id)
        {
            var data = from a in db.ChiTietLichLamViecs
                       join b in db.NhanViens on a.MaNV equals b.MaNV
                       join c in db.ViTris on a.MaVTri equals c.MaVTri
                       where a.MaCV == id
                       select new ChiTietLLV_NV_ViewModel()
                       {
                           MaCV = a.MaCV,
                           MaNV = a.MaNV,
                           TenNV = b.Ten,
                           ViTri = c.Ten
                       };
            return data.ToList();
        }
        //public int ChangeViTri(long manv, long macv, long mavtri)
        //{
        //    if(mavtri == 1)
        //    {
        //        var dbEntry = db.ChiTietLichLamViecs.SingleOrDefault(x => x.MaCV == macv && x.MaVTri == 1);
        //        dbEntry.MaVTri = 2;
        //        var dbEntry2 = db.ChiTietLichLamViecs.SingleOrDefault(x => x.MaCV == macv && x.MaCV == cv);

        //    }
        //}
    }
}
