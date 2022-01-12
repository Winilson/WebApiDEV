using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Business.Interfaces
{
    public interface IUser
    {
        string name { get; }
        Guid GetUserId();
        string GetUserEmail();
        Boolean IsAuthenticated();
        Boolean IsInRole(string role);
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
