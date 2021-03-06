﻿using Cobwebs.Models;
using Cobwebs.Models.DAL;
using Cobwebs.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Cobwebs.Controllers
{
    public class ProjectController : Controller
    {
        private CobwebsContext db = new CobwebsContext();

        // GET: Project
        public ActionResult Index(int? projectID, int? avatarID)
        {
            var viewModel = new ProjectsIndexData();
            viewModel.Projects = db.Projects
                .Include(p => p.Avatars)
                .OrderBy(p => p.Name);
            if (projectID != null)
            {
                viewModel.ProjectID = projectID.Value;
                viewModel.Avatars = viewModel.Projects
                    .Single(p => p.ID == projectID.Value)
                    .Avatars
                    .OrderBy(a => a.LastName);
            }
            if (avatarID != null)
            {
                viewModel.AvatarID = avatarID.Value;
                viewModel.Notes = viewModel.Avatars
                    .Single(a => a.ID == avatarID.Value)
                    .Notes
                    .OrderBy(n => n.DateModified);
            }
            return View(viewModel);
        }

        // GET: Project/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,DateCreated,DateModified")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                //project.Avatars.Add({}); //Add default avatar
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(project);
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Project/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,DateCreated,DateModified")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
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
