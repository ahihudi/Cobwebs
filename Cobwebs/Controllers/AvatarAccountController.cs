using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cobwebs.Models;
using Cobwebs.Models.DAL;

namespace Cobwebs.Controllers
{
    public class AvatarAccountController : Controller
    {
        private CobwebsContext db = new CobwebsContext();

        // GET: AvatarAccount
        public ActionResult Index()
        {
            return View(db.AvatarAccounts.ToList());
        }

        // GET: AvatarAccount/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvatarAccount avatarAccount = db.AvatarAccounts.Find(id);
            if (avatarAccount == null)
            {
                return HttpNotFound();
            }
            return View(avatarAccount);
        }

        // GET: AvatarAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AvatarAccount/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AvatarID,Username,Password,Url,DateCreated,DateModified")] AvatarAccount avatarAccount)
        {
            if (ModelState.IsValid)
            {
                db.AvatarAccounts.Add(avatarAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(avatarAccount);
        }

        // GET: AvatarAccount/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvatarAccount avatarAccount = db.AvatarAccounts.Find(id);
            if (avatarAccount == null)
            {
                return HttpNotFound();
            }
            return View(avatarAccount);
        }

        // POST: AvatarAccount/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AvatarID,Username,Password,Url,DateCreated,DateModified")] AvatarAccount avatarAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(avatarAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(avatarAccount);
        }

        // GET: AvatarAccount/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvatarAccount avatarAccount = db.AvatarAccounts.Find(id);
            if (avatarAccount == null)
            {
                return HttpNotFound();
            }
            return View(avatarAccount);
        }

        // POST: AvatarAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AvatarAccount avatarAccount = db.AvatarAccounts.Find(id);
            db.AvatarAccounts.Remove(avatarAccount);
            db.SaveChanges();
            return RedirectToAction("Index");
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
