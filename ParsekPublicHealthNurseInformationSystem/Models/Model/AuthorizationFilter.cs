using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public class AuthorizationFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        public new void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                // Don't check for authorization as AllowAnonymous filter is applied to the action or controller
                return;
            }

            User user = (User)HttpContext.Current.Session["user"];
            if(user != null)
            {
                Role.RoleEnum userRole = user.Role.Title;
                if (RolesEnum != null)
                {
                    // Check if roles match.
                    foreach (var role in RolesEnum)
                    {
                        if (userRole == role)
                        {
                            return;
                        }
                    }

                }

                Employee.JobTitle userTitle = user.Employee.Title;
                if (TitlesEnum != null)
                {
                    // Check if titles match.
                    foreach (var title in TitlesEnum)
                    {
                        if (userTitle == title)
                        {
                            return;
                        }
                    }
                }
            }

            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary{
                    { "controller", "Home" },
                    { "action", "Index" }
                });
        }

        
        private Role.RoleEnum[] RolesEnum { get; set; }
        private Employee.JobTitle[] TitlesEnum { get; set; }

        public AuthorizationFilter(params Role.RoleEnum[] rolesRequired)
        {
            RolesEnum = rolesRequired;
        }

        public AuthorizationFilter(params Employee.JobTitle[] titlesRequired)
        {
            TitlesEnum = titlesRequired;
        }


    }
}