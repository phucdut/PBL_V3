using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL_V3.Entity
{
    public class BILLinfo
    {
        private String matHang;
        private double donGia;
        private int soLuong;
        private double tongTien;

        public string MatHang { get => matHang; set => matHang = value; }
        public double DonGia { get => donGia; set => donGia = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public double TongTien { get => tongTien; set => tongTien = value; }
    }
}
