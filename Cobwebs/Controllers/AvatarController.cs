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
    public class AvatarController : Controller
    {
        private CobwebsContext db = new CobwebsContext();

        // GET: Avatar
        public ActionResult Index()
        {
            var avatars = db.Avatars.Include(a => a.Project);
            return View(avatars.ToList());
        }

        // GET: Avatar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avatar avatar = db.Avatars.Find(id);
            if (avatar == null)
            {
                return HttpNotFound();
            }
            return View(avatar);
        }

        // GET: Avatar/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "Name");
            return View();
        }

        // POST: Avatar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,LastName,FirstName,AvatarType,Gender,DateCreated,DateModified")] Avatar avatar)
        {
            if (ModelState.IsValid)
            {
                db.Avatars.Add(avatar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "Name", avatar.ProjectID);
            return View(avatar);
        }

        // GET: Avatar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avatar avatar = db.Avatars.Find(id);
            if (avatar == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "Name", avatar.ProjectID);
            return View(avatar);
        }

        // POST: Avatar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,LastName,FirstName,AvatarType,Gender,DateCreated,DateModified")] Avatar avatar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(avatar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "Name", avatar.ProjectID);
            return View(avatar);
        }

        // GET: Avatar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avatar avatar = db.Avatars.Find(id);
            if (avatar == null)
            {
                return HttpNotFound();
            }
            return View(avatar);
        }

        // POST: Avatar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Avatar avatar = db.Avatars.Find(id);
            db.Avatars.Remove(avatar);
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
