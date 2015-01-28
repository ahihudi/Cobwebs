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
    public class AvatarNoteController : Controller
    {
        private CobwebsContext db = new CobwebsContext();

        // GET: AvatarNote
        public ActionResult Index()
        {
            var avatarNotes = db.AvatarNotes.Include(a => a.Avatar);
            return View(avatarNotes.ToList());
        }

        // GET: AvatarNote/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvatarNote avatarNote = db.AvatarNotes.Find(id);
            if (avatarNote == null)
            {
                return HttpNotFound();
            }
            return View(avatarNote);
        }

        // GET: AvatarNote/Create
        public ActionResult Create()
        {
            ViewBag.AvatarID = new SelectList(db.Avatars, "ID", "LastName");
            return View();
        }

        // POST: AvatarNote/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AvatarID,Content,DateCreated,DateModified")] AvatarNote avatarNote)
        {
            if (ModelState.IsValid)
            {
                db.AvatarNotes.Add(avatarNote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AvatarID = new SelectList(db.Avatars, "ID", "LastName", avatarNote.AvatarID);
            return View(avatarNote);
        }

        // GET: AvatarNote/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvatarNote avatarNote = db.AvatarNotes.Find(id);
            if (avatarNote == null)
            {
                return HttpNotFound();
            }
            ViewBag.AvatarID = new SelectList(db.Avatars, "ID", "LastName", avatarNote.AvatarID);
            return View(avatarNote);
        }

        // POST: AvatarNote/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AvatarID,Content,DateCreated,DateModified")] AvatarNote avatarNote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(avatarNote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AvatarID = new SelectList(db.Avatars, "ID", "LastName", avatarNote.AvatarID);
            return View(avatarNote);
        }

        // GET: AvatarNote/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvatarNote avatarNote = db.AvatarNotes.Find(id);
            if (avatarNote == null)
            {
                return HttpNotFound();
            }
            return View(avatarNote);
        }

        // POST: AvatarNote/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AvatarNote avatarNote = db.AvatarNotes.Find(id);
            db.AvatarNotes.Remove(avatarNote);
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
