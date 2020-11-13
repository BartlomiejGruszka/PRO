using PRO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using PRO.ViewModels;

namespace PRO.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private ApplicationDbContext _context;
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public UsersController()
        {
            _context = new ApplicationDbContext();

        }


        // GET: Users
        [Route("users/manage")]
        public ActionResult Manage()
        {
            var pageString = Request.QueryString["page"];
            var itemString = Request.QueryString["items"];

            var users = _context.AppUsers.Include(a => a.ApplicationUser).Include(i => i.Image).ToList();

            ViewBag.Pagination = new Pagination(pageString, itemString, users.Count());
            return View(users);
        }

        [Route("users/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _context.AppUsers
                .Include(a => a.ApplicationUser)
                .Include(a => a.Image)
                .SingleOrDefault(i => i.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [Route("users/details/{id}")]
        public ActionResult ManageDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _context.AppUsers
                .Include(a => a.ApplicationUser)
                .Include(a => a.Image)
                .SingleOrDefault(i => i.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [Route("users/add")]
        public ActionResult Add()
        {
            NewUserViewModel viewModel = new NewUserViewModel
            {
                Images = _context.Images.ToList()
            };
            return View(viewModel);
        }

        [Route("users/add")]
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(NewUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //create normal user object
                    var userModel = new User
                    {
                        UserId = user.Id,
                        RegisterDate = model.RegisterDate,
                        IsActive = model.IsActive,
                        IsPublic = model.IsPublic,
                        ImageId = model.ImageId,
                        Description = model.Description
                    };

                    //temp also in Account Controller
                    /*var roleStore = new RoleStore<IdentityRole>(_context);
                    var roleManager = new RoleManager<IdentityRole>(roleStore);
                    await roleManager.CreateAsync(new IdentityRole(""));
                    await UserManager.AddToRoleAsync(user.Id, "");*/
                    //end temp

                    _context.AppUsers.Add(userModel);
                    _context.SaveChanges();

                    return RedirectToAction("Manage", "Users");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            model.Images = _context.Images.ToList();
            return View(model);
        }

        [Route("users/edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _context.AppUsers.Include(a => a.ApplicationUser).SingleOrDefault(i => i.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            EditUserViewModel viewModel = new EditUserViewModel
            {
                UserName = user.ApplicationUser.UserName,
                Id = (int)id,
                Email = user.ApplicationUser.Email,
                RegisterDate = user.RegisterDate,
                Description = user.Description,
                IsActive = user.IsActive,
                IsPublic = user.IsPublic,
                ImageId = user.ImageId,
                Images = _context.Images.ToList()
            };


            return View(viewModel);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("users/edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.AppUsers.Include(s => s.ApplicationUser).SingleOrDefault(s => s.Id == model.Id);
                var appuser = user.ApplicationUser;

                appuser.Email = model.Email;
                appuser.UserName = model.UserName;

                user.RegisterDate = model.RegisterDate;
                user.Description = model.Description;
                user.IsActive = model.IsActive;
                user.IsPublic = model.IsPublic;
                user.ImageId = model.ImageId;


                _context.Entry(user).State = EntityState.Modified;
                _context.Entry(appuser).State = EntityState.Modified;

                _context.SaveChanges();

                return RedirectToAction("Manage", "Users");

            }
            model.Images = _context.Images.ToList();
            return View(model);
        }

        // GET: Authors/Delete/5
        [Route("users/delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _context.AppUsers
                .Include(a => a.ApplicationUser)
                .Include(a => a.Image)
                .SingleOrDefault(i => i.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("users/delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = _context.AppUsers
                .Include(a => a.ApplicationUser)
                .Include(a => a.Image)
                .SingleOrDefault(i => i.Id == id);
            var userid = user.UserId;
            // _context.AppUsers.Remove(user);

            //remove applicationUser too right here
            _context.SaveChanges();
            return RedirectToAction("DeleteUser", "Manage", new { userId = userid });
        }



        [Route("users/{id}/lists")]
        public ActionResult UserGameList(int id)
        {

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}