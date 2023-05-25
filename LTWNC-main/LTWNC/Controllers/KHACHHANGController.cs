using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LTWNC.Models;
namespace LTWNC.Controllers
{
    public class KHACHHANGController : Controller
    {
        tourdulichEntities db = new tourdulichEntities();

        // GET: KHACHHANG
        public ActionResult Index()
        {
            var khachhang = db.KHACHHANGs.ToList();
            return View(khachhang);
        }

        // GET: KHACHHANG/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACHHANG kHACHHANG = db.KHACHHANGs.Find(id);
            if (kHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACHHANG);
        }

        // GET: KHACHHANG/Create
        public ActionResult Create()
        {
            ViewBag.IDLKH = new SelectList(db.LOAIKHACHHANGs, "IDLKH", "TENLOAI");
            ViewBag.IDKM = new SelectList(db.KHUYENMAIs, "IDKM", "TENKM");
            return View();
        }

        // POST: KHACHHANG/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDKH,MAKH,HOTENKH,EMAIL,SDT,DIACHI,AVATARKH,IDLKH,IDKM")] KHACHHANG kh, HttpPostedFileBase UploadImage)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(Convert.ToString(kh.EMAIL)))
                    ModelState.AddModelError(string.Empty, "Email không được để trống");
                if (string.IsNullOrEmpty(Convert.ToString(kh.DIACHI)))
                    ModelState.AddModelError(string.Empty, "Địa chỉ không được để trống");
                if (string.IsNullOrEmpty(kh.SDT))
                    ModelState.AddModelError(string.Empty, "Số điện thoại không được để trống");
                if (ModelState.IsValid)
                {
                    if (UploadImage != null)
                    {
                        string filename = Path.GetFileNameWithoutExtension(UploadImage.FileName);
                        string extent = Path.GetExtension(UploadImage.FileName);
                        filename = filename + extent;
                        kh.AVATARKH = "~/Content/Images/" + filename;
                        UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Content/Images/"), filename));
                    }
                    db.KHACHHANGs.Add(kh);
                    db.SaveChanges();
                    return RedirectToAction("KhachHang","Management");
                }
            }
            ViewBag.IDLKH = new SelectList(db.LOAIKHACHHANGs, "IDLKH", "TENLOAI");
            ViewBag.IDKM = new SelectList(db.KHUYENMAIs, "IDKM", "TENKM");
            return View();
        }

        // GET: KHACHHANG/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var kh = db.KHACHHANGs.Where(s => s.IDKH == id).FirstOrDefault();
            ViewBag.IDLKH = new SelectList(db.LOAIKHACHHANGs, "IDLKH", "TENLOAI");
            ViewBag.IDKM = new SelectList(db.KHUYENMAIs, "IDKM", "TENKM");
            return View(kh);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDKH,MAKH,HOTENKH,EMAIL,SDT,DIACHI,AVATARKH,IDLKH,IDKM")] KHACHHANG KH, HttpPostedFileBase UploadImage)
        {
            if (ModelState.IsValid)
            {
                var khachhang = db.KHACHHANGs.FirstOrDefault(kh => kh.IDKH == KH.IDKH);
                if (khachhang != null)
                {
                    khachhang.IDKH = KH.IDKH;
                    khachhang.HOTENKH = KH.HOTENKH;
                    khachhang.EMAIL = KH.EMAIL;
                    khachhang.SDT = KH.SDT;
                    khachhang.DIACHI = KH.DIACHI;
                    khachhang.IDLKH = KH.IDLKH;
                    khachhang.IDKM = KH.IDKM;
                    if (UploadImage != null)
                    {
                        string filename = Path.GetFileNameWithoutExtension(UploadImage.FileName);
                        string extent = Path.GetExtension(UploadImage.FileName);
                        filename = filename + extent;
                        khachhang.AVATARKH = "~/Content/Images/" + filename;
                        UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Content/Images/"), filename));
                    }

                }
                db.SaveChanges();
                return RedirectToAction("KhachHang", "Management");
            }
            ViewBag.IDLKH = new SelectList(db.LOAIKHACHHANGs, "IDLKH", "TENLOAI");
            ViewBag.IDKM = new SelectList(db.KHUYENMAIs, "IDKM", "TENKM");
            return View(KH);
        }

        // GET: KHACHHANG/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACHHANG kHACHHANG = db.KHACHHANGs.Find(id);
            if (kHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACHHANG);
        }

        // POST: KHACHHANG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KHACHHANG kHACHHANG = db.KHACHHANGs.Find(id);
            db.KHACHHANGs.Remove(kHACHHANG);
            db.SaveChanges();
            return RedirectToAction("KhachHang", "Management");
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
