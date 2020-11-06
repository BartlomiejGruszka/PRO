﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PRO.Models;
using PRO.ViewModels;
using PRO.Helpers;

namespace PRO.Controllers
{
    public class GameListsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GameLists
        [Route("gamelists/manage")]
        public ActionResult Manage()
        {
            var pageString = Request.QueryString["page"];
            var itemString = Request.QueryString["items"];
            var gameLists = db.GetFullGameListsList();

            ViewBag.Pagination = new Pagination(pageString, itemString, gameLists.Count());

            return View(gameLists);
        }

        // GET: GameLists/Details/5
        [Route("gamelists/details/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var gameList = db.GetFullGameListById(id);
            if (gameList == null)
            {
                return HttpNotFound();
            }
            return View(gameList);
        }

        // GET: GameLists/Create
        [Route("gamelists/add")]
        public ActionResult Add()
        {

            var users = db.AppUsers.Include(i => i.ApplicationUser).ToList();
            var usersList = users.Select(s => new { Id = s.Id, UserName = s.ApplicationUser.UserName }).ToList();

            ViewBag.userList = usersList;
            ViewBag.Games = db.GetGamesList().ToList();
            return View(new GameList());
        }
        [HttpPost]
        [Route("gamelists/getuserlists/{id}")]
        public ActionResult GetUserLists(int id)
        {
            List<UserList> userLists = db.GetUsersListList().Where(s => s.UserId == id).ToList();
            SelectList viewLists = new SelectList(userLists, "Id", "Name", 0);
            return Json(viewLists);
        }

        // POST: GameLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("gamelists/add")]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "Id,AddedDate,HoursPlayed,PersonalScore,UserListId,GameId")] GameList gameList)
        {
            if (ModelState.IsValid)
            {
                db.GameLists.Add(gameList);
                db.SaveChanges();
                return RedirectToAction("Manage");
            }

            var users = db.AppUsers.Include(i => i.ApplicationUser).ToList();
            var usersList = users.Select(s => new { Id = s.Id, UserName = s.ApplicationUser.UserName }).ToList();

            ViewBag.userList = usersList;
            ViewBag.Games = db.GetGamesList().ToList();

            return View(gameList);
        }

        // GET: GameLists/Edit/5
        [Route("gamelists/edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var users = db.AppUsers.Include(i => i.ApplicationUser).ToList();
            var usersList = users.Select(s => new { Id = s.Id, UserName = s.ApplicationUser.UserName }).ToList();

            ViewBag.userList = usersList;
            ViewBag.Games = db.GetGamesList().ToList();

            var gameList = db.GetFullGameListById(id);

            if (gameList == null)
            {
                return HttpNotFound();
            }

            return View(gameList);
        }

        // POST: GameLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("gamelists/edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AddedDate,HoursPlayed,PersonalScore,UserListId,GameId")] GameList gameList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gameList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Manage");
            }
            var users = db.AppUsers.Include(i => i.ApplicationUser).ToList();
            var usersList = users.Select(s => new { Id = s.Id, UserName = s.ApplicationUser.UserName }).ToList();

            ViewBag.userList = usersList;
            ViewBag.Games = db.GetGamesList().ToList();

            return View(gameList);
        }

        // GET: GameLists/Delete/5
        [Route("gamelists/delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var gameList = db.GetFullGameListById(id);
            if (gameList == null)
            {
                return HttpNotFound();
            }
            return View(gameList);
        }

        // POST: GameLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("gamelists/delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var gameList = db.GetFullGameListById(id);
            db.GameLists.Remove(gameList);
            db.SaveChanges();
            return RedirectToAction("Manage");
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
