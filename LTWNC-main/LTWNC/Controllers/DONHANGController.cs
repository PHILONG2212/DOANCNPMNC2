using LTWNC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LTWNC.Controllers
{
    public class DONHANGController : Controller
    {
        tourdulichEntities db = new tourdulichEntities();

        // GET: KHACHHANG
        public ActionResult Index()
        {
            var donhang = db.DONHANGs.ToList();
            return View(donhang);
        }





        // GET: KHACHHANG/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var kh = db.DONHANGs.Where(s => s.IDDH == id).FirstOrDefault();
         /*   ViewBag.IDLKH = new SelectList(db.LOAIKHACHHANGs, "IDLKH", "TENLOAI");
            ViewBag.IDKM = new SelectList(db.KHUYENMAIs, "IDKM", "TENKM");*/
            return View(kh);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDDH,IDKH,NGAYDAT,TRANGTHAIDH,PHUONGTHUCTHANHTOAN,DIACHI,TRANGTHAI,TENNGUOINHAN,NGẠKHOIHANH")] DONHANG KH)
        {
            if (ModelState.IsValid)
            {
                var khachhang = db.DONHANGs.FirstOrDefault(kh => kh.IDDH == KH.IDDH);
                if (khachhang != null)
                {
                    khachhang.IDKH = KH.IDKH;
                    khachhang.NGAYDAT = KH.NGAYDAT;
                    khachhang.TRANGTHAIDH = KH.TRANGTHAIDH;
                    khachhang.PHUONGTHUCTHANHTOAN = KH.PHUONGTHUCTHANHTOAN;
                    khachhang.DIACHI = KH.DIACHI;
                    khachhang.TRANGTHAI = KH.TRANGTHAI;
                    khachhang.TENNGUOINHAN = KH.TENNGUOINHAN;
                    khachhang.NGAYKHOIHANH =KH.NGAYKHOIHANH;
                  /*  if (UploadImage != null)
                    {
                        string filename = Path.GetFileNameWithoutExtension(UploadImage.FileName);
                        string extent = Path.GetExtension(UploadImage.FileName);
                        filename = filename + extent;
                        khachhang.AVATARKH = "~/Content/Images/" + filename;
                        UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Content/Images/"), filename));
                    }*/

                }
                db.SaveChanges();
                return RedirectToAction("DONHANG", "Management");
            }
        /*    ViewBag.IDLKH = new SelectList(db.LOAIKHACHHANGs, "IDLKH", "TENLOAI");
            ViewBag.IDKM = new SelectList(db.KHUYENMAIs, "IDKM", "TENKM");*/
            return View(KH);
        }

      
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}