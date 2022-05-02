using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AplicacaoComCodeFirst.Models;

namespace AplicacaoComCodeFirst.Controllers
{
    public class PostsController : Controller
    {
        private BlogContext db = new BlogContext();

        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.Categorias);
            return View(posts.ToList());
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Posts posts = db.Posts.Find(id);

            if (posts == null)
            {
                return HttpNotFound();
            }

            return View(posts);
        }

        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Categoria");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostID,TituloPost,ResumoPost,ConteudoPost,DataPostagem,CategoriaID")] Posts posts)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(posts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Categoria", posts.CategoriaID);
            return View(posts);
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Posts posts = db.Posts.Find(id);

            if (posts == null)
            {
                return HttpNotFound();
            }

            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Categoria", posts.CategoriaID);
            return View(posts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostID,TituloPost,ResumoPost,ConteudoPost,DataPostagem,CategoriaID")] Posts posts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(posts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Categoria", posts.CategoriaID);
            return View(posts);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Posts posts = db.Posts.Find(id);

            if (posts == null)
            {
                return HttpNotFound();
            }

            return View(posts);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Posts posts = db.Posts.Find(id);
            db.Posts.Remove(posts);
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
