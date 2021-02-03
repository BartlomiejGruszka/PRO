using PRO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO.ViewModels
{
    public class UserProfileViewModel
    {
        public User User { get; set; }
        public List<UserList> UserLists { get; set; }
        public List<Game> RecentlyUpdatedGames { get; set; }
        public List<GameList> GameLists { get; set; }
        public List<Review> Reviews { get; set; }

        public IndexViewModel Index { get; set; }

        public List<ListType> ListTypes { get; set; }
        public int? LoggedUserId { get; set; }
        public  EditUserViewModel EditUser { get; set; }

        public ChangePasswordViewModel ChangePassword { get; set; }

    }
}