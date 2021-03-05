using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PRO.Models;

namespace PRO.Controllers
{
    [Authorize]
    public class ImagesController : Controller
    {


        private ApplicationDbContext _context;

        public ImagesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Image
        [Route("images/")]
        public ActionResult Index()
        {
            return View();
        }
        [Route("images/manage")]
        [Authorize(Roles = "Admin,Author")]
        public ActionResult Manage()
        {
            var pageString = Request.QueryString["page"];
            var itemString = Request.QueryString["items"];
            var images = _context.Images.Include(i => i.ImageType).ToList();
            ViewBag.Pagination = new Pagination(pageString, itemString, images.Count());
            return View(images);
        }

        [Route("images/details/{id}")]
        [Authorize(Roles = "Admin,Author")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = _context.Images.Include(i=>i.ImageType).FirstOrDefault(s=>s.Id==id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        [HttpGet]
        [Route("images/add")]
        [Authorize(Roles = "Admin,Author")]
        public ActionResult Add()
        {
            ViewBag.ImageTypes = _context.ImageTypes.ToList();
            return View();
        }

        [HttpPost]
        [Route("images/add")]
        [Authorize(Roles = "Admin,Author")]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Image image)
        {
            if (ModelState.IsValid) {
            string fileName = Path.GetFileNameWithoutExtension(image.ImageFile.FileName);
            string extension = Path.GetExtension(image.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            image.ImagePath = "~/Image/" + fileName;

            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            image.ImageFile.SaveAs(fileName);

            _context.Images.Add(image);
            _context.SaveChanges();


            return RedirectToAction("Manage");
            }
            return View(image);
        }

        // GET: Companies/Edit/5
        [Route("images/edit/{id}")]
        [Authorize(Roles = "Admin,Author")]
        public ActionResult EditFile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = _context.Images.Include(i => i.ImageType).FirstOrDefault(s => s.Id == id);
            if (image == null)
            {
                return HttpNotFound();
            }
            ViewBag.ImageTypes = _context.ImageTypes.ToList();
            return View(image);
        }
        [Route("images/rename/{id}")]
        [Authorize(Roles = "Admin,Author")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = _context.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            ViewBag.ImageTypes = _context.ImageTypes.ToList();
            return View(image);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("images/edit/{id}")]
        [Authorize(Roles = "Admin,Author")]
        [ValidateAntiForgeryToken]
        public ActionResult EditFile(Image image)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(image.ImageFile.FileName);
                string extension = Path.GetExtension(image.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                image.ImagePath = "~/Image/" + fileName;

                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                image.ImageFile.SaveAs(fileName);
                _context.Entry(image).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Manage");
            }
            ViewBag.ImageTypes = _context.ImageTypes.ToList();
            return View(image);
        }
        [HttpPost]
        [Route("images/rename/{id}")]
        [Authorize(Roles = "Admin,Author")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Image image)
        {
            var errorList = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );
            if (!errorList.ContainsKey("Name") && image.ImageFile == null)
            {
                _context.Images.Attach(image);
                _context.Configuration.ValidateOnSaveEnabled = false;
                _context.Entry(image).Property(x => x.Name).IsModified = true;
                _context.Entry(image).Property(x => x.ImageTypeId).IsModified = true;
                //  ValidateOnSaveEnabled = false;
                _context.SaveChanges();
                _context.Configuration.ValidateOnSaveEnabled = true;
                return RedirectToAction("Manage");
            }
            ViewBag.ImageTypes = _context.ImageTypes.ToList();
            return View(image);
        }

        // GET: Companies/Delete/5
        [Route("images/delete/{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = _context.Images.Include(i => i.ImageType).FirstOrDefault(s => s.Id == id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("images/delete/{id}")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Image image = _context.Images.Find(id);

            var games = _context.Games.Where(i => i.ImageId == id).ToList();
            foreach (var element in games)
            {
                element.ImageId = null;
            };
            var articles = _context.Articles.Where(i => i.ImageId == id).ToList();
            foreach (var element in articles)
            {
                element.ImageId = null;
            };
            var users = _context.AppUsers.Where(i => i.ImageId == id).ToList();
            foreach (var element in users)
            {
                element.ImageId = null;
            };

            _context.Images.Remove(image);
            _context.SaveChanges();
            var path = HttpContext.Server.MapPath(image.ImagePath);
            if ((System.IO.File.Exists(path)))
            {
                System.IO.File.Delete(path);
            }
            return RedirectToAction("Manage");
        }
    }
}