using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorSkraApp1.Data;
using Microsoft.AspNetCore.Identity;

namespace BlazorSkraApp1.Services
{
    public interface IAdminService
    {
        Task<List<IdentityUser>> Get();
        Task<List<IdentityUser>> GetSearchList(string searchString);
        Task<List<IdentityUser>> GetSortedList();
        Task<IdentityUser> Get(string userName);
        Task<IdentityUser> Add(IdentityUser user);
        Task<IdentityUser> Update(IdentityUser user);
        Task<IdentityUser> Delete(IdentityUser user);
        Task<IdentityUser> AddAdminRole(IdentityUser user);
        Task<IdentityUser> RemoveAdminRole(IdentityUser user);
        Task<string> GetRoles(IdentityUser user);
        Task<List<IdentityUser>> GetAdminUsers();
    }
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _context;
        private UserManager<IdentityUser> _userManager;

        public AdminService(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // Returns a list of all users
        public async Task<List<IdentityUser>> Get()
        {
            var userList = _userManager.Users.ToListAsync();
            return await userList;
        }

        // Get user by Name
        public async Task<IdentityUser> Get(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return user;
        }

        public async Task<List<IdentityUser>> GetSearchList(string searchString)
        {
            var searchList = _userManager.Users.Where(x => x.UserName.Contains(searchString)).ToListAsync();
            return  await searchList;
        }

        public async Task<List<IdentityUser>> GetSortedList()
        {
            var sortedList = _userManager.Users.OrderBy(x => x.UserName).ToListAsync();
            return  await sortedList;
        }

        // Creates the specified user in the database
        public async Task<IdentityUser> Add(IdentityUser user)
        {
            await _userManager.CreateAsync(user);
            return user;
        }

        // Updates the specified user
        public async Task<IdentityUser> Update(IdentityUser user)
        {
            //Find user
            var userfound = await _userManager.FindByIdAsync(user.Id);
            //Update attributes we want to change
            //await _userManager.AddToRoleAsync(user, "Admin");
    
            return user;
        }

        // Deletes the specified user
        public async Task<IdentityUser> Delete(IdentityUser user)
        {
            await _userManager.DeleteAsync(user);
            return user;
        }

        // Gives the specified user the role of admin
        public async Task<IdentityUser> AddAdminRole(IdentityUser user)
        {
            await _userManager.AddToRoleAsync(user, "Admin");
            return user;
        }

        // Takes the admin role from the specified user
        public async Task<IdentityUser> RemoveAdminRole(IdentityUser user)
        {
            await _userManager.RemoveFromRoleAsync(user, "Admin");
            return user; 
        }

        // Returns a list of all admin users
        public async Task<List<IdentityUser>> GetAdminUsers()
        {
            var adminUsersList = (from userRoles in await _userManager.GetUsersInRoleAsync("Admin")
                              select userRoles).ToList();
            return adminUsersList;
        }

        // Returns all roles of the specified user
        public async Task<string> GetRoles(IdentityUser user)
        {
            var roleList = await _userManager.GetRolesAsync(user);
            //Change the list into a string with the delimiter ", "
            var rolesString = string.Join(", ", roleList.ToArray());
            return rolesString;
        }
    }
}
