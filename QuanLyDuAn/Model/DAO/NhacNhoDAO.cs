﻿using System;
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
        public NhacNho GetByID(string id)
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
        public bool Delete(string item)
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
        public List<NhacNhoView> GetByNV(string id)
        {
            //var data_send = from a in db.NhacNhoes
            //                join b in db.NhanViens on  a.MaNV equals b.MaNV
            //                join c in db.NhanViens on a.
            //                select new 
        }
    }
}
