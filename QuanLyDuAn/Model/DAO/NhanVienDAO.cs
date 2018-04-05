﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class NhanVienDAO
    {
        QLDADbContext db = null;

        public NhanVienDAO()
        {
            db = new QLDADbContext();
        }

        public NhanVien GetByID(string id)
        {
            return db.NhanViens.SingleOrDefault(x => x.MaNV == id);
        }
        public List<NhanVien> ListAll()
        {
            return db.NhanViens.ToList();
        }
        public bool Insert(NhanVien item)
        {
            try
            {
                db.NhanViens.Add(item);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(NhanVien item)
        {
            var dbEntry = GetByID(item.MaNV);
            try
            {
                dbEntry.MaBP = item.MaBP;
                dbEntry.MaPB = item.MaPB;
                dbEntry.MatKhau = item.MatKhau;
                dbEntry.MaVT = item.MaVT;
                dbEntry.SoDT = item.SoDT;
                dbEntry.SoTK = item.SoTK;
                dbEntry.TaiKhoan = item.TaiKhoan;
                dbEntry.Ten = item.Ten;
                dbEntry.TrinhDo = item.TrinhDo;
                dbEntry.Email = item.Email;
                dbEntry.DiaChi = item.DiaChi;
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
                db.NhanViens.Remove(dbEntry);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void ChangStatus(string id)
        {
            var dbEntry = GetByID(id);
            dbEntry.Status = dbEntry.Status == 0 ? 1 : 0;
        }
    }
}