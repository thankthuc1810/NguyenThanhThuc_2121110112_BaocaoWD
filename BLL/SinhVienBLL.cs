﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class SinhVienBLL
    {
        SinhVienDAL dalSV;
        public SinhVienBLL()
        {
            dalSV = new SinhVienDAL();
        }
        public DataTable getAllSinhVien()
        {
            return dalSV.getAllSinhVien();
        }
        public bool InsertSinhVien(tblSinhVien sv)
        {
            return dalSV.InsertSinhVien(sv);
        }
        public bool UpdateSinhVien(tblSinhVien sv)
        {
            return dalSV.UpdateSinhVien(sv);
        }
        public bool SearchSinhVien(tblSinhVien sv)
        {
            return dalSV.SearchSinhVien(sv);
        }
        public bool DeleteSinhVien(tblSinhVien sv)
        {
            return dalSV.DeleteSinhVien(sv);
        }
    }
}
