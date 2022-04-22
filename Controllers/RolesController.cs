using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ShovitBastakoti.Models;

namespace ShovitBastakoti.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public RolesController(RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IActionResult Create() {

            return View();
        }

        //id represent RoleID
        public async Task<IActionResult> Manage(string id) {

            IdentityRole role = await roleManager.FindByIdAsync(id);

            if (role == null) {
                return Content("Role not found!");
            }

            //create an empty list of memebers and non-members
            List<IdentityUser> members = new List<IdentityUser>();
            List<IdentityUser> nonmembers = new List<IdentityUser>();
            //get list of all users
            //iterate thru users and determine if they below the the specified role

            foreach(IdentityUser currentUser in userManager.Users.ToList()) {
               
                var whichList = await userManager.IsInRoleAsync(currentUser, role.Name) 
                    ? members : nonmembers;
                nonmembers.Add(currentUser);

            }
            //if do, add to memebers list
            //if don't add to non-members list


            RoleMembership roleMembership = new RoleMembership
            {

                Role = role,
                Members = members,
                NonMembers = nonmembers
            };

            return View(roleMembership);


        }


        [Route("Roles/RemoveUserFromRole/{userId}/{roleId}")]
        public async Task<IActionResult> RemoveUserFromRole(string userId, string roleId)
        {
            IdentityUser user = await userManager.FindByIdAsync(userId);

            // userManager.RemoveFromRoleAsync(userObject, roleObject.RoleName)
            return Content("Remove from role: user = " + userId + " role = " + roleId);
        }
        //[Route("Roles/AddUserToRole/{userId}/{roleId}")]
        public async Task<IActionResult> AddUserToRole(string userId, string roleId)
        {
            IdentityRole role = await roleManager.FindByIdAsync(userId);

            //userManager.AddToRoleAsync(userObject, roleObject.RoleName)
            return Content("Add to role: user = " + userId + " role = " + roleId);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleName")]Role role ) {

            if (ModelState.IsValid) {
                                        //roleManager.DeleteAsync
              IdentityResult result =  await roleManager.CreateAsync(new IdentityRole(role.RoleName));
                if (result.Succeeded)
                {

                    return RedirectToAction("Index");
                }
                else {
                    return Content("An error occurred");
                }
            }
            return View(role);
        }

        public IActionResult Index()
        {
            return View(roleManager.Roles);
        }

        public async Task<IActionResult> Delete(string id) {

            IdentityRole role = await roleManager.FindByIdAsync(id);

            if (role == null) {
                return Content("Role with ID of " + id + " not found!");
            }

            return View(role); // add view file Delete and give confirmation

        
        }
    }
}
