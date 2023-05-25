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
    public class DANHMUCsController : Controller
    {
        private tourdulichEntities db = new tourdulichEntities();

        // GET: DANHMUCs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANHMUC dANHMUC = db.DANHMUCs.Find(id);
            if (dANHMUC == null)
            {
                return HttpNotFound();
            }
            return View(dANHMUC);
        }

        // GET: DANHMUCs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DANHMUCs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDDANHMUC,TENDANHMUC")] DANHMUC dm)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(dm.IDDANHMUC))
                    ModelState.AddModelError(string.Empty, "ID danh mục không được để trống");
                if (string.IsNullOrEmpty(Convert.ToString(dm.TENDANHMUC)))
                    ModelState.AddModelError(string.Empty, "Tên danh mục không được để trống");
                if (ModelState.IsValid)
                {
                    db.DANHMUCs.Add(dm);
                    db.SaveChanges();
                    return Redirect("/Management/QuanlyDanhMuc");
                }
            }
            return View(dm);
        }

        // GET: DANHMUCs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANHMUC dANHMUC = db.DANHMUCs.Find(id);
            if (dANHMUC == null)
            {
                return HttpNotFound();
            }
            return View(dANHMUC);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDDANHMUC,TENDANHMUC")] DANHMUC dm)
        {
            if (ModelState.IsValid)
            {
                var danhmucdb = db.DANHMUCs.FirstOrDefault(dms => dms.ID == dm.ID);
                if (danhmucdb != null)
                {
                    danhmucdb.IDDANHMUC = dm.IDDANHMUC;
                    danhmucdb.TENDANHMUC = dm.TENDANHMUC;
                }
                db.SaveChanges();
                return Redirect("/Management/QuanlyDanhMuc");
            }
            return View(dm);
        }

        // GET: DANHMUCs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANHMUC dANHMUC = db.DANHMUCs.Find(id);
            if (dANHMUC == null)
            {
                return HttpNotFound();
            }
            return View(dANHMUC);
        }

        // POST: DANHMUCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DANHMUC dANHMUC = db.DANHMUCs.Find(id);
            db.DANHMUCs.Remove(dANHMUC);
            db.SaveChanges();
            return RedirectToAction("/Management/QuanlyKhuyenMai");
        }
    }
}
