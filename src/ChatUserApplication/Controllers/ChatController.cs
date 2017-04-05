using ChatUserApplication.Data;
using ChatUserApplication.Models;
using ChatUserApplication.Models.ChatViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatUserApplication.Controllers
{
    public class ChatController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        public ChatController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public ActionResult Index(string email)
        {
            var appUser = userManager.Users.Where(e => e.Email == email).Single();
            var userName = context.ChatUsers.Where(i => i.ChatUserId == appUser.ChatUserId).Single();
            IndexViewModel vm = new IndexViewModel { Name = userName.Name, ChatUserId = appUser.ChatUserId};
            return View(vm);
        }
    }
}
