using HRPotter.Data;
using HRPotter.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureADB2C.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HRPotter.Authorization
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, HRPotterContext dbContext)
        {
            await Authorize(httpContext, dbContext);

            await _next(httpContext);
        }

        private static async Task Authorize(HttpContext httpContext, HRPotterContext dbContext)
        {
            var user = httpContext.User;
            if (user == null || !user.Identity.IsAuthenticated && !user.HasClaim(claim => claim.Type.EndsWith("objectidentifier")))
            {
                return;
            }

            if (user.HasClaim(claim => claim.Type == ClaimTypes.Role))
            {
                return;
            }

            var key = user.Claims.Where(claim => claim.Type.EndsWith("objectidentifier")).First().Value;
            var hrpotterUser = await dbContext.Users.Include(x => x.Role).FirstOrDefaultAsync(u => u.B2CKey == key);
            if (hrpotterUser == null)
            {
                var name = user.Claims.Where(claim => claim.Type.EndsWith("givenname")).FirstOrDefault()?.Value;
                if (name == null)
                {
                    return;
                }

                hrpotterUser = new User() { B2CKey = key, Name = name, RoleId = 1 };
                await dbContext.Users.AddAsync(hrpotterUser);
                await dbContext.SaveChangesAsync();
                hrpotterUser = await dbContext.Users.Include(x => x.Role).FirstOrDefaultAsync(u => u.B2CKey == key);
            }


            var identity = user.Identity as ClaimsIdentity;
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, hrpotterUser.Id.ToString()),
                    new Claim(ClaimTypes.Name, hrpotterUser.Name),
                    new Claim(ClaimTypes.Role, hrpotterUser.Role),
                    new Claim(ClaimTypes.GroupSid, hrpotterUser.RoleId.ToString()),
                    new Claim(ClaimTypes.Sid, hrpotterUser.B2CKey),
                };
            claims.AddRange(identity.Claims);

            var claimsIdentity = new ClaimsIdentity(
                claims, AzureADB2CDefaults.CookieScheme);

            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                // Refreshing the authentication session should be allowed.

                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                IsPersistent = true,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };

            await httpContext.SignInAsync(
                AzureADB2CDefaults.CookieScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }
    }
}
