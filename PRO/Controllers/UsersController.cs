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
using PRO.Helpers;
using static PRO.Controllers.ManageController;

namespace PRO.Controllers
{

    public class UsersController : Controller
    {
        private ApplicationDbContext _context;
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;
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
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        public UsersController()
        {
            _context = new ApplicationDbContext();

        }


        // GET: Users
        [Route("users/manage")]
        [Authorize(Roles = "Admin,Moderator")]
        public ActionResult Manage()
        {
            var pageString = Request.QueryString["page"];
            var itemString = Request.QueryString["items"];

            var users = _context.AppUsers.Include(a => a.ApplicationUser).Include(i => i.Image).ToList();

            ViewBag.Pagination = new Pagination(pageString, itemString, users.Count());
            return View(users);
        }

        [Route("users/{id}")]
        [AllowAnonymous]
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
            if (user.IsActive == false)
            {
                return HttpNotFound();
            }

            List<UserList> userLists = _context.UserLists
                .Where(u => u.UserId == id)
                .Include(l => l.ListType)
                .ToList();
            List<GameList> gameLists = _context.GameLists
                .Include(i => i.UserList)
                .Include(i => i.Game)
                .Where(u => u.UserList.UserId == id)
                .ToList();
            List<Review> reviews = _context.
                GetReviewsList()
                .Where(r => r.UserId == id)
                .ToList();
            List<ListType> listTypes = _context.ListTypes.ToList();



            int? loggeduserid = getCurrentUserId();
            if (loggeduserid == null) { loggeduserid = -1; }
            //
            // ManageController ctr = new ManageController();
            // var index = await ctr.setupUserPageAsync();
            //

            UserProfileViewModel model = new UserProfileViewModel
            {
                User = user,
                UserLists = userLists,
                GameLists = gameLists,
                Reviews = reviews,
                //Index = index
                LoggedUserId = loggeduserid,
                ListTypes = listTypes
            };

            return View(model);
        }

        [Route("users/details/{id}")]
        [Authorize(Roles = "Admin,Moderator")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult Add()
        {
            NewUserViewModel viewModel = new NewUserViewModel
            {
                Images = _context.Images.ToList()
            };
            return View(viewModel);
        }

        [Route("users/add")]
        [Authorize(Roles = "Admin")]
        [HttpPost]
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
        [Authorize(Roles = "Admin,Moderator")]
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
        [Authorize(Roles = "Admin,Moderator")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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

        // GET: /Manage/ChangePassword
        [Authorize(Roles = "Admin")]
        [Route("users/changePassword/{id}")]
        public ActionResult ChangePassword(int id)
        {
            ChangePasswordViewModel viewModel = new ChangePasswordViewModel
            {
                id = id
            };
            return View(viewModel);
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("users/changePassword/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(AdminChangePasswordViewModel model)
        {
            var userdata = _context.AppUsers.Include(a => a.ApplicationUser).SingleOrDefault(a => a.Id == model.id);
            if (userdata == null)
            { return RedirectToAction("Manage"); }

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            string resetToken = await UserManager.GeneratePasswordResetTokenAsync(userdata.UserId);
            IdentityResult passwordChangeResult = await UserManager.ResetPasswordAsync(userdata.UserId, resetToken, model.NewPassword);
            if (passwordChangeResult.Succeeded)
            {
                return RedirectToAction("Manage");

            }
            AddErrors(passwordChangeResult);
            return View(model);
        }

        // GET: /Manage/ChangePassword
        [HttpGet]
        [Authorize]
        [Route("users/{id}/password")]
        public ActionResult UserChangePassword(int id)
        {
            int? loggeduserid = getCurrentUserId();
            if (loggeduserid == null) return HttpNotFound();
            if (loggeduserid != id) return HttpNotFound();
            User user = _context.AppUsers.Include(a => a.ApplicationUser).SingleOrDefault(i => i.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ChangePasswordViewModel changePassword = new ChangePasswordViewModel
            {
                id = id
            };
            UserProfileViewModel model = new UserProfileViewModel
            {
                User = user,
                LoggedUserId = loggeduserid,
                ChangePassword = changePassword
            };

            return View(model);
        }


        // change password function requiring old password
        [HttpPost]
        [Authorize]
        [Route("users/{id}/password")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UserChangePassword(ChangePasswordViewModel model, int id)
        {
            int? loggeduserid = getCurrentUserId();
            if (loggeduserid == null) return HttpNotFound();
            if (loggeduserid != id) return HttpNotFound();

            var userdata = _context.AppUsers.Include(a => a.ApplicationUser).SingleOrDefault(a => a.Id == model.id);
            if (userdata == null)
            { return RedirectToAction("Details"); }

            ChangePasswordViewModel changePassword = new ChangePasswordViewModel
            {
                id = id
            };
            UserProfileViewModel userProfile = new UserProfileViewModel
            {
                User = userdata,
                LoggedUserId = loggeduserid,
                ChangePassword = changePassword
            };

            if (!ModelState.IsValid)
            {
                return View(userProfile);
            }
            var result = await UserManager.ChangePasswordAsync(userdata.UserId, model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                return RedirectToAction("Details");
            }
            AddErrors(result);


            return View(userProfile);
        }


        [Route("users/{id}/lists")]
        [AllowAnonymous]
        public ActionResult UserGameList(int id)
        {

            return View();
        }
        [HttpGet]
        [Authorize]
        [Route("users/{id}/profile")]
        public ActionResult EditProfile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int? loggeduserid = getCurrentUserId();
            if (loggeduserid == null) return HttpNotFound();
            if (loggeduserid != id) return HttpNotFound();

            User user = _context.AppUsers.Include(a => a.ApplicationUser).SingleOrDefault(i => i.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            EditUserViewModel editViewModel = new EditUserViewModel
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

            UserProfileViewModel model = new UserProfileViewModel
            {
                User = user,
                LoggedUserId = loggeduserid,
                EditUser = editViewModel
            };


            return View(model);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [Route("users/{id}/profile")]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(EditUserViewModel model)
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

                _context.SaveChanges();

                return RedirectToAction("Details", "Users", new { id = model.Id });

            }
            model.Images = _context.Images.ToList();
            return View(model);
        }



        public int? getCurrentUserId()
        {
            string currentUserId = User.Identity.GetUserId();
            var user = _context.AppUsers.SingleOrDefault(s => s.UserId.Equals(currentUserId));
            if (user == null) return null;
            var id = user.Id;
            return id;
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