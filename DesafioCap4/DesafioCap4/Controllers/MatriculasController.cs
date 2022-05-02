using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DesafioCap4.Models;

namespace DesafioCap4.Controllers
{
    public class MatriculasController : Controller
    {
        private DesafioContext db = new DesafioContext();

        public ActionResult Index()
        {
            var matriculas = db.Matriculas.Include(m => m.Aluno).Include(m => m.Curso);
            return View(matriculas.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Matricula matricula = db.Matriculas.Find(id);

            if (matricula == null)
            {
                return HttpNotFound();
            }

            return View(matricula);
        }

        public ActionResult Create()
        {
            ViewBag.AlunoId = new SelectList(db.Alunos, "Id", "Nome");
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CursoId,AlunoId")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                db.Matriculas.Add(matricula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlunoId = new SelectList(db.Alunos, "Id", "Nome", matricula.AlunoId);
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Nome", matricula.CursoId);
            return View(matricula);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Matricula matricula = db.Matriculas.Find(id);

            if (matricula == null)
            {
                return HttpNotFound();
            }

            ViewBag.AlunoId = new SelectList(db.Alunos, "Id", "Nome", matricula.AlunoId);
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Nome", matricula.CursoId);
            return View(matricula);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CursoId,AlunoId")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matricula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlunoId = new SelectList(db.Alunos, "Id", "Nome", matricula.AlunoId);
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Nome", matricula.CursoId);
            return View(matricula);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Matricula matricula = db.Matriculas.Find(id);

            if (matricula == null)
            {
                return HttpNotFound();
            }

            return View(matricula);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Matricula matricula = db.Matriculas.Find(id);
            db.Matriculas.Remove(matricula);
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
