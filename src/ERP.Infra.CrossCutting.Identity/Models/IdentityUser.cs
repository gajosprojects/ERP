using ERP.Domain.Core.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace ERP.Infra.CrossCutting.Identity.Models
{
    public class User : IUser
    {
        public string Name => _accessor.HttpContext.User.Identity.Name;
        private readonly IHttpContextAccessor _accessor;
        private readonly UserManager<IdentityUser> _userManager;

        public User(IHttpContextAccessor accessor, UserManager<IdentityUser> userManager)
        {
            _accessor = accessor;
            _userManager = userManager;
        }

        public Guid GetUserId()
        {
            return IsAuthenticated() ? Guid.Parse(_userManager.GetUserId(_accessor.HttpContext.User)) : Guid.NewGuid();
        }

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }
    }
}