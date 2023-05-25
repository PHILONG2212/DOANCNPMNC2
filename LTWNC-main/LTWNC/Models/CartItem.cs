using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTWNC.Models
{
    public class CartItem
    {
        tourdulichEntities database = new tourdulichEntities();

        public int IDTOUR { get; set; }
        public string TENTOUR { get; set; }
        public string HINHANH { get; set; }
        public decimal DONGIA { get; set; }
        public int SOLUONG { get; set; }
        //public decimal GIATRI { get; set; }

        //public int IDKH { get; set; }

        //Thanh Tien
        public decimal THANHTIEN()
        {
            return SOLUONG * DONGIA;
        }

        //public decimal TONGTIEN()
        //{
        //    return THANHTIEN() * (GIATRI / 100);
        //}

        public CartItem(int IDTOUR)
        {
            this.IDTOUR = IDTOUR;

            var sanphamDB = database.TOURs.Single(sp => sp.IDTOUR == this.IDTOUR);

            this.TENTOUR = sanphamDB.TENTOUR;
            this.HINHANH = sanphamDB.HINH;
            this.DONGIA = (decimal)sanphamDB.DONGIA;
            this.SOLUONG = 1;


            //var idkhachhang = database.KHACHHANGs.Single(kh => kh.IDKH == this.IDKH);
            //var Khuyenmaidb = database.KHUYENMAIs.Single(km => km.IDKM == this.IDKH);
            //this.GIATRI = (decimal)Khuyenmaidb.GIATRI;
        }
    }
}