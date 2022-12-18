using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test.Data;

namespace App.Admin.Role
{
    public class RolePageModel : PageModel
    {
        protected readonly RoleManager<IdentityRole> _roleManager;
        protected readonly LapTopContext _context;

        [TempData]
        public string StatusMessage { get; set; }// noi dung status o trang nay co the doc duoc o trang khac
        public RolePageModel(RoleManager<IdentityRole> roleManager, LapTopContext myBlogContext)
        {
            _roleManager = roleManager;
            _context = myBlogContext;
        }
    }
}