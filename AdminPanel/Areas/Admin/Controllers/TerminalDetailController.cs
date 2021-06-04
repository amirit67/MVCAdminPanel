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
    public class TerminalDetailController : Controller
    {
        private ITerminalDetailRepository terminalDetailRepository;
        private ITerminalGroupRepository terminalGroupRepository;

        MyCmsContext db = new MyCmsContext();

        public TerminalDetailController()
        {
            terminalDetailRepository = new TerminalDetailRepository(db);
            terminalGroupRepository = new TerminalGroupRepository(db);
        }

        // GET: Admin/TerminalDetail
        public ActionResult Index()
        {
            var terminal_Details = terminalDetailRepository.GetAllTerminals();
            return View(terminal_Details.ToList());
        }

        // GET: Admin/TerminalDetail/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            terminal_detail terminal_detail = terminalDetailRepository.GetTerminalById(id.Value);
            if (terminal_detail == null)
            {
                return HttpNotFound();
            }
            return View(terminal_detail);
        }

        // GET: Admin/TerminalDetail/Create
        public ActionResult Create()
        {
            ViewBag.group_id = new SelectList(db.terminal_Groups, "group_id", "group_name");
            return View();
        }

        // POST: Admin/TerminalDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,group_id,acceptor,terminal_number,place_name,place_phone,serial_number,is_access,is_authenticate,createDate,modifiedDate")] terminal_detail terminal_detail)
        {
            if (ModelState.IsValid)
            {
                terminal_detail.id = Guid.NewGuid();
                terminal_detail.createDate = DateTime.Now;
                terminal_detail.modifiedDate = DateTime.Now;
                terminalDetailRepository.InsertTerminal(terminal_detail);
                terminalDetailRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.group_id = new SelectList(terminalGroupRepository.GetAllGroup(), "group_id", "group_name", terminal_detail.group_id);
            return View(terminal_detail);
        }

        // GET: Admin/TerminalDetail/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            terminal_detail terminal_detail = terminalDetailRepository.GetTerminalById(id.Value);
            if (terminal_detail == null)
            {
                return HttpNotFound();
            }
            ViewBag.group_id = new SelectList(terminalGroupRepository.GetAllGroup(), "group_id", "group_name", terminal_detail.group_id);
            return View(terminal_detail);
        }

        // POST: Admin/TerminalDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,group_id,acceptor,terminal_number,place_name,place_phone,serial_number,is_access,is_authenticate,createDate,modifiedDate")] terminal_detail terminal_detail)
        {
            if (ModelState.IsValid)
            {
                terminalDetailRepository.UpdateTerminal(terminal_detail);
                terminalDetailRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.group_id = new SelectList(db.terminal_Groups, "group_id", "group_name", terminal_detail.group_id);
            return View(terminal_detail);
        }

        // GET: Admin/TerminalDetail/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            terminal_detail terminal_detail = terminalDetailRepository.GetTerminalById(id.Value);
            if (terminal_detail == null)
            {
                return HttpNotFound();
            }
            return View(terminal_detail);
        }

        // POST: Admin/TerminalDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            terminal_detail terminal_detail = terminalDetailRepository.GetTerminalById(id);
            db.terminal_Details.Remove(terminal_detail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                terminalDetailRepository.Dispose();
                terminalGroupRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
