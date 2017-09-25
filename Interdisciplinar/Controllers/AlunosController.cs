using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Interdisciplinar.Contexts;
using Interdisciplinar.Models;

namespace Interdisciplinar.Controllers
{
    public class AlunosController : Controller
    {

        private readonly EFContext _context = new EFContext();


        // GET: Alunos
        public ActionResult Index()
        {
            return View(_context.Alunos.OrderBy(s => s.Nome));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }



        public ActionResult Edit(long? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var aluno = _context.Alunos.Find(id.Value);


            if (aluno == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(aluno).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(aluno);
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var aluno = _context.Alunos.Find(id.Value);

            if (aluno == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View(aluno);
        }


        public ActionResult Delete(long? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var aluno = _context.Alunos.Find(id.Value);

            if (aluno == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View(aluno);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {

            Aluno aluno = _context.Alunos.Find(id);
            _context.Alunos.Remove(aluno);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}