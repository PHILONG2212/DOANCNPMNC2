using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LTWNC.Models;
using PagedList;

namespace LTWNC.Controllers
{
    public class KHUYENMAIsController : Controller
    {
        private tourdulichEntities database = new tourdulichEntities();

        // GET: KHUYENMAIs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHUYENMAI kHUYENMAI = database.KHUYENMAIs.Find(id);
            if (kHUYENMAI == null)
            {
                return HttpNotFound();
            }
            return View(kHUYENMAI);
        }

        // GET: KHUYENMAIs/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDKM,TENKM,GIATRI,NGAYTAO,NGAYHET")] KHUYENMAI km)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(km.TENKM))
                    ModelState.AddModelError(string.Empty, "Tên khuyến mãi không được để trống");
                if (string.IsNullOrEmpty(Convert.ToString(km.GIATRI)))
                    ModelState.AddModelError(string.Empty, "Giá trị không được để trống");
                if (string.IsNullOrEmpty(Convert.ToString(km.NGAYTAO)))
                    ModelState.AddModelError(string.Empty, "Ngày tạo không được để trống");
                if (string.IsNullOrEmpty(Convert.ToString(km.NGAYHET)))
                    ModelState.AddModelError(string.Empty, "Ngày hết hạn không được để trống");
                if (ModelState.IsValid)
                {
                    database.KHUYENMAIs.Add(km);
                    database.SaveChanges();
                    return Redirect("/Management/QuanlyKhuyenMai");
                }
            }
            return View(km);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHUYENMAI kHUYENMAI = database.KHUYENMAIs.Find(id);
            if (kHUYENMAI == null)
            {
                return HttpNotFound();
            }
            return View(kHUYENMAI);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDKM,TENKM,GIATRI,NGAYTAO,NGAYHET")] KHUYENMAI km)
        {
            if (ModelState.IsValid)
            {
                var khuyenmaidb = database.KHUYENMAIs.FirstOrDefault(kms => kms.IDKM == km.IDKM);
                if (khuyenmaidb != null)
                {
                    khuyenmaidb.TENKM = km.TENKM;
                    khuyenmaidb.GIATRI = km.GIATRI;
                    khuyenmaidb.NGAYTAO = km.NGAYTAO;
                    khuyenmaidb.NGAYHET = km.NGAYHET;
                }
                database.SaveChanges();
                return Redirect("/Management/QuanlyKhuyenMai");
            }
            return View(km);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHUYENMAI kHUYENMAI = database.KHUYENMAIs.Find(id);
            if (kHUYENMAI == null)
            {
                return HttpNotFound();
            }
            return View(kHUYENMAI);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KHUYENMAI kHUYENMAI = database.KHUYENMAIs.Find(id);
            database.KHUYENMAIs.Remove(kHUYENMAI);
            database.SaveChanges();
            return RedirectToAction("/Management/QuanlyKhuyenMai");
        }
    }
}
