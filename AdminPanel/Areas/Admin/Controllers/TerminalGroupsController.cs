using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace AdminPanel.Areas.Admin.Controllers
{
    [Authorize]
    public class TerminalGroupsController : Controller
    {
        ITerminalGroupRepository terminalGroupRepository;

        MyCmsContext db = new MyCmsContext();

        public TerminalGroupsController()
        {
            terminalGroupRepository = new TerminalGroupRepository(db);
        }

        // GET: Admin/TerminalGroups
        public ActionResult Index()
        {
            return View(terminalGroupRepository.GetAllGroup());
        }

        // GET: Admin/TerminalGroups/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            terminal_groups terminal_groups = terminalGroupRepository.GetGroupById(id.Value);
            if (terminal_groups == null)
            {
                return HttpNotFound();
            }
            return View(terminal_groups);
        }

        // GET: Admin/TerminalGroups/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Admin/TerminalGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "group_id,group_name")] terminal_groups terminal_groups)
        {
            if (ModelState.IsValid)
            {
                terminal_groups.group_id = Guid.NewGuid();
                terminalGroupRepository.InsertGroup(terminal_groups);
                terminalGroupRepository.Save();
                return RedirectToAction("Index");
            }

            return View(terminal_groups);
        }

        // GET: Admin/TerminalGroups/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            terminal_groups terminal_groups = terminalGroupRepository.GetGroupById(id.Value);
            if (terminal_groups == null)
            {
                return HttpNotFound();
            }
            return PartialView(terminal_groups);
        }

        // POST: Admin/TerminalGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "group_id,group_name")] terminal_groups terminal_groups)
        {
            if (ModelState.IsValid)
            {
                terminalGroupRepository.UpdateGroup(terminal_groups);
                terminalGroupRepository.Save();
                return RedirectToAction("Index");
            }
            return View(terminal_groups);
        }

        // GET: Admin/TerminalGroups/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            terminal_groups terminal_groups = terminalGroupRepository.GetGroupById(id.Value);
            if (terminal_groups == null)
            {
                return HttpNotFound();
            }
            return PartialView(terminal_groups);
        }

        // POST: Admin/TerminalGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            terminal_groups terminal_groups = terminalGroupRepository.GetGroupById(id);
            terminalGroupRepository.DeleteGroup(terminal_groups);
            terminalGroupRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                terminalGroupRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
