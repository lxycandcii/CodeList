using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeRecord.Models;

namespace CodeRecord.Controllers
{
    public class CodeListsController : Controller
    {
        private CodeListContext db = new CodeListContext();

        // GET: CodeLists
        public ActionResult Index()
        {
            return View(db.Codes.ToList());
        }

        // GET: CodeLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodeList codeList = db.Codes.Find(id);
            if (codeList == null)
            {
                return HttpNotFound();
            }
            return View(codeList);
        }

        // GET: CodeLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CodeLists/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodeName,Code,Readmd,CreateTime,UpdateTime")] CodeList codeList)
        {
            if (ModelState.IsValid)
            {
                db.Codes.Add(codeList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(codeList);
        }

        // GET: CodeLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodeList codeList = db.Codes.Find(id);
            if (codeList == null)
            {
                return HttpNotFound();
            }
            return View(codeList);
        }

        // POST: CodeLists/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodeName,Code,Readmd,CreateTime,UpdateTime")] CodeList codeList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(codeList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(codeList);
        }

        // GET: CodeLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodeList codeList = db.Codes.Find(id);
            if (codeList == null)
            {
                return HttpNotFound();
            }
            return View(codeList);
        }

        // POST: CodeLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CodeList codeList = db.Codes.Find(id);
            db.Codes.Remove(codeList);
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
